using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using WinForm = System.Windows.Forms;

namespace ZS.WordAddIn
{
    public partial class MyTools:Office.IRibbonExtensibility
    {
        #region 测试选项卡回调函数

        /// <summary>
        /// 测试功能
        /// </summary>
        /// <param name="ctrl"></param>
        public void OnClick_Test(Office.IRibbonControl ctrl)
        {
            switch (ctrl.Id)
            {
                case "btnTest_Form_Size":
                    TestForms.frmTest_WindowsSize frm = new TestForms.frmTest_WindowsSize();
                    frm.DocumentFullName = Globals.ThisAddIn.Application.ActiveDocument.FullName;
                    frm.BringToFront();
                    frm.Show();
                    break;
                case "qatbtnTest":
                    WinForm.MessageBox.Show("TTT");
                    break;
                case "DHD_BTN_TEST_GETOUTLINE": // 获取大纲


                    break;
                default:
                    break;
            }

        }

        #endregion

    }
}
