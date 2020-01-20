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
    public partial class frmReg : Form
    {
        public frmReg()
        {
            InitializeComponent();
        }

        private void frmReg_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryHive root = ItemToRegHive();
                DateTime dt = Win32.RegHelper.GetRegKeyLastWritetime(root, txtSubKeys.Text);
                txtRegModifyTime.Text = dt.ToString();
            }
            catch (Exception ex)
            {
                txtRegModifyTime.Text = "获取修改时间失败：" + ex.Message;
            }
        }


        private Microsoft.Win32.RegistryHive ItemToRegHive()
        {
            switch (cbxRootKeys.SelectedItem.ToString())
            {
                case "HKCR":
                    return Microsoft.Win32.RegistryHive.ClassesRoot;
                case "HKCU":
                    return Microsoft.Win32.RegistryHive.CurrentUser;
                case "HKLM":
                    return Microsoft.Win32.RegistryHive.LocalMachine;
                case "HKU":
                    return Microsoft.Win32.RegistryHive.Users;
                default:
                    return Microsoft.Win32.RegistryHive.LocalMachine;
            }
        }
    }
}
