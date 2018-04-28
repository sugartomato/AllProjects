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
    public partial class frmWindowsMessages : Form
    {
        public frmWindowsMessages()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("这是来自消息的文字！");

            IntPtr window = ZS.Common.Win32.API.FindWindow(null, "无标题 - 记事本");
            if (window != IntPtr.Zero)
            {
               Int32 re =   ZS.Common.Win32.API.SendMessage(window, ZS.Common.Win32.SystemDefinedMessages.WM_SETTEXT, sb.Capacity, sb);
                MessageBox.Show("消息发送结果：" + re);
            }
            else
            {
                MessageBox.Show("未找到窗口！");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = null;

            // 获取窗口
            IntPtr window = ZS.Common.Win32.API.FindWindow(null, txtWindowTitle.Text.Trim());
            window = txtConsole.Handle;
            if (window == IntPtr.Zero)
            {
                MessageBox.Show("未找到窗口！");
                return;
            }

            // 随机设置一个文本标题
            sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1, 9999).ToString());
            Int32 re = ZS.Common.Win32.API.SendMessage(window, ZS.Common.Win32.SystemDefinedMessages.WM_SETTEXT, 0, sb);


            // 获取文本的长度
            Int32 size = ZS.Common.Win32.API.SendMessage(window, ZS.Common.Win32.SystemDefinedMessages.WM_GETTEXTLENGTH, 0, 0);

            // 根据长度构建sb
            sb = new StringBuilder(size + 1);

            Int32 newSize = ZS.Common.Win32.API.SendMessage(window, ZS.Common.Win32.SystemDefinedMessages.WM_GETTEXT, sb.Capacity, sb);

            MessageBox.Show(newSize.ToString());
            MessageBox.Show(sb.ToString());
            txtWindowTitle.Text = sb.ToString();
        }


        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == ZS.Common.Win32.SystemDefinedMessages.WM_DROPFILES)
                {
                    //MessageBox.Show(m.WParam);
                    MessageBox.Show("拖拽文件！");
                }
                else
                {
                    
                    base.WndProc(ref m);
                }
            }
            catch (Exception)
            {

            }
        }

        private void frmWindowsMessages_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
