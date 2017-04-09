using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZS.Common.Test
{
    [TestClass]
    public class HardDevice_NetworkAdapterTest
    {
        [TestMethod]
        public void GetAllMacAddress()
        {
            string[] ss = ZS.Common.HardDevice.NetworkAdapter.GetAllMacAddress();

            Console.WriteLine(ss.ToString());

        }


    }
}
