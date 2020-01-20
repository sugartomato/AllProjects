using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using E =Microsoft.Office.Interop.Excel;

namespace ZSExcelAddIn.Controls
{
	public partial class frmTest : Form
	{
		E.Workbook m_ActiveBook = (E.Workbook)Globals.ThisAddIn.Application.ActiveWorkbook;
		E.Worksheet m_ActiveSheet = (E.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
		public frmTest()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}

        private void button2_Click(object sender, EventArgs e)
        {
            var rib = Globals.Ribbons.GetRibbon(typeof(RibMyTools));
            MessageBox.Show(rib.GetType().ToString());
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.DoDragDrop(listBox1.SelectedItem.ToString(), DragDropEffects.Copy);
        }

        private void btnGetFomula_Click(object sender, EventArgs e)
        {
            lblFormula.Text = Convert.ToString(Globals.ThisAddIn.Application.ActiveCell.Formula);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Msg.ShowError("这是个错误！");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Common.WriteConsole("这是一条测试消息！");
        }

        private void button5_Click(object sender, EventArgs e)
        {

            ((E.Range)Globals.ThisAddIn.Application.ActiveCell).ID = txtCellID.Text;
            System.Threading.Thread.Sleep(3000);
            ((E.Range)Globals.ThisAddIn.Application.ActiveCell).Value = "123";
            System.Threading.Thread.Sleep(3000);
            txtCellID.Text = Convert.ToString(((E.Range)Globals.ThisAddIn.Application.ActiveCell).ID);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtCellID.Text = Convert.ToString(((E.Range)Globals.ThisAddIn.Application.ActiveCell).ID);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ((E.Range)Globals.ThisAddIn.Application.ActiveCell).ID = txtCellID.Text;
        }

        private void chkTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chkTopMost.Checked;
        }

        private void btnSpecialString_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String s1 = System.IO.File.ReadAllText(ofd.FileName);
                //String s2 = System.Text.Encoding.Unicode.GetString(System.Text.Encoding.Default.GetBytes(s1));
                String s2 = s1;
                s2 = s2.Replace("[m2]", "m\x00B2");
                s2 = s2.Replace("[O2]", "O\x2082");
                txtSpecialStringResult.Text = s2;
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            E.Range rng = (E.Range)Globals.ThisAddIn.Application.ActiveCell;
            sb.AppendLine("Range.Left:" + Convert.ToString(rng.Left));
            sb.AppendLine("Range.Top:" + Convert.ToString(rng.Top));
            sb.AppendLine("Window.Left:" + Convert.ToString(rng.Application.ActiveWindow.Left));
            sb.AppendLine("Window.Top:" + Convert.ToString(rng.Application.ActiveWindow.Top));
            sb.AppendLine("Window.PointsToScreenPixelsX(0):" + Convert.ToString(rng.Application.ActiveWindow.PointsToScreenPixelsX(0)));
            sb.AppendLine("Window.PointsToScreenPixelsY(0):" + Convert.ToString(rng.Application.ActiveWindow.PointsToScreenPixelsY(0)));
            sb.AppendLine("Window.PointsToScreenPixelsX(Range.Left):" + Convert.ToString(rng.Application.ActiveWindow.PointsToScreenPixelsX(Convert.ToInt32(rng.Left))));
            sb.AppendLine("Window.PointsToScreenPixelsY(Range.Top):" + Convert.ToString(rng.Application.ActiveWindow.PointsToScreenPixelsY(Convert.ToInt32(rng.Top))));
            lblLocation.Text = sb.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application wordApp = null;
            wordApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application") as Microsoft.Office.Interop.Word.Application;
            wordApp.Visible = true;
            wordApp.Documents.Add();
            wordApp.Activate();

            Microsoft.Office.Core.COMAddIns addins = wordApp.COMAddIns;
            foreach (Microsoft.Office.Core.COMAddIn addin in addins)
            {
                Msg.ShowInfo(addin.ProgId);
            }

        }
    }
}
