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
        private delegate void UpdateWatchText(string text);
        public Form1()
        {
            InitializeComponent();
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
            if (m_Watcher == null)
            {
                m_Watcher = new System.IO.FileSystemWatcher();
                m_Watcher.Path = txtFolder.Text;
                m_Watcher.Filter = "*.*";
                m_Watcher.Created += M_Watcher_Created;

                m_Watcher.EnableRaisingEvents = true;

            }
        }

        private void M_Watcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            this.BeginInvoke(new UpdateWatchText(UpText), e.FullPath);
        }

        private void UpText(string text)
        {
            txtConsole.AppendText(text + "\r\n");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            m_Watcher.EnableRaisingEvents = false;
        }
    }
}
