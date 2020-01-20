using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace ZSExcelAddIn.Controls
{

    /// <summary>
    /// 遮罩窗体形式聚光灯
    ///     窗体设置：
    /// </summary>
	public partial class frmFocus : Form
	{
		private Window _ExcelWindow = Globals.ThisAddIn.Application.ActiveWindow;

		public frmFocus()
		{
			InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            

			this.BackColor = Color.Black;
			this.TransparencyKey = Color.Black;
			//this.Opacity = 0;
			this.TopMost = true;
			this.Width = (Int32)_ExcelWindow.Width;
			this.Height = (Int32)_ExcelWindow.Height;
			this.ShowInTaskbar = false;
			panelY.Width = 2;
			panelY.Height = this.Height;
			panelY.Location = new System.Drawing.Point(0, 0);
			panelX.Height = 2;
			panelX.Width = this.Width;
			panelX.Location = new System.Drawing.Point(0, 0);
			
		}

		private void frmFocus_Load(object sender, EventArgs e)
		{

		}


		private const int WM_MOUSEACTIVATE = 0x21;
        private const int WM_ACTIVATE = 0x0006;

        private const int MA_NOACTIVATE = 3;

        private const int WA_INACTIVE = 0;
        private const int WA_CLICKACTIVE = 2;
        private const int WA_ACTIVE = 1;

        protected override void WndProc(ref Message m)
		{
            //if (m.Msg == WM_MOUSEACTIVATE)
            //{
            //	m.Result = new IntPtr(MA_NOACTIVATE);
            //	return;
            //}

            if (m.Msg == WM_ACTIVATE)
            {
                //if (m.WParam.ToInt32() == WA_ACTIVE || m.WParam.ToInt32() == WA_CLICKACTIVE)
                if (m.WParam.ToInt32() == WA_INACTIVE)
                {
                    if (m.LParam == BindControl)
                    {
                        this.Visible = true;
                    }
                    else
                    {
                        this.Visible = false;
                    }
                }
            }

			base.WndProc(ref m);
		}


        /// <summary>
        /// 重设聚光灯
        /// 
        /// </summary>
        /// <param name="target"></param>
        public void ReSet(Microsoft.Office.Interop.Excel.Range target = null)
        {
            if (!this.IsShow) return;
            SetFormPosition();

            if (target != null)
            {
                panelX.Visible = false;
                panelY.Visible = false;

                var window = Globals.ThisAddIn.Application.ActiveWindow;

                Single cellLeft_Point = Convert.ToSingle(target.Left);
                Single cellLeft_Pixel = PointToPixel(cellLeft_Point * (Int32)window.Zoom / 100, false);
                Single cellTop_Point = Convert.ToSingle(target.Top);
                Single cellTop_Pixel = PointToPixel(cellTop_Point * (Int32)window.Zoom / 100, true);

                Single windowLeft = PointToPixel(Convert.ToSingle(window.Left), false);
                Single windowTop = PointToPixel(Convert.ToSingle(window.Top), true);

                if (window.WindowState == XlWindowState.xlMaximized)
                {
                    windowLeft = 0;
                    windowTop = 0;
                }

                Single toolBarHeight = this.Location.Y - windowTop;

                Single left = cellLeft_Pixel + window.PointsToScreenPixelsX(0) - windowLeft;
                Single top = (cellTop_Pixel + window.PointsToScreenPixelsY(0)) - windowTop - toolBarHeight;

                Common.WriteConsole(String.Format("leftPoint：{0}，leftPixel:{1},PointToScreenPixelX:{2},Window.Left(Pixel):{3}", cellLeft_Point, cellLeft_Pixel, window.PointsToScreenPixelsX(0), windowLeft));
                Common.WriteConsole(String.Format("topPoint：{0}，topPixel:{1},PointsToScreenPixelsY:{2},Window.Top(Pixel):{3}", cellTop_Point, cellTop_Pixel, window.PointsToScreenPixelsY(0), windowTop));

                Common.WriteConsole("ActiveWindow.PointsToScreenPixelsX:" + window.PointsToScreenPixelsX(Convert.ToInt32(target.Left)));
                Common.WriteConsole("ActiveWindow.PointsToScreenPixelsY:" + window.PointsToScreenPixelsX(Convert.ToInt32(target.Top)));

                panelY.Location = new System.Drawing.Point((Int32)left - 3, 0);
                panelX.Location = new System.Drawing.Point(0, (Int32)top - 4);

                //panelY.Width = (Int32)PointToPixel(Convert.ToSingle(target.Width), false);
                //panelX.Height = (Int32)PointToPixel(Convert.ToSingle(target.Height), false);
                panelX.BackColor = Config.SpotlightColor;
                panelY.BackColor = Config.SpotlightColor;

                panelX.Visible = true;
                panelY.Visible = true;
            }
            this.Visible = IsShow;
        }



        #region 调试代码



        private void button1_Click(object sender, EventArgs e)
        {
            Workbook book = (Workbook)Globals.ThisAddIn.Application.ActiveWorkbook;
            Worksheet sheet = (Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
            sheet.Range["A1"].Value = "UsableHeight";
            sheet.Range["B1"].Value = Globals.ThisAddIn.Application.ActiveWindow.UsableHeight;
            sheet.Range["A2"].Value = "UsableWidth";
            sheet.Range["B2"].Value = Globals.ThisAddIn.Application.ActiveWindow.UsableWidth;

            sheet.Range["A2"].Value = "UsableWidth";
            sheet.Range["B2"].Value = Globals.ThisAddIn.Application.ActiveWindow.Hwnd;

        }



        #endregion
        private void frmFocus_ResizeEnd(object sender, EventArgs e)
		{
			//panelY.Height = this.Height;
			panelY.Location = new System.Drawing.Point(panelY.Location.X, 0);
			//panelX.Width = this.Width;
			panelX.Location = new System.Drawing.Point(0, panelX.Location.Y);
		}


		private Single PointToPixel(Single point, Boolean isVer)
		{
			var dpiX = (Int32)CreateGraphics().DpiX;
			var dpiY = (Int32)CreateGraphics().DpiY;
			if (isVer)
			{
				return (point * dpiY) / 72;
			}
			else
			{
				return (point * dpiX) / 72;
			}

		}

		private IntPtr _propBindControl = IntPtr.Zero;
		public IntPtr BindControl
		{
			get
			{
				return _propBindControl;
			}
			set
			{
				_propBindControl = value;
				SetFormPosition();
			}
		}

        /// <summary>
        /// 重新设定窗口的位置。
        /// 根据绑定的控件的位置与尺寸，重新设定遮罩窗体的位置与尺寸。
        /// </summary>
		private void SetFormPosition()
		{
			ZS.Common.Win32.API.RECT rec = new ZS.Common.Win32.API.RECT();
            // 通过API 获取窗口尺寸
			if (_propBindControl != IntPtr.Zero)
			{
				ZS.Common.Win32.API.GetWindowRect(_propBindControl, ref rec);

			}
			if (rec.bottom != 0)
			{
				this.Location = new System.Drawing.Point(rec.left, rec.top);
				this.Size = new System.Drawing.Size(rec.right - rec.left, rec.bottom - rec.top);
                panelY.Height = this.Height - 28;
                panelX.Width = this.Width - 22;
            }
        }

        private void timerCheckPosition_Tick(object sender, EventArgs e)
		{

			////// 获取当前的焦点窗口，如果不是绑定的Excel窗口，就隐藏，否则显示
			//IntPtr handle = ZS.Common.Win32.API.GetFocus();
			//IntPtr parent = ZS.Common.Win32.API.GetParent(BindControl);
			//if (handle == BindControl || handle == parent)
			//{
			//	this.Visible = true;
			//}
			//else
			//{
			//	this.Visible = false;
			//	return;
			//}


			// 获取绑定窗口的位置
			ZS.Common.Win32.API.RECT rec = new ZS.Common.Win32.API.RECT();
			if (_propBindControl != IntPtr.Zero)
			{
				ZS.Common.Win32.API.GetWindowRect(_propBindControl, ref rec);

			}

			if (this.Location.X != rec.left || this.Location.Y != rec.top)
			{
				ReSet();
			}

		}

		public void Display()
		{
			this.Visible = true;
			//this.WindowState = FormWindowState.Normal;
		}

		public void Hidden()
		{
			this.Visible = false;
			//this.WindowState = FormWindowState.Minimized;
		}

        private Boolean _propIsShow = false;
        public Boolean IsShow
        {
            get {
                return _propIsShow;
            }
            set
            {
                _propIsShow = value;
                this.Visible = value;
            }

        }

	}
}
