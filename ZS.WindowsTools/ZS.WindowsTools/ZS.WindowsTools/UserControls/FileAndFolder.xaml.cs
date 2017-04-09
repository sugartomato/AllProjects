using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using WinForm = System.Windows.Forms;
using System.IO;

namespace ZS.WindowsTools.UserControls

{
    /// <summary>
    /// Interaction logic for FileAndFolder.xaml
    /// </summary>
    public partial class FileAndFolder : UserControl
    {
        public FileAndFolder()
        {
            InitializeComponent();
        }

        private void ZS_BTN_SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            WinForm.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ZS_TXT_TargetFolder.Text = fbd.SelectedPath;
            }
        }

        private void ZS_BTN_ReplaceFileName_Click(object sender, RoutedEventArgs e)
        {
            string strTargetFolder = ZS_TXT_TargetFolder.Text;

            if (!System.IO.Directory.Exists(strTargetFolder))
            {
                MessageBox.Show("目录未设置或者不存在！", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            System.IO.DirectoryInfo dir = new DirectoryInfo(strTargetFolder);
            FileInfo[] files = dir.GetFiles();
            if (files != null && files.Length > 0)
            {
                Int32 i = 0;
                for (i = 0; i < files.Length; ++i)
                {
                    System.IO.File.Move(files[i].FullName, files[i].FullName.Replace(ZS_TXT_Target.Text, ZS_TXT_Replacement.Text));
                }
            }

            MessageBox.Show("替换完成！");
        }
    }
}
