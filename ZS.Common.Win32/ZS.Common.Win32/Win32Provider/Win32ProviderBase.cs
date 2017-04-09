using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Win32Provider
{
    /// <summary>
    /// 基础类
    /// </summary>
    public class Win32ProviderBase
    {

        public Win32ProviderBase()
        { }

        /// <summary>
        /// 改类型的ManagementObject数据
        /// </summary>
        public System.Management.ManagementObject ManageObject { get; set; }

        /// <summary>
        /// 输出该类的所有属性的名称、值、类型
        /// </summary>
        /// <returns></returns>
        public string ToDebugString()
        {
            System.Reflection.PropertyInfo[] ps = this.GetType().GetProperties();
            if(ps == null || ps.Length == 0)
                return null;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*".PadLeft(30, '*'));
            foreach(var pro in ps)
            {
                if(pro.PropertyType == typeof(System.String[]))
                {
                    object val = pro.GetValue(this, null);
                    if(val != null)
                    {

                        string strVal = string.Empty;
                        foreach(string item in val as string[])
                        {
                            strVal += "|" + item;
                        }

                        sb.AppendLine(string.Format("[{0}]\t[{1}]\t[{2}]", pro.Name, strVal, pro.PropertyType.FullName));
                    }
                    else
                    {
                        sb.AppendLine(string.Format("[{0}]\t[{1}]\t[{2}]", pro.Name, "", pro.PropertyType.FullName));
                    }
                }
                else
                {
                    sb.AppendLine(string.Format("[{0}]\t[{1}]\t[{2}]", pro.Name, pro.GetValue(this, null), pro.PropertyType.FullName));
                }

            }

            return sb.ToString();
        }
    }
}
