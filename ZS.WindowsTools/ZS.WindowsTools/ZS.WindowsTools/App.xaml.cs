using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace ZS.WindowsTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }


    public class Program
    {
        [STAThread]
        public static void Main(string[] args)    
        {

            // 参数之间按照-来分隔。
            // 参数应为这种格式：-t+参数值。参数与参数值之间不需要空格。


            if(args != null && args.Length > 0)
            {

                foreach(string s in args)
                {
                    // 帮助信息

                    if(s == "-help")
                    {
                        Console.WriteLine("ABCDEFG");
                        Console.ReadLine();
                        return;
                    }

                    // 复制参数值
                    if(s.StartsWith("-c"))
                    {
                        if(s.Length > 2)
                        {
                            System.Windows.Clipboard.SetData(DataFormats.Text, s.Substring(2));
                            return;
                        }
                        else
                        {
                            System.Windows.Clipboard.SetData(DataFormats.Text, "KKTools：只有一个参数，没有要复制的内容。");
                            return;
                        }

                    }

                }

            }

            App app = new App();
            app.InitializeComponent();
            app.Run();

        }

    }


    public class Arguements
    {
        private System.Collections.Specialized.StringDictionary m_Parameters;

        public Arguements(string[] args)
        {
        }


    }

}
