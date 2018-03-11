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
    public class WXDefineTests
    {
        [TestMethod()]
        public void GetWXRedirectUrlTest()
        {
            String t = "http://www.sk-zx.com/wx/123/?d=d&m=4";
            String r = UrlHelper.GetWXAuthRedirectUrl(t);
            Console.WriteLine(r);
        }
    }
}