using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SysMonitor_Pro
{
    public partial class FormDeskTop : Form
    {
        private readonly Computer computer;
        private Timer diskTimer;
        private Timer netTimer;
        private List<string> pingHosts = new List<string> { "8.8.8.8", "1.1.1.1", "google.com" };

        public FormDeskTop()
        {
            InitializeComponent();

            computer = new Computer();
            computer.CPUEnabled = true;
            computer.GPUEnabled = true;
            computer.RAMEnabled = true;
            computer.HDDEnabled = true;
            computer.Open();

            timerUpdate.Interval = 1000;
            timerUpdate.Tick += timerUpdate_Tick;
            timerUpdate.Start();

            SetupDiskMonitoring();
            SetupNetworkMonitoring();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void timerUpdate_Tick(object sender, EventArgs e)
        {
            await UpdateHardwareInfoAsync();
        }

        private async Task UpdateHardwareInfoAsync()
        {
            await Task.WhenAll(
                UpdateCpuInfoAsync(),
                UpdateGpuInfoAsync(),
                UpdateRamInfoAsync(),
                UpdateTemperatureInfoAsync()
            );
        }

        private async Task UpdateCpuInfoAsync()
        {
            float cpuUsage = await Task.Run(GetCpuUsage);
            SafeSetLabelText(lblCpuUsage, "Использование CPU: " + cpuUsage + "%");

            int cpuFrequency = await Task.Run(GetCpuFrequency);
            SafeSetLabelText(lblCpuFrequency, "Частота CPU: " + cpuFrequency + " MHz");

            string[] topProcesses = await Task.Run(GetTopProcesses);
            SafeSetListBoxDataSource(lstTopProcesses, topProcesses);
        }

        private float GetCpuUsage()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
            {
                ManagementObjectCollection collection = searcher.Get();
                for (int i = 0; i < collection.Count; i++)
                {
                    ManagementObject obj = collection.Cast<ManagementObject>().ElementAt(i);
                    return Convert.ToSingle(obj["LoadPercentage"]);
                }
            }
            return 0;
        }

        private int GetCpuFrequency()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
            {
                ManagementObjectCollection collection = searcher.Get();
                for (int i = 0; i < collection.Count; i++)
                {
                    ManagementObject obj = collection.Cast<ManagementObject>().ElementAt(i);
                    return Convert.ToInt32(obj["CurrentClockSpeed"]);
                }
            }
            return 0;
        }

        private string[] GetTopProcesses()
        {
            Process[] processes = Process.GetProcesses();
            Array.Sort(processes, (p1, p2) => p2.WorkingSet64.CompareTo(p1.WorkingSet64));

            int takeCount = 10;
            if (takeCount > processes.Length)
            {
                takeCount = processes.Length;
            }

            string[] result = new string[takeCount];
            for (int i = 0; i < takeCount; i++)
            {
                result[i] = processes[i].ProcessName;
            }
            return result;
        }

        private async Task UpdateGpuInfoAsync()
        {
            float gpuTemp = await Task.Run(GetGpuTemperature);
            SafeSetLabelText(lblGpuTemp, "Температура GPU: " + gpuTemp + " °C");
        }

        private float GetGpuTemperature()
        {
            IList<IHardware> hardwareList = computer.Hardware;
            int hardwareCount = hardwareList.Count;
            for (int h = 0; h < hardwareCount; h++)
            {
                IHardware hardwareItem = hardwareList[h];
                if (hardwareItem.HardwareType == HardwareType.GpuAti || hardwareItem.HardwareType == HardwareType.GpuNvidia)
                {
                    hardwareItem.Update();
                    IList<ISensor> sensorsList = hardwareItem.Sensors;
                    int sensorsCount = sensorsList.Count;
                    for (int s = 0; s < sensorsCount; s++)
                    {
                        ISensor sensor = sensorsList[s];
                        if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                        {
                            return sensor.Value.Value;
                        }
                    }
                }
            }
            return 0;
        }

        private async Task UpdateRamInfoAsync()
        {
            float ramUsage = await Task.Run(GetRamUsage);
            SafeSetLabelText(lblRamUsage, "Использование RAM: " + ramUsage.ToString("F1") + "%");
        }

        private float GetRamUsage()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
            {
                ManagementObjectCollection collection = searcher.Get();
                for (int i = 0; i < collection.Count; i++)
                {
                    ManagementObject obj = collection.Cast<ManagementObject>().ElementAt(i);
                    double totalVisibleMemory = Convert.ToDouble(obj["TotalVisibleMemorySize"]);
                    double freePhysicalMemory = Convert.ToDouble(obj["FreePhysicalMemory"]);
                    double used = (totalVisibleMemory - freePhysicalMemory) / totalVisibleMemory * 100;
                    return (float)used;
                }
            }
            return 0;
        }

        private async Task UpdateTemperatureInfoAsync()
        {
            await Task.Run(() =>
            {
                IList<IHardware> hardwareList = computer.Hardware;
                for (int h = 0; h < hardwareList.Count; h++)
                {
                    IHardware hardwareItem = hardwareList[h];
                    hardwareItem.Update();

                    if (hardwareItem.HardwareType == HardwareType.GpuAti || hardwareItem.HardwareType == HardwareType.GpuNvidia)
                    {
                        var gpuTempSensor = GetFirstTemperatureSensor(hardwareItem);
                        if (gpuTempSensor != null && gpuTempSensor.Value.HasValue)
                        {
                            float value = gpuTempSensor.Value.Value;
                            SafeSetLabelText(lblGpuTemp, $"Температура GPU: {value:F1} °C");
                        }
                    }

                    if (hardwareItem.HardwareType == HardwareType.HDD)
                    {
                        HandleDiskTemperature(hardwareItem);
                    }
                }
            });
        }

        private ISensor GetFirstTemperatureSensor(IHardware hardware)
        {
            foreach (ISensor sensor in hardware.Sensors)
            {
                if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                {
                    return sensor;
                }
            }
            return null;
        }


        private void HandleDiskTemperature(IHardware hardwareItem)
        {
            string diskType = GetDiskTypeByModel(hardwareItem.Name);

            if (diskType == "SSD")
            {
                SafeSetLabelText(lblHddTemp, "Это SSD, температура не выводится.");
                return;
            }

            bool hasSensor = HasTemperatureSensor(hardwareItem);
            if (hasSensor == false)
            {
                SafeSetLabelText(lblHddTemp, "Диск (" + hardwareItem.Name + "): \nдатчик температуры отсутствует.");
                return;
            }

            ISensor tempSensor = null;
            IList<ISensor> sensorsList = hardwareItem.Sensors;
            int sensorsCount = sensorsList.Count;
            for (int s = 0; s < sensorsCount; s++)
            {
                ISensor sensor = sensorsList[s];
                if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                {
                    tempSensor = sensor;
                    break;
                }
            }

            if (tempSensor != null)
            {
                float value = tempSensor.Value.Value;
                SafeSetLabelText(lblHddTemp, "Температура HDD (" + hardwareItem.Name + "): " + value.ToString("F1") + " °C");
            }
            else
            {
                SafeSetLabelText(lblHddTemp, "Температура HDD (" + hardwareItem.Name + "): датчик не возвращает значение.");
            }
        }

        private bool HasTemperatureSensor(IHardware hardwareItem)
        {
            IList<ISensor> sensorsList = hardwareItem.Sensors;
            int sensorsCount = sensorsList.Count;
            for (int s = 0; s < sensorsCount; s++)
            {
                ISensor sensor = sensorsList[s];
                if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                {
                    return true;
                }
            }
            return false;
        }

        private string GetDiskTypeByModel(string diskNameOrModel)
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Model, MediaType FROM Win32_DiskDrive"))
                {
                    ManagementObjectCollection collection = searcher.Get();
                    for (int i = 0; i < collection.Count; i++)
                    {
                        ManagementObject disk = collection.Cast<ManagementObject>().ElementAt(i);
                        string modelObj = "";
                        object modelValue = disk["Model"];
                        if (modelValue != null)
                        {
                            modelObj = modelValue.ToString();
                        }

                        string mediaTypeObj = "";
                        object mediaTypeValue = disk["MediaType"];
                        if (mediaTypeValue != null)
                        {
                            mediaTypeObj = mediaTypeValue.ToString();
                        }

                        string modelLower = modelObj.ToLower();
                        string mediaLower = mediaTypeObj.ToLower();
                        string diskNameLower = "";
                        if (diskNameOrModel != null)
                        {
                            diskNameLower = diskNameOrModel.ToLower();
                        }

                        bool modelContainsDiskName = modelLower.Contains(diskNameLower);
                        bool diskNameContainsModel = diskNameLower.Contains(modelLower);

                        if (modelContainsDiskName == false && diskNameContainsModel == false)
                        {
                            continue;
                        }

                        bool isSsdByMedia = mediaLower.Contains("solid state");
                        bool isSsdByModel = modelLower.Contains("ssd");

                        if (isSsdByMedia || isSsdByModel)
                        {
                            return "SSD";
                        }
                        else
                        {
                            return "HDD";
                        }
                    }
                }
            }
            catch { }

            return "Unknown";
        }

        private void SafeSetLabelText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.BeginInvoke((Action)(() => label.Text = text));
            }
            else
            {
                label.Text = text;
            }
        }

        private void SafeSetListBoxDataSource(ListBox listBox, object dataSource)
        {
            if (listBox.InvokeRequired)
            {
                listBox.BeginInvoke((Action)(() => listBox.DataSource = dataSource));
            }
            else
            {
                listBox.DataSource = dataSource;
            }
        }

        private void FormDeskTop_FormClosed(object sender, FormClosedEventArgs e)
        {
            computer.Close();
            if (diskTimer != null)
            {
                diskTimer.Stop();
                diskTimer.Dispose();
            }
            if (netTimer != null)
            {
                netTimer.Stop();
                netTimer.Dispose();
            }
        }

        private void SetupDiskMonitoring()
        {
            diskTimer = new Timer();
            diskTimer.Interval = 5000;
            diskTimer.Tick += async (s, e) => await UpdateDiskInfoAsync();
            diskTimer.Start();

            InitDiskChart();
        }

        private void InitDiskChart()
        {
            chartDisk.Series.Clear();
            chartDisk.ChartAreas.Clear();
            chartDisk.Legends.Clear();

            ChartArea area = new ChartArea("DiskArea");
            area.AxisY.Title = "% загрузка";
            area.AxisX.Title = "Время";
            area.AxisY.Maximum = 100;
            area.AxisY.Minimum = 0;
            chartDisk.ChartAreas.Add(area);

            Legend legend = new Legend("DiskLegend");
            chartDisk.Legends.Add(legend);

            Series existingCSeries = chartDisk.Series.FindByName("C:");
            if (existingCSeries == null)
            {
                Series diskCSeries = new Series("C:");
                diskCSeries.ChartType = SeriesChartType.Line;
                diskCSeries.Color = Color.Green;
                diskCSeries.BorderWidth = 2;
                diskCSeries.ChartArea = "DiskArea";
                diskCSeries.Legend = "DiskLegend";
                chartDisk.Series.Add(diskCSeries);
            }

            Series existingDSeries = chartDisk.Series.FindByName("D:");
            if (existingDSeries == null)
            {
                Series diskDSeries = new Series("D:");
                diskDSeries.ChartType = SeriesChartType.Line;
                diskDSeries.Color = Color.Orange;
                diskDSeries.BorderWidth = 2;
                diskDSeries.ChartArea = "DiskArea";
                diskDSeries.Legend = "DiskLegend";
                chartDisk.Series.Add(diskDSeries);
            }
        }

        private async Task UpdateDiskInfoAsync()
        {
            await Task.Run(() =>
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                List<DriveInfo> filteredDrives = new List<DriveInfo>();
                for (int i = 0; i < drives.Length; i++)
                {
                    DriveInfo drive = drives[i];
                    if (drive.IsReady && drive.DriveType == DriveType.Fixed)
                    {
                        filteredDrives.Add(drive);
                    }
                }

                filteredDrives.Sort((d1, d2) => string.Compare(d1.Name, d2.Name, StringComparison.Ordinal));
                DriveInfo[] sortedDrives = filteredDrives.ToArray();

                string summary = "";
                Dictionary<string, double> diskUsageData = new Dictionary<string, double>();

                for (int d = 0; d < sortedDrives.Length; d++)
                {
                    DriveInfo drive = sortedDrives[d];
                    double totalGB = drive.TotalSize / (1024d * 1024 * 1024);
                    double freeGB = drive.AvailableFreeSpace / (1024d * 1024 * 1024);
                    double usedGB = totalGB - freeGB;
                    double usedPct = 0;
                    if (totalGB > 0)
                    {
                        usedPct = usedGB / totalGB * 100;
                    }

                    string diskType = GetDiskType(drive.Name.Replace("\\\\", ""));
                    string driveKey = drive.Name.TrimEnd(':');
                    diskUsageData[driveKey] = usedPct;

                    string line = "";
                    line += "[" + drive.Name + "] " + diskType;
                    line += ", занято " + usedPct.ToString("F0") + "% (свободно " +
                            freeGB.ToString("F1") + " из " + totalGB.ToString("F1") + " GB)";

                    float busy = -1;
                    try
                    {
                        string instanceName = "_Total";
                        using (PerformanceCounter pc = new PerformanceCounter("PhysicalDisk", "% Disk Time", instanceName))
                        {
                            busy = pc.NextValue();
                        }
                    }
                    catch { }

                    if (busy >= 0)
                    {
                        line += ", загрузка: " + busy.ToString("F0") + "%";
                    }
                    else
                    {
                        line += ", загрузка: N/A";
                    }

                    summary += line + Environment.NewLine;
                }

                SafeSetLabelText(lblDiskAnalysis, summary);
                UpdateDiskChart(diskUsageData);
            });
        }

        private void UpdateDiskChart(Dictionary<string, double> diskUsageData)
        {
            if (chartDisk.InvokeRequired)
            {
                chartDisk.BeginInvoke(new Action(() => UpdateDiskChart(diskUsageData)));
                return;
            }

            string timeLabel = DateTime.Now.ToString("HH:mm:ss");

            string[] keysArray = new string[diskUsageData.Count];
            diskUsageData.Keys.CopyTo(keysArray, 0);

            for (int i = 0; i < keysArray.Length; i++)
            {
                string driveKey = keysArray[i];
                double usage = diskUsageData[driveKey];
                string driveName = driveKey + ":";

                Series existingSeries = null;
                for (int s = 0; s < chartDisk.Series.Count; s++)
                {
                    if (chartDisk.Series[s].Name == driveName)
                    {
                        existingSeries = chartDisk.Series[s];
                        break;
                    }
                }

                if (existingSeries != null)
                {
                    existingSeries.Points.AddXY(timeLabel, usage);
                }
                else
                {
                    Series newSeries = new Series(driveName);
                    newSeries.ChartType = SeriesChartType.Line;
                    newSeries.Color = GetSeriesColor(driveName);
                    newSeries.BorderWidth = 2;
                    newSeries.ChartArea = "DiskArea";
                    newSeries.Legend = "DiskLegend";
                    chartDisk.Series.Add(newSeries);
                    newSeries.Points.AddXY(timeLabel, usage);
                }
            }

            int maxPoints = 50;
            for (int s = 0; s < chartDisk.Series.Count; s++)
            {
                Series series = chartDisk.Series[s];
                while (series.Points.Count > maxPoints)
                {
                    series.Points.RemoveAt(0);
                }
            }

            chartDisk.ResetAutoValues();
        }

        private Color GetSeriesColor(string driveName)
        {
            Dictionary<string, Color> colors = new Dictionary<string, Color>
            {
                ["C:"] = Color.Green,
                ["D:"] = Color.Orange,
                ["E:"] = Color.Purple,
                ["F:"] = Color.Red
            };

            if (colors.ContainsKey(driveName))
            {
                return colors[driveName];
            }
            return Color.Blue;
        }

        private string GetDiskType(string driveLetter)
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                    "root\\\\Microsoft\\\\Windows\\\\Storage",
                    "SELECT * FROM MSFT_PhysicalDisk"))
                {
                    ManagementObjectCollection collection = searcher.Get();
                    for (int i = 0; i < collection.Count; i++)
                    {
                        ManagementObject disk = collection.Cast<ManagementObject>().ElementAt(i);
                        uint mediaType = 0;
                        object mediaTypeObj = disk["MediaType"];
                        if (mediaTypeObj != null)
                        {
                            mediaType = (uint)mediaTypeObj;
                        }

                        if (mediaType == 4)
                        {
                            return "SSD";
                        }
                        if (mediaType == 3)
                        {
                            return "HDD";
                        }
                    }
                }
            }
            catch { }

            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Model FROM Win32_DiskDrive"))
                {
                    ManagementObjectCollection collection = searcher.Get();
                    for (int i = 0; i < collection.Count; i++)
                    {
                        ManagementObject disk = collection.Cast<ManagementObject>().ElementAt(i);
                        string model = "";
                        object modelValue = disk["Model"];
                        if (modelValue != null)
                        {
                            model = modelValue.ToString().ToLower();
                        }
                        if (model.Contains("ssd") || model.Contains("nvme"))
                        {
                            return "SSD";
                        }
                    }
                }
            }
            catch { }

            return "HDD";
        }

        private void SetupNetworkMonitoring()
        {
            netTimer = new Timer();
            netTimer.Interval = 3000;
            netTimer.Tick += async (s, e) => await UpdateNetworkInfoAsync();
            netTimer.Start();

            InitNetworkChart();
        }

        private void InitNetworkChart()
        {
            chartNetwork.Series.Clear();
            chartNetwork.ChartAreas.Clear();
            chartNetwork.Legends.Clear();

            ChartArea area = new ChartArea();
            area.AxisY.Title = "Mbps";
            area.AxisX.Title = "Время";
            chartNetwork.ChartAreas.Add(area);

            Legend legend = new Legend("Legend");
            chartNetwork.Legends.Add(legend);

            Series inSeries = new Series("Входящий ↓");
            inSeries.ChartType = SeriesChartType.Line;
            inSeries.Color = Color.Blue;
            inSeries.BorderWidth = 2;
            if (chartNetwork.ChartAreas.Count > 0)
            {
                inSeries.ChartArea = chartNetwork.ChartAreas[0].Name;
            }
            inSeries.Legend = "Legend";
            chartNetwork.Series.Add(inSeries);

            Series outSeries = new Series("Исходящий ↑");
            outSeries.ChartType = SeriesChartType.Line;
            outSeries.Color = Color.Red;
            outSeries.BorderWidth = 2;
            if (chartNetwork.ChartAreas.Count > 0)
            {
                outSeries.ChartArea = chartNetwork.ChartAreas[0].Name;
            }
            outSeries.Legend = "Legend";
            chartNetwork.Series.Add(outSeries);
        }

        private async Task UpdateNetworkInfoAsync()
        {
            await Task.Run(() =>
            {
                string trafficInfo = GetNetworkTraffic();
                string pingInfo = GetPingStatus();
                string connectionsInfo = GetActiveConnections();

                string fullInfo = trafficInfo + Environment.NewLine + pingInfo + Environment.NewLine + connectionsInfo;
                SafeSetLabelText(lblNetworkAnalysis, fullInfo);

                UpdateNetworkChart();
            });
        }

        private void UpdateNetworkChart()
        {
            if (chartNetwork.InvokeRequired)
            {
                chartNetwork.BeginInvoke(new Action(UpdateNetworkChart));
                return;
            }

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            List<NetworkInterface> filteredAdapters = new List<NetworkInterface>();

            for (int i = 0; i < adapters.Length; i++)
            {
                NetworkInterface n = adapters[i];
                if (n.OperationalStatus == OperationalStatus.Up)
                {
                    filteredAdapters.Add(n);
                }
            }

            filteredAdapters.Sort((n1, n2) => n2.GetIPStatistics().BytesReceived.CompareTo(n1.GetIPStatistics().BytesReceived));

            int takeCount = 1;
            if (takeCount > filteredAdapters.Count)
            {
                takeCount = filteredAdapters.Count;
            }

            NetworkInterface[] selectedAdapters = new NetworkInterface[takeCount];
            for (int i = 0; i < takeCount; i++)
            {
                selectedAdapters[i] = filteredAdapters[i];
            }

            if (selectedAdapters.Length > 0)
            {
                NetworkInterface adapter = selectedAdapters[0];
                var stats = adapter.GetIPStatistics();

                double currentInMbps = stats.BytesReceived / 1024.0 / 1024.0 * 8 / 3;
                double currentOutMbps = stats.BytesSent / 1024.0 / 1024.0 * 8 / 3;

                bool hasInSeries = false;
                for (int s = 0; s < chartNetwork.Series.Count; s++)
                {
                    if (chartNetwork.Series[s].Name == "Входящий ↓")
                    {
                        hasInSeries = true;
                        break;
                    }
                }
                if (hasInSeries)
                {
                    chartNetwork.Series["Входящий ↓"].Points.AddXY(DateTime.Now.ToString("HH:mm:ss"), currentInMbps);
                }

                bool hasOutSeries = false;
                for (int s = 0; s < chartNetwork.Series.Count; s++)
                {
                    if (chartNetwork.Series[s].Name == "Исходящий ↑")
                    {
                        hasOutSeries = true;
                        break;
                    }
                }
                if (hasOutSeries)
                {
                    chartNetwork.Series["Исходящий ↑"].Points.AddXY(DateTime.Now.ToString("HH:mm:ss"), currentOutMbps);
                }

                int maxPoints = 50;
                bool foundInSeries = false;
                for (int s = 0; s < chartNetwork.Series.Count; s++)
                {
                    if (chartNetwork.Series[s].Name == "Входящий ↓")
                    {
                        foundInSeries = true;
                        while (chartNetwork.Series[s].Points.Count > maxPoints)
                        {
                            chartNetwork.Series[s].Points.RemoveAt(0);
                        }
                        break;
                    }
                }

                bool foundOutSeries = false;
                for (int s = 0; s < chartNetwork.Series.Count; s++)
                {
                    if (chartNetwork.Series[s].Name == "Исходящий ↑")
                    {
                        foundOutSeries = true;
                        while (chartNetwork.Series[s].Points.Count > maxPoints)
                        {
                            chartNetwork.Series[s].Points.RemoveAt(0);
                        }
                        break;
                    }
                }

                chartNetwork.ResetAutoValues();
            }
        }

        private string GetNetworkTraffic()
        {
            string result = "";
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            List<NetworkInterface> filteredAdapters = new List<NetworkInterface>();

            for (int i = 0; i < adapters.Length; i++)
            {
                NetworkInterface n = adapters[i];
                if (n.OperationalStatus == OperationalStatus.Up &&
                   (n.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                    n.NetworkInterfaceType == NetworkInterfaceType.Wireless80211))
                {
                    filteredAdapters.Add(n);
                }
            }

            filteredAdapters.Sort((n1, n2) => n2.GetIPStatistics().BytesReceived.CompareTo(n1.GetIPStatistics().BytesReceived));

            int takeCount = 2;
            if (takeCount > filteredAdapters.Count)
            {
                takeCount = filteredAdapters.Count;
            }

            NetworkInterface[] selectedAdapters = new NetworkInterface[takeCount];
            for (int i = 0; i < takeCount; i++)
            {
                selectedAdapters[i] = filteredAdapters[i];
            }

            for (int i = 0; i < selectedAdapters.Length; i++)
            {
                var adapter = selectedAdapters[i];
                var stats = adapter.GetIPStatistics();
                long bytesReceived = stats.BytesReceived;
                long bytesSent = stats.BytesSent;

                double inMbps = bytesReceived / 1024.0 / 1024.0 * 8 / 3;
                double outMbps = bytesSent / 1024.0 / 1024.0 * 8 / 3;

                string name = adapter.Name;
                if (name.Length > 20)
                {
                    name = name.Substring(0, 17) + "...";
                }

                result += $"[{name}] ↑{outMbps:F1} ↓{inMbps:F1} Mbps ";
            }
            return result;
        }

        private string GetPingStatus()
        {
            string result = "";
            using (Ping ping = new Ping())
            {
                int pingHostsCount = pingHosts.Count;
                for (int i = 0; i < 2 && i < pingHostsCount; i++)
                {
                    string host = pingHosts[i];
                    try
                    {
                        PingReply reply = ping.Send(host, 2000);
                        string status = "TIMEOUT";
                        if (reply.Status == IPStatus.Success)
                        {
                            status = reply.RoundtripTime + "мс";
                        }

                        result += $"[{host}] {status} ";
                    }
                    catch
                    {
                        result += $"[{host}] ERROR ";
                    }
                }
            }
            return result;
        }

        private string GetActiveConnections()
        {
            try
            {
                using (Process p = new Process())
                {
                    p.StartInfo.FileName = "netstat";
                    p.StartInfo.Arguments = "-an | findstr ESTABLISHED";
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();

                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit(3000);

                    string[] lines = output.Split('\n');
                    int tcpCount = lines.Length - 1;
                    int udpCount = GetUdpConnections();

                    return $"TCP:{tcpCount} UDP:{udpCount} соединений";
                }
            }
            catch
            {
                return "Соединения: N/A";
            }
        }

        private int GetUdpConnections()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PerfRawData_Tcpip_UDP"))
                {
                    ManagementObjectCollection collection = searcher.Get();
                    for (int i = 0; i < collection.Count; i++)
                    {
                        ManagementObject obj = collection.Cast<ManagementObject>().ElementAt(i);
                        return Convert.ToInt32(obj["DatagramsPerSecond"]);
                    }
                }
            }
            catch { }
            return 0;
        }
    }
}
