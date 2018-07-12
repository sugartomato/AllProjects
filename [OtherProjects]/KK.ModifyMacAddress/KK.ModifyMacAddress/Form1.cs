using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KK.ModifyMacAddress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            InitializeComponent();
        }

        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var exAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            String loadDllName = args.Name;
            if (loadDllName.Contains(","))
            {
                loadDllName = args.Name.Substring(0, args.Name.IndexOf(","));
            }

            String[] resourceNames = exAssembly.GetManifestResourceNames();
            if (resourceNames != null && resourceNames.Length > 0)
            {
                foreach (String resourceName in resourceNames)
                {
                    if (resourceName.Contains(loadDllName))
                    {
                        using (var resourceStream = exAssembly.GetManifestResourceStream(resourceName))
                        {
                            var assData = new Byte[resourceStream.Length];
                            resourceStream.Read(assData, 0, assData.Length);
                            return System.Reflection.Assembly.Load(assData);
                        }
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                String[] connIDs = ZS.Common.Win32.Net.NetworkAdapter.GetAllConnectionID();
                for (Int32 i = 0; i < connIDs.Length; i++)
                {
                    listConnIDS.Items.Add(connIDs[i]);
                }
            }
            catch (Exception ex)
            {
                ShowError("Load失败：" + ex.Message);
            }
        }

        private void ShowError(String msg)
        {
            MessageBox.Show(msg);
        }
        private void ShowInfo(String msg)
        {
            MessageBox.Show(msg);
        }

        private void listConnIDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadSelectedConnMAC();
            }
            catch (Exception ex)
            {
                ShowError("切换失败：" + ex.Message);
            }
        }

        private void btnGenerateMac_Click(object sender, EventArgs e)
        {
            try
            {
                String macFormat = String.Format("00:00:00:00:{0}:{1}", PickRandomMacVal(),PickRandomMacVal());
                txtTargetMac.Text = macFormat.ToUpper();
            }
            catch (Exception ex)
            {
                ShowError("生成失败：" + ex.Message);
            }
        }
        private String PickRandomMacVal()
        {
            String rndRange = "0123456789ABCDEF";
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            var m = rndRange[rnd.Next(0, 16)];
            var n = rndRange[rnd.Next(0, 16)];
            return m.ToString() + n.ToString();
            //return rndRange[rnd.Next(0, 17)] + rndRange[rnd.Next(0, 17)];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                String connID = listConnIDS.SelectedItem.ToString();
                String mac = txtTargetMac.Text;
                this.Enabled = false;
                Boolean result = ZS.Common.Win32.Net.NetworkAdapter.ModifyMacAddress_ByConnectionID(connID, mac);
                if (result)
                {
                    result =ZS.Common.Win32.Net.NetworkAdapter.Disable_ByConnectionID(connID);
                    System.Threading.Thread.Sleep(3000);
                    result = ZS.Common.Win32.Net.NetworkAdapter.Enable_ByConnectionID(connID);
                    if (result)
                    {
                        ShowInfo("修改完成！");
                        LoadSelectedConnMAC();
                    }
                    else
                    {
                        ShowError("MAC地址修改成功，但重启网卡失败！");
                    }
                }
                else
                {
                    ShowError("MAC地址修改失败！");
                }

            }
            catch (Exception ex)
            {
                ShowError("修改失败：" + ex.Message);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void LoadSelectedConnMAC()
        {
            try
            {
                this.Enabled = false;
                String currMac = ZS.Common.Win32.Net.NetworkAdapter.GetMACAddress(listConnIDS.SelectedItem.ToString());
                txtCurrentMac.Text = currMac;
            }
            catch (Exception ex)
            {
                ShowError("获取失败：" + ex.Message);
            }
            finally
            {
                this.Enabled = true;
            }
        }
    }
}
