using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace ZS.Common.Win32.Win32Provider
{
    /// <summary>
    /// Win32 Provider信息查询
    /// </summary>
    public static class ProviderHelper<T> where T:Win32ProviderBase,new()
    {
        /// <summary>
        /// 获取指定的Win32类型的所有集合
        /// </summary>
        /// <returns></returns>
        public static List<T> GetAll()
        {

            // 获取字段名
            string className = string.Empty;
            Type type = typeof(T);
            className = type.Name;

            //Dictionary<String, Type> ps = GetPropertyTable();
            //if(ps == null || ps.Count == 0)
            //    return null;

            System.Reflection.PropertyInfo[] properties = type.GetProperties();
            if(properties == null || properties.Length == 0)
                return null;

            // 构造查询
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher();
            objSearcher.Query.QueryString = "SELECT * FROM " + className;
            ManagementObjectCollection objColl = objSearcher.Get();

            if(objColl != null && objColl.Count > 0)
            {
                List<T> result = new List<T>();

                foreach(var o in objColl)
                {
                    T tmpObj = new T();
                    // 遍历属性，进行属性赋值
                    foreach(var pro in properties)
                    {
                        if(pro.PropertyType == typeof(System.Management.ManagementObject))
                        {
                            pro.SetValue(tmpObj, o, null);
                        }
                        else
                        {
                            pro.SetValue(tmpObj, o.GetPropertyValue(pro.Name), null);
                        }
                    }
                    result.Add(tmpObj);
                }

                return result;
            }

            return null;
        }

        /// <summary>
        /// 获取该Win32类型中的所有字段与数据类型对照表
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static Dictionary<string, Type> GetPropertyTable()
        {
            Type type = typeof(T);
            Dictionary<string, Type> result = new Dictionary<string, Type>();

            System.Reflection.PropertyInfo[] properties = type.GetProperties();
            if(properties != null && properties.Length > 0)
            {
                foreach(var p in properties)
                {
                    result.Add(p.Name, p.GetType());
                }

                return result;
            }

            return null;
        }
    }
}
