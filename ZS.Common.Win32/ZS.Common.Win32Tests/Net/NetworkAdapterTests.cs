using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZS.Common.Win32.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Net.Tests
{
    [TestClass()]
    public class NetworkAdapterTests
    {
        [TestMethod()]
        public void GetAdapterIndex_ByNetConnectionIDTest()
        {
            Int32 index = Win32.Net.NetworkAdapter.GetAdapterIndex_ByNetConnectionID("以太网");
            Console.WriteLine(index.ToString());
        }

        [TestMethod()]
        public void ModifyMacAddress_ByConnectionIDTest()
        {
            //78:45:C4:AC:26:81
            NetworkAdapter.ModifyMacAddress(1, "");
        }

        [TestMethod()]
        public void GetActiveConnectionIDTest()
        {
            Console.WriteLine(NetworkAdapter.GetActiveConnectionID());
        }

        [TestMethod()]
        public void GetIPV4AddressesTest()
        {
            string[] ips = NetworkAdapter.GetIPV4Addresses(NetworkAdapter.GetActiveConnectionID());
            if(ips != null && ips.Length > 0)
            {
                foreach(string ip in ips)
                {
                    Console.WriteLine(ip);
                }
            }
        }

        [TestMethod()]
        public void GetConnectionIDsTest()
        {
            string[] ids = NetworkAdapter.GetAllConnectionID();
            if(ids != null && ids.Length > 0)
            {
                foreach(string id in ids)
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}