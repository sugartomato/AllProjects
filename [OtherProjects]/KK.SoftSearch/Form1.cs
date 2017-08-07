using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KK.SoftSearch
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            chkListBox.Items.Add("360杀毒");
            chkListBox.Items.Add("百度杀毒");
            chkListBox.Items.Add("金山毒霸");
            chkListBox.Items.Add("卡巴斯基");
            chkListBox.Items.Add("诺顿");
            chkListBox.Items.Add("瑞星");
            chkListBox.Items.Add("小红伞");
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            RegSoftCheck regCheck = new RegSoftCheck();
            string antInstalled = "";
            string officeInstalled = "";

            if (regCheck.HasAnt360())
            {
                txtAnts.Text += "360杀毒,";
            }

            if (regCheck.HasOffice_WPSPersonal())
            {
                txtOffices.Text += "WPS个人版,";
            }
            if (regCheck.HasOffice_WPSPro())
            {
                txtOffices.Text += "WPS专业版,";
            }



        }

        

        private void SetAntItemCheckState(string item, Boolean isChecked)
        {
            if (chkListBox.Items.Count > 0)
            {
                for (Int32 m = 0; m < chkListBox.Items.Count; m++)
                {
                    if (chkListBox.Items[m].ToString().Contains(item))
                    {
                        chkListBox.SetItemChecked(m, isChecked);
                    }
                }
            }
        }

    }
}
