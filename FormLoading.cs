using System;
using System.Windows.Forms;

namespace SysMonitor_Pro
{
    public partial class FormLoading : Form
    {
        private int progressValue = 0;

        public FormLoading()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            timerPB.Interval = 50;
            StartProgress();
        }

        private void timerPB_Tick(object sender, EventArgs e)
        {
            if (progressValue < 100)
            {
                progressValue += 2;  
                progressBar.Value = progressValue;
            }
            else
            {
                timerPB.Stop();
                this.Hide();
                FormDeskTop formDeskTop = new FormDeskTop(); 
                formDeskTop.Show();
            }
        }

        public void StartProgress()
        {
            progressValue = 0;
            progressBar.Value = progressValue;
            timerPB.Start();
        }
    }
}