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

namespace ZS.WindowsTools.UserControls
{
    /// <summary>
    /// Interaction logic for Process.xaml
    /// </summary>
    public partial class Process : UserControl
    {
        public Process()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcesses();
            foreach (var pp in p)
            {
                txtConsole.Text += "进程：" + pp.ProcessName + "\r\n";
                try
                {
                    if (pp.Modules != null && pp.Modules.Count > 0)
                    {
                        foreach (System.Diagnostics.ProcessModule m in pp.Modules)
                        {
                            txtConsole.Text += m.FileName + "!!" + m.ModuleName + "\r\n";
                        }
                    }
                }
                catch (Exception ex)
                {
                    txtConsole.Text += "模块读取错误" + ex.Message + "\r\n";
                }

            }

            Clipboard.SetText(txtConsole.Text);
        }
    }
}
