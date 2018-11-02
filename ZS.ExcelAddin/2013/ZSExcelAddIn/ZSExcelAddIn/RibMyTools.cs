using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using ZS.Common;
using Excel = Microsoft.Office.Interop.Excel;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new RibMyTools();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace ZSExcelAddIn
{
    [ComVisible(true)]
    public partial  class RibMyTools : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        // 调试信息显示用户控件
        private Controls.CustomPans.MainPanHost m_RuntimeInfoConsole = null;
        private Controls.ExecuteProgress m_ProgressWindow = null;
        public delegate object GenerateCellValue(Microsoft.Office.Interop.Excel.Range currentCell);
        // 遍历单元格处理委托
        public delegate void OperateCell(Microsoft.Office.Interop.Excel.Range currentCell);
        public System.ComponentModel.BackgroundWorker m_BackWorkerWriteCell = null;


        public RibMyTools()
        {
            m_BackWorkerWriteCell = new BackgroundWorker();
            m_BackWorkerWriteCell.WorkerReportsProgress = true;
            m_BackWorkerWriteCell.WorkerSupportsCancellation = true;
            m_BackWorkerWriteCell.DoWork += new DoWorkEventHandler(BackWorkerWriteCell_DoWork);
            m_BackWorkerWriteCell.ProgressChanged += new ProgressChangedEventHandler(BackWorkerWriteCell_ProgressChanged);
            m_BackWorkerWriteCell.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackWorkerWriteCell_WorkComplete);

       }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("ZSExcelAddIn.RibMyTools.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit http://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;

        }




        public void CheckBox_HightLightRowColumn(Office.IRibbonControl ctrl, bool Pressed)
        {
            Config.HightLightRowAndColumn = Pressed;
        }

        /// <summary>
        /// 设置行高亮的颜色
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="selectedID"></param>
        /// <param name="selectedIndex"></param>
        public void Gallery_SetHightLightColor(Office.IRibbonControl ctrl, string selectedID, Int32 selectedIndex)
        {
            Config.HightLightRowColumnColor = selectedIndex;
        }

        #endregion

        #region 插入 - 日期时间

        public void OnClick_InsertDateTime(Office.IRibbonControl ctrl)
        {
            switch (ctrl.Id)
            {
                case "ZS_BTN_InsertDate":
                case "ZS_ContextMenuCell_InsertDate":
                case "ZS_ContextMenuListRange_InsertDate":
                    WriteCells(DateTime.Now.ToString("yyyy-MM-dd"));
                    //Globals.ThisAddIn.Application.OnUndo("撤销 插入GUID", "UndoEE");
                    break;
                case "ZS_BTN_InsertTime":
                case "ZS_ContextMenuCell_InsertTime":
                case "ZS_ContextMenuListRange_InsertTime":
                    WriteCells(DateTime.Now.ToString("HH:mm:ss"));
                    break;
                case "ZS_BTN_InsertDateTime":
                    WriteCells(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                case "ZS_BTN_Calendar":
                    Controls.DateTimePicker dtp = new Controls.DateTimePicker();
                    if (dtp.ShowDialog() == DialogResult.OK)
                    {
                        WriteCells(dtp.Date);
                    }

                    //Globals.ThisAddIn.Application.InputBox("", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,Type.Missing);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 工作表工作簿操作


        public void OnClick_BookAndSheetOperate(Office.IRibbonControl ctrl)
        {
            switch (ctrl.Id)
            {
                case "ZS_BTN_ExportSheetsToFile":
                    this.WriteRuntimeInfo("准备导出工作表");
                    try
                    {
                        this.WriteRuntimeInfo("工作簿【" + Globals.ThisAddIn.Application.ActiveWorkbook.Name + "】的文件格式为：" + Globals.ThisAddIn.Application.ActiveWorkbook.FileFormat.ToString());
                        Controls.ExportSheetsToSingleFile f = new Controls.ExportSheetsToSingleFile();
                        f.RuntimeInfoControl = m_RuntimeInfoConsole;
                        f.ShowInTaskbar = false;
                        f.Topmost = true;
                        f.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        this.WriteRuntimeInfo(ex.Message + ex.StackTrace);
                    }
                    break;

                case "ZS_BTN_MergeSheets":
                    try
                    {
                        Controls.MergeSheets f = new Controls.MergeSheets();
                        f.ShowDialog();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;
                case "ZS_BTN_SortSheet":
                    try
                    {
                        Controls.SortWorkSheets f = new Controls.SortWorkSheets();
                        f.ShowDialog();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;
                default:
                    break;
            }
        }


        #endregion

        #region 显示设置

        // 向当前窗口的调试信息界面写入信息
        private void WriteRuntimeInfo(string text)
        {
            if (m_RuntimeInfoConsole != null) m_RuntimeInfoConsole.AppendText(text);
        }

        #endregion  

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion

        #region 主任务窗口

        // 显示调试信息界面按钮点击事件。
        public void OnCLick_ShowMainPan(Office.IRibbonControl ctrl, bool pressed)
        {
            m_RuntimeInfoConsole = new Controls.CustomPans.MainPanHost();
            Microsoft.Office.Tools.CustomTaskPane pan = null;
            string key = string.Format("{0}({1})", "RuntimeInfo", Globals.ThisAddIn.Application.Hwnd);
            if (!Config.TaskPans.ContainsKey(key))
            {
                pan = Globals.ThisAddIn.CustomTaskPanes.Add(m_RuntimeInfoConsole, "辅助面板[" + Globals.ThisAddIn.Application.Hwnd.ToString() + "]");
                pan.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
                pan.DockPositionRestrict = Microsoft.Office.Core.MsoCTPDockPositionRestrict.msoCTPDockPositionRestrictNoChange;
                pan.VisibleChanged += TaskPan_VisibleChanged;
                Config.TaskPans[key] = pan;
            }
            else
            {
                pan = Config.TaskPans[key];
            }
            pan.Visible = pressed;


        }

        private void TaskPan_VisibleChanged(object sender, EventArgs e)
        {
            ribbon.InvalidateControl("ZS_Toggle_ShowMainPan");
        }

        // TODO 下面注释的实现方式在打开新的工作簿之后就失效了。
        // //获取togglebutton的状态。希望打开工作簿之后调试信息窗口默认打开的，让默认选中，并且执行一下显示调试信息窗口的方法。
        public bool OnClick_GetPressed_ShowMainPan(Office.IRibbonControl ctrl)
        {
            string key = string.Format("{0}({1})", "RuntimeInfo", Globals.ThisAddIn.Application.Hwnd);
            if (!Config.TaskPans.ContainsKey(key))
            {
                return false;
            }
            return Config.TaskPans[key].Visible;
        }

        #endregion

        #region 插入 - GUID


        private Boolean _GUIDToUpper = false;

        public void OnCheckChanged_GUIDCase(Office.IRibbonControl ctrl, bool isPressed)
        {
            _GUIDToUpper = isPressed;
        }

        public void OnClick_InsertGUID(Office.IRibbonControl ctrl)
        {
            if (ctrl != null)
            {
                WriteCellsAsync(GetGUID);


                //// 获取选择的区域
                //Microsoft.Office.Interop.Excel.Worksheet sheet = Globals.ThisAddIn.Application.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                //Microsoft.Office.Interop.Excel.Range selRang =  Globals.ThisAddIn.Application.Selection as Microsoft.Office.Interop.Excel.Range;

                //if (selRang != null && selRang.Cells.Count > 0)
                //{
                //    foreach (Microsoft.Office.Interop.Excel.Range c in selRang.Cells)
                //    {
                //        string guid = System.Guid.NewGuid().ToString(ctrl.Tag.ToString());
                //        if (_GUIDToUpper) guid = guid.ToUpper();
                //        c.Value = guid;
                //    }
                //    Console.WriteLine(selRang.ToString());
                //}

                //Globals.ThisAddIn.Application.ActiveCell.Value = guid;

            }
        }

        public void UndoEE()
        {
            MessageBox.Show("1");
        }
		public string GetGUID(Microsoft.Office.Interop.Excel.Range currentCell)
		{
			string guid = System.Guid.NewGuid().ToString("N");
			if (_GUIDToUpper) guid = guid.ToUpper();
			return guid;
		}

		#endregion

		#region 插入 - 前缀后缀

		/// <summary>
		/// 插入前缀后缀点击事件
		/// </summary>
		/// <param name="ctrl"></param>
		public void OnClick_InsertPreSuffix(Office.IRibbonControl ctrl)
        {
            try
            {
                Controls.PreSuffixInsert frm = new Controls.PreSuffixInsert();

                frm.Address = GetActiveRangeAddress();
                frm.Show();

            }
            catch (Exception ex)
             {
                MessageBox.Show("处理失败：" + ex.JoinWithInnerExMessage());
            }
        }

        #endregion

        #region 单元格内容批量处理


        private void BackWorkerWriteCell_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            GenerateCellValue GetValue = e.Argument as GenerateCellValue;
            Microsoft.Office.Interop.Excel.Range selRang = Globals.ThisAddIn.Application.Selection as Microsoft.Office.Interop.Excel.Range;

            Int32 cellTotal = 0;
            if (selRang != null && selRang.Cells.Count > 0)
            {
                cellTotal = selRang.Cells.Count;
                for (Int32 i = 1; i <= cellTotal; i++)
                {
                    // 主要任务处理
                    Microsoft.Office.Interop.Excel.Range c = (Microsoft.Office.Interop.Excel.Range)selRang.Cells[i];
                    c.Value = GetValue(c).ToString();

                    // 提交处理进度
                    Int32 p = (Int32)(((Double)(i + 1) / cellTotal) * 100);
                    worker.ReportProgress(p);
                }
            }

        }
        private void BackWorkerWriteCell_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            m_ProgressWindow.Percentage = e.ProgressPercentage;
        }

        private void BackWorkerWriteCell_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            // 卸载进度窗体
        }

        public void WriteCellsAsync(GenerateCellValue GetValue)
        {
            m_ProgressWindow = new Controls.ExecuteProgress();
            m_ProgressWindow.AutoCloseAfterComplete = true;

            m_BackWorkerWriteCell.RunWorkerAsync(GetValue);
            m_ProgressWindow.Show();

        }

        /// <summary>
        /// 向选中的单元格批量写入具体的值
        /// </summary>
        /// <param name="val"></param>
        public void WriteCells(object val)
        {
            if (val == null) return;
            Microsoft.Office.Interop.Excel.Range selRang = Globals.ThisAddIn.Application.Selection as Microsoft.Office.Interop.Excel.Range;

            Int32 cellTotal = 0;
            if (selRang != null && selRang.Cells.Count > 0)
            {
                cellTotal = selRang.Cells.Count;
                for (Int32 i = 1; i <= cellTotal; i++)
                {
                    // 主要任务处理
                    Microsoft.Office.Interop.Excel.Range c = (Microsoft.Office.Interop.Excel.Range)selRang.Cells[i];
                    c.Value = val;
                }
            }

        }

        /// <summary>
        /// 用指定的方法批量处理单元格
        /// </summary>
        /// <param name="fun"></param>
        public void OperateCells(OperateCell fun)
        {
            if (fun == null)
            {
                WriteRuntimeInfo("“OperateCells”未设置委托方法。");
                return;
            }

            Microsoft.Office.Interop.Excel.Range selRang = Globals.ThisAddIn.Application.Selection as Microsoft.Office.Interop.Excel.Range;

            Int32 cellTotal = 0;
            if (selRang != null && selRang.Cells.Count > 0)
            {
                cellTotal = selRang.Cells.Count;
                for (Int32 i = 1; i <= cellTotal; i++)
                {
                    // 主要任务处理
                    Microsoft.Office.Interop.Excel.Range c = (Microsoft.Office.Interop.Excel.Range)selRang.Cells[i];
                    fun(c);
                }
            }
        }

        #endregion

        #region 内容格式化

        private string _macSeparator = "-";
        /// <summary>
        /// 单元格内容格式化
        /// </summary>
        /// <param name="ctrl"></param>
        public void OnClick_FormatCellTo(Office.IRibbonControl ctrl)
        {
            if (ctrl == null || ctrl.Id == "") return;

            switch (ctrl.Id)
            {
                case "ZS_BTN_Format_MAC_A":
                case "ZS_BTN_Format_MAC_B":
                case "ZS_BTN_Format_MAC_C":
                    _macSeparator = ctrl.Tag.ToString();
                    if (_macSeparator == "none") _macSeparator = "";
                    OperateCells(FormatCellToMAC);
                    break;

                case "ZS_BTN_ConvertToUpperCase":
                case "ZS_BTN_ConvertToLowerCase":
                case "ZS_BTN_ConvertToFirstCaseUpper":
                    string toType = ctrl.Tag.ToString();
                    if (toType == "upper")
                    {
                        OperateCells(FormatCellToUpper);
                    }
                    else if (toType == "lower")
                    {
                        OperateCells(FormatCellToLower);
                    }
                    else if (toType == "first")
                    {
                        OperateCells(FormatCellToFirstUpper);
                    }
                    break;

            }
        }

        /// <summary>
        /// 将单元格格式化为MAC
        /// </summary>
        /// <param name="rng"></param>
        private void FormatCellToMAC(Microsoft.Office.Interop.Excel.Range rng)
        {
            if (rng == null)
            {
                WriteRuntimeInfo("[Range]参数为null在FormatCellToMAC方法");
                return;
            }

            if (rng.Value == null || Convert.ToString(rng.Value) == "") return;

            string val = Convert.ToString(rng.Value);
            if (val.IsMacAddress())
            {
                // 是MAC地址，按格式处理
                val = val.Replace(":", "").Replace("-", "");

                val = System.Text.RegularExpressions.Regex.Replace(val, @"([\da-fA-F]{2})", "$1" + _macSeparator).Trim(_macSeparator!= ""?_macSeparator[0]:'=');

                rng.Value = val;

                FormatCellToNormalState(rng);
            }
            else
            {
                // 不是mac地址，进行格式标记
                FormatCellToFormatFaild(rng);
            }



        }

        private void FormatCellToUpper(Microsoft.Office.Interop.Excel.Range rng)
        {
            if (rng == null)
            {
                WriteRuntimeInfo("[Range]参数为null在[FormatCellToUpper]方法");
                return;
            }

            if (rng.Value == null || Convert.ToString(rng.Value) == "") return;
            string val = Convert.ToString(rng.Value);
            val = val.ToUpper();
            rng.Value = val;
        }
        private void FormatCellToLower(Microsoft.Office.Interop.Excel.Range rng)
        {
            if (rng == null)
            {
                WriteRuntimeInfo("[Range]参数为null在[FormatCellToLower]方法");
                return;
            }
           

            if (rng.Value == null || Convert.ToString(rng.Value) == "") return;
            string val = Convert.ToString(rng.Value);
            val = val.ToLower();
            rng.Value = val;
        }
        private void FormatCellToFirstUpper(Microsoft.Office.Interop.Excel.Range rng)
        {
            if (rng == null)
            {
                WriteRuntimeInfo("[Range]参数为null在[FormatCellToFirstUpper]方法");
                return;
            }

            if (rng.Value == null || Convert.ToString(rng.Value) == "") return;
            string val = Convert.ToString(rng.Value);
            val = val.Substring(0, 1).ToUpper() + val.Substring(1);
            rng.Value = val;
        }

        /// <summary>
        /// 将单元格格式化为处理失败的状态
        /// </summary>
        /// <param name="rng"></param>
        private void FormatCellToFormatFaild(Microsoft.Office.Interop.Excel.Range rng)
        {
            rng.Font.Bold = true;
            //rng.Font.ColorIndex = 10;
            rng.Interior.ColorIndex = 3;
        }

        /// <summary>
        /// 将单元格格式化为正常状态
        /// </summary>
        /// <param name="rng"></param>
        private void FormatCellToNormalState(Microsoft.Office.Interop.Excel.Range rng)
        {
            rng.Font.Bold = false;
            rng.Interior.ColorIndex = 0;
        }


		#endregion

		#region 快捷方式

		/// <summary>
		/// 启动系统工具
		/// </summary>
		/// <param name="ctrl"></param>
		public void OnClick_Shortcut(Office.IRibbonControl ctrl)
		{
			switch (ctrl.Id)
			{
				case "ZS_BTN_Start_Calculator":
					StartProcess("calc");
					break;
				case "ZS_BTN_Start_Notepad":
					StartProcess("notepad");
					break;
				default:
					break;
			}
		}

		private void StartProcess(String processName)
		{
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.FileName = processName;
			startInfo.UseShellExecute = true;
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
			System.Diagnostics.Process.Start(startInfo);
		}

		#endregion

		#region 公共方法

		/// <summary>
		/// 控件图标获取回调
		/// </summary>
		/// <param name="ctrl"></param>
		/// <returns></returns>
		public System.Drawing.Bitmap Get_ControlImage(Office.IRibbonControl ctrl)
        {
            switch (ctrl.Id)
            {
                // 插入日期时间部分按钮
                case "ZS_BTN_InsertDate":
                case "ZS_ContextMenuCell_InsertDate":
                case "ZS_ContextMenuListRange_InsertDate":
                    return new System.Drawing.Bitmap(Properties.Resources.Today_32x32);
                case "ZS_BTN_InsertTime":
                case "ZS_ContextMenuCell_InsertTime":
                case "ZS_ContextMenuListRange_InsertTime":
                    return new System.Drawing.Bitmap(Properties.Resources.Time_32x32);
                case "ZS_BTN_InsertDateTime":
                    return new System.Drawing.Bitmap(Properties.Resources.Calendar_32x32);
                case "ZS_BTN_Calendar":
                    return new System.Drawing.Bitmap(Properties.Resources.SwitchTimeScalesTo_32x32);

                // 显示设置
                case "ZS_Toggle_ShowMainPan":
                    return new System.Drawing.Bitmap(Properties.Resources.Show_32x32);

                // 工作表工作簿操作部分按钮
                case "ZS_BTN_ExportSheetsToFile":  // 导出工作表为单文件
                    return new System.Drawing.Bitmap(Properties.Resources.Export_32x32);
                case "ZS_BTN_MergeSheets":
                    return new System.Drawing.Bitmap(Properties.Resources.AddNewDataSource_32x32);
                case "ZS_BTN_SortSheet":
                    return new System.Drawing.Bitmap(Properties.Resources.SortAsc_32x32);
				case "ZS_BTN_Start_Calculator":
					return Properties.Resources.Calculator.ToBitmap();

				default:
                    return new System.Drawing.Bitmap(Properties.Resources.settings_32);
            }
        }


        /// <summary>
        /// 获取当前活动单元格区域的地址
        /// </summary>
        /// <returns></returns>
        public string GetActiveRangeAddress()
        {
            Excel.Range rng = Globals.ThisAddIn.Application.Selection as Excel.Range;
            return rng.Address;
        }

        private Excel.Workbook _ActiveBook
        {
            get
            {
                if (Globals.ThisAddIn.Application == null || Globals.ThisAddIn.Application.ActiveWorkbook == null) return null;
                return (Excel.Workbook)Globals.ThisAddIn.Application.ActiveWorkbook;
            }
        }

        private Excel.Worksheet _ActiveSheet
        {
            get
            {
                if (Globals.ThisAddIn.Application == null || Globals.ThisAddIn.Application.ActiveWorkbook == null) return null;
                return (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
            }
        }


        private void ShowError(String msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfo(String msg)
        {
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		#endregion

	}



}

