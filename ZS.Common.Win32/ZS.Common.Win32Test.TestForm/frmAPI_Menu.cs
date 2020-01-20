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
    public partial class frmAPI_Menu : Form
    {
        public frmAPI_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr h = Win32.API.GetMenu(new IntPtr(Int32.Parse(txtWindowHandle.Text)));
            MessageBox.Show(h.ToString());
        }
    }
}
