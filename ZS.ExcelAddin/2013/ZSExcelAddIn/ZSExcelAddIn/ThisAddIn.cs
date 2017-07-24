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

        protected override Office.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            RibMyTools rb = new RibMyTools();
            return rb;
        }
        protected override void OnStartup()
        {
            base.OnStartup();
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //RuntimeDebugInfo = new Controls.RuntimeInfoHost();
            //TaskPanRuntimeDebugInfo = this.CustomTaskPanes.Add(RuntimeDebugInfo, "运行时信息");
            //TaskPanRuntimeDebugInfo.Visible = true;

            //RuntimeDebugInfo.AppendText("开始处理ThisAddIn_Startup事件。");

            this.Application.WorkbookActivate += Application_WorkbookActivate;
            this.Application.WorkbookOpen += Application_WorkbookOpen;
        }

        private void Application_WorkbookOpen(Excel.Workbook Wb)
        {
            //RuntimeDebugInfo.AppendText("工作表打开！");
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            this.Application.WorkbookActivate -= Application_WorkbookActivate;
        }

        #region Excel事件
        private void Application_WorkbookActivate(Excel.Workbook Wb)
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
        }

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
