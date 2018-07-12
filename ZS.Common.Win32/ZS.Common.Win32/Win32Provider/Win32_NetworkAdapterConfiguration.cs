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

        public UInt16 DefaultTTL { get; set; }
        /// <summary>
        /// If TRUE, the dynamic host configuration protocol (DHCP) server automatically assigns an IP address to the computer system when establishing a network connection.
        /// </summary>
        public Boolean DHCPEnabled { get; set; }
        /// <summary>
        /// Expiration date and time for a leased IP address that was assigned to the computer by the dynamic host configuration protocol (DHCP) server.
        /// Example: 20521201000230.000000000
        /// </summary>
        public DateTime DHCPLeaseExpires { get; set; }
        /// <summary>
        /// Date and time the lease was obtained for the IP address assigned to the computer by the dynamic host configuration protocol (DHCP) server.
        /// Example: 19521201000230.000000000
        /// </summary>
        public DateTime DHCPLeaseObtained { get; set; }
        /// <summary>
        /// IP address of the dynamic host configuration protocol (DHCP) server.
        /// Example: "10.55.34.2"
        /// </summary>
        public string DHCPServer { get; set; }
        /// <summary>
        /// Organization name followed by a period and an extension that indicates the type of organization, such as "microsoft.com". 
        /// The name can be any combination of the letters A through Z, the numerals 0 through 9, and the hyphen (-), plus the period (.) character used as a separator.
        /// </summary>
        public string DNSDomain { get; set; }
        /// <summary>
        /// Host name used to identify the local computer for authentication by some utilities. 
        /// Other TCP/IP-based utilities can use this value to acquire the name of the local computer. 
        /// Host names are stored on DNS servers in a table that maps names to IP addresses for use by DNS. 
        /// The name can be any combination of the letters A through Z, the numerals 0 through 9, and the hyphen (-), plus the period (.) character used as a separator. 
        /// By default, this value is the Microsoft networking computer name, but the network administrator can assign another host name without affecting the computer name.
        /// </summary>
        public string DNSHostName { get; set; }
        /// <summary>
        /// Array of integer cost metric values (ranging from 1 to 9999) to be used in calculating the fastest, most reliable, or least resource-intensive routes. 
        /// This argument has a one-to-one correspondence with the DefaultIPGateway property.
        /// </summary>
        public UInt16 GatewayCostMetric { get; set; }
        /// <summary>
        /// Index number of the Windows network adapter configuration. 
        /// The index number is used when there is more than one configuration available.
        /// </summary>
        public UInt32 Index { get; set; }
        /// <summary>
        /// Index value that uniquely identifies the local network interface. 
        /// The value in this property is the same as the value in the InterfaceIndex property in the instance of Win32_IP4RouteTable that represents the network interface in the route table.
        /// </summary>
        public UInt32 InterfaceIndex { get; set; }
        /// <summary>
        /// Array of all of the IP addresses associated with the current network adapter. 
        /// This property can contain either IPv6 addresses or IPv4 addresses. 
        /// For more information, see IPv6 and IPv4 Support in WMI.
        /// </summary>
        public string[] IPAddress { get; set; }

        /// <summary>
        /// Cost of using the configured routes for the IP bound adapter and is the weighted value for those routes in the IP routing table. 
        /// If there are multiple routes to a destination in the IP routing table, the route with the lowest metric is used. 
        /// The default value is 1.
        /// </summary>
        public UInt32 IPConnectionMetric { get; set; }
        /// <summary>
        /// If TRUE, TCP/IP is bound and enabled on this network adapter.
        /// </summary>
        public Boolean IPEnabled { get; set; }
        /// <summary>
        /// Array of all of the subnet masks associated with the current network adapter.
        /// Example: "255.255.0.0"
        /// </summary>
        public String IPSubnet { get; set; }
        /// <summary>
        /// Interval separating Keep Alive Retransmissions until a response is received.
        /// After a response is received, the delay until the next Keep Alive Transmission is again controlled by the value of KeepAliveTime. 
        /// The connection will be aborted after the number of retransmissions specified by TcpMaxDataRetransmissions have gone unanswered. 
        /// Default: 1000, Valid Range: 1 - 0xFFFFFFFF.
        /// </summary>
        public UInt32 KeepAliveInterval { get; set; }
        /// <summary>
        /// The KeepAliveTime property indicates how often the TCP attempts to verify that an idle connection is still intact by sending a Keep Alive Packet. 
        /// A remote system that is reachable will acknowledge the keep alive transmission. Keep Alive packets are not sent by default. 
        /// This feature may be enabled in a connection by an application. Default: 7,200,000 (two hours).
        /// </summary>
        public UInt32 KeepAliveTime { get; set; }
        /// <summary>
        /// Media Access Control (MAC) address of the network adapter. A MAC address is assigned by the manufacturer to uniquely identify the network adapter.
        /// Example: "00:80:C7:8F:6C:96"
        /// </summary>
        public string MACAddress { get; set; }
        /// <summary>
        /// Overrides the default Maximum Transmission Unit (MTU) for a network interface. 
        /// The MTU is the maximum packet size (including the transport header) that the transport will transmit over the underlying network. 
        /// The IP datagram can span multiple packets. The range of this value spans the minimum packet size (68) to the MTU supported by the underlying network.
        /// </summary>
        public UInt32 MTU { get; set; }
        /// <summary>
        /// Service name of the network adapter. This name is usually shorter than the full product name.
        /// Example: "Elnkii"
        /// </summary>
        public String ServiceName { get; set; }
        /// <summary>
        /// Identifier by which the current object is known.
        /// </summary>
        public String SettingID { get; set; }
    }
}
