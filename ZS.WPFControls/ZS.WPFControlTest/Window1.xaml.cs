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
using System.Windows.Shapes;

namespace ZS.WPFControlTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ZS.WPFControls.WindowBase
    {
        public Window1()
        {
            InitializeComponent();
            this.Icon = BitmapFrame.Create(ZS.Images.ImageAdapter.Instance().GetImageAsStream(@"Actions\Open_16x16.png"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = new Random().Next(0, Themes.Count);
            this.Theme = (Themes[i]);
            
        }

        private void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            //System.Windows.Resources.StreamResourceInfo sri = Application.GetResourceStream(new Uri("/Images/bg01.jpg", UriKind.RelativeOrAbsolute));
            //Console.WriteLine(sri.ContentType);

            //System.Windows.Media.Imaging.BitmapImage image = new BitmapImage();
            //image.BeginInit();
            //image.StreamSource = sri.Stream;
            //image.EndInit();
            //Image1.Source = image;

            //System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(this.GetType());
            //string resourceName = assembly.GetName().Name + ".g";
            //System.Resources.ResourceManager rsManager = new System.Resources.ResourceManager(resourceName, assembly);
            //using (System.Resources.ResourceSet set = rsManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true))
            //{
            //    System.IO.UnmanagedMemoryStream umn = (System.IO.UnmanagedMemoryStream)set.GetObject("Images/bg01.jpg", true);
            //    System.Windows.Media.Imaging.BitmapImage image = new BitmapImage();
            //    image.BeginInit();
            //    image.StreamSource = umn;
            //    image.EndInit();
            //    Image1.Source = image;
            //}

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(this.GetType());
            string resourceName = assembly.GetName().Name + ".g";
            System.Resources.ResourceManager rsManager = new System.Resources.ResourceManager(resourceName, assembly);
            using (System.Resources.ResourceSet set = rsManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true))
            {
                foreach (System.Collections.DictionaryEntry res in set)
                {
                    TextBox1.AppendText(res.Key.ToString());
                    TextBox1.AppendText("\t");
                    TextBox1.AppendText(res.Value.GetType().ToString());
                    TextBox1.AppendText("\r");

                }
            }


        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 w = new Window2();
            w.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window4 w = new Window4();
            w.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window3 w = new Window3();
            w.Show();
        }
    }
}
