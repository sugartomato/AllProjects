using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZS.Common.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Tests
{
    [TestClass()]
    public class RegHelperTests
    {
        [TestMethod()]
        public void ExportTest()
        {
            Boolean result = RegHelper.Export(@"HKLM\SOFTWARE\CANON", @":\canon.reg", true);
            Console.WriteLine(result);
        }


        [TestMethod()]
        public void RegOpenKeyExTest()
        {
            IntPtr result = IntPtr.Zero;
            API.RegOpenKeyEx((IntPtr)Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\Google\Chrome", 0, API.RegSamEnum.KEY_READ, ref result);
            Console.WriteLine(result.ToString());
        }

        [TestMethod()]
        public void RegQueryInfoKeyTest()
        {
            IntPtr keyHandle = IntPtr.Zero;
            API.RegOpenKeyEx((IntPtr)Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Kingsoft Office", 0, API.RegSamEnum.KEY_READ, ref keyHandle);

            System.Runtime.InteropServices.ComTypes.FILETIME fTime = default(System.Runtime.InteropServices.ComTypes.FILETIME);
            DateTime dt1 = new DateTime(((long)fTime.dwHighDateTime) << 32 | (uint)fTime.dwLowDateTime);
            Console.WriteLine(dt1.ToString());
            Int32 result = 0;
            result = API.RegQueryInfoKey((IntPtr)keyHandle, null, 0, (IntPtr)0, (IntPtr)0, (IntPtr)0, (IntPtr)0, (IntPtr)0, (IntPtr)0, (IntPtr)0, (IntPtr)0, ref fTime);

            Console.WriteLine(result);
            long hft2 = (((long)fTime.dwHighDateTime) << 32) | ((uint)fTime.dwLowDateTime);
            Console.WriteLine(DateTime.FromFileTimeUtc(hft2).ToString());
            //API._SYSTEMTIME dt3 = new API._SYSTEMTIME();
            //API.FileTimeToSystemTime(ref fTime, out dt3);
            //Console.WriteLine(dt3.ToString())12;

        }

        [TestMethod()]
        public void GetRegKeyLastWritetimeTest()
        {
            DateTime t1 = RegHelper.GetRegKeyLastWritetime(Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\ILST_22_0_0");
            Console.WriteLine(t1.ToString());

            DateTime t2 = RegHelper.GetRegKeyLastWritetime(Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\WinRAR");
            Console.WriteLine(t2.ToString());

            DateTime t3 = RegHelper.GetRegKeyLastWritetime(Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\7-Zip");
            Console.WriteLine(t3.ToString());
        }
    }
}