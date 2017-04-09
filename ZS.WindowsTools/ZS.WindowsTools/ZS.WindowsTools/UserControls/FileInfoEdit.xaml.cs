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
using WinForm =System.Windows.Forms;
using System.IO;

namespace ZS.WindowsTools.UserControls
{
    /// <summary>
    /// Interaction logic for FileInfoEdit.xaml
    /// </summary>
    public partial class FileInfoEdit : UserControl
    {
        public FileInfoEdit()
        {
            InitializeComponent();
        }

        private void OnClick_LoadFiles(object sender, RoutedEventArgs e)
        {
            string p = ZS_TXT_FolderPath.Text;
            if (!Directory.Exists(p))
            {
                System.Windows.MessageBox.Show("目录不存在！");
                return;
            }

            Shell32.ShellClass sh = new Shell32.ShellClass();
            Shell32.Folder dir = sh.NameSpace(p);
            foreach (Shell32.FolderItem item in dir.Items())
            {
                txtTest.Text += "\r\n" + dir.GetDetailsOf(item, 0);
                txtTest.Text += "\r\n" + dir.GetDetailsOf(item, 1);
                txtTest.Text += "\r\n" + dir.GetDetailsOf(item, 21);
                txtTest.Text += "\r\n" + dir.GetDetailsOf(item, 27);
                
            }

            //string[] files = Directory.GetFiles(ZS_TXT_FolderPath.Text);
            //foreach (string f in files)
            //{
            //    Shell32.FolderItem item = dir.ParseName(f);
            //}

            sh = null;

        }

        private void OnClick_SelectFolder(object sender, RoutedEventArgs e)
        {
            WinForm.FolderBrowserDialog fd = new WinForm.FolderBrowserDialog();
            if (fd.ShowDialog() == WinForm.DialogResult.OK)
            {
                ZS_TXT_FolderPath.Text = fd.SelectedPath;
            }
        }
    }
}
