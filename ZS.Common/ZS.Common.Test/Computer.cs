using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZS.Common.Test
{
    [TestClass]
    public class Computer
    {
        [TestMethod]
        public void SetComputerName()
        {
            String err = string.Empty;
            Boolean b = ZS.Common.Computer.SetComputerName("Sugartomato", ref err);
            Console.WriteLine(b);
            Console.WriteLine(err);
        }


    }
}
