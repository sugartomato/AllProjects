using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32
{
    /// <summary>
    /// 信息查询
    /// </summary>
    public class Query
    {
        /// <summary>
        /// 获取计算机的序列号
        /// </summary>
        /// <returns></returns>
        public static string GetIdentifyingNumber()
        {
            List<Win32Provider.Win32_ComputerSystemProduct> l = Win32Provider.ProviderHelper<Win32Provider.Win32_ComputerSystemProduct>.GetAll();
            if (l != null && l.Count > 0)
            {
                return l[0].IdentifyingNumber;
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取计算机名
        /// </summary>
        /// <returns></returns>
        public static string GetComputerName()
        {
            return Environment.MachineName;
        }


    }
}
