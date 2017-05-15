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
    public partial class frmCursorPoint : Form
    {
        public frmCursorPoint()
        {
            InitializeComponent();
        }

        private void timer1_Tick(Object sender, EventArgs e)
        {
        }

        private void frmCursorPoint_Load(Object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void button2_Click(Object sender, EventArgs e)
        {
            ZS.Common.Win32.API.SetCursorPos(Int32.Parse(txtX.Text), Int32.Parse(txtY.Text));
        }

        Int32 clickCount = 1;
        private void button1_Click(Object sender, EventArgs e)
        {
            clickCount++;
            button1.Text = string.Format("点击了{0}次！", clickCount);
        }

        // 鼠标点击
        private void button4_Click(Object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            System.Threading.Thread.Sleep(2000);
            ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
        }

        // 移动鼠标
        private void button3_Click(Object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            //Int32 x = 3;
            //for(Int32 m = 0; m < 100; m++)
            //{
            //    ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, 1, 1, 0, UIntPtr.Zero);
            //    System.Threading.Thread.Sleep(1);
            //}


            List<Button> targets = new List<Button>() { btnTarget1, btnTarget2, btnTarget3, btnTarget4,button1 };
            for(Int32 i = 0; i < targets.Count; ++i)
            {
                //ZS.Common.Win32.API.POINT pt = new Point(0, 0);
                //// 鼠标当前绝对坐标
                //ZS.Common.Win32.API.GetCursorPos(ref pt);
                //textBox1.AppendText(pt.X + "," + pt.Y + "\r\n");

                // 目标控件绝对坐标
                System.Drawing.Point target = PointToScreen(targets[i].Location);
                textBox1.AppendText(target.X + "," + target.Y + "\r\n");


                Int32 count = 100;
                while(count != 0)
                {
                    Int32 stepX = (target.X + 5 - Cursor.Position.X) / count;
                    Int32 stepY = (target.Y + 5 - Cursor.Position.Y) / count;
                    count--;
                    if(count != 0)
                    {
                        ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, stepX, stepY, 0, UIntPtr.Zero);
                        System.Threading.Thread.Sleep(3);
                    }
                }

                //ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, 4, 4, 0, UIntPtr.Zero);
                ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                System.Threading.Thread.Sleep(100);
                ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
                Application.DoEvents();
                System.Threading.Thread.Sleep(2000);
            }










            // 计算对角线的长度

            //Int32 dx = Math.Abs(target.X - pt.X);
            //Int32 dy = Math.Abs(target.Y - pt.Y);
            //Int32 len = (Int32)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

            //Int32 perX = dx / len;
            //if(perX < 1)
            //    perX = 1;
            //if(target.X < pt.X)
            //    perX = -perX;

            //Int32 perY = dy / len;
            //if(perY < 1)
            //    perY = 1;
            //if(target.Y < pt.Y)
            //    perY = -perY;


            //textBox1.AppendText(perX + "\r\n");
            //textBox1.AppendText(perY + "\r\n");
            //textBox1.AppendText(len + "\r\n");

            //for(Int32 z = 0; z < len; z++)
            //{
            //    if(Math.Abs(perX * z) > dx)
            //    {
            //        perX = 0;
            //    }

            //    if(Math.Abs(perY * z) > dy)
            //    {
            //        perY = 0;
            //    }

            //    ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, perX, perY, 0, UIntPtr.Zero);
            //    System.Threading.Thread.Sleep(1);
            //}



            return;

            //Int32 k = Math.Abs(target.Y - pt.Y) / Math.Abs(target.X - pt.X);
            //textBox1.AppendText(k.ToString());
            //if(pt.Y > target.Y)
            //    k = -k;

            //Int32 m = 0;
            //if(pt.X > target.X)
            //{
            //    m = -1;
            //}
            //else
            //{
            //    m = 1;
            //}

            //for(Int32 i = 0; i < Math.Abs(target.X - pt.X); i++)
            //{


            //    ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, m, k, 0, UIntPtr.Zero);
            //    System.Threading.Thread.Sleep(1);
            //}

            //Int32 perX = ((target.X + this.Left) - pt.X) / 100;
            //Int32 perY = ((target.Y + this.Top) - pt.Y) / 100;
            //for(Int32 m = 0; m < 100; m++)
            //{
            //    ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, perX, perY, 0, UIntPtr.Zero);
            //    System.Threading.Thread.Sleep(1);
            //}
        }

        private void frmCursorPoint_MouseMove(Object sender, MouseEventArgs e)
        {
            ZS.Common.Win32.API.POINT pt = new Win32.API.POINT(0, 0);
            ZS.Common.Win32.API.GetCursorPos(ref pt);
            label1.Text = "X:" + pt.X;
            label1.Location = new Point(pt.X - this.Left,pt.Y - this.Top);
        }

        private void btnTarget2_Click(Object sender, EventArgs e)
        {
            (sender as Button).Text = DateTime.Now.ToString("ss:FFF");
        }

        Random rd = new Random();
        private void button5_Click(object sender, EventArgs e)
        {
            for (Int32 i = 0; i < 1; i++)
            {
                ZS.Common.Win32.API.POINT pt = new Point(0, 0);
                // 鼠标当前绝对坐标
                ZS.Common.Win32.API.GetCursorPos(ref pt);
                Int32 x = rd.Next(1, 900);
                Int32 y = rd.Next(1, 900);
                textBox1.AppendText("从：" + pt.X + "," + pt.Y + "\r\n");
                textBox1.AppendText("到：" + x + "," + y + "\r\n");

                System.Drawing.Point pt1 = new Point(x,y);
                ZS.Common.Win32.Mouse.MoveTo(pt1,(Int32)numericUpDown1.Value);
            }
        }
    }
}
