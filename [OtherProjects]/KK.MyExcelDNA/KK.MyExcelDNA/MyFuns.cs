using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDna.Integration;

namespace KK.MyExcelDNA
{
    public static class MyFuns
    {
        [ExcelFunction(Description ="测试函数")]
        public static String HelloDNA(String name)
        {
            return "你说" + name;
        }
    }
}
