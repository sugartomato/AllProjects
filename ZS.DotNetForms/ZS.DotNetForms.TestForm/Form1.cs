using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZS.DotNetForms.TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZS.DotNetForms.PopupWindow frm = new PopupWindow();
            frm.Content = "private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展  ";
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxEx msg = new MessageBoxEx("这是一条执行成功的消息！！", MessageBoxEx.MessageType.Success, null);
            msg.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Int32 m = Convert.ToInt32("aaa");
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("执行转换的时候失败！", ex);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx msg = new MessageBoxEx(ex.Message, MessageBoxEx.MessageType.Error, ex);
                msg.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBoxEx msg = new MessageBoxEx("这是一条显示信息的消息！！", MessageBoxEx.MessageType.Info, null);
            msg.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBoxEx msg = new MessageBoxEx("这是一条显示警告的消息！！", MessageBoxEx.MessageType.Warning, null);
            msg.ShowDialog();
        }
    }
}
