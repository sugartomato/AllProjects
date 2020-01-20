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
        private Controls.ExecuteProgress m_ProgressWindow = null;
        public delegate object GenerateCellValueDelegate(Microsoft.Office.Interop.Excel.Range currentCell);
        // 遍历单元格处理委托
        public delegate void OperateCellDelegate(Microsoft.Office.Interop.Excel.Range currentCell, Object options = null);

        /// <summary>
        /// 后台处理进程
        /// </summary>
        public System.ComponentModel.BackgroundWorker m_BackWorker_WriteCell = null;

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("ZSExcelAddIn.Ribbon.RibMyTools.xml");
        }
		#endregion

		#region 初始化
		public RibMyTools()
		{
			m_BackWorker_WriteCell = new BackgroundWorker();
			m_BackWorker_WriteCell.WorkerReportsProgress = true;
			m_BackWorker_WriteCell.WorkerSupportsCancellation = true;
			m_BackWorker_WriteCell.DoWork += new DoWorkEventHandler(BackWorkerWriteCell_DoWork);
			m_BackWorker_WriteCell.ProgressChanged += new ProgressChangedEventHandler(BackWorkerWriteCell_ProgressChanged);
			m_BackWorker_WriteCell.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackWorkerWriteCell_WorkComplete);

		}

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

		public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;

			// 注册事件
			Globals.ThisAddIn.Application.WorkbookActivate += Application_WorkbookActivate;
		}

		#endregion

		#region 主任务窗格

		/// <summary>
		/// 主任务窗格显示按钮回调事件
		/// </summary>
		/// <param name="ctrl"></param>
		/// <param name="pressed"></param>
		public void OnCLick_ShowMainPan(Office.IRibbonControl ctrl, Boolean pressed)
		{
			Microsoft.Office.Tools.CustomTaskPane pan = null;
			string key = string.Format("{0}({1})", "RuntimeInfo", Globals.ThisAddIn.Application.Hwnd);
			// 获取对应的任务窗格
			if (Config.TaskPans.ContainsKey(key))
			{
				// 设置任务窗格显示状态
				pan = Config.TaskPans[key];
				pan.Visible = pressed;
			}
            
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

        #region 聚光灯

        /// <summary>
        /// 主任务窗格显示按钮回调事件
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="pressed"></param>
        public void OnCLick_ShowFocus(Office.IRibbonControl ctrl, Boolean pressed)
        {
            Spotlight.IsVisible = pressed;
            Spotlight.Reset();
            if (!pressed)
            {
                Spotlight.Hidden();
            }
        }

        // TODO 下面注释的实现方式在打开新的工作簿之后就失效了。
        // //获取togglebutton的状态。希望打开工作簿之后调试信息窗口默认打开的，让默认选中，并且执行一下显示调试信息窗口的方法。
        public bool OnClick_GetPressed_ShowFocus(Office.IRibbonControl ctrl)
        {
            return Spotlight.IsVisible;
        }
        #endregion

        #region 固定文件列表

        public void OnClick_PinnedFiles(Office.IRibbonControl ctrl)
        {
            List<Model.PinnedFile> files = Config.PinnedFiles;
            if (files == null)
            {
                files = new List<Model.PinnedFile>();
            }

            // 检查是否已经存在
            foreach (var f in files)
            {
                if (f.FilePath == Common.ActiveBook?.FullName)
                {
                    return;
                }
            }

            // 添加到固定列表
            Model.PinnedFile tmpFile = new Model.PinnedFile();
            tmpFile.FilePath = Common.ActiveBook?.FullName;
            tmpFile.FileName = Common.ActiveBook?.Name;
            tmpFile.Mark = System.Guid.NewGuid().ToString("N").ToUpper();
            files.Add(tmpFile);

            Config.PinnedFiles = files;
            Config.SaveConfig();
            ribbon.InvalidateControl("ZS_LIST_PinnedFiles");
            Msg.ShowSuccess("添加完成！");
        }

        public void OnClick_OpenPinnedFiles(Office.IRibbonControl ctrl, String selectedID, Int32 selectedIndex)
        {
            List<Model.PinnedFile> files = Config.PinnedFiles;
            if (files == null || files.Count == 0)
            {
                return;
            }
            //Common.App.Workbooks.Open(files.FirstOrDefault(x => x.Mark == selectedID)?.FilePath);
            Common.App.Workbooks.Open(files[selectedIndex]?.FilePath);
        }

        public Int32 PinnedFiles_GetCount(Office.IRibbonControl ctrl)
        {
            List<Model.PinnedFile> files = Config.PinnedFiles;
            if (files == null)
            {
                return 0;
            }
            return files.Count;
        }

        public String PinnedFiles_GetLabel(Office.IRibbonControl ctrl, Int32 index)
        {
            List<Model.PinnedFile> files = Config.PinnedFiles;
            if (files == null)
            {
                return String.Empty;
            }
            return String.Format("【{0}】|{1}",files[index].FileName, files[index].FilePath);
        }

        public String PinnedFiles_GetItemID(Office.IRibbonControl ctrl, Int32 index)
        {
            List<Model.PinnedFile> files = Config.PinnedFiles;
            if (files == null)
            {
                return String.Empty;
            }
            return files[index].Mark;
        }

        #endregion

        #region 工作簿工作表事件

        private void Application_WorkbookActivate(Excel.Workbook Wb)
		{
			WriteConsole("Ribbon事件：Application_WorkbookActivate,工作簿：" + Wb.Name);
		}

		#endregion

		#region 工作表工作簿操作

		public void OnClick_BookAndSheetOperate(Office.IRibbonControl ctrl)
        {
            switch (ctrl.Id)
            {
                case "ZS_BTN_ExportSheetsToFile":
                    this.WriteConsole("准备导出工作表");
                    try
                    {
                        this.WriteConsole("工作簿【" + Globals.ThisAddIn.Application.ActiveWorkbook.Name + "】的文件格式为：" + Globals.ThisAddIn.Application.ActiveWorkbook.FileFormat.ToString());
                        Controls.ExportSheetsToSingleFile f = new Controls.ExportSheetsToSingleFile();
                        f.ShowInTaskbar = false;
                        f.Topmost = true;
                        f.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        this.WriteConsole(ex.Message + ex.StackTrace);
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
                case "ZS_BTN_SaveCurrentSheet": // 导出当前工作表为单文件
                    try
                    {
                        // 弹出保存窗口
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.InitialDirectory = _CurrentDirectory;
                        sfd.Title = "另存工作表";
                        sfd.Filter = "Excel文件|*.xlsx";
                        sfd.FileName = _ActiveSheet.Name + ".xlsx";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            Excel.Worksheet sourceSheet = _ActiveSheet;
                            // 执行保存
                            // 创建新的工作簿
                            Excel.Workbook tmpBook = Globals.ThisAddIn.Application.Workbooks.Add();

                            // 复制工作表
                            Excel.Worksheet tmpSheet = (Excel.Worksheet)tmpBook.Worksheets[1];
                            sourceSheet.Copy(Before:tmpSheet);
                            tmpBook.SaveAs(Filename: sfd.FileName,
                                FileFormat: Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook,
                                AccessMode: Excel.XlSaveAsAccessMode.xlNoChange);
                            tmpBook.Close(false);
                            Msg.ShowSuccess("另存完成。\r\n" + sfd.FileName);
                        }

                    }
                    catch (Exception ex)
                    {
                        this.WriteConsole(ex.Message + ex.StackTrace);
                        Msg.ShowError("当前工作表导出异常：" + ex.Message + "，详细查看输出信息！");
                    }
                    break;
                default:
                    break;
            }
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

        #region 文本处理

        public void OnClick_Text(Office.IRibbonControl ctrl)
        {
            switch (ctrl.Id)
            {
                case "ZS_BTN_MergeCellText":
                    Controls.frmMergeCellText frm = new Controls.frmMergeCellText();
                    frm.Show();
                    break;
                case "ZS_BTN_SeparateCellText":
                    Controls.frmSeparateCellText frm1 = new Controls.frmSeparateCellText();
                    frm1.Show();
                    break;
                default:
                    ShowError("没有定义的处理分支！");
                    break;
            }
        }


        #endregion

        #region 单元格内容批量处理


        private void BackWorkerWriteCell_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            GenerateCellValueDelegate GetValue = e.Argument as GenerateCellValueDelegate;
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

        public void WriteCellsAsync(GenerateCellValueDelegate GetValue)
        {
            m_ProgressWindow = new Controls.ExecuteProgress();
            m_ProgressWindow.AutoCloseAfterComplete = true;

            m_BackWorker_WriteCell.RunWorkerAsync(GetValue);
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
        public void OperateCells(OperateCellDelegate fun, Object options = null)
        {
            if (fun == null)
            {
                WriteConsole("“OperateCells”未设置委托方法。");
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
					fun(c, options);
                }
            }
        }

        #endregion

        #region 内容格式化

        //private string _macSeparator = "-";
        /// <summary>
        /// 单元格内容格式化
        /// </summary>
        /// <param name="ctrl"></param>
        public void OnClick_FormatCellTo(Office.IRibbonControl ctrl)
        {
			try
			{
				if (ctrl == null || ctrl.Id == "") return;

				switch (ctrl.Id)
				{
					case "ZS_BTN_Format_MAC_A":
					case "ZS_BTN_Format_MAC_B":
					case "ZS_BTN_Format_MAC_C":
						//_macSeparator = ctrl.Tag.ToString();
						//if (_macSeparator == "none") _macSeparator = "";
						String macSeparator = ctrl.Tag.ToString();
						if (macSeparator == "none") macSeparator = "";
						OperateCells(FormatCellToMAC, ctrl.Tag.ToString());
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
			catch (Exception ex)
			{
				MessageBox.Show("执行错误" + ex.Message);
				WriteConsole(ex.Message + ex.StackTrace);
			}

        }

        /// <summary>
        /// 将单元格格式化为MAC
        /// </summary>
        /// <param name="rng"></param>
		/// <param name="options">参数类型为String，MAC地址分隔符</param>
        private void FormatCellToMAC(Microsoft.Office.Interop.Excel.Range rng, Object options)
        {
			String separator = options != null ? options as String : "-";
            if (rng == null)
            {
                WriteConsole("[Range]参数为null在FormatCellToMAC方法");
                return;
            }

			if (rng.Value == null || Convert.ToString(rng.Value) == "")
			{
				WriteConsole(rng.Address + "值为空，跳过[格式化MAC]处理。");
			}

            string val = Convert.ToString(rng.Value);
            if (val.IsMacAddress())
            {
                // 是MAC地址，按格式处理
                val = val.Replace(":", "").Replace("-", "");

                val = System.Text.RegularExpressions.Regex.Replace(val, @"([\da-fA-F]{2})", "$1" + separator).Trim(separator != ""? separator[0]:'-');

                rng.Value = val;

                FormatCellToNormalState(rng);
            }
            else
            {
                // 不是mac地址，进行格式标记
                FormatCellToFormatFaild(rng);
            }

        }

        private void FormatCellToUpper(Microsoft.Office.Interop.Excel.Range rng, Object options = null)
        {
            if (rng == null)
            {
                WriteConsole("[Range]参数为null在[FormatCellToUpper]方法");
                return;
            }

            if (rng.Value == null || Convert.ToString(rng.Value) == "") return;
            string val = Convert.ToString(rng.Value);
            val = val.ToUpper();
            rng.Value = val;
        }
        private void FormatCellToLower(Microsoft.Office.Interop.Excel.Range rng, Object options = null)
        {
            if (rng == null)
            {
                WriteConsole("[Range]参数为null在[FormatCellToLower]方法");
                return;
            }
           

            if (rng.Value == null || Convert.ToString(rng.Value) == "") return;
            string val = Convert.ToString(rng.Value);
            val = val.ToLower();
            rng.Value = val;
        }
        private void FormatCellToFirstUpper(Microsoft.Office.Interop.Excel.Range rng, Object options = null)
        {
            if (rng == null)
            {
                WriteConsole("[Range]参数为null在[FormatCellToFirstUpper]方法");
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

        #region 设置

        public void OnClick_Setting(Office.IRibbonControl ctrl)
        {
            Controls.Setting.Setting frm = new Controls.Setting.Setting();
            frm.ShowDialog();
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

        public Excel.Application _App
        {
            get
            {
                return Globals.ThisAddIn.Application;
            }
        }

        /// <summary>
        /// 获取当前活动工作簿所在的目录。如果工作簿的目录不存在，则返回桌面路径。
        /// </summary>
        public String _CurrentDirectory
        {
            get
            {
                String result = String.Empty;
                result = System.IO.Path.GetDirectoryName(_ActiveBook.FullName);
                if (!System.IO.Directory.Exists(result)) return Config.LastSelectDir;
                return result;
            }
        }

		// 向当前窗口的调试信息界面写入信息
		private void WriteConsole(string text)
		{
			Common.WriteConsole(text);
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

