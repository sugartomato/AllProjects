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
    public partial class frmNetworkAdapter : Form
    {
        public frmNetworkAdapter()
        {
            InitializeComponent();
        }

        private void button2_Click(Object sender, EventArgs e)
        {
            txtMACAddress.Text = ZS.Common.Win32.Net.NetworkAdapter.GetMACAddress(txtAdapterName.Text);
        }

        private void button1_Click(Object sender, EventArgs e)
        {
            try
            {
                bool b = Win32.Net.NetworkAdapter.ModifyMacAddress_ByConnectionID(txtAdapterName.Text, txtMACAddress.Text);
                MessageBox.Show(b == true ? "成功！" : "失败！");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmModifyHardwareInfo_Load(Object sender, EventArgs e)
        {

        }

        private void button3_Click(Object sender, EventArgs e)
        {
            List<Win32.Win32Provider.Win32_NetworkAdapter> list = Win32.Win32Provider.ProviderHelper<Win32.Win32Provider.Win32_NetworkAdapter>.GetAll();
            if(list != null && list.Count > 0)
            {
                foreach(var item in list)
                {
                    txtConsole.AppendText(item.ToDebugString());
                }
            }
         }

        private void button4_Click(Object sender, EventArgs e)
        {
            try
            {
                bool b = Win32.Net.NetworkAdapter.Enable_ByConnectionID(txtAdapterName.Text);
                MessageBox.Show(b == true ? "成功！" : "失败！");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(Object sender, EventArgs e)
        {
            try
            {
                bool b = Win32.Net.NetworkAdapter.Disable_ByConnectionID(txtAdapterName.Text);
                MessageBox.Show(b == true ? "成功！" : "失败！");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(Object sender, EventArgs e)
        {
            List<Win32.Win32Provider.Win32_NetworkAdapter> list = Win32.Win32Provider.ProviderHelper<Win32.Win32Provider.Win32_NetworkAdapter>.GetAll();
            if(list != null && list.Count > 0)
            {
                foreach(var item in list)
                {
                    txtConsole.AppendText(item.Index + " : " + item.NetConnectionID + "\r\n");
                }
            }
        }

        private void button7_Click(Object sender, EventArgs e)
        {
            txtConsole.Text = "";
            List<Win32.Win32Provider.Win32_NetworkAdapterConfiguration> list = Win32.Win32Provider.ProviderHelper<Win32.Win32Provider.Win32_NetworkAdapterConfiguration>.GetAll();
            if(list != null && list.Count > 0)
            {
                foreach(var item in list)
                {
                    txtConsole.AppendText(item.ToDebugString());
                }
            }
        }
    }
}
