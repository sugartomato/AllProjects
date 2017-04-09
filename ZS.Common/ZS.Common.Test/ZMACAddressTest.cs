using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZS.Common.Test
{
    [TestClass]
    public class ZMACAddressTest
    {

        [TestMethod]
        public void TryParseTest()
        {
            string mac = "000102030405";
            ZMACAddress outObj = null;
            if (ZMACAddress.TryParse(mac, ref outObj))
            {
                Console.Write("有效！");
            }
            else
            {
                Console.Write("无效！");
            }


        }

    }
}
