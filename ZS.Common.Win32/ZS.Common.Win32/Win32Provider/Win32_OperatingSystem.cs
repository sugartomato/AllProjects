using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Win32Provider
{
    /// <summary>
    /// The Win32_OperatingSystem WMI class represents a Windows-based operating system installed on a computer.
    /// </summary>
    public class Win32_OperatingSystem:Win32ProviderBase
    {
        /// <summary>
        /// Name of the disk drive from which the Windows operating system starts.
        /// Example: "\\Device\Harddisk0"
        /// </summary>
        public String BootDevice { get; set; } = String.Empty;

        /// <summary>
        /// Build number of an operating system. It can be used for more precise version information than product release version numbers.
        /// Example: "1381"
        /// </summary>
        public String BuildNumber { get; set; } = String.Empty;

        /// <summary>
        /// Short description of the object—a one-line string. The string includes the operating system version. For example, "Microsoft Windows 7 Enterprise ". This property can be localized.
        /// Windows Vista and Windows 7:  This property may contain trailing characters. For example, the string "Microsoft Windows 7 Enterprise " (trailing space included) may be necessary to retrieve information using this property.
        /// </summary>
        public String Caption { get; set; } = String.Empty;

        /// <summary>
        /// NULL-terminated string that indicates the latest service pack installed on a computer. If no service pack is installed, the string is NULL.
        /// Example: "Service Pack 3"
        /// </summary>
        public String CSDVersion { get; set; } = String.Empty;

        /// <summary>
        /// Name of the scoping computer system.
        /// </summary>
        public String CSName { get; set; } = String.Empty;

        /// <summary>
        /// Description of the Windows operating system. Some user interfaces for example, those that allow editing of this description, limit its length to 48 characters.
        /// </summary>
        public String Description { get; set; } = String.Empty;

        /// <summary>
        /// Date object was installed. This property does not require a value to indicate that the object is installed.
        /// </summary>
        public DateTime InstallDate { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Date and time the operating system was last restarted.
        /// </summary>
        public DateTime LastBootUpTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Operating system instance within a computer system.
        /// </summary>
        public String Name { get; set; } = String.Empty;

        /// <summary>
        /// Operating system product serial identification number.
        /// Example: "10497-OEM-0031416-71674"
        /// </summary>
        public String SerialNumber { get; set; } = String.Empty;

        /// <summary>
        /// Version number of the operating system.
        /// Example: "4.0"
        /// </summary>
        public UInt32 SuiteMask { get; set; } = 0;

        public String Version { get; set; } = String.Empty;
    }

    /// <summary>
    /// Bit flags that identify the product suites available on the system.
    /// </summary>
    public enum Win32_OperatingSystem_SuiteMaskEnum:UInt32
    {
        Small_Business = 1,
        Enterprise = 2,
        BackOffice = 4,
        Communications = 8,
        Terminal_Services = 16,
        Small_Business_Restricted = 32,
        Embedded_Edition = 64,
        Datacenter_Edition = 128,
        Single_User = 256,
        Home_Edition = 512,
        Web_Server_Edition = 2048
    }

}
