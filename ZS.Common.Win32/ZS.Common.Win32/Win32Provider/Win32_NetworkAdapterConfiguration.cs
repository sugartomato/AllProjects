using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Win32Provider
{
    /// <summary>
    /// 网卡配置信息
    /// </summary>
    public class Win32_NetworkAdapterConfiguration:Win32ProviderBase
    {

        /// <summary>
        /// Short textual description of the current object.
        /// </summary>
        public string Caption { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Identifier by which the current object is known.
        /// </summary>
        public string SettingID { get; set; }

        public UInt16 DefaultTTL { get; set; }
        public Boolean DHCPEnabled { get; set; }
        public string DHCPServer { get; set; }
        public string DNSDomain { get; set; }
        public string DNSHostName { get; set; }
        public UInt32 Index { get; set; }
        /// <summary>
        /// Index value that uniquely identifies the local network interface. The value in this property is the same as the value in the InterfaceIndex property in the instance of Win32_IP4RouteTable that represents the network interface in the route table.
        /// </summary>
        public UInt32 InterfaceIndex { get; set; }
        /// <summary>
        /// Array of all of the IP addresses associated with the current network adapter. This property can contain either IPv6 addresses or IPv4 addresses. For more information, see IPv6 and IPv4 Support in WMI.
        /// </summary>
        public string[] IPAddress { get; set; }

        /// <summary>
        /// Cost of using the configured routes for the IP bound adapter and is the weighted value for those routes in the IP routing table. If there are multiple routes to a destination in the IP routing table, the route with the lowest metric is used. The default value is 1.
        /// </summary>
        public UInt32 IPConnectionMetric { get; set; }
        /// <summary>
        /// If TRUE, TCP/IP is bound and enabled on this network adapter.
        /// </summary>
        public Boolean IPEnabled { get; set; }
        public string MACAddress { get; set; }
        public UInt32 MTU { get; set; }
    }
}
