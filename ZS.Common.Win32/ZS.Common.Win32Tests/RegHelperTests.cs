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
    }
}