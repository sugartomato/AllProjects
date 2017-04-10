using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
namespace ZSExcelAddIn
{
    public class Common
    {

        /// <summary>
        /// 将当前活动工作簿的指定名称的工作表设置为活动
        /// </summary>
        /// <param name="sheetName"></param>
        public static void ActiveSheet(string sheetName)
        {

            Microsoft.Office.Interop.Excel.Workbook book = Globals.ThisAddIn.Application.ActiveWorkbook;
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

        public static string GetActiveSheetName()
        {
            Microsoft.Office.Interop.Excel.Worksheet sheet = null;
            sheet = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            return sheet.Name;
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



    }




}
