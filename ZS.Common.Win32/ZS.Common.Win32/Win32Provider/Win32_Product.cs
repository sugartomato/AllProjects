using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Win32Provider
{
    /// <summary>
    /// The Win32_Product WMI class represents products as they are installed by Windows Installer. A product generally correlates to one installation package.
    /// </summary>
    public class Win32_Product:Win32ProviderBase
    {
        public string Caption { get; set; }
        public string Description { get; set; }
        public string IdentifyingNumber { get; set; }
    }
}
