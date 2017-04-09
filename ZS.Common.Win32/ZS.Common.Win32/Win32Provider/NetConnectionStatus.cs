using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Win32Provider
{
    /// <summary>
    /// 网络连接状态枚举
    /// </summary>
    public enum NetConnectionStatus : UInt16
    {
        Disconnected = 0,
        Connecting = 1,
        Connected = 2,
        Disconnecting = 3,
        HardwareNotPresent = 4,
        HardwareDisabled = 5,
        HardwareMalfunction = 6,
        MediaDisconnected = 7,
        Authenticating = 8,
        AuthenticationSucceeded = 9,
        AuthenticationFailed = 10,
        InvalidAddress = 11,
        CredentialsRequired = 12,
        Other = 65535

    }
}
