using Microsoft.VisualStudio.TestTools.UnitTesting;
using KK.WX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WX.Tests
{
    [TestClass()]
    public class ConfigTests
    {
        [TestMethod()]
        public void InitTest()
        {
            KK.WX.Config.Init("wx41011056bea66e5e", "7e8e0d7b60649112a6df3395876d5725", "gh_a67b1140a810", "http://www.sk-zx.com/wx/system/ReadAccessToken");
            for (Int32 i = 0; i < 1; i++)
            {
                String x = KK.WX.Config.AccessToken;
                String m = KK.WX.Config.AccessTokenError;
                Console.WriteLine(x);
                Console.WriteLine(m);
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}