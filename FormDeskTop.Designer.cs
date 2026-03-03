namespace SysMonitor_Pro
{
    partial class FormDeskTop
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDeskTop));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblHddTemp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRamUsage = new System.Windows.Forms.Label();
            this.lblGpuTemp = new System.Windows.Forms.Label();
            this.lstTopProcesses = new System.Windows.Forms.ListBox();
            this.lblCpuFrequency = new System.Windows.Forms.Label();
            this.lblCpuUsage = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chartDisk = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblDiskAnalysis = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chartNetwork = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblNetworkAnalysis = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.guna2TabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDisk)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNetwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.BorderRadius = 15;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.guna2TabControl1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.panel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(59)))), ((int)(((byte)(69)))));
            this.panel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(125)))), ((int)(((byte)(140)))));
            this.panel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(167)))), ((int)(((byte)(178)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 554);
            this.panel1.TabIndex = 0;
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Controls.Add(this.tabPage1);
            this.guna2TabControl1.Controls.Add(this.tabPage2);
            this.guna2TabControl1.Controls.Add(this.tabPage3);
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(16, 60);
            this.guna2TabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(1035, 479);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.TabIndex = 2;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.lblHddTemp);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lblRamUsage);
            this.tabPage1.Controls.Add(this.lblGpuTemp);
            this.tabPage1.Controls.Add(this.lstTopProcesses);
            this.tabPage1.Controls.Add(this.lblCpuFrequency);
            this.tabPage1.Controls.Add(this.lblCpuUsage);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1027, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Мониторинг аппаратных ресурсов";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblHddTemp
            // 
            this.lblHddTemp.AutoSize = true;
            this.lblHddTemp.BackColor = System.Drawing.Color.Transparent;
            this.lblHddTemp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHddTemp.ForeColor = System.Drawing.Color.Black;
            this.lblHddTemp.Location = new System.Drawing.Point(8, 200);
            this.lblHddTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHddTemp.Name = "lblHddTemp";
            this.lblHddTemp.Size = new System.Drawing.Size(346, 32);
            this.lblHddTemp.TabIndex = 12;
            this.lblHddTemp.Text = "Анализ температуры HDD...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(296, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(429, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "Мониторинг аппаратных ресурсов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(704, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "Топ-процессы";
            // 
            // lblRamUsage
            // 
            this.lblRamUsage.AutoSize = true;
            this.lblRamUsage.BackColor = System.Drawing.Color.Transparent;
            this.lblRamUsage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRamUsage.ForeColor = System.Drawing.Color.Black;
            this.lblRamUsage.Location = new System.Drawing.Point(8, 265);
            this.lblRamUsage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRamUsage.Name = "lblRamUsage";
            this.lblRamUsage.Size = new System.Drawing.Size(373, 32);
            this.lblRamUsage.TabIndex = 7;
            this.lblRamUsage.Text = "Анализ использования RAM...";
            // 
            // lblGpuTemp
            // 
            this.lblGpuTemp.AutoSize = true;
            this.lblGpuTemp.BackColor = System.Drawing.Color.Transparent;
            this.lblGpuTemp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGpuTemp.ForeColor = System.Drawing.Color.Black;
            this.lblGpuTemp.Location = new System.Drawing.Point(8, 169);
            this.lblGpuTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGpuTemp.Name = "lblGpuTemp";
            this.lblGpuTemp.Size = new System.Drawing.Size(342, 32);
            this.lblGpuTemp.TabIndex = 5;
            this.lblGpuTemp.Text = "Анализ температуры GPU...";
            // 
            // lstTopProcesses
            // 
            this.lstTopProcesses.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstTopProcesses.FormattingEnabled = true;
            this.lstTopProcesses.ItemHeight = 32;
            this.lstTopProcesses.Location = new System.Drawing.Point(585, 69);
            this.lstTopProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstTopProcesses.Name = "lstTopProcesses";
            this.lstTopProcesses.Size = new System.Drawing.Size(429, 292);
            this.lstTopProcesses.TabIndex = 3;
            // 
            // lblCpuFrequency
            // 
            this.lblCpuFrequency.AutoSize = true;
            this.lblCpuFrequency.BackColor = System.Drawing.Color.Transparent;
            this.lblCpuFrequency.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCpuFrequency.ForeColor = System.Drawing.Color.Black;
            this.lblCpuFrequency.Location = new System.Drawing.Point(8, 137);
            this.lblCpuFrequency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCpuFrequency.Name = "lblCpuFrequency";
            this.lblCpuFrequency.Size = new System.Drawing.Size(278, 32);
            this.lblCpuFrequency.TabIndex = 2;
            this.lblCpuFrequency.Text = "Анализ частоты CPU...";
            // 
            // lblCpuUsage
            // 
            this.lblCpuUsage.AutoSize = true;
            this.lblCpuUsage.BackColor = System.Drawing.Color.Transparent;
            this.lblCpuUsage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCpuUsage.ForeColor = System.Drawing.Color.Black;
            this.lblCpuUsage.Location = new System.Drawing.Point(8, 106);
            this.lblCpuUsage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCpuUsage.Name = "lblCpuUsage";
            this.lblCpuUsage.Size = new System.Drawing.Size(364, 32);
            this.lblCpuUsage.TabIndex = 1;
            this.lblCpuUsage.Text = "Анализ использования CPU...";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartDisk);
            this.tabPage2.Controls.Add(this.lblDiskAnalysis);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(1027, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Мониторинг дисковой подсистемы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chartDisk
            // 
            chartArea3.Name = "ChartArea1";
            this.chartDisk.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartDisk.Legends.Add(legend3);
            this.chartDisk.Location = new System.Drawing.Point(536, 121);
            this.chartDisk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartDisk.Name = "chartDisk";
            series3.ChartArea = "ChartArea1";
            series3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartDisk.Series.Add(series3);
            this.chartDisk.Size = new System.Drawing.Size(480, 295);
            this.chartDisk.TabIndex = 18;
            this.chartDisk.Text = "chart1";
            // 
            // lblDiskAnalysis
            // 
            this.lblDiskAnalysis.AutoSize = true;
            this.lblDiskAnalysis.BackColor = System.Drawing.Color.Transparent;
            this.lblDiskAnalysis.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDiskAnalysis.ForeColor = System.Drawing.Color.Black;
            this.lblDiskAnalysis.Location = new System.Drawing.Point(8, 50);
            this.lblDiskAnalysis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiskAnalysis.Name = "lblDiskAnalysis";
            this.lblDiskAnalysis.Size = new System.Drawing.Size(396, 32);
            this.lblDiskAnalysis.TabIndex = 14;
            this.lblDiskAnalysis.Text = "Анализ дисковой подсистемы...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(285, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(438, 32);
            this.label4.TabIndex = 11;
            this.label4.Text = "Мониторинг дисковой подсистемы";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chartNetwork);
            this.tabPage3.Controls.Add(this.lblNetworkAnalysis);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(1027, 431);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Мониторинг сети";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chartNetwork
            // 
            chartArea4.Name = "ChartArea1";
            this.chartNetwork.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartNetwork.Legends.Add(legend4);
            this.chartNetwork.Location = new System.Drawing.Point(432, 117);
            this.chartNetwork.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartNetwork.Name = "chartNetwork";
            series4.ChartArea = "ChartArea1";
            series4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartNetwork.Series.Add(series4);
            this.chartNetwork.Size = new System.Drawing.Size(584, 295);
            this.chartNetwork.TabIndex = 17;
            this.chartNetwork.Text = "chart1";
            // 
            // lblNetworkAnalysis
            // 
            this.lblNetworkAnalysis.AutoSize = true;
            this.lblNetworkAnalysis.BackColor = System.Drawing.Color.Transparent;
            this.lblNetworkAnalysis.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNetworkAnalysis.ForeColor = System.Drawing.Color.Black;
            this.lblNetworkAnalysis.Location = new System.Drawing.Point(8, 57);
            this.lblNetworkAnalysis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNetworkAnalysis.Name = "lblNetworkAnalysis";
            this.lblNetworkAnalysis.Size = new System.Drawing.Size(179, 32);
            this.lblNetworkAnalysis.TabIndex = 16;
            this.lblNetworkAnalysis.Text = "Анализ сети...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(375, 4);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "Мониторинг сети";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1024, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(125, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(799, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "SysMonitor Pro: Полный контроль над каждым тактом.";
            // 
            // timerUpdate
            // 
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // FormDeskTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormDeskTop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SysMonitor Pro";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guna2TabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDisk)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNetwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerUpdate;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblHddTemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRamUsage;
        private System.Windows.Forms.Label lblGpuTemp;
        private System.Windows.Forms.ListBox lstTopProcesses;
        private System.Windows.Forms.Label lblCpuFrequency;
        private System.Windows.Forms.Label lblCpuUsage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDisk;
        private System.Windows.Forms.Label lblDiskAnalysis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNetwork;
        private System.Windows.Forms.Label lblNetworkAnalysis;
        private System.Windows.Forms.Label label6;
    }
}

