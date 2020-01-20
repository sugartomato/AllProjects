using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using WordControls = Microsoft.Office.Tools.Word.Controls;
using WordTools = Microsoft.Office.Tools.Word;
using WinForm = System.Windows.Forms;
using ZS.Common;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new MyTools();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace ZS.WordAddIn
{
    public partial class MyTools : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private Word.Application m_App;
        private Microsoft.Office.Tools.CustomTaskPane m_MainPan;

        public MyTools()
        {


        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("ZS.WordAddIn.MyTools.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit http://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;

            m_App = Globals.ThisAddIn.Application;

            // 文档打开事件，绑定如自动加载功能区的。
            m_App.DocumentChange += M_App_DocumentChange;
            //new System.Windows.Forms.FileDialog().ShowDialog()
            
        }

        /// <summary>
        /// 文档切换事件
        /// </summary>
        private void M_App_DocumentChange()
        {
            // 这里做文档有效性判断，否则在关闭最后一个文档的时候，会引发错误。
            if (m_App != null && m_App.Documents != null && m_App.Documents.Count > 0)
            {
                // 自动加载辅助面板
                CreateMainPan();
                m_MainPan.Visible = true;

                // 修改文档窗口标题，显示文档路径
                m_App.ActiveWindow.Caption = string.Format("★ {0} ★ [{1}]",  m_App.ActiveWindow.Caption, m_App.ActiveDocument.Path);
            }
        }



        Word.Table testTable = null;
        public void Click_AddTables(Office.IRibbonControl ctrl)
        {
            //object start = 0;
            //object end = 0;

            //Microsoft.Office.Interop.Word.Range tableLocation = Globals.ThisAddIn.Application.ActiveDocument.Range(ref start, ref end);

            //testTable = Globals.ThisAddIn.Application.ActiveDocument.Tables.Add(tableLocation, 3, 3);
            //testTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;

            //WordControls.Button btn;
            WordTools.Document doc = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument);
            if (!doc.Controls.Contains("TTTT"))
            {
                WinForm.Button btnFrm = new System.Windows.Forms.Button();
                btnFrm.Text = "点击";
                btnFrm.Click += BtnFrm_Click;
                btnFrm.Name = "btnTest";
                btnFrm.BackColor = System.Drawing.Color.Black;
                btnFrm.ForeColor = System.Drawing.Color.Yellow;
                doc.Controls.AddControl(btnFrm, Globals.ThisAddIn.Application.ActiveDocument.Paragraphs[1].Range, 100, 30, "TTTT");
            }
            else
            {
                (doc.Controls["TTTT"] as WinForm.Button).Visible = true;
            }



        }

        private void BtnFrm_Click(object sender, EventArgs e)
        {
            WinForm.MessageBox.Show("CCCCC");
        }

        public void Click_AddRows(Office.IRibbonControl ctrl)
        {

            //TestForms.Form1 frm = new TestForms.Form1();
            //frm.ShowDialog();
            //return;

            //testTable.Rows.Add();

            //Word.Paragraph p = null;
            //foreach (Word.Paragraph pp in Globals.ThisAddIn.Application.ActiveDocument.Paragraphs)
            //{
                
            //}
        }

        #endregion

        #region 图片处理

        /// <summary>
        /// 批量导入图片按钮点击
        /// </summary>
        /// <param name="ctrl"></param>
        public void OnClick_BatchInsertImages(Office.IRibbonControl ctrl)
        {
            try
            {
                UserControls.frmBatchInsertImages frm = new UserControls.frmBatchInsertImages();
                frm.Show();
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }


        #endregion

        #region 自定义功能区

        /// <summary>
        /// 显示功能区按钮点击
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="pressed"></param>
        public void OnClick_ShowMainPan(Office.IRibbonControl ctrl, bool pressed)
        {
            try
            {
                if (m_MainPan != null)
                {
                }
                else
                {
                    CreateMainPan();
                }
                m_MainPan.Visible = pressed;
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        /// <summary>
        /// 创建一个新的辅助面板
        /// </summary>
        private void CreateMainPan()
        {
            // 设置辅助面板
            string key = m_App.ActiveWindow.Hwnd.ToString();
            if (!CustomPans.Exists(key))
            {
                m_MainPan = CustomPans.Add(key, "KK辅助", new UserControls.MainTaskPanHost(m_App.ActiveDocument), true, MainTaskPan_VisibleChanged);
            }
            else
            {
                m_MainPan = CustomPans.Get(key);
            }
        }

        /// <summary>
        /// 辅助面板的可见性变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTaskPan_VisibleChanged(object sender, EventArgs e)
        {
            // 更新界面按钮的状态
            ribbon.InvalidateControl("ZS_BTN_ShowMainPan");
        }

        /// <summary>
        /// 显示辅助面板按钮的获取按下状态的回掉函数。
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public Boolean GetPressed_ShowMainPan(Office.IRibbonControl ctrl)
        {
            if (m_MainPan != null)
            {
                return m_MainPan.Visible;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region 文字处理

        public void OnClick_OperateText(Office.IRibbonControl ctrl)
        {
            switch(ctrl.Id)
            {

                case "DHD_BTN_Text_ReplaceShiftEnter":
                    ReplaceAllShiftEnterToEnter();
                    break;
            }
        }

        /// <summary>
        /// 将所有的软回车替换为硬回车
        /// </summary>
        private void ReplaceAllShiftEnterToEnter()
        {
            try
            {
                Word.Find findObject = m_App.ActiveDocument.Range(0).Find;
                findObject.ClearFormatting();
                findObject.Text = "\v";
                findObject.Replacement.ClearFormatting();
                findObject.Replacement.Text = "\r";
                findObject.Execute(Replace: Word.WdReplace.wdReplaceAll);

                
                // ==================================================
                // 2017-3-21注销
                // 此方法循环每个字，大篇幅效率太低。
                // ==================================================
                //if(m_App.ActiveDocument.Words.Count > 0)
                //{
                //    for(Int32 i = 1; i <= m_App.ActiveDocument.Words.Count; i++)
                //    {
                //        if(m_App.ActiveDocument.Words[i].Text.Contains("\v"))
                //        {
                //            m_App.ActiveDocument.Words[i].Text = m_App.ActiveDocument.Words[i].Text.Replace("\v", "\r");
                //        }
                //    }
                //}

                // ==================================================
                // 2017-3-20注销
                // 此方法会替换掉原文档的格式。
                // ==================================================
                //Word.Range rng = m_App.ActiveDocument.Range(0);
                //rng.Text = rng.Text.Replace("\v", "\r");
            }
            catch(Exception ex)
            {
                HandleError(ex);
            }
        }

        #endregion

        #region 文档处理

        public void OnClick_OperateDocument(Office.IRibbonControl ctrl)
        {
            switch (ctrl.Id)
            {

                case "DHD_BTN_Doc_SaveAsPDF":
                    SaveDocument();
                    break;
            }
        }

        /// <summary>
        /// 将活动文档存储为同路径同名的pdf格式文件。如果活动文档目录不存在，就存储到桌面。
        /// word另存类型枚举参考：https://msdn.microsoft.com/en-us/library/office/ff839952.aspx
        /// </summary>
        private void SaveDocument()
        {
            try
            {
                if (m_App.ActiveWindow == null) return;

                string savePath = m_App.ActiveDocument.Path;

                if (!System.IO.Directory.Exists(savePath))
                {
                    savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }

                if (!savePath.EndsWith("\\"))
                {
                    savePath += "\\";
                }

                savePath += System.IO.Path.GetFileNameWithoutExtension(m_App.ActiveDocument.Name);

                savePath += ".pdf";

                //NotifyHelper.Show(savePath);

                if (System.IO.File.Exists(savePath))
                {
                    if (System.Windows.MessageBox.Show("文件已存在，是否覆盖？点击确定覆盖，点击取消停止操作。", "是否覆盖？", System.Windows.MessageBoxButton.OKCancel) != System.Windows.MessageBoxResult.OK)
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            System.IO.File.Delete(savePath);
                        }
                        catch (Exception ex)
                        {
                            HandleError(ex);
                        }
                    }
                }

                m_App.ActiveDocument.SaveAs2(savePath, FileFormat:Word.WdSaveFormat.wdFormatPDF);

                System.Windows.MessageBox.Show("保存完成！\r\n" + savePath);

                //System.Windows.MessageBox.Show(savePath);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        #endregion

        #region 属性



        #endregion

        #region 公共方法

        private void HandleError(Exception ex)
        {
            System.Windows.MessageBox.Show("执行异常：" + ex.Message);
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

        /// <summary>
        /// 异常处理。执行最终的异常处理。
        /// </summary>
        private void HandleExceptions(Exception ex)
        {
            WinForm.MessageBox.Show(ex.JoinWithInnerExMessage(), "执行错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        #endregion

    }
}
