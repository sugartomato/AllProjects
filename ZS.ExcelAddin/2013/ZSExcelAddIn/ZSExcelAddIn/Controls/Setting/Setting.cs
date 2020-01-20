using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZSExcelAddIn.Controls.Setting
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            try
            {
                panelSpotlightColor.BackColor = Config.SpotlightColor;
            }
            catch (Exception ex)
            {
                Msg.ShowError("设置窗体加载异常:" + ex.Message, ex);
            }
        }


        private void panelSpotlightColor_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = Config.SpotlightColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                //Config.SpotlightColor = cd.Color;
                panelSpotlightColor.BackColor = cd.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Config.SpotlightColor = panelSpotlightColor.BackColor;
            Config.SaveConfig();
        }
    }
}
