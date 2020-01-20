using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MSExcel = Microsoft.Office.Interop.Excel;

#region Office
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
#endregion

namespace ZSExcelAddIn
{
    public class Common
    {

        /// <summary>
        /// 将当前活动工作簿的指定名称的工作表设置为活动
        /// </summary>
        /// <param name="sheetName"></param>
        public static void ActiveSheetByName(string sheetName)
        {

            MSExcel.Workbook book = Globals.ThisAddIn.Application.ActiveWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet sheet = null;
            if (book == null) return;
            Int32 i = 0;
            for (i = 1; i <= book.Worksheets.Count; ++i)
            {
                sheet = book.Worksheets[i] as Microsoft.Office.Interop.Excel.Worksheet;
                if (sheet.Name == sheetName)
                {
                    sheet.Activate();
                }
            }
        }

        public static MSExcel.Worksheet ActiveSheet { get { return (MSExcel.Worksheet)App.ActiveSheet; } }
        public static MSExcel.Application App { get { return (MSExcel.Application)Globals.ThisAddIn.Application; } }
        public static MSExcel.Workbook ActiveBook { get { return (MSExcel.Workbook)App.ActiveWorkbook; } }
        public static MSExcel.Range ActiveCell { get { return (MSExcel.Range)App.ActiveCell; } }



        public static string GetActiveSheetName()
        {
            Microsoft.Office.Interop.Excel.Worksheet sheet = null;
            sheet = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            return sheet.Name;
        }

        /// <summary>
        /// 获取当前活动工作簿的所有工作表名
        /// </summary>
        /// <returns></returns>
        public static List<String> GetSheetNamesOfActiveBook()
        {
            Excel.Workbook book = (Excel.Workbook)Globals.ThisAddIn.Application.ActiveWorkbook;
            List<String> result = new List<string>();
            foreach (var sheet in book.Sheets)
            {
                result.Add((sheet as Excel.Worksheet).Name);
            }
            return result;
        }


        public class TreeViewItemBase : INotifyPropertyChanged
        {

            private System.Windows.Media.SolidColorBrush _propBackGroundColor = null;
            public System.Windows.Media.SolidColorBrush BackGroundColor
            {
                get { return this._propBackGroundColor; }
                set
                {
                    this._propBackGroundColor = value;
                    NotifyPropertyChanged("BackGroundColor");
                }
            }




            public event PropertyChangedEventHandler PropertyChanged;

            public void NotifyPropertyChanged(string pName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(pName));
                }
            }
        }

		/// <summary>
		/// 向当前活动窗口的面板写入消息
		/// </summary>
		/// <param name="text"></param>
		public static void WriteConsole(String text)
		{
			// 获取当前活动窗口的主taskpan
			// 如果有，获取控件，写入消息
			String key = string.Format("{0}({1})", "RuntimeInfo", Globals.ThisAddIn.Application.ActiveWindow.Hwnd);
			if (Config.TaskPans.ContainsKey(key))
			{
				var ctrl = Config.TaskPans[key].Control as Controls.CustomPans.MainPanHost;
				ctrl.WriteConsole(text);
			}
		}

		/// <summary>
		/// 向指定窗口的面板写入消息
		/// </summary>
		/// <param name="text"></param>
		/// <param name="window"></param>
		public static void WriteConsole(String text, Int32 hwnd)
		{
			// 获取当前活动窗口的主taskpan
			// 如果有，获取控件，写入消息
			String key = string.Format("{0}({1})", "RuntimeInfo", hwnd);
			if (Config.TaskPans.ContainsKey(key))
			{
				var ctrl = Config.TaskPans[key].Control as Controls.CustomPans.MainPanHost;
				ctrl.WriteConsole(text);
			}
		}

        /// <summary>
        /// 是否显示聚光灯
        /// </summary>
        public static Boolean IsShowFocusForm { get; set; } = false;


        /// <summary>
        /// 主工具栏
        /// </summary>
        public static RibMyTools MainRibbon { get; set; }


        #region 提示消息

        public static void ShowError(String msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        public static void ShowSuccess(String msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        #endregion

    }


}
