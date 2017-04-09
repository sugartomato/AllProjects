using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZS.WordAddIn
{
    public partial class Notify : Form
    {
        public Notify()
        {
            InitializeComponent();
            //this.Size = new Size(0, 0);
            //this.Visible = false;
            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.Visible = true;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public void ShowInfo(string message, string title = "KK工具箱", Int32 delay = 6000)
        {
            notifyIcon1.ShowBalloonTip(delay, title, message, ToolTipIcon.Info);
            //this.BeginInvoke((Action)delegate {
            //});
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowInfo("123");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
