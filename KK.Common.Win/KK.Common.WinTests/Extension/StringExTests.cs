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
    public class StringExTests
    {
        [TestMethod()]
        public void ToHexStringTest()
        {
            String t = "今天是个好日子！   lala  laa la la la";
            Console.WriteLine(t.ToHexString(System.Text.Encoding.Default));

            String m = t.ToHexString().FromHexString();
            Console.WriteLine(m);
        }

        [TestMethod()]
        public void SplitByFixedLengthTest()
        {
            String t = "11 223!>x 3445566778<!> 890x-!@#$%^&*()_+";
            String[] sr = t.SplitByFixedLength(5);
            foreach (var s in sr)
            {
                Console.WriteLine(s);
            }
        }
    }
}