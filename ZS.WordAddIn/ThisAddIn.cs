using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using OfficeCore = Microsoft.Office.Core;
using OfficeTools = Microsoft.Office.Tools;
using Microsoft.Office.Tools.Word;

namespace ZS.WordAddIn
{
    public partial class ThisAddIn
    {

        protected override OfficeCore.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new MyTools();
        }


        // 自定义面板
        private UserControls.MainTaskPanHost m_MainTaskPaneControl;
        private OfficeTools.CustomTaskPane m_MainTaskPane;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            try
            {

                // TODO 写本地日志
            }
            catch (Exception)
            {

                throw;
                // TODO 写本地日志
            }





        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            Globals.ThisAddIn.Application.WindowSelectionChange -= Application_WindowSelectionChange;
        }



        public System.Windows.Forms.Form FPanel = null;
        private void Application_WindowSelectionChange(Word.Selection Sel)
        {
            //if (FPanel == null || !FPanel.IsHandleCreated) FPanel = new TestForms.frmTest_WindowsSize();
            //if (Sel.Range.Words.Count > 1)
            //{
            //    FPanel.Show();
            //    FPanel.BringToFront();
            //}
            //else
            //{
            //    FPanel.Hide();
            //}

        }


        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
