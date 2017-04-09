using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZS.WordAddIn.TestForms
{
    public partial class frmTest_WindowsSize : Form
    {
        public frmTest_WindowsSize()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = string.Empty;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(100, 100);
            //this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;


            Globals.ThisAddIn.Application.WindowSize += Application_WindowSize;
            Globals.ThisAddIn.Application.DocumentChange += Application_DocumentChange;
            Globals.ThisAddIn.Application.WindowDeactivate += Application_WindowDeactivate;
            Globals.ThisAddIn.Application.WindowSelectionChange += Application_WindowSelectionChange;
            
        }

        private void frmTest_WindowsSize_Load(object sender, EventArgs e)
        {
            SetLocation();
            this.Text = _propDocumentFullName;
        }

        private void frmTest_WindowsSize_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 窗体关闭之后，需要卸载绑定的事件
            Globals.ThisAddIn.Application.WindowSize -= Application_WindowSize;
        }

        private void Application_WindowDeactivate(Microsoft.Office.Interop.Word.Document Doc, Microsoft.Office.Interop.Word.Window Wn)
        {
            // Word程序失去焦点，比如切换到其它程序时，将该窗口的置顶取消。
            // this.TopMost = false;
        }

        // 文档变成事件
        private void Application_DocumentChange()
        {
            
            //TODO 设置TopMost的属性存在一个缺陷，当切换文档时，初次是两个打开的窗口同时显示在最上面，在文档内点击使文档得到焦点时，才会达到正确效果。
            //this.TopMost = Globals.ThisAddIn.Application.ActiveDocument.FullName == _propDocumentFullName ? true : false;

            // 使用隐藏方式的缺陷是只有当前活动文档才能显示出来该窗口。
            if (Globals.ThisAddIn.Application.ActiveDocument.FullName != _propDocumentFullName)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }

            // 查找自己所属文档，文档不存在就关闭。
            int i;
            bool closeMe = true;
            for (i = 1; i <= Globals.ThisAddIn.Application.Documents.Count; ++i)
            {
                if (Globals.ThisAddIn.Application.Documents[i].FullName == _propDocumentFullName)
                {
                    closeMe = false;
                    break;
                }
            }
            UpdateDisplay();
            //if (closeMe) this.Close();
        }

        // 窗口尺寸、位置变化事件
        private void Application_WindowSize(Microsoft.Office.Interop.Word.Document Doc, Microsoft.Office.Interop.Word.Window Wn)
        {
            // 匹配自己所属的文档
            if (Globals.ThisAddIn.Application.ActiveDocument.FullName == _propDocumentFullName)
            {
                if (Wn.WindowState == Microsoft.Office.Interop.Word.WdWindowState.wdWindowStateMinimize)
                {
                    this.Hide();
                }
                else
                {
                    this.Show();
                    //this.TopMost = Globals.ThisAddIn.Application.ActiveDocument.FullName == _propDocumentFullName ? true : false;
                    SetLocation();
                }
            }
            UpdateDisplay();
        }

        private void Application_WindowSelectionChange(Microsoft.Office.Interop.Word.Selection Sel)
        {
            SetLocation();
        }

        private string _propDocumentFullName = string.Empty;
        public string DocumentFullName { set { this._propDocumentFullName = value; } }
        public Point LocationInWord
        {
            get
            {
                return this.Location;
            }
            set
            {
                this.Location = value;
            }
        }

        // 设置窗体在文档中的位置
        private void SetLocation()
        {
            System.Drawing.Point location = this.Get_SelectionTextLocation();
            location.Y -= this.Height - 5;
            this.Location = location;

        }

        private System.Drawing.Point Get_SelectionTextLocation()
        {
            int left;
            int top;
            int width;
            int height;
            Globals.ThisAddIn.Application.ActiveWindow.GetPoint(out left, out top, out width, out height, Globals.ThisAddIn.Application.Selection.Range);

            return new System.Drawing.Point(left, top);
        }

        private void UpdateDisplay()
        {
            Globals.ThisAddIn.Application.ScreenRefresh();
        }

    }
}
