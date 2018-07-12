using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Win32Provider
{
    /// <summary>
    /// 
    /// </summary>
    [Win32ClassBind(className: "Win32_NetworkAdapter")]
    public class Win32_NetworkAdapter : Win32ProviderBase
    {
        /// <summary>
        /// 适配器类型
        /// </summary>
        [Win32FieldsBind(name: "AdapterType")]
        public string AdapterType { get; set; }
        /// <summary>
        /// 适配器类型ID
        /// </summary>
        public UInt16 AdapterTypeID { get; set; }

        public UInt16 Availability { get; set; }
        /// <summary>
        /// MAC地址
        /// </summary>
        public string MACAddress { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }
        public string DeviceID { get; set; }
        public UInt32 Index { get; set; }

        public DateTime InstallDate { get; set; }
        public UInt32 InterfaceIndex { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string NetConnectionID { get; set; }
        public UInt16 NetConnectionStatus { get; set; }
        public string Status { get; set; }
        public UInt16 StatusInfo { get; set; }

        #region 方法

        /// <summary>
        /// 禁用网卡。需要管理员权限运行
        /// </summary>
        /// <returns></returns>
        public Boolean Disable()
        {
            
            if(ManageObject == null)
            {
                throw new ApplicationException("未设置的ManagementObject对象");
            }

            try
            {
                object result = ManageObject.InvokeMethod("Disable", null);

                UInt32 r = UInt32.Parse(result.ToString());
                if(r == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                throw new ApplicationException("禁用网卡失败。", ex);
            }

        }


        /// <summary>
        /// 启用网卡。需要管理员权限运行
        /// </summary>
        /// <returns></returns>
        public Boolean Enable()
        {

            if(ManageObject == null)
            {
                throw new ApplicationException("未设置的ManagementObject对象");
            }

            try
            {
                object result = ManageObject.InvokeMethod("Enable", null);

                UInt32 r = UInt32.Parse(result.ToString());
                if(r == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                throw new ApplicationException("启用网卡失败。", ex);
            }

        }
        #endregion

        #region 定义

        /// <summary>Ethernet 802.3</summary>
        public const String AdapterType_Ethernet8023 = "Ethernet 802.3";
        public const String AdapterType_TokenRing8025 = "Token Ring 802.5";
        public const String AdapterType_FDDI = "Fiber Distributed Data Interface (FDDI)";
        public const String AdapterType_WAN = "Wide Area Network (WAN)";
        public const String AdapterType_LocalTalk = "LocalTalk";
        public const String AdapterType_EthernetusingDIXheaderformat = "Ethernet using DIX header format";
        public const String AdapterType_ARCNET = "ARCNET";
        public const String AdapterType_ARCNET8782 = "ARCNET (878.2)";
        public const String AdapterType_ATM = "ATM";
        public const String AdapterType_Wireless = "Wireless";
        public const String AdapterType_InfraredWireless = "Infrared Wireless";
        public const String AdapterType_Bpc = "Bpc";
        public const String AdapterType_CoWan = "CoWan";
        public const String AdapterType_1394 = "1394";

        #endregion
    }
}
