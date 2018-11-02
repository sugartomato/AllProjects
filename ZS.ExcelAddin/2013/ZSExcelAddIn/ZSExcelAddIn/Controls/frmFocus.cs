using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace ZSExcelAddIn.Controls
{
	public partial class frmFocus : Form
	{
		private Window _ExcelWindow = Globals.ThisAddIn.Application.ActiveWindow;

		public frmFocus()
		{
			InitializeComponent();
			//this.FormBorderStyle = FormBorderStyle.None;
			this.BackColor = Color.Black;
			this.TransparencyKey = Color.Black;
			//this.Opacity = 0;
			this.TopMost = true;
			this.Width = (Int32)_ExcelWindow.Width;
			this.Height = (Int32)_ExcelWindow.Height;
		}

		private const int WM_MOUSEACTIVATE = 0x21;
		private const int MA_NOACTIVATE = 3;
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == WM_MOUSEACTIVATE)
			{
				m.Result = new IntPtr(MA_NOACTIVATE);
				return;
			}
			base.WndProc(ref m);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Workbook book = (Workbook)Globals.ThisAddIn.Application.ActiveWorkbook;
			Worksheet sheet = (Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
			sheet.Range["A1"].Value = "UsableHeight";
			sheet.Range["B1"].Value = Globals.ThisAddIn.Application.ActiveWindow.UsableHeight;
			sheet.Range["A2"].Value = "UsableWidth";
			sheet.Range["B2"].Value = Globals.ThisAddIn.Application.ActiveWindow.UsableWidth;

			sheet.Range["A2"].Value = "UsableWidth";
			sheet.Range["B2"].Value = Globals.ThisAddIn.Application.ActiveWindow.Hwnd;
			
		}
	}
}
