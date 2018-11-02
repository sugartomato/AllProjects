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
	}
}
