using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WX
{
    internal class Common : WXBase
    {
        public static String BaseAPIUrl
        {
            get {
                return "https://api.weixin.qq.com/";
            }
        }

        public static Int32 TimeToUnixTimeStamp(DateTime date)
        {
            return (Int32)date.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

    }
}
