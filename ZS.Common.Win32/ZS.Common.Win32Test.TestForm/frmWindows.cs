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

            IntPtr parentWindow = ZS.Common.Win32.API.FindWindow(null, txtWindowTitleA.Text);
            txtConsole.AppendText("父窗口句柄" + parentWindow.ToString() + "\n");
            if (parentWindow == IntPtr.Zero)
            {
                MessageBox.Show("未找到窗口,将传递null值");
            }

            ZS.Common.Win32.API.EnumChildWindows(parentWindow, new Win32.API.EnumChildProc(EnumProc), 0);

            AppendText("完成！");
        }

        private Boolean EnumProc(IntPtr hwnd, Int32 lparam)
        {
            AppendText(hwnd.ToString());

            if (hwnd != IntPtr.Zero)
            {
                // 给找到的窗口设置文本

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(DateTime.Now.ToLongDateString() + "程序设置");
                ZS.Common.Win32.API.SendMessage(hwnd, ZS.Common.Win32.SystemDefinedMessages.WM_SETTEXT, 0, sb);

            }


            return true;
        }

        private void AppendText(string text, Boolean newLine = true)
        {
            txtConsole.AppendText(text);
            if (newLine)
            {
                txtConsole.AppendText("\n");
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

            AppendText("返回结果:" + newHWND.ToString());
            AppendText("处理完成！");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }
    }
}
