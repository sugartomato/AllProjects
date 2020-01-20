using Microsoft.VisualStudio.TestTools.UnitTesting;
using KK.Common.Win;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.Common.Win.Tests
{
    [TestClass()]
    public class ImageHelperTests
    {
        [TestMethod()]
        public void CompressImageTest()
        {
            ImageHelper.CompressImage(@"D:\OneDrive\Photos\[20190120] - 民航博物馆\IMG_20190120_104636.jpg", 50);
        }
    }
}