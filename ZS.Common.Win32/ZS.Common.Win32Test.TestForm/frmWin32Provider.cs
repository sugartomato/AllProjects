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
    public partial class frmWin32Provider : Form
    {
        public frmWin32Provider()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ZS.Common.Win32.Win32Provider.Win32_Product> list =  ZS.Common.Win32.Win32Provider.ProviderHelper<ZS.Common.Win32.Win32Provider.Win32_Product>.GetAll();
            foreach (var t in list)
            {
                txtConsole.AppendText(t.ToDebugString());
            }
        }
    }
}
