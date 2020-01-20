using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;

namespace KK.WordAddIn
{
    public partial class ThisAddIn
    {

        protected override Office.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new RibMyTools();
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            var taskPan = this.CustomTaskPanes.Add(new Controls.MainTaskPan(), "KK工具箱");
            taskPan.Width = 300;
            taskPan.Visible = true;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {

        }

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
