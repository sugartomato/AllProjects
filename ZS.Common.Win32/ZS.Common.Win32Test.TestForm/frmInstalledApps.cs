using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZS.Common.Win32Test.TestForm
{
    public partial class frmInstalledApps : Form
    {
        public frmInstalledApps()
        {
            InitializeComponent();
        }

        private void frmInstalledApps_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ZS.Common.Win32.InstalledApp> list = ZS.Common.Win32.Query.GetInstalledApps();
            foreach (var app in list)
            {
                textBox1.AppendText(app.ToDebugString(new string[] { "Name", "InstallLocation", "UninstallString", "IsWindowsUpdate", "ReleaseType", "RegKeyPath" }));
            }
        }
    }
}
