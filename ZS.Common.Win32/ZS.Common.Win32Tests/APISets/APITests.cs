using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZS.Common.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Tests
{
    [TestClass()]
    public class APITests
    {
        [TestMethod()]
        public void FindWindowTest()
        {
            IntPtr hwnd = API.FindWindow(null, "无标题 - 记事本");
            if(hwnd != IntPtr.Zero)
            {
                //API.AnimateWindow(hwnd, 300, API.AnimateWindowType.AW_CENTER);
            }
            //Console.WriteLine( ZS.Common.Win32.API.FindWindow(null, "无标题 - 记事本"));
        }

        [TestMethod()]
        public void EnumWindowsTest()
        {
            Console.Clear();
            API.EnumWindowsProc ewp = new API.EnumWindowsProc(enumWindowProc);
            API.EnumWindows(ewp, 0);

            API.POINT pt = new API.POINT(100, 100);
            System.Drawing.Point pt1 = pt;
        }


        public Boolean enumWindowProc(IntPtr hwnd, Int32 lParam)
        {
            Boolean bln = API.IsWindowVisible(hwnd);
            if(bln)
            {
                Console.WriteLine(hwnd + ":" + GetWindowTest(hwnd) + "\t" + "ClassName:" + GetWindowClassName(hwnd));
            }
            return true;
        }

        private string GetWindowTest(IntPtr hwnd)
        {
            Int32 len = API.GetWindowTextLength(hwnd);
            StringBuilder sb = new StringBuilder("", len + 2);
            API.GetWindowText(hwnd, sb, len + 2);
            return sb.ToString();
        }

        private string GetWindowClassName(IntPtr hwnd)
        {
            StringBuilder sb = new StringBuilder(256);
            Int32 ret = API.GetClassName(hwnd, sb, sb.Capacity);
            if(ret != 0)
            {
                return sb.ToString();
            }
            else
            {
                return "获取失败。";
            }
        }

        [TestMethod()]
        public void sndPlaySoundTest()
        {
            Boolean b = API.sndPlaySound(@"C:\Windows\Media\Ring05.wav", API.PlaySoundFlags.SND_SYNC);
            Console.WriteLine(b);
        }
    }
}