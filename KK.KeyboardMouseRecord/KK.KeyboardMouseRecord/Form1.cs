using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZS.Common.Win32Messages;
using MouseKeyboardLibrary;

namespace KK.KeyboardMouseRecord
{
    public partial class Form1 : Form
    {

        // http://blog.csdn.net/smartsmile2012/article/details/25191249
        // http://blog.csdn.net/zp373860147/article/details/7385910

        MouseHook mouseHook = new MouseHook();
        KeyboardHook keyboardHook = new KeyboardHook();

        private System.Collections.Generic.Queue<string> m_logQueue;
        private System.Threading.Timer m_LogTimer;
        private string m_LogFolder = AppDomain.CurrentDomain.BaseDirectory + @"\Log\";
    public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击总数
        /// </summary>
        private Int64 m_ClickCount = 0;
        /// <summary>
        /// 鼠标点击总数
        /// </summary>
        private Int64 m_MouseClickCount = 0;
        /// <summary>
        /// 键盘点击总数
        /// </summary>
        private Int64 m_KeyboardClickCount = 0;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            //switch (m.Msg)
            //{
            //    case MESSAGE.WM_LBUTTONDBLCLK:
            //        textBox1.Text = System.DateTime.Now.ToString();
            //        break;
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            m_logQueue = new Queue<string>();
            m_LogTimer = new System.Threading.Timer(WriteToLocal,null,0,System.Threading.Timeout.Infinite);

            if (!System.IO.Directory.Exists(m_LogFolder))
            {
                System.IO.Directory.CreateDirectory(m_LogFolder);
            }


            mouseHook.MouseMove += new MouseEventHandler(mouseHook_MouseMove);
            mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);
            mouseHook.MouseUp += new MouseEventHandler(mouseHook_MouseUp);
            mouseHook.MouseWheel += new MouseEventHandler(mouseHook_MouseWheel);

            //keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);
            keyboardHook.KeyUp += new KeyEventHandler(keyboardHook_KeyUp);
            //keyboardHook.KeyPress += new KeyPressEventHandler(keyboardHook_KeyPress);

            mouseHook.Start();
            keyboardHook.Start();

            SetXYLabel(MouseSimulator.X, MouseSimulator.Y);

            listView2.Columns.Add(new ColumnHeader() { Text = "A" });
            listView2.Columns.Add(new ColumnHeader() { Text = "B" });
            listView2.Columns.Add(new ColumnHeader() { Text = "C" });
            listView2.Columns.Add(new ColumnHeader() { Text = "D" });
            listView2.Columns.Add(new ColumnHeader() { Text = "E" });
            listView2.Columns.Add(new ColumnHeader() { Text = "F" });

            this.ShowInTaskbar = false;
            

        }

        void keyboardHook_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddKeyboardEvent(
                "KeyPress",
                "",
                e.KeyChar.ToString(),
                "",
                "",
                ""
                );

        }

        void keyboardHook_KeyUp(object sender, KeyEventArgs e)
        {
            m_KeyboardClickCount += 1;
            AddToQueue(e.KeyCode.ToString());


            AddKeyboardEvent(
                "KeyUp",
                e.KeyCode.ToString(),
                "",
                e.Shift.ToString(),
                e.Alt.ToString(),
                e.Control.ToString()
                );

        }

        void keyboardHook_KeyDown(object sender, KeyEventArgs e)
        {

            AddKeyboardEvent(
                "KeyDown",
                e.KeyCode.ToString(),
                "",
                e.Shift.ToString(),
                e.Alt.ToString(),
                e.Control.ToString()
                );

        }

        void mouseHook_MouseWheel(object sender, MouseEventArgs e)
        {

            AddMouseEvent(
                "MouseWheel",
                "",
                "",
                "",
                e.Delta.ToString()
                );

        }

        void mouseHook_MouseUp(object sender, MouseEventArgs e)
        {


            AddMouseEvent(
                "MouseUp",
                e.Button.ToString(),
                e.X.ToString(),
                e.Y.ToString(),
                ""
                );

        }

        void mouseHook_MouseDown(object sender, MouseEventArgs e)
        {

            m_MouseClickCount += 1;
            AddToQueue(e.Button.ToString());
            AddMouseEvent(
                "MouseDown",
                e.Button.ToString(),
                e.X.ToString(),
                e.Y.ToString(),
                ""
                );


        }

        void mouseHook_MouseMove(object sender, MouseEventArgs e)
        {

            SetXYLabel(e.X, e.Y);

        }

        void SetXYLabel(int x, int y)
        {

            textBox1.Text = String.Format("Current Mouse Point: X={0}, y={1}", x, y);

        }

        void AddMouseEvent(string eventType, string button, string x, string y, string delta)
        {

            listView1.Items.Insert(0,
                new ListViewItem(
                    new string[]{
                        eventType,
                        button,
                        x,
                        y,
                        delta
                    }));

        }

        void AddKeyboardEvent(string eventType, string keyCode, string keyChar, string shift, string alt, string control)
        {

            listView2.Items.Insert(0,
                 new ListViewItem(
                     new string[]{
                        keyCode,
                        eventType,
                        keyChar,
                        shift,
                        alt,
                        control
                }));

        }

        private void TestForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            // Not necessary anymore, will stop when application exits  

            //mouseHook.Stop();  
            //keyboardHook.Stop();  

        }


        #region 记录本地


        private void AddToQueue(string log)
        {
            m_logQueue.Enqueue(log);
        }

        private void WriteToLocal(object state)
        {
            if (m_logQueue.Count > 0)
            {
                string m = m_logQueue.Dequeue();

                string logFile = m_LogFolder + DateTime.Now.ToString("yyyyMMdd") + ".log";

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(logFile, true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(System.DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss.fff") + "\t" + m);
                    sw.Flush();
                    sw.Close();
                }
            }

            m_LogTimer.Change(200, System.Threading.Timeout.Infinite);
        }
        #endregion

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                notifyIcon1.BalloonTipText = "按键记录运行中！";
                notifyIcon1.ShowBalloonTip(4000);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
    }
}
