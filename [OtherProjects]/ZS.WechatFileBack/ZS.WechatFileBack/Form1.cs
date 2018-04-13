using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZS.WechatFileBack
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>.4
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                fsw.EnableRaisingEvents = false;
                fsw.IncludeSubdirectories = true;

                // 加载微信路径
                LoadWXFilePath();

                // 加载本地路径
                LoadLocalPath();

                // 验证开机运行标记
                GetIfIsAutoRun();

                btnStart_Click(null, null);


            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 查找微信文件存储路径
        /// </summary>
        private void LoadWXFilePath()
        {
            // 注册表查找
            Microsoft.Win32.RegistryKey regRoot = Microsoft.Win32.Registry.CurrentUser;
            try
            {
                Microsoft.Win32.RegistryKey regWX = regRoot.OpenSubKey(@"SOFTWARE\Tencent\WeChat");
                if (regWX != null && regWX.ValueCount > 0)
                {
                    object val = regWX.GetValue("FileSavePath");
                    if (val != null)
                    {
                        String path = val.ToString();
                        if (path == "MyDocument:")
                        {
                            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        }
                        path = (path + "\\WeChat Files").Replace(@"\\",@"\");
                        if (System.IO.Directory.Exists(path))
                        {
                            txtWXFolder.Text = path;
                        }
                    }
                }
                
            }
            catch (Exception ) 
            {
                throw;
            }
            finally
            {
                regRoot.Close();
            }
        }

        /// <summary>
        /// 加载本地路径
        /// </summary>
        private void LoadLocalPath()
        {
            using (Microsoft.Win32.RegistryKey regRoot = Microsoft.Win32.Registry.CurrentUser)
            {
                Microsoft.Win32.RegistryKey regThis = regRoot.OpenSubKey(@"SOFTWARE\DHDTools\WXFileBack", true);
                if (regThis != null)
                {
                    object val = regThis.GetValue("BackFolder");
                    if (val != null)
                    {
                        txtBackFolder.Text = val.ToString();
                    }
                }
            }
        }

        private void SetLocalPath(String path)
        {
            using (Microsoft.Win32.RegistryKey regRoot = Microsoft.Win32.Registry.CurrentUser)
            {
                Microsoft.Win32.RegistryKey regThis = regRoot.OpenSubKey(@"SOFTWARE\DHDTools\WXFileBack",true);
                if (regThis == null)
                {
                    regThis = regRoot.CreateSubKey(@"SOFTWARE\DHDTools\WXFileBack");
                }
                regThis.SetValue("BackFolder", path);
            }
        }

        /// <summary>
        /// 文件创建备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fsw_Created(object sender, System.IO.FileSystemEventArgs e)
        {
        }

        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fsw_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            // 新创建文件，复制到备份目录
            try
            {
                // 验证文件是否在Files目录里
                if (System.IO.Path.GetDirectoryName(e.FullPath).Trim('\\').EndsWith("Files"))
                {
                    // 提取文件名
                    String fileName = System.IO.Path.GetFileName(e.FullPath);

                    // 验证目标目录中是否存在同名文件，如果存在，就设置一个新的名字
                    String[] files = System.IO.Directory.GetFiles(txtBackFolder.Text);
                    if (files != null && files.Length > 0)
                    {
                        foreach (String fName in files)
                        {
                            if (System.IO.Path.GetFileName(fName) == fileName)
                            {
                                fileName = System.IO.Path.GetFileNameWithoutExtension(fileName) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + System.IO.Path.GetExtension(fileName);
                                break;
                            }
                        }
                    }

                    // 拷贝文件到目标目录
                    System.IO.File.Copy(e.FullPath, txtBackFolder.Text + "\\" + fileName);
                    WriteLocalLog("备份文件：" + e.FullPath + "\t" + txtBackFolder.Text + "\\" + fileName);
                }
            }
            catch (Exception ex)
            {
                WriteLocalLog(ex.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // 验证路径
            if (!System.IO.Directory.Exists(txtWXFolder.Text) || !System.IO.Directory.Exists(txtBackFolder.Text))
            {
                MessageBox.Show("微信目录或者备份目录无效，检查设置！");
                return;
            }

            // 初始化监控器
            // 验证通过，自动启动
            fsw.Path = txtWXFolder.Text;
            fsw.EnableRaisingEvents = true;

            // 刷新控件格式
            UpControlState();

            // 一切正常，则最小化运行
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            fsw.EnableRaisingEvents = false;
            UpControlState();
        }
        private void UpControlState()
        {
            btnStart.Enabled = !fsw.EnableRaisingEvents;
            btnStop.Enabled = fsw.EnableRaisingEvents;
            if (fsw.EnableRaisingEvents)
            {
                lblState.Text = "正在运行。。。。";
                lblState.ForeColor = Color.Green;
            }
            else
            {
                lblState.Text = "已停止！";
                lblState.ForeColor = Color.Red;
            }
        }

        private void btnSelWXFolder_Click(object sender, EventArgs e)
        {
            fbd.Description = "选择微信接收文件目录：";
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtWXFolder.Text = fbd.SelectedPath;
            }
        }

        private void btnSelBackFolder_Click(object sender, EventArgs e)
        {
            fbd.Description = "选择备份文件目录。选择之后，将会记住该目录。";
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtBackFolder.Text = fbd.SelectedPath;
                // 保存路径到注册表
                SetLocalPath(txtBackFolder.Text);
            }
        }

        /// <summary>
        /// 写本地日志
        /// </summary>
        /// <param name="msg"></param>
        private void WriteLocalLog(String msg)
        {
            String logFilePath = Application.StartupPath + "\\微信文件备份.log.txt";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(logFilePath,true, Encoding.UTF8))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + msg);
                sw.Close();
            }
        }

        /// <summary>
        /// 设置开机自动运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            using (Microsoft.Win32.RegistryKey regRoot = Microsoft.Win32.Registry.CurrentUser)
            {
                Microsoft.Win32.RegistryKey regThis = regRoot.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (regThis != null)
                {
                    if (chkAutoStart.Checked)
                    {
                        regThis.SetValue("WXFileBack", Application.ExecutablePath);
                    }
                    else
                    {
                        regThis.DeleteValue("WXFileBack");
                    }
                }
            }
        }

        /// <summary>
        /// 获取是否设置了自动运行，并根据获取的值设置复选框状态
        /// </summary>
        private void GetIfIsAutoRun()
        {
            using (Microsoft.Win32.RegistryKey regRoot = Microsoft.Win32.Registry.CurrentUser)
            {
                Microsoft.Win32.RegistryKey regThis = regRoot.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                if (regThis != null)
                {
                    Object val = regThis.GetValue("WXFileBack");
                    if (val != null && val.ToString() == Application.ExecutablePath)
                    {
                        chkAutoStart.Checked = true;
                        return;
                    }
                }
                chkAutoStart.Checked = false;
            }
        }

        #region 通知区域处理

        /// <summary>
        /// 双击还原主界面，通知区域不显示，任务栏显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        /// <summary>
        /// 最小化时，通知区域显示并气泡提醒，任务栏不显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                if (fsw.EnableRaisingEvents)
                {
                    notifyIcon1.ShowBalloonTip(2000, "提示^_^", "备份正在运行！", ToolTipIcon.Info);
                }
                else
                {
                    notifyIcon1.ShowBalloonTip(2000, "提示@_@", "备份没有运行。。。。。", ToolTipIcon.Warning);
                }
            }
        }
        #endregion

    }
}
