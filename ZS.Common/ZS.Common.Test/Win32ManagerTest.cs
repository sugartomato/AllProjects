using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace ZS.Common.Test
{
    [TestClass]
    public class Win32ManageClass
    {
        [TestMethod]
        public void GetAllProperty()
        {

            List<Dictionary<string, object>> list = ZS.Common.Win32Manager.Win32ManageAdapter.GetTargetAllInfo(Win32Manager.Win32Classes.ComputerSystemHardware.MassStorage.Win32_DiskDrive);
            if (list != null && list.Count > 0)
            {
                foreach (var l in list)
                {
                    Console.WriteLine();
                    if (l != null && l.Count > 0)
                    {
                        foreach (var o in l)
                        {
                            string val = o.Value != null ? o.Value.ToString() : "";
                            Console.WriteLine(o.Key + ":  " +  val);
                        }
                    }

                }
            }


        }
    }
}
