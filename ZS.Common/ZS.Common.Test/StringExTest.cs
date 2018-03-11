using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZS.Common;
using System.Collections;
using System.Collections.Generic;

namespace ZS.Common.Test
{
    [TestClass]
    public class StringExTest
    {
        [TestMethod]
        public void ToMD5()
        {

            string source = System.Guid.NewGuid().ToString("N");
            string md5 = source.ToMD5();


        }

        [TestMethod]
        public void IsIPv4AddressTest()
        {
            string ip = "1.1.01.1";
            Boolean r = ip.IsIPv4Address();

            Console.WriteLine(r);
        }

        [TestMethod]
        public void IsMacAddressTest()
        {
            string mac = "";
            Boolean r = mac.IsMacAddress();
            Console.WriteLine(r);

        }

        [TestMethod]
        public void ToListOfStringTest()
        {
            string str = "1,2,3,4,5,5,6,7,7,10>8,";
            List<String> r = null;
            r = str.ToListOfString(",");

            foreach (string s in r)
            {
                Console.WriteLine(s);
            }
        }

        [TestMethod]
        public void ToListOfInt32Test()
        {
            string str = "1,2,3,4,5,5,6,7,7,a";
            List<Int32> r = null;
            r = str.ToListOfInt32(",");

            foreach (Int32 s in r)
            {
                Console.WriteLine(s);
            }
        }


        [TestMethod]
        public void IsInt32Test()
        {
            Console.WriteLine("aa".IsInt32());
        }

    }
}
