using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KK.CodeLineCounter
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSelFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtDir.Text = fbd.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            CodeLineCounter.OnFileChanged += CodeLineCounter_OnFileChanged;
            CodeLineCounter.OnDirectoryChanged += CodeLineCounter_OnDirectoryChanged;
            Int64 lineCount = CodeLineCounter.CountLine(txtDir.Text, ".cs");
            txtConsole.AppendText(lineCount + "\r\n");
            //MessageBox.Show(lineCount.ToString());
        }

        private void CodeLineCounter_OnDirectoryChanged(DirectoryChangedEventArgs args)
        {
            if (args == null)
            {
                WriteDebug("目录变更参数为空！");
            }

            if (args.IsOpenSuccess)
            {
                WriteDebug("打开目录：" + args.DirectoryPath);
            }
            else
            {
                WriteDebug("目录【" + args.DirectoryPath + "】打开失败，原因：" + args.ErrMessage);
            }
        }

        private void CodeLineCounter_OnFileChanged(string file,Int32 lineCount)
        {
            if (file != null)
            {
                txtConsole.AppendText(string.Format("[{0}] {1}\r\n", lineCount, file));
            }
        }

        private void btnClearConsole_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }

        private void WriteDebug(string message)
        {
            txtConsole.AppendText(string.Format("{0}\r\n", message));
        }
    }
}
