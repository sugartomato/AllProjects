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
    public partial class frmForm_SendKeys : Form
    {
        public frmForm_SendKeys()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                SendKeys.Send(txtKeys.Text);
            }
            catch (Exception ex)
            {
                txtConsole.AppendText(ex.Message + ex.StackTrace);
                
            }
        }
    }
}
