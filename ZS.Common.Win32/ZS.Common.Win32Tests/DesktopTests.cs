using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZS.Common.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Tests
{
    [TestClass()]
    public class DesktopTests
    {
        [TestMethod()]
        public void GetSelectedCountTest()
        {
            IntPtr hwnd = Desktop.GetDefaultIntptr();
            Desktop d = new Desktop(hwnd);
            Int32 t = d.GetSelectedCount();
            Console.WriteLine(t.ToString());
        }

        [TestMethod()]
        public void GetItemsCountTest()
        {
            Desktop d = new Desktop();
            Int32 t = d.GetItemsCount();
            Console.WriteLine(t.ToString());
        }

        [TestMethod()]
        public void SelectItemTest()
        {
            IntPtr hwnd = Desktop.GetDefaultIntptr();
            Desktop d = new Desktop(hwnd);
            d.SelectItem(10);
        }

        [TestMethod()]
        public void GetItemTextTest()
        {
            IntPtr hwnd = Desktop.GetDefaultIntptr();
            Desktop d = new Desktop(hwnd);
            Int32 itemCount = d.GetItemsCount();
            String t = d.GetItemText(24);
            Console.WriteLine(t);
            for (Int32 i = 0; i < itemCount; i++)
            {
            }
        }

        [TestMethod()]
        public void SetItemLocationTest()
        {
            IntPtr hwnd = Desktop.GetDefaultIntptr();
            Desktop d = new Desktop(hwnd);
            for (Int32 i = 0; i < 5; i++)
            {
                d.SetItemLocation(i, new System.Drawing.Point(1440, i*100));
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}