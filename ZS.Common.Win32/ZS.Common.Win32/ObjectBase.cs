using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32
{
    /// <summary>
    /// 对象基础类
    /// </summary>
    public class ObjectBase
    {

        /// <summary>
        /// 输出该类的所有属性的名称、值、类型
        /// </summary>
        /// <returns></returns>
        public string ToDebugString()
        {
            return ToDebugString(null);
        }

        /// <summary>
        /// 输出该类中指定属性的的所有属性的名称、值、类型
        /// </summary>
        /// <param name="displayProps"></param>
        /// <returns></returns>
        public String ToDebugString(String[] displayProps)
        {
            Boolean _showAppointedProps = false;  // 是否只显示指定的属性
            if (displayProps != null && displayProps.Length > 0) _showAppointedProps = true;

            System.Reflection.PropertyInfo[] ps = this.GetType().GetProperties();
            if (ps == null || ps.Length == 0)
                return null;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*".PadLeft(30, '*'));
            foreach (var pro in ps)
            {
                if (_showAppointedProps && !displayProps.Contains(pro.Name)) continue;

                if (pro.PropertyType == typeof(System.String[]))
                {
                    object val = pro.GetValue(this, null);
                    if (val != null)
                    {

                        string strVal = string.Empty;
                        foreach (string item in val as string[])
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
