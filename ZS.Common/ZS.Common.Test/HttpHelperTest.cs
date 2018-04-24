using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZS.Common.Test
{
    [TestClass]
    public class HttpHelperTest
    {
        [TestMethod]
        public void GetHtml1()
        {
            String url = "http://www.sina.com.cn";
            String html = HttpHelper.HttpHelper.GetHTML(url);
            Console.Write(html);
        }

    }
}
