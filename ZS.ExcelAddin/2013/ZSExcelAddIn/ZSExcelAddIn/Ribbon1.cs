using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace ZSExcelAddIn
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnInsertDate_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.Application.ActiveCell.Value2 = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void btnInsertTime_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.Application.ActiveCell.Value2 = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnInsertDateTime_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.Application.ActiveCell.Value2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void btnCalendar_Click(object sender, RibbonControlEventArgs e)
        {
            Controls.DateTimePicker dtp = new Controls.DateTimePicker();
            dtp.ShowDialog();
            

        }

        /// <summary>
        /// 高亮显示行列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkHighLightRowAndCloumn_Click(object sender, RibbonControlEventArgs e)
        {
            Config.HightLightRowAndColumn = chkHighLightRowAndCloumn.Checked;
        }

    }
}
