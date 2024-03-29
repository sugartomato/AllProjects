﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZS.Common.Win32Test.TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.LightBlue;
            this.TopMost = true;
            this.ShowInTaskbar = true;
        }

        private void Form1_Load(Object sender, EventArgs e)
        {
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //ZS.Common.Win32.API.AnimateWindow(this.Handle, 2000, (Int32)Win32.API.AnimateWindowType.AW_CENTER);
        }

        protected override void OnLoad(EventArgs e)
        {
            System.Windows.Forms.Screen sc = Screen.FromHandle(this.Handle);


            Int32 x;Int32 y;
            x = sc.WorkingArea.Width - this.Width;
            y = sc.WorkingArea.Height - this.Height;
            if(sc.WorkingArea.Location.X != 0)
            {
                x = sc.WorkingArea.Location.X + sc.WorkingArea.Width - this.Width;
                y = sc.WorkingArea.Location.Y + sc.WorkingArea.Height - this.Height;
            }


            this.Location = new Point(x, y);
            lblLocation.Text = string.Format("x:{0}\ry:{1}", sc.WorkingArea.Location.X, sc.WorkingArea.Location.Y);
            ZS.Common.Win32.API.AnimateWindow(this.Handle, 200, Win32.API.AnimateWindowType.AW_HOR_NEGATIVE);
            //ZS.Common.Win32.API.AnimateWindow(this.Handle, 500, (Int32)(Win32.API.AnimateWindowType.AW_ACTIVATE) + (Int32)Win32.API.AnimateWindowType.AW_BLEND);
            //ZS.Common.Win32.API.AnimateWindow(this.Handle, 1000, (Int32)(Win32.API.AnimateWindowType.AW_VER_NEGATIVE) + (Int32)Win32.API.AnimateWindowType.AW_HOR_NEGATIVE);
        }

        private void button1_Click(Object sender, EventArgs e)
        {
			ZS.Common.Win32.API.AnimateWindow(this.Handle, 200, Win32.API.AnimateWindowType.AW_HIDE | Win32.API.AnimateWindowType.AW_BLEND);
            this.Close();
        }

		private void button5_Click(Object sender, EventArgs e)
		{

			ZS.Common.Win32.API.AnimateWindow(this.Handle, 200, Win32.API.AnimateWindowType.AW_VER_POSITIVE| Win32.API.AnimateWindowType.AW_HIDE|Win32.API.AnimateWindowType.AW_SLIDE);
			//System.Threading.Thread.Sleep(1000);
			this.WindowState = FormWindowState.Minimized;
		}

		private void button2_Click(Object sender, EventArgs e)
        {
            frmCursorPoint frm = new frmCursorPoint();
            frm.Show();
        }

        private void button3_Click(Object sender, EventArgs e)
        {
            BackgroundWorker bk = new BackgroundWorker();
            bk.RunWorkerCompleted += Bk_RunWorkerCompleted;
            bk.DoWork += Bk_DoWork;
            bk.RunWorkerAsync();
            lblLocation.Text = "开始播放";
            lblLocation.BackColor = Color.LightGreen;
        }

        private void Bk_DoWork(Object sender, DoWorkEventArgs e)
        {
            Boolean b = ZS.Common.Win32.API.sndPlaySound(txtURL.Text, Win32.API.PlaySoundFlags.SND_SYNC);
        }

        private void Bk_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            lblLocation.Text = "播放结束";
            lblLocation.BackColor = Color.Red;
        }

        private void button4_Click(Object sender, EventArgs e)
        {
            frmNetworkAdapter frm = new frmNetworkAdapter();
            frm.Show();
        }


        // 绘图
        private void button6_Click(Object sender, EventArgs e)
        {

            frmPaint frm = new frmPaint();
            frm.Show();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmWin32Provider frm = new frmWin32Provider();
            frm.Show();

                
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmInstalledApps frm = new frmInstalledApps();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmWindowsMessages frm = new frmWindowsMessages();
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmWindows frm = new frmWindows();
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmMemory frm = new frmMemory();
            frm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmListBox frm = new frmListBox();
            frm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            frmForm_Menu_ContextMenu_ToolBar_StatusBarcs frm = new frmForm_Menu_ContextMenu_ToolBar_StatusBarcs();
            frm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            frmForm_SendKeys frm = new frmForm_SendKeys();
            frm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            frmForm_Splitter frm = new frmForm_Splitter();
            frm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            frmReg frm = new frmReg();
            frm.Show();
        }
    }
}
