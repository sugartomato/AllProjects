using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reg = Microsoft.Win32;

namespace ZS.Common.Win32.Net
{
    /// <summary>
    /// 网卡操作
    /// </summary>
    public class NetworkAdapter
    {

        /// <summary>
        /// 根据网卡的连接名称获取网卡的序号。
        /// 如果指定的连接名称不存在，返回-1。
        /// </summary>
        /// <param name="pConnID"></param>
        /// <returns></returns>
        public static Int32 GetAdapterIndex_ByNetConnectionID(string pConnID)
        {
            List<Win32Provider.Win32_NetworkAdapter> list = Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapter>.GetAll();
            if(list == null || list.Count == 0)
                return -1;

            Win32Provider.Win32_NetworkAdapter obj = list.FirstOrDefault(o => o.NetConnectionID == pConnID);
            if(obj == null)
                return -1;

            return (Int32)obj.Index;
        }

        /// <summary>
        /// 根据网卡MAC地址获取网卡序号。mac的格式为xx:xx:xx:xx:xx:xx
        /// 如果指定的连接名称不存在，返回-1。
        /// </summary>
        /// <param name="pMac"></param>
        /// <returns></returns>
        public static Int32 GetAdapterIndex_ByMacAddress(string pMac)
        {
            List<Win32Provider.Win32_NetworkAdapter> list = Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapter>.GetAll();
            if(list == null || list.Count == 0)
                return -1;

            Win32Provider.Win32_NetworkAdapter obj = list.FirstOrDefault(o => o.MACAddress == pMac.ToUpper());
            if(obj == null)
                return -1;

            return (Int32)obj.Index;
        }


        /// <summary>
        /// 获取当前活动着的网络链接的名称。
        /// </summary>
        /// <returns></returns>
        public static string GetActiveConnectionID()
        {
            List<Win32Provider.Win32_NetworkAdapterConfiguration> list = Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapterConfiguration>.GetAll();
            if(list == null || list.Count == 0)
                return string.Empty;

            Win32Provider.Win32_NetworkAdapterConfiguration obj = list.FirstOrDefault(o => o.IPEnabled == true);
            if(obj == null)
                return string.Empty;

            // 根据MAC地址，找到连接的名称

            List<Win32Provider.Win32_NetworkAdapter> listAdapters = Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapter>.GetAll();
            if(listAdapters == null || listAdapters.Count == 0)
                return string.Empty;

            Win32Provider.Win32_NetworkAdapter objAdapter = listAdapters.FirstOrDefault(o => o.MACAddress == obj.MACAddress);
            if(obj == null)
                return string.Empty;

            return objAdapter.NetConnectionID;

        }

        /// <summary>
        /// 获取所有不为空的网络连接ID。
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllConnectionID()
        {
            // 根据MAC地址，找到连接的名称
            List<string> result = new List<string>();
            List<Win32Provider.Win32_NetworkAdapter> listAdapters = Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapter>.GetAll();
            if(listAdapters == null || listAdapters.Count == 0)
                return null;

            foreach(var item in listAdapters)
            {
                if(!string.IsNullOrEmpty(item.NetConnectionID))
                {
                    result.Add(item.NetConnectionID);
                }
            }

            if(result.Count > 0)
                return result.ToArray();

            return null;
        }



        #region 修改MAC地址

        /// <summary>
        /// 修改指定序号的网卡的MAC地址。
        /// </summary>
        /// <param name="pAdapterIndex">网卡序号</param>
        /// <param name="pMacAddress">网卡MAC地址</param>
        /// <returns></returns>
        public static Boolean ModifyMacAddress(Int32 pAdapterIndex, string pMacAddress)
        {
            // 网卡序号从0开始
            if(pAdapterIndex < 0)
                throw new ApplicationException("无效的网卡序号！");

            string strIndex = pAdapterIndex.ToString().PadLeft(4, '0');
            strIndex = strIndex.Substring(strIndex.Length - 4);

            // 网卡格式。长度为12。剔除里面的-或者：
            if (!String.IsNullOrEmpty(pMacAddress) && pMacAddress.Length > 0)
            {
                pMacAddress = pMacAddress.Trim().Replace(":", "").Replace("-", "").Replace(" ", "");
                pMacAddress = pMacAddress.ToUpper();
            }
            if (pMacAddress.Length > 0 && pMacAddress.Length != 12)
            {
                throw new ApplicationException("无效的MAC地址");
            }

            Reg.RegistryKey regRoot = Reg.Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\" + strIndex, true);
            Reg.RegistryKey regParams = regRoot.OpenSubKey(@"Ndi\params\NetworkAddress", true);

            string[] valNames = regRoot.GetValueNames();
            //先删除
            if(valNames.Contains("NetworkAddress"))
            {
                regRoot.DeleteValue("NetworkAddress");
                regParams.SetValue("Default", "");
            }

            if(!string.IsNullOrEmpty(pMacAddress) && pMacAddress.Length > 0)
            {
                regRoot.SetValue("NetworkAddress", pMacAddress);
                regParams.SetValue("Default", pMacAddress);
            }

            //Console.WriteLine(regRoot.GetValue("InfPath").ToString());
            return true;
        }

        /// <summary>
        /// 修改指定连接名称的网卡的MAC地址
        /// </summary>
        /// <param name="pConnID">连接名称</param>
        /// <param name="pMacAddress">MAC地址</param>
        /// <returns></returns>
        public static Boolean ModifyMacAddress_ByConnectionID(string pConnID, string pMacAddress)
        {
            Int32 index = GetAdapterIndex_ByNetConnectionID(pConnID);
            if(index == -1)
            {
                throw new ApplicationException("指定连接名称的网卡不存在!");
            }

            return ModifyMacAddress(index, pMacAddress);
        }

        #endregion

        #region 获取MAC地址

        /// <summary>
        /// 根据连接名称获取MAC地址
        /// </summary>
        /// <param name="pConnID">网卡连接名称</param>
        /// <returns></returns>
        public static string GetMACAddress(string pConnID)
        {
            List<Win32Provider.Win32_NetworkAdapter> list = Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapter>.GetAll();
            if(list == null || list.Count == 0)
                return string.Empty;

            Win32Provider.Win32_NetworkAdapter obj = list.FirstOrDefault(o => o.NetConnectionID == pConnID);
            if(obj == null)
                return string.Empty;

            return obj.MACAddress;
        }

        #endregion

        #region 获取IP地址


        /// <summary>
        /// 获取指定连接名称的IPv4地址
        /// </summary>
        /// <param name="pConnID"></param>
        /// <returns></returns>
        public static string[] GetIPV4Addresses(string pConnID)
        {

            // 根据名称获取网卡序号
            List<Win32Provider.Win32_NetworkAdapter> list = Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapter>.GetAll();
            if(list == null || list.Count == 0)
                return null;

            Win32Provider.Win32_NetworkAdapter obj = list.FirstOrDefault(o => o.NetConnectionID == pConnID);
            if(obj == null)
                return null;


            // 根据网卡MAC地址获取网卡信息
            List<Win32Provider.Win32_NetworkAdapterConfiguration> listConfig = Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapterConfiguration>.GetAll();
            if(listConfig == null || listConfig.Count == 0)
                return null;


            Win32Provider.Win32_NetworkAdapterConfiguration objConfig = null;
            foreach(var config in listConfig)
            {
                if(config.MACAddress == obj.MACAddress && config.IPAddress != null && config.IPAddress.Length > 0)
                {
                    objConfig = config;
                }
            }

            if(objConfig == null || objConfig.IPAddress == null || objConfig.IPAddress.Length == 0)
                return null;

            // 返回IP地址
            List<string> result = new List<string>();

            // 冒号为IPv6，.为IPv4
            foreach(string ip in objConfig.IPAddress)
            {
                if(ip.Contains("."))
                    result.Add(ip);
            }


            if(result.Count > 0)
            {
                return result.ToArray();
            }

            return null;


        }

        /// <summary>
        /// 获取本机活动网卡的IPv4地址
        /// </summary>
        /// <returns></returns>
        public static string[] GetIPV4Addresses()
        {
            List<Win32Provider.Win32_NetworkAdapterConfiguration> list = Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapterConfiguration>.GetAll();
            if(list == null || list.Count == 0)
                return null;


            Win32Provider.Win32_NetworkAdapterConfiguration obj = list.FirstOrDefault(o => o.IPEnabled == true);
            if(obj == null)
                return null;



            //// 返回IP地址
            //List<string> result = new List<string>();

            //// 冒号为IPv6，.为IPv4
            //foreach(string ip in objConfig.IPAddress)
            //{
            //    if(ip.Contains("."))
            //        result.Add(ip);
            //}


            //if(result.Count > 0)
            //{
            //    return result.ToArray();
            //}

            return null;

        }

        #endregion

        #region 网卡启用/禁用

        /// <summary>
        /// 根据网卡连接ID启用网卡
        /// </summary>
        /// <param name="pConnID">网卡连接ID</param>
        /// <returns></returns>
        public static Boolean Enable_ByConnectionID(string pConnID)
        {
            List<Win32Provider.Win32_NetworkAdapter> list = Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapter>.GetAll();
            if(list == null || list.Count == 0)
                return false;

            Win32Provider.Win32_NetworkAdapter obj = list.FirstOrDefault(o => o.NetConnectionID == pConnID);
            if(obj == null)
                return false;

            return obj.Enable();
        }


        /// <summary>
        /// 根据网卡连接ID禁用网卡
        /// </summary>
        /// <param name="pConnID">网卡连接ID</param>
        /// <returns></returns>
        public static Boolean Disable_ByConnectionID(string pConnID)
        {
            List<Win32Provider.Win32_NetworkAdapter> list = Win32Provider.ProviderHelper<Win32Provider.Win32_NetworkAdapter>.GetAll();
            if(list == null || list.Count == 0)
                return false;

            Win32Provider.Win32_NetworkAdapter obj = list.FirstOrDefault(o => o.NetConnectionID == pConnID);
            if(obj == null)
                return false;

            return obj.Disable();
        }

        #endregion

    }
}
