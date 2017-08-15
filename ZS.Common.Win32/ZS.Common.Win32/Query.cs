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


        #region 获取安装软件列表

        /// <summary>
        /// 获取已安装的软件列表。不包含系统组件与Windows更新
        /// </summary>
        /// <returns></returns>
        public static List<InstalledApp> GetInstalledApps()
        {
            List<InstalledApp> result = new List<InstalledApp>();

            // 注册表


        }



        #endregion


    }
}
