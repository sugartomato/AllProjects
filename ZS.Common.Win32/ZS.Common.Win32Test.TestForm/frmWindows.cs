using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZS.Common.Win32Test.TestForm
{
    public partial class frmWindows : Form
    {
        public frmWindows()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // 获取父窗口

            IntPtr parentWindow = ZS.Common.Win32.API.FindWindowEx(IntPtr.Zero,IntPtr.Zero, null, txtWindowText.Text);
            AppendText("父窗口句柄:" + parentWindow.ToString());
            if (parentWindow == IntPtr.Zero)
            {
                MessageBox.Show("未找到父窗口");
                return;
            }

            ZS.Common.Win32.API.EnumChildWindows(parentWindow, new Win32.API.EnumChildProc(EnumProc), 0);

            AppendText("完成！");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //IntPtr parentWindow = ZS.Common.Win32.API.FindWindowEx(IntPtr.Zero, IntPtr.Zero, null, txtWindowText.Text);
            IntPtr parentWindow = new IntPtr(Int32.Parse(txtWindowHandle.Text));
            AppendText("父窗口句柄:" + parentWindow.ToString());
            if (parentWindow == IntPtr.Zero)
            {
                MessageBox.Show("未找到父窗口");
                return;
            }

            ZS.Common.Win32.API.EnumChildWindows(parentWindow, new Win32.API.EnumChildProc(EnumProc), 0);

            AppendText("完成！");
        }


        private Boolean EnumProc(IntPtr hwnd, Int32 lparam)
        {
            
			
            if (hwnd != IntPtr.Zero)
            {

                // 找到该句柄的窗
                String className = Win32.API.GetClassName(hwnd);
				String text = Win32.API.GetWindowText(hwnd);
				AppendText(String.Format("[{0}]-[{1}]-[{2}]", hwnd, text, className));
            }


            return true;
        }

        private void AppendText(string text, Boolean newLine = true)
        {
            txtConsole.AppendText(text);
            if (newLine)
            {
                txtConsole.AppendText("\r\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IntPtr parentWindow = ZS.Common.Win32.API.FindWindow(null, txtWindowTitleA.Text);
            if (parentWindow == null || parentWindow == IntPtr.Zero)
            {
                AppendText("没有找到父窗口！");
                return;
            }

            IntPtr childWindow = ZS.Common.Win32.API.FindWindow(null, txtWindowTitleB.Text);
            if (childWindow == null || childWindow == IntPtr.Zero)
            {
                AppendText("没有找到子窗口！");
                return;
            }

            IntPtr newHWND =  ZS.Common.Win32.API.SetParent(childWindow, parentWindow);

            ZS.Common.Win32.API.RECT rec = new Win32.API.RECT();
            ZS.Common.Win32.API.GetWindowRect(parentWindow, ref rec);
            ZS.Common.Win32.API.MoveWindow(childWindow, 0, 0, rec.right - rec.left, rec.bottom - rec.top, true);

            AppendText("返回结果:" + newHWND.ToString());
            AppendText("处理完成！");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }

		private void btnEnumWindows_Click(object sender, EventArgs e)
		{
			Win32.API.EnumWindows(new Win32.API.EnumWindowsProc(DoEnumWindows), 0);
		}

		private Boolean DoEnumWindows(IntPtr hwnd, Int32 index)
		{
			Boolean bln = Win32.API.IsWindowVisible(hwnd);
			if (bln)
			{
				txtConsole.AppendText(hwnd + ":" + Win32.API.GetWindowText(hwnd) + "\r\n");
			}
			return true;
		}

		private void button4_Click(object sender, EventArgs e)
		{
            //IntPtr parentWindow = ZS.Common.Win32.API.FindWindow(null, txtWindowText.Text);
            IntPtr parentWindow = new IntPtr(Int32.Parse(txtWindowHandle.Text));

            AppendText("父窗口句柄:" + parentWindow.ToString());
			if (parentWindow == IntPtr.Zero)
			{
				MessageBox.Show("未找到父窗口");
				return;
			}

			ZS.Common.Win32.API.EnumChildWindows(parentWindow, new Win32.API.EnumChildProc(EnumProcSetControlText), 0);

			AppendText("完成！");
		}
		private Boolean EnumProcSetControlText(IntPtr hwnd, Int32 lparam)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(txtControlText.Text);

			//Int32 re = ZS.Common.Win32.API.SendMessage(hwnd, ZS.Common.Win32.SystemDefinedMessages.WM_SETTEXT, sb.Capacity, sb);
			Int32 re = ZS.Common.Win32.API.SendMessage(hwnd, ZS.Common.Win32.SystemDefinedMessages.WM_SETTEXT, IntPtr.Zero, txtControlText.Text);
			AppendText("消息发送结果：" + re);
			return true;
		}

		ZS.Common.Win32.Mouse ms = null;
		private void button5_Click(object sender, EventArgs e)
		{
			ms = new Win32.Mouse();
			ms.MouseMove += Ms_MouseMove;
			ms.StartHook();
		}

		private void Ms_MouseMove(object sender, Win32.Mouse.MouseEventArgs args)
		{
			IntPtr hwnd = ZS.Common.Win32.API.WindowFromPoint(args.Location);
			String txt = Win32.API.GetWindowText(hwnd);
			txtWindowHandle.Text = hwnd.ToString();
			txtWindowText.Text = txt;
			//AppendText("鼠标所在窗口标题：" + txt);
			//this.Text = txt;
			//Win32.API.RECT rec = new Win32.API.RECT();


			//Win32.API.GetWindowRect(hwnd, ref rec);
			//AppendText(rec.ToString());
			
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (ms != null)
			{
				ms.StopHook();
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Win32.API.RECT rec = new Win32.API.RECT();
			Win32.API.GetWindowRect(new IntPtr(Int32.Parse(txtWindowHandle.Text)), ref rec);
			AppendText(rec.ToString());
			this.Location = new Point(rec.left, rec.top);
			this.Size = new Size(rec.right - rec.left, rec.bottom - rec.top);
		}

		private void button9_Click(object sender, EventArgs e)
		{
			Win32.Window.WindowSearcher s = new Win32.Window.WindowSearcher();
			IntPtr parent = IntPtr.Zero;
			if (!String.IsNullOrEmpty(txtWindowHandle.Text))
			{
				parent = new IntPtr(Int32.Parse(txtWindowHandle.Text));
			}
			s.Parent = parent;
			s.Title = txtSearchKey.Text;
			IntPtr result = s.Find();
			AppendText(result.ToString());
		}

        private void button10_Click(object sender, EventArgs e)
        {

            IntPtr window1 = new IntPtr(Int32.Parse(txtWindowHandle.Text));
            IntPtr window2 = new IntPtr(Int32.Parse(targetWindow.Text));
            Win32.API.SetWindowPos(window1, window2, 0, 0, 0, 0, Win32.API.SetWindowPosFlags.SWP_NOMOVE | Win32.API.SetWindowPosFlags.SWP_NOACTIVATE | Win32.API.SetWindowPosFlags.SWP_NOSIZE);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            IntPtr hwnd = new IntPtr(Int32.Parse(txtWindowHandle.Text));
            MessageBox.Show(Win32.API.IsWindow(hwnd).ToString());
        }


        ZS.Common.Win32.Mouse ms1 = null;
        private void button12_Click(object sender, EventArgs e)
        {
            ms1 = new Win32.Mouse();
            ms1.MouseMove += Ms1_MouseMove;
            ms1.StartHook();
        }

        private void Ms1_MouseMove(object sender, Win32.Mouse.MouseEventArgs args)
        {
            IntPtr parent = new IntPtr(Int32.Parse(txtWindowHandle.Text));
            Win32.API.RECT rec = new Win32.API.RECT();
            Win32.API.GetWindowRect(parent, ref rec);
            Win32.API.POINT pt = new Win32.API.POINT();
            if (args.X >= rec.left && args.X <= rec.right && args.Y > rec.top && args.Y < rec.bottom)
            {
                pt.X = args.X - rec.left;
                pt.Y = args.Y - rec.top;
            }

            IntPtr target = Win32.API.ChildWindowFromPointEx(parent, pt, 0x0000);
            if (target != IntPtr.Zero)
            {
                String txt = Win32.API.GetWindowText(target);
                AppendText(target + ":" + txt);
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            ms1.StopHook();
        }

        ZS.Common.Win32.Mouse ms2 = null;
        private void button14_Click(object sender, EventArgs e)
        {
            ms2 = new Win32.Mouse();
            ms2.MouseMove += Ms2_MouseMove;
            ms2.StartHook();
        }

        private void Ms2_MouseMove(object sender, Win32.Mouse.MouseEventArgs args)
        {
            IntPtr parent = new IntPtr(Int32.Parse(txtWindowHandle.Text));
            Win32.API.POINT pt = new Win32.API.POINT();
            pt.X = args.X;
            pt.Y = args.Y;
            if (Win32.API.ScreenToClient(parent, ref pt))
            {
                IntPtr target = Win32.API.RealChildWindowFromPoint(parent, pt);
                if (target != IntPtr.Zero)
                {
                    String txt = Win32.API.GetWindowText(target);
                    AppendText(target + ":" + txt);
                }
            }
            else
            {
                MessageBox.Show("屏幕坐标到区域坐标转换失败！");
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            ms2.StopHook();
        }


        ZS.Common.Win32.Mouse ms3 = null;

        private void button16_Click(object sender, EventArgs e)
        {
            ms3 = new Win32.Mouse();
            ms3.MouseMove += Ms3_MouseMove;
            ms3.StartHook();
        }

        private void Ms3_MouseMove(object sender, Win32.Mouse.MouseEventArgs args)
        {
            IntPtr parent = new IntPtr(Int32.Parse(txtWindowHandle.Text));
            Win32.API.POINT pt = new Win32.API.POINT();
            pt.X = args.X;
            pt.Y = args.Y;
            if (Win32.API.ScreenToClient(parent, ref pt))
            {
                IntPtr target = Win32.API.ChildWindowFromPoint(parent, pt);
                if (target != IntPtr.Zero)
                {
                    String txt = Win32.API.GetWindowText(target);
                    AppendText(target + ":" + txt);
                }
            }
            else
            {
                MessageBox.Show("屏幕坐标到区域坐标转换失败！");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ms3.StopHook();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Win32.API.FlashWindowType flashType = 0;
            switch (cbxFlashWindowType.SelectedItem.ToString().Substring(0, 1))
                {
                case "1":
                    break;
                case "2":
                    flashType = Win32.API.FlashWindowType.FLASHW_ALL;
                    break;
                case "3":
                    flashType = Win32.API.FlashWindowType.FLASHW_CAPTION;
                    break;
                case "4":
                    flashType = Win32.API.FlashWindowType.FLASHW_TRAY;
                    break;
                case "5":
                    flashType = Win32.API.FlashWindowType.FLASHW_TIMER;
                    break;
                case "6":
                    flashType = Win32.API.FlashWindowType.FLASHW_TIMERNOFG;
                    break;
            }
            IntPtr hwnd = new IntPtr(Int32.Parse(txtWindowHandle.Text));
            Win32.API.FlashWindowEx(hwnd, flashType);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            frmContainer frm = new frmContainer();
            frm.Show();
        }
    }
}
