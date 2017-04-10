using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace ZSExcelAddIn.Controls
{


    public struct RefEditState
    {
        public Size ParentClientSize;
        public Boolean IsParentMinimized;
        public Boolean ShowParentControlBox;
        public System.Windows.Forms.FormBorderStyle ParentPrevBorder;
        public Int32 ControlPrevX;
        public Int32 ControlPrevY;
        public System.Windows.Forms.AnchorStyles ControlAnchor;
        public System.Windows.Forms.Control ActualParent;

    }


    public partial class RefEdit__ : UserControl
    {
        private Excel.Workbook m_xlBook;
        private Excel.Worksheet m_xlSheet;
        private RefEditState m_DisplayState;

        public RefEdit__()
        {
            InitializeComponent();
        }




        #region "属性定义"

        private Excel.Application _propExcelConnector = null;
        public Excel.Application ExcelConnector
        {
            get
            {
                return _propExcelConnector;
            }
            set
            {
                // 获得Excel应用程序，读取冰设置Workbook和Worksheet对象。
                _propExcelConnector = value;
                if (_propExcelConnector == null) return;
                if (_propExcelConnector.Workbooks.Count > 0)
                {
                    m_xlBook = (Excel.Workbook)_propExcelConnector.ActiveWorkbook;
                    if (m_xlBook.Worksheets.Count > 0)
                    {
                        m_xlSheet = (Excel.Worksheet)m_xlBook.ActiveSheet;
                    }
                }
            }
        }



        /// <summary>
        /// 设置内容是否从右向左显示。
        /// </summary>
        public System.Windows.Forms.RightToLeft RefEditRightToLeft
        {
            get
            {
                return this.txtAddress.RightToLeft;
            }
            set
            {
                this.txtAddress.RightToLeft = value;
            }
        }


        /// <summary>
        /// 获取或者设置地址对话框字体
        /// </summary>
        public System.Drawing.Font RefEditFont
        {
            get { return this.txtAddress.Font; }
            set { this.txtAddress.Font = value; }
        }


        /// <summary>
        /// 获取或者设置地址对话框的字体颜色
        /// </summary>
        public System.Drawing.Color RefEditForeColor
        {
            get { return this.txtAddress.ForeColor; }
            set { this.txtAddress.ForeColor = value; }
        }


        private string _propAddress = "";
        /// <summary>
        /// 获取或者设置所选择区域的地址
        /// </summary>
        public string Address
        {
            get
            {
                return _propAddress;
            }
            set
            {
                if (value == null)
                {
                    _propAddress = string.Empty;
                }
                else
                {
                    _propAddress = value;
                }
            }
        }


        private Boolean _propIsIncludeSheetName;
        public Boolean IsIncludeSheetName
        {
            get { return _propIsIncludeSheetName; }
            set
            {
                _propIsIncludeSheetName = value;
                this.Invalidate();

            }
        }

        private Boolean _propShowColumnAbsoluteIndicator;
        public Boolean ShowColumnAbsoluteIndicator
        {
            get { return _propShowColumnAbsoluteIndicator; }
            set
            {
                _propShowColumnAbsoluteIndicator = value;
                this.Invalidate();
            }
        }

        private Boolean _propShowRowAbsoluteIndicator;
        public Boolean ShowRowAbsoluteIndicator
        {
            get { return _propShowRowAbsoluteIndicator; }
            set
            {
                _propShowRowAbsoluteIndicator = value;
                this.Invalidate();
            }

        }
        public FlatButtonAppearance FlatAppearance
        {
            get
            {
                return this.btnState.FlatAppearance;
            }
            set
            {
                this.btnState.FlatAppearance.BorderColor = value.BorderColor;
                this.btnState.FlatAppearance.BorderSize = value.BorderSize;
                this.btnState.FlatAppearance.CheckedBackColor = value.CheckedBackColor;
                this.btnState.FlatAppearance.MouseDownBackColor = value.MouseDownBackColor;
                this.btnState.FlatAppearance.MouseOverBackColor = value.MouseOverBackColor;
            }
        }


        public FlatStyle DropButtonFlatStyle
        {
            get { return this.btnState.FlatStyle; }
            set { this.btnState.FlatStyle = value; }
        }


        private Image _propImageMinimized = ZSExcelAddIn.Properties.Resources.RefEditMin;
        public Image ImageMinimized
        {
            get { return _propImageMinimized; }
            set
            {
                if (value != null)
                {
                    _propImageMinimized = value;
                }
                else
                {
                    _propImageMinimized = ZSExcelAddIn.Properties.Resources.RefEditMin;
                }
            }
        }


        private Image _propImageMaximized = ZSExcelAddIn.Properties.Resources.RefEditMax;
        public Image ImageMaximized
        {
            get { return _propImageMaximized; }
            set
            {
                if (value != null)
                {
                    _propImageMaximized = value;
                }
                else
                {
                    _propImageMaximized = ZSExcelAddIn.Properties.Resources.RefEditMax;
                }
            }
        }

        #endregion


        #region 事件

        public event EventHandler Changed;

        public event EventHandler DropButtonClicked;

        public event EventHandler<AfterResizeEventArgs> AfterResize;

        public event EventHandler<BeforeResizeEventArgs> BeforeResize;


        #endregion


        private delegate void WriteValue(string value);


        private void SelectionChange(Excel.Range target)
        {
            string address = "";
            string sheetName = "'" + target.Worksheet.Name + "'!";
            foreach (Excel.Range rng in target.Areas)
            {
                if (address.Length > 0)
                {
                    address += ",";
                }
                if (_propIsIncludeSheetName)
                {
                    address += sheetName;
                }

                //_propShowRowAbsoluteIndicator,_propShowColumnAbsoluteIndicator,Excel.XlReferenceStyle.xlA1,"",""
                address += rng.Address[_propShowRowAbsoluteIndicator, _propShowColumnAbsoluteIndicator, Excel.XlReferenceStyle.xlA1];

                WriteData(address);
                _NAR(rng);

            }

            _NAR(target);
        }

        private void WriteData(string value)
        {
            if (this.InvokeRequired)
            {
                //this.Invoke()
            }
            else
            {
                this.txtAddress.Text = value;
                this.Address = value;
                if (Changed != null)
                {
                    Changed(this, new System.EventArgs());
                }
            }
        }


        #region 内部控件事件

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            if (_propExcelConnector == null) return;
            if (this.Address != string.Empty)
            {
                m_xlSheet.Range[this.Address].Select();
            }
            m_xlSheet.SelectionChange += SelectionChange;
        }


        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (_propExcelConnector == null) return;
            m_xlSheet.SelectionChange -= SelectionChange;
        }


        #endregion

        private void txtAddress_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                _Resize();
                this.txtAddress.Focus();
            }
        }

        #region 按钮事件

        private void btnState_Click(object sender, EventArgs e)
        {
            _Resize();
            this.txtAddress.Focus();
            DropButtonClicked(this, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_Resize();

            Excel.Application xlApp = Globals.ThisAddIn.Application;
            object rng;
            this.Hide();
            rng = xlApp.InputBox("", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 8);

            //this.txtAddress.Focus();
            //DropButtonClicked(this, new EventArgs());
        }

        private void OnBeforeResize(BeforeResizeEventArgs e)
        {
            BeforeResize(this, e);
        }


        #endregion




        private void _Resize()
        {

            BeforeResizeEventArgs arg = new BeforeResizeEventArgs() { DisplayState = this.m_DisplayState };


            if (ParentForm == null) return;

            // 显示或者隐藏父窗口的所有控件
            // Hides/Shows all of the controls on the form
            foreach (Control c in ParentForm.Controls)
            {
                c.Visible = m_DisplayState.IsParentMinimized;
            }

            // Makes sure the control is visible
            this.Visible = true;



            // This is a fix related to placing the control into other container types such
            // as TabControls or Groupboxes.
            if (m_DisplayState.ActualParent == null)
            {
                m_DisplayState.ActualParent = this.Parent;
            }


            if (!m_DisplayState.IsParentMinimized)
            {
                // This is a fix related to placing the control into other container types such
                // as TabControls or Groupboxes.
                if (m_DisplayState.ActualParent.GetType() != typeof(Form))
                {
                    this.ParentForm.Controls.Add(this);
                }


                // Set the button's image to the minimized image
                this.btnState.Image = _propImageMinimized;

                // Store the current state of the form
                m_DisplayState.ParentClientSize = ParentForm.ClientSize;
                m_DisplayState.ParentPrevBorder = ParentForm.FormBorderStyle;
                m_DisplayState.ShowParentControlBox = ParentForm.ControlBox;

                // Store the current state of the control
                m_DisplayState.ControlPrevX = this.Left;
                m_DisplayState.ControlPrevY = this.Top;
                m_DisplayState.ControlAnchor = this.Anchor;

                // Set the new state minimized state of the form.
                ParentForm.ClientSize = new Size(this.Width, this.Height);
                this.ParentForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.ParentForm.ControlBox = false;

                // Set the location of the control
                this.Anchor = AnchorStyles.Left;
                this.Left = 0;
                this.Top = 0;
            }
            else
            {
                // This is a fix related to placing the control into other container types such
                // as TabControls or Groupboxes.

                if (m_DisplayState.ActualParent.GetType() != typeof(Form))
                {
                    this.ParentForm.Controls.Remove(this);
                    m_DisplayState.ActualParent.Controls.Add(this);
                }

                // Set the button's image to the maximized image
                this.btnState.Image = _propImageMaximized;

                // Set the form to the stored state
                ParentForm.ClientSize = m_DisplayState.ParentClientSize;
                ParentForm.FormBorderStyle = m_DisplayState.ParentPrevBorder;
                ParentForm.ControlBox = m_DisplayState.ShowParentControlBox;

                // Set the control to the stored state
                this.Anchor = m_DisplayState.ControlAnchor;
                this.Left = m_DisplayState.ControlPrevX;
                this.Top = m_DisplayState.ControlPrevY;
            }

            // Set the display state of the parent
            m_DisplayState.IsParentMinimized = !m_DisplayState.IsParentMinimized;

            // Raises the AfterResize event
            AfterResize(this, new AfterResizeEventArgs() { DisplayState = m_DisplayState });

        }


        #region 资源释放


        private void _NAR(object comObj)
        {
            try
            {
                Marshal.ReleaseComObject(comObj);
                comObj = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        #endregion

        private void RefEdit_Load(object sender, EventArgs e)
        {
            txtAddress.Focus();
        }

    }



    public class AfterResizeEventArgs : EventArgs
    {

        public RefEditState DisplayState { get; set; }
    }

    public class BeforeResizeEventArgs : EventArgs
    {
        public RefEditState DisplayState { get; set; }
    }
}
