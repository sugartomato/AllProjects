using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace KK.FileBackup
{
    public partial class frmMain : Form
    {
        private OpenFileDialog m_OFD = null;
        private SMTPSetting m_SMTPSetting = null;
        private String m_StoreListFile = Application.StartupPath + "\\FileList.txt";
        private System.Timers.Timer m_Timer_Backup = null;
        private delegate void WriteMessageDelegate(String msg);
        private WriteMessageDelegate WriteMessage = null;

        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(Object sender, EventArgs e)
        {
            m_OFD = new OpenFileDialog();
            gridMain.AllowUserToAddRows = false;
            gridMain.AutoSize = false;
            gridMain.ScrollBars = ScrollBars.Both;


            txtServerUrl.Text = "smtp-mail.outlook.com";//"smtp.office365.com";
            txtMailAccount.Text = "go18600870447@outlook.com";
            txtPassword.Text = "";
            txtReceiver.Text = "15801524452@outlook.com";
            txtPort.Text = "587";

            txtConsole.Clear();

            WriteMessage = new WriteMessageDelegate(WriteMsg);
            // 定时器
            m_Timer_Backup = new System.Timers.Timer();
            m_Timer_Backup.Elapsed += M_Timer_Backup_Elapsed;
            m_Timer_Backup.Interval = TimeSpan.FromMinutes(1).TotalMilliseconds;

            // 加载已保存文件
            GetFileList();

            UpdateControlState();
        }


        private void frmMain_FormClosing(Object sender, FormClosingEventArgs e)
        {
            m_Timer_Backup.Stop();
            // 关闭时保存设置的文件
            SaveFileList();
        }


        private void btnAddFile_Click(Object sender, EventArgs e)
        {
            m_OFD.InitialDirectory = LastDir;
            m_OFD.Multiselect = true;
            if(m_OFD.ShowDialog() == DialogResult.OK)
            {
                if(m_OFD.FileNames.Length > 0)
                {
                    foreach(String file in m_OFD.FileNames)
                    {
                        AddPath(file);
                    }
                    LastDir = System.IO.Path.GetDirectoryName(m_OFD.FileName);
                }

                gridMain.AutoResizeColumns();
            }
        }


        private void AddPath(String path)
        {
            if(IsPathExists(path))
                return;

            gridMain.Rows.Add();
            Int32 rowIndex = gridMain.Rows.Count-1;
            gridMain.Rows[rowIndex].Cells[0].Value = "删除";
            gridMain.Rows[rowIndex].Cells[1].Value = System.IO.Path.GetFileName(path);
            gridMain.Rows[rowIndex].Cells[2].Value = path;
        }

        /// <summary>
        /// 检查要备份的文件是否存在
        /// </summary>
        /// <param name="path"></param>
        private Boolean IsPathExists(String path)
        {
            if(gridMain.Rows.Count == 0)
                return false;
            foreach(DataGridViewRow row in gridMain.Rows)
            {
                if(row.Cells[1].Value.ToString().ToLower() == path.ToLower())
                {
                    return true;
                }
            }
            return false;
        }


        #region Grid操作

        private void gridMain_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            if(gridMain.Rows.Count > 0)
            {
                if(gridMain.Columns[e.ColumnIndex].Name == "clmRemove")
                {
                    gridMain.Rows.RemoveAt(e.RowIndex);
                    gridMain.AutoResizeColumns();
                }
            }
        }


        private void btnClearAll_Click(Object sender, EventArgs e)
        {
            if(gridMain.Rows.Count > 0)
            {
                gridMain.Rows.Clear();
            }
        }

        private void btnResizeCLMWidth_Click(Object sender, EventArgs e)
        {
            gridMain.AutoResizeColumns();
        }

        #endregion


        #region 邮件发送部分

        private void SendMail(string file)
        {
            Application.DoEvents();
            WriteMsg("[开始]邮件发送文件：" + file);
            String subject = "文件备份[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]：" + System.IO.Path.GetFileName(file);
            String content = "如附件！";

            MailMessage mail = new MailMessage(txtMailAccount.Text.Trim(),txtReceiver.Text.Trim(), subject, content);
            mail.IsBodyHtml = false;
            Attachment data = new Attachment(file, System.Net.Mime.MediaTypeNames.Application.Octet);
            System.Net.Mime.ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            mail.Attachments.Add(data);

            mail.Sender = new MailAddress(txtMailAccount.Text);

            // SMTP设置
            SmtpClient client = new SmtpClient(m_SMTPSetting.Host, m_SMTPSetting.Port);
            //client.Port = 25;//587;
            client.EnableSsl = true;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(m_SMTPSetting.Account, m_SMTPSetting.Password);


            try
            {
                client.Send(mail);
                WriteMsg("[完成]邮件发送文件：" + file);
            }
            catch(Exception ex)
            {
                WriteMsg("文件【" + file + "】发送邮件失败：" + ex.Message + "\r\n" + ex.StackTrace);
                //MessageBox.Show(ex.Message + ex.StackTrace);
            }
            finally
            {
                Application.DoEvents();
            }

        }



        #endregion

        private void WriteMsg(String msg)
        {
            txtConsole.AppendText(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + "\t" + msg + "\r\n");
            txtConsole.AppendText("=".PadLeft(50, '=') + "\r\n");
        }


        #region 属性

        public String LastDir { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        #endregion

        private void btSendNow_Click(Object sender, EventArgs e)
        {
            try
            {
                WriteMsg("开始备份");
                if (gridMain.Rows.Count > 0)
                {
                    m_SMTPSetting = new SMTPSetting();
                    m_SMTPSetting.Host = txtServerUrl.Text.Trim();
                    m_SMTPSetting.Port = Int32.Parse(txtPort.Text);
                    m_SMTPSetting.Account = txtMailAccount.Text.Trim();
                    m_SMTPSetting.Password = txtPassword.Text.Trim();

                    foreach (DataGridViewRow row in gridMain.Rows)
                    {
                        SendMail(row.Cells[2].Value.ToString());
                    }
                }
                else
                {
                    WriteMsg("没有可备份内容！");
                    return;
                }

                WriteMsg("发送完成！");

            }
            catch(Exception ex)
            {
                WriteMsg("执行发送失败：" + ex.Message + ex.StackTrace);
            }
        }


        #region 文件列表保存/读取

        private void SaveFileList()
        {
            try
            {
                if(System.IO.File.Exists(m_StoreListFile))
                    System.IO.File.Delete(m_StoreListFile);

                if(gridMain.Rows.Count == 0)
                    return;


                using(System.IO.StreamWriter sw = new System.IO.StreamWriter(m_StoreListFile, true, System.Text.Encoding.UTF8))
                {
                    foreach(DataGridViewRow row in gridMain.Rows)
                    {
                        sw.WriteLine(row.Cells[2].Value.ToString());
                    }
                    sw.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("保存记录文件失败：" + ex.Message);
            }
        }

        private void GetFileList()
        {
            try
            {
                if(!System.IO.File.Exists(m_StoreListFile))
                {
                    return;
                }

                String[] files = System.IO.File.ReadAllLines(m_StoreListFile);
                if(files != null && files.Length > 0)
                {
                    foreach(String file in files)
                    {
                        if(System.IO.File.Exists(file))
                        {
                            AddPath(file);
                        }
                        else
                        {
                            WriteMsg("已不存在的文件：" + file);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                WriteMsg("读取记录文件异常：" + ex.Message);
            }


        }

        #endregion

        private void frmMain_Resize(Object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(Object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }


        #region 定时备份

        private void M_Timer_Backup_Elapsed(Object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                // 12点备份1次，4.50备份1次
                String time = DateTime.Now.ToString("HH:mm");
                if(time == "12:00" || time == "17:02")
                {
                    WriteMessage("时间条件成立，开始备份！");
                    btSendNow_Click(null,null);
                }
            }
            catch(Exception ex)
            {
                WriteMessage("备份异常：" + ex.Message);
            }
        }

        private void btnStart_Click(Object sender, EventArgs e)
        {
            m_Timer_Backup.Start();
            UpdateControlState();
        }


        private void button1_Click(Object sender, EventArgs e)
        {
            m_Timer_Backup.Stop();
            UpdateControlState();
        }

        private void UpdateControlState()
        {
            btnStart.Enabled = !m_Timer_Backup.Enabled;
            btnStop.Enabled = m_Timer_Backup.Enabled;
        }

        #endregion

    }
}
