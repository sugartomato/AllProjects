using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KK.Common.Win
{
    /// <summary>
    /// String类扩展功能
    /// </summary>
    public static class StringEx
    {

        public static List<Int32> ToListOfInt(this String s, Char separator)
        {
            if (String.IsNullOrEmpty(s)) return null;
            List<Int32> result = new List<int>();
            String[] arrs = s.Split(new Char[] { separator });
            foreach (String t in arrs)
            {
                if (!String.IsNullOrEmpty(t))
                {
                    Int32 i = Int32.Parse(t);
                    result.Add(i);
                }
            }
            return result;
        }

        public static List<String> ToListOfString(this String s, Char separator)
        {
            throw new ApplicationException("未实现的方法");
        }


        #region 格式验证

        public static Boolean IsIPv4Address(this String s)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(s, @"^(([1-9]{1}[0-9]{0,1}|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.){3}([1-9]{1}[0-9]{0,1}|1[0-9][0-9]|2[0-4][0-9]|25[0-5])$");
        }

        public static Boolean IsMacAddress(this String s)
        {
            if (String.IsNullOrEmpty(s) || s.Length == 0) return false;
            s = s.Replace(":", "-");
            return System.Text.RegularExpressions.Regex.IsMatch(s, @"^([\da-fA-F]{2})(([-:]{0,1}[\da-fA-F]{2}){5})$");
        }

        public static Boolean IsCellPhoneNumber(this String s)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(s, @"^[1]{1}[0-9]{10}$");
        }


        #endregion

        #region 格式转换

        public static String ToHexString(this String s)
        {
            return ToHexString(s, System.Text.Encoding.Default, false);
        }

        public static String ToHexString(this String s, System.Text.Encoding encoding)
        {
            return ToHexString(s, encoding, false);
        }

        public static String ToHexString(this String s, System.Text.Encoding encoding, Boolean addBackslash = false)
        {
            if (String.IsNullOrEmpty(s)) return String.Empty;
            if (encoding == null) encoding = System.Text.Encoding.Default;
            if (String.IsNullOrEmpty(s) || s.Length == 0) return String.Empty;
            Byte[] b = encoding.GetBytes(s);
            String[] s1 = new string[b.Length];
            for (Int32 i = 0; i < b.Length; i++)
            {
                s1[i] = b[i].ToString("x");
            }

            String result = String.Empty;
            for (Int32 i = 0; i < s1.Length; i++)
            {
                result += addBackslash ? @"\" + s1[i].ToUpper() : s1[i].ToUpper();
            }

            return result;
        }


        public static String FromHexString(this String s)
        {
            return FromHexString(s, System.Text.Encoding.Default);
        }
        public static String FromHexString(this String s, System.Text.Encoding encoding)
        {

            String result = String.Empty;
            String[] sa = s.SplitByFixedLength(2);
            Byte[] b = new Byte[sa.Length];
            for (Int32 i = 0; i < sa.Length; i++)
            {
                b[i] = Convert.ToByte(sa[i], 16);
            }

            result = encoding.GetString(b);

            return result;
        }

        #endregion

        #region 合并与拆分

        /// <summary>
        /// 按照指定的单位长度将字符串切分为数组
        /// </summary>
        /// <param name="s"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static String[] SplitByFixedLength(this String s, Int32 len)
        {
            return System.Text.RegularExpressions.Regex.Replace(s, @"(?<=.{" + len + "}).{1," + len + "}", "x<!>x$0").Split(new String[] { "x<!>x" }, StringSplitOptions.None);
        }

        #endregion

    }
}
