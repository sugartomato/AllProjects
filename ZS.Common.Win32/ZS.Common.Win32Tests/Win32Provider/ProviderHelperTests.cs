using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZS.Common.Win32.Win32Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Win32Provider.Tests
{
    [TestClass()]
    public class ProviderHelperTests
    {
        [TestMethod()]
        public void GetAllTest_Win32_NetworkAdapterConfiguration()
        {
            List<Win32Provider.Win32_NetworkAdapterConfiguration> list = Win32.Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapterConfiguration>.GetAll();
            if(list != null && list.Count > 0)
            {
                foreach(var o in list)
                {
                    Console.WriteLine(o.ToDebugString());
                }
            }
        }

        [TestMethod()]
        public void GetAllTest_Win32_NetworkAdapter()
        {
            List<Win32Provider.Win32_NetworkAdapter> list = Win32.Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapter>.GetAll();
            if(list != null && list.Count > 0)
            {
                foreach(var o in list)
                {
                    Console.WriteLine(o.ToDebugString());
                }

                Boolean val = list.First(c => c.NetConnectionID == "以太网").Enable();
                Console.WriteLine(val);
            }
        }
        [TestMethod()]
        public void GetAllTest_Win32_Product()
        {
            List<Win32Provider.Win32_Product> list = Win32.Win32Provider.ProviderHelper<Win32Provider.Win32_Product>.GetAll();
            if (list != null && list.Count > 0)
            {
                foreach (var o in list)
                {
                    Console.WriteLine(o.ToDebugString());
                }
            }
        }

        [TestMethod()]
        public void GetAllTest_Win32_ComputerSystemProduct()
        {
            List<Win32Provider.Win32_ComputerSystemProduct> list = Win32.Win32Provider.ProviderHelper<Win32Provider.Win32_ComputerSystemProduct>.GetAll();
            if (list != null && list.Count > 0)
            {
                foreach (var o in list)
                {
                    Console.WriteLine(o.ToDebugString());
                }
            }
        }

        [TestMethod()]
        public void GetAllTest_Win32_OperatingSystem()
        {
            List<Win32Provider.Win32_OperatingSystem> list = Win32.Win32Provider.ProviderHelper<Win32Provider.Win32_OperatingSystem>.GetAll();
            if (list != null && list.Count > 0)
            {
                foreach (var o in list)
                {
                    Console.WriteLine(o.ToDebugString());
                }
            }
        }
        [TestMethod()]
        public void GetAllTest_Win32_Service()
        {
            List<Win32Provider.Win32_Service> list = Win32.Win32Provider.ProviderHelper<Win32Provider.Win32_Service>.GetAll();
            if (list != null && list.Count > 0)
            {
                foreach (var o in list)
                {
                    Console.WriteLine(o.ToDebugString());
                }
            }
        }

        [TestMethod()]
        public void GetAllTest_Win32_StartupCommand()
        {
            List<Win32Provider.Win32_StartupCommand> list = Win32.Win32Provider.ProviderHelper<Win32Provider.Win32_StartupCommand>.GetAll();
            if (list != null && list.Count > 0)
            {
                foreach (var o in list)
                {
                    Console.WriteLine(o.ToDebugString());
                }
            }
        }

    }
}