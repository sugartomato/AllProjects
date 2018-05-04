using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WechatAuto
{
    public class Common
    {

        public static String GetDeviceID()
        {
            return "e" + GetRandom(15);
        }

        public static String GetRandom(Int32 length)
        {
            String result = String.Empty;
            Random rnd = new Random();
            String number = "0123456789";
            for (Int32 i = 0; i < length; i++)
            {
                result += number.Substring(rnd.Next(0, number.Length - 1), 1);
            }
            return result;
        }

        public static Int64 GetTimeStamp()
        {
            DateTime de = DateTime.Now;
            DateTime dS = new DateTime(1970, 1, 1, 0, 0, 0, DateTime.Now.Kind);
            return (Int64)((de - dS).TotalMilliseconds);
        }

        public static String GetTimeStampF()
        {
            return (~(uint)GetTimeStamp()).ToString();
        }

        public static String GetTimeStampF(Int64 stamp)
        {
            return (~(uint)stamp).ToString();
        }
        public static System.Drawing.Image ConvertFromBase64String(String imgStr)
        {
            byte[] imgBytes = Convert.FromBase64String(imgStr);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return img;

        }

        /// <summary>
        /// 调试信息
        /// </summary>
        public static System.Collections.Queue DebugMessage { get; set; } = new System.Collections.Queue();
        public static System.Collections.Queue UserMessage { get; set; } = new System.Collections.Queue();

        /// <summary>
        /// 返回随机的程序执行间隔，单位为毫秒
        /// </summary>
        /// <param name="minSec"></param>
        /// <param name="maxSec"></param>
        /// <returns></returns>
        public static Int32 RandomSleep(Int32 minSec, Int32 maxSec)
        {
            return (Int32)TimeSpan.FromSeconds(new Random().Next(minSec, maxSec)).TotalMilliseconds;
        }

        /// <summary>
        /// 在5-15秒之间随机返回一个时间间隔，单位为毫秒。
        /// </summary>
        /// <returns></returns>
        public static Int32 RandomSleep()
        {
            return RandomSleep(5, 15);
        }
    }
}
