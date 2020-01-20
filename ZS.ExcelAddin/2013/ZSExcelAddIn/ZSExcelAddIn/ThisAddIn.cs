using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;

namespace ZSExcelAddIn
{
	public partial class ThisAddIn
	{

        //public Controls.RuntimeInfoHost RuntimeDebugInfo = null;
        //public Microsoft.Office.Tools.CustomTaskPane TaskPanRuntimeDebugInfo = null;

        #region 初始化


        protected override Office.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            RibMyTools rb = new RibMyTools();
            Common.MainRibbon = rb;
            return rb;
        }

        protected override void OnStartup()
        {
            base.OnStartup();
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.WorkbookActivate += Application_WorkbookActivate;
            this.Application.WorkbookDeactivate += Application_WorkbookDeactivate;
            this.Application.WorkbookOpen += Application_WorkbookOpen;

            this.Application.WindowDeactivate += Application_WindowDeactivate;
            this.Application.WindowResize += Application_WindowResize;

            ((Excel.AppEvents_Event)Globals.ThisAddIn.Application).NewWorkbook += ThisAddIn_NewWorkbook;
            ((Excel.AppEvents_Event)Globals.ThisAddIn.Application).SheetSelectionChange += ThisAddIn_SheetSelectionChange;

            //((Excel.AppEvents_Event)Globals.ThisAddIn.Application).WindowResize += ThisAddIn_WindowResize;
            //((Excel.AppEvents_Event)Globals.ThisAddIn.Application).WorkbookBeforeClose += ThisAddIn_WorkbookBeforeClose;
            //((Excel.AppEvents_Event)Globals.ThisAddIn.Application).WindowDeactivate += ThisAddIn_WindowDeactivate;
            //((Excel.AppEvents_Event)Globals.ThisAddIn.Application).WindowActivate += ThisAddIn_WindowActivate;
        }

        private void Application_WindowResize(Excel.Workbook Wb, Excel.Window Wn)
        {
            throw new NotImplementedException();
        }

        private void Application_WindowDeactivate(Excel.Workbook Wb, Excel.Window Wn)
        {
            Spotlight.Hidden();
        }

        #endregion


        #region Excel事件处理

        private void ThisAddIn_WindowActivate(Excel.Workbook Wb, Excel.Window Wn)
        {
            Common.WriteConsole(String.Format("触发事件：{0},time:{1},对象：{2}", nameof(ThisAddIn_WindowActivate), DateTime.Now.ToString("HH:mm:ss fff"), Wb.Name));
        }
        private void ThisAddIn_WindowDeactivate(Excel.Workbook Wb, Excel.Window Wn)
        {
            Common.WriteConsole(String.Format("触发事件：{0},time:{1},对象：{2}", nameof(ThisAddIn_WindowDeactivate), DateTime.Now.ToString("HH:mm:ss fff"), Wb.Name));
        }
        private void ThisAddIn_WindowResize(Excel.Workbook Wb, Excel.Window Wn)
        {
        }

        private void ThisAddIn_NewWorkbook(Excel.Workbook Wb)
        {
            Common.WriteConsole(String.Format("触发事件：{0},time:{1},对象：{2}", nameof(ThisAddIn_NewWorkbook), DateTime.Now.ToString("HH:mm:ss fff"), Wb.Name));
            InitMainTaskPan();
        }
        private void Application_WorkbookOpen(Excel.Workbook Wb)
        {
            Common.WriteConsole(String.Format("触发事件：{0},time:{1},对象：{2}", nameof(Application_WorkbookOpen), DateTime.Now.ToString("HH:mm:ss fff"), Wb.Name));
            //RuntimeDebugInfo.AppendText("工作表打开！");
            InitMainTaskPan();

        }
        private void Application_WorkbookActivate(Excel.Workbook Wb)
        {
            Common.WriteConsole("Addin事件：Application_WorkbookActivate,工作簿：" + Wb.FullName);
            try
            {
                if (this.Application.ActiveWorkbook != null)
                {
                    string caption = Convert.ToString(Application.ActiveWindow.Caption);
                    if (caption != null && !caption.StartsWith("★") && !caption.EndsWith("★"))
                    {
                        Application.ActiveWindow.Caption = string.Format("★ {0} ★ [{1}]★", Application.ActiveWindow.Caption, Application.ActiveWorkbook.Path);
                    }
                    //RuntimeDebugInfo.AppendText("当前工作簿:" + this.Application.ActiveWorkbook.FullName);
                }
                Spotlight.Reset();
            }
            catch (Exception ex)
            {
                Common.WriteConsole("工作簿激活事件执行异常：" + Wb.FullName + ex.Message + ex.StackTrace);
            }

        }

        private void Application_WorkbookDeactivate(Excel.Workbook Wb)
        {
            Common.WriteConsole("Addin事件：Application_WorkbookDeactivate,工作簿：" + Wb.FullName);
            Spotlight.Hidden();
        }

        private void ThisAddIn_WorkbookBeforeClose(Excel.Workbook Wb, ref bool Cancel)
        {

        }


        private void ThisAddIn_SheetSelectionChange(object Sh, Excel.Range Target)
        {
            
        }






        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // 保存配置文件
            Config.SaveConfig();
            this.Application.WorkbookActivate -= Application_WorkbookActivate;
        }




		#endregion

		#region 任务窗格设置

		#region 主任务窗口

		private Controls.CustomPans.MainPanHost m_MainTaskPan = null;
		private void InitMainTaskPan()
		{
			Microsoft.Office.Tools.CustomTaskPane pan = null;
			string key = string.Format("{0}({1})", "RuntimeInfo", Globals.ThisAddIn.Application.ActiveWindow.Hwnd);
			if (!Config.TaskPans.ContainsKey(key))
			{
				m_MainTaskPan = new Controls.CustomPans.MainPanHost();
                m_MainTaskPan.BindWorkbook = Common.ActiveBook;
				pan = Globals.ThisAddIn.CustomTaskPanes.Add(m_MainTaskPan, "辅助面板[" + Globals.ThisAddIn.Application.ActiveWindow.Hwnd.ToString() + "]");
				pan.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
				pan.DockPositionRestrict = Microsoft.Office.Core.MsoCTPDockPositionRestrict.msoCTPDockPositionRestrictNoChange;
				pan.Width = 300;
				Config.TaskPans[key] = pan;
			}
			else
			{
				pan = Config.TaskPans[key];
			}
			pan.Visible = true;
		}

		#endregion

		#endregion

		#region VSTO 生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(ThisAddIn_Startup);
			this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
		}

		#endregion
	}
}
