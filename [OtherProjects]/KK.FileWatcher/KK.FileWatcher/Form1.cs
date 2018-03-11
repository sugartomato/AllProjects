using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KK.FileWatcher
{
    public partial class Form1 : Form
    {

        private System.IO.FileSystemWatcher m_Watcher;
        private delegate void WriteMessageDelegate(string text, Color color);
        private WriteMessageDelegate WriteMessage;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                RiseWatchStatus();
                this.TopMost = chkTopMost.Checked;
                WriteMessage = new WriteMessageDelegate(DoWriteMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化失败：" + ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                m_Watcher.EnableRaisingEvents = false;
            }
            catch (Exception)
            {
            }
        }


        private void btnSelFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = fbd.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!System.IO.Directory.Exists(txtFolder.Text))
                {
                    WriteMessage("不存在的目录：" + txtFolder.Text, Color.Red);
                    return;
                }
                if (m_Watcher == null)
                {
                    m_Watcher = new System.IO.FileSystemWatcher();
                    m_Watcher.Path = txtFolder.Text;
                    m_Watcher.IncludeSubdirectories = true;
                    m_Watcher.Filter = "*.*";
                    m_Watcher.Created += M_Watcher_Created;
                    m_Watcher.Renamed += M_Watcher_Renamed;
                    m_Watcher.Changed += M_Watcher_Changed;
                    m_Watcher.Deleted += M_Watcher_Deleted;
                    

                    m_Watcher.EnableRaisingEvents = true;

                }

                RiseWatchStatus();
            }
            catch (Exception ex)
            {
                WriteMessage("监视启动异常：" + ex.Message, Color.Red);
                throw;
            }
        }

        private void M_Watcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            WriteMessage("删除：" + e.FullPath, Color.Red);
        }

        private void M_Watcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            WriteMessage("修改：" + e.FullPath, Color.DarkBlue);
        }

        private void M_Watcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            WriteMessage("重命名：" + e.FullPath, Color.Blue);
        }

        private void M_Watcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            WriteMessage("创建：" + e.FullPath, Color.Green);
            //this.BeginInvoke(new WriteMessageDelegate(UpText), e.FullPath);
        }

        private void DoWriteMessage(string text, Color color)
        {
            Int32 start = txtConsole.Text.Length;
            txtConsole.AppendText(text + "\r\n");
            txtConsole.Select(start, txtConsole.Text.Length);
            txtConsole.SelectionColor = color;
            txtConsole.Select(txtConsole.Text.Length,0);
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            m_Watcher.EnableRaisingEvents = false;
            RiseWatchStatus();
        }


        private void checkTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chkTopMost.Checked;
        }

        private void RiseWatchStatus()
        {
            if (m_Watcher == null || m_Watcher.EnableRaisingEvents == false)
            {
                lblIsRunning.Text = "停止";
                lblIsRunning.ForeColor = Color.Red;
            }
            else
            {
                lblIsRunning.Text = "运行中";
                lblIsRunning.ForeColor = Color.Green;
            }
        }

    }
}
