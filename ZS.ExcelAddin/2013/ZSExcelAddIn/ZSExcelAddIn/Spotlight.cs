using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace ZSExcelAddIn
{
    internal class Spotlight
    {
        /// <summary>
        /// 条件格式的聚光灯名称
        /// </summary>
        private const String ConditionRangeName = "b455baf64adf11e99ce400000000c88e";

        /// <summary>
        /// 聚光灯模式
        /// </summary>
        public static SpotlightTypeEnum SpotLightType { get; set; } = SpotlightTypeEnum.Form;

        private static Boolean _propIsVisible = false;
        public static Boolean IsVisible { get { return _propIsVisible; } set { _propIsVisible = value; } }

        private static Controls.frmFocus _propFocusForm = null;
        public static Controls.frmFocus FocusForm
        {
            get
            {
                if (_propFocusForm == null)
                {
                    _propFocusForm = new Controls.frmFocus();
                    _propFocusForm.Visible = false;
                }
                return _propFocusForm;
            }
        }



        public static void Show()
        {
            MSExcel.Range target = Globals.ThisAddIn.Application.ActiveCell;
            MSExcel.Application _app = Common.App;
            if (SpotLightType == SpotlightTypeEnum.FilterFormat)
            {
                // 设置条件格式
                RemoveCondition();
                Common.ActiveBook.Names.Add(Name: ConditionRangeName, RefersTo: target);
                MSExcel.Range range = ConditionRange;
                range.FormatConditions.Add(MSExcel.XlFormatConditionType.xlExpression, Formula1: "=ROW(" + ConditionRangeName + ")=ROW()");
                ((MSExcel.FormatCondition)(range.FormatConditions[range.FormatConditions.Count])).Interior.Color = Config.SpotlightColor;
                range.FormatConditions.Add(MSExcel.XlFormatConditionType.xlExpression, Formula1: "=COLUMN(" + ConditionRangeName + ")=COLUMN()");
                ((MSExcel.FormatCondition)(range.FormatConditions[range.FormatConditions.Count])).Interior.Color = Config.SpotlightColor;

            }
            else
            {
                Common.App.SheetSelectionChange -= App_SheetSelectionChange;
                Common.App.SheetSelectionChange += App_SheetSelectionChange;
            }
            _propIsVisible = true;
        }

        private static void App_SheetSelectionChange(object Sh, MSExcel.Range Target)
        {
            if (Target != null)
            {
                string windowKey = Common.App.ActiveWindow.Caption.ToString();
                IntPtr hwnd = ZS.Common.Win32.Window.FindWindow(new IntPtr(Globals.ThisAddIn.Application.ActiveWindow.Hwnd), windowKey);
                FocusForm.BindControl = hwnd;
                FocusForm.IsShow = true;
                FocusForm.ReSet(Target);
            }
            else
            {
                FocusForm.Visible = false;
                FocusForm.IsShow = false;
            }
        }

        public static void Hidden()
        {
            if (SpotLightType == SpotlightTypeEnum.FilterFormat)
            {
                // 设置条件格式
                RemoveCondition();
            }
            else
            {
                Common.App.SheetSelectionChange -= App_SheetSelectionChange;
                FocusForm.Hidden();
            }
            _propIsVisible = false;
        }

        /// <summary>
        /// 获取条件格式设置区域
        /// </summary>
        private static MSExcel.Range ConditionRange
        {
            get
            {
                Int32 firRow = Common.ActiveSheet.UsedRange.Row;
                Int32 firColumn = Common.ActiveSheet.UsedRange.Column;
                Int32 rowCount = Common.ActiveSheet.UsedRange.Rows.Count;
                Int32 columnCount = Common.ActiveSheet.UsedRange.Columns.Count;
                return Common.ActiveSheet.Range[Common.ActiveSheet.Cells[firRow, firColumn], Common.ActiveSheet.Cells[firRow + rowCount, firColumn + columnCount]];
            }
        }


        private static void RemoveCondition()
        {
            if (ConditionRange.FormatConditions != null && ConditionRange.FormatConditions.Count > 0)
            {
                try
                {
                    for (Int32 i = 0; i < ConditionRange.FormatConditions.Count; i++)
                    {
                        if (i < 0 || i >= ConditionRange.FormatConditions.Count)
                        {
                            break;
                        }

                        MSExcel.FormatCondition c = ConditionRange.FormatConditions[i + 1] as MSExcel.FormatCondition;
                        if (c != null && c.Formula1.Contains(ConditionRangeName))
                        {
                            c.Delete();
                            i -= 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Msg.ShowError("聚光灯清除条件格式发生异常：" + ex.Message, ex);
                }
            }
        }

        public static void Reset()
        {
            if (_propIsVisible)
            {
                Show();
            }

        }

        /// <summary>
        /// 聚光灯模式
        /// </summary>
        public enum SpotlightTypeEnum
        {
            FilterFormat,
            Form
        }



    }
}
