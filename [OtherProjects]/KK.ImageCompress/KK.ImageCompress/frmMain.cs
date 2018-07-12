using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KK.ImageCompress
{
    public partial class frmMain : Form
    {
        private delegate void LogDelegate(String msg, LogType ltype);
        private LogDelegate LogWriter;
        private List<String> m_FileExt = new List<string>();

        public frmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSelFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = fbd.SelectedPath;
                Log("选择目录：" + fbd.SelectedPath, LogType.Success);
            }
        }


        #region 消息输出

        private void Log(String msg, LogType logType = LogType.Info)
        {
            msg = DateTime.Now.ToString("HH:mm:ss fff") + "\t" + msg + "\n";
            txtConsole.AppendText(msg);
            Int32 selStart = txtConsole.Find(msg);
            if (selStart > -1)
            {
                txtConsole.Select(selStart, msg.Length);
            }

            String tmpText = txtConsole.Text;
            //MessageBox.Show(tmpText.IndexOf(msg).ToString());
            txtConsole.Select(tmpText.IndexOf(msg), msg.Length);

            switch (logType)
            {
                case LogType.Error:
                    txtConsole.SelectionColor = Color.Red;
                    break;
                case LogType.Success:
                    txtConsole.SelectionColor = Color.Green;
                    break;
                case LogType.Warning:
                    txtConsole.SelectionColor = Color.OrangeRed;
                    break;

            }
            txtConsole.Select(txtConsole.Text.Length, 0);
        }

        private enum LogType
        {
            Info,
            Success,
            Error,
            Warning
        }

        /// <summary>
        /// 消息框单选，选择整行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtConsole_Click(object sender, EventArgs e)
        {
            Int32 index = txtConsole.GetFirstCharIndexOfCurrentLine();
            String tmp = txtConsole.Text.Substring(index);
            if (tmp.Contains("\n"))
            {
                tmp = tmp.Substring(0, tmp.IndexOf("\n"));
            }
            //Log(index.ToString());
            txtConsole.Select(index, tmp.Length);
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Log("开始处理！");


                // 初始化处理参数
                Options o = new Options();
                if (!System.IO.Directory.Exists(txtFolder.Text))
                {
                    Log("指定的目录：[" + txtFolder.Text + "]不存在");
                    return;
                }
                // 获取要处理的后缀名
                Control.ControlCollection chks = panelChkFileExt.Controls;
                foreach (var chk in chks)
                {
                    CheckBox t = (CheckBox)chk;
                    if (t.Checked)
                    {
                        o.FileExts.Add(t.Tag.ToString().ToLower());
                    }
                }

                o.RootFolder = txtFolder.Text;

                ZS.Common.ImageHelper.ResizeSetting setting = new ZS.Common.ImageHelper.ResizeSetting();
                setting.CompressionLevel = 10;
                setting.ResizeMode = ZS.Common.ImageHelper.ResizeType.Auto;
                //setting.TargetWidht = 100;
                setting.CompressionLevel = trackBar1.Value;
                o.ResizeSetting = setting;

                LogWriter = new LogDelegate(Log);
                // 调用处理方法
                //CompressImage(o);
                bgWorker.RunWorkerAsync(o);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnClearMsg_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }


        #region 图片压缩处理


        private void CompressImage(Options option)
        {
            string[] files = System.IO.Directory.GetFiles(option.RootFolder);
            foreach (String file in files)
            {
                if (file.EndsWith(".jpg"))
                {
                    Log(file, LogType.Warning);
                }
            }
        }

        private class Options
        {
            public String RootFolder { get; set; }
            public List<String> FileExts { get; set; } = new List<string>();
            
            public ZS.Common.ImageHelper.ResizeSetting ResizeSetting { get; set; }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Options option = (Options)e.Argument;

            string[] files = System.IO.Directory.GetFiles(option.RootFolder);
            foreach (String file in files)
            {
                if (option.FileExts.Contains(System.IO.Path.GetExtension(file).ToLower()))
                {
                    this.Invoke(LogWriter, "[处理]" +file, LogType.Warning);
                    ZS.Common.ImageHelper.Resize(file, option.ResizeSetting);
                }
                else
                {
                    this.Invoke(LogWriter, "[跳过]" + file, LogType.Warning);
                }
            }

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Log("处理完成！", LogType.Success);
        }


        #endregion

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblCompressLevel.Text = "压缩比例：" + trackBar1.Value;
        }

        private void chkEx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            String t = c.Tag.ToString();
            if (!t.StartsWith("."))
            {
                t = "." + t;
            }
            if (c.Checked)
            {
                m_FileExt.Add(t.ToLower());
            }
            else
            {
                m_FileExt.Remove(t.ToLower());
            }
        }
    }
}
