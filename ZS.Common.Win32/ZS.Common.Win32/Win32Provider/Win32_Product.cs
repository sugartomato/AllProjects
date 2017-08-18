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
        public UInt16 AssignmentType { get; set; }
        public String Caption { get; set; }
        public String Description { get; set; }
        public String IdentifyingNumber { get; set; }
        public String InstallDate { get; set; }
        /// <summary>
        /// Date that this product was installed on the system. This property does not require a value to indicate that the object is installed. For more information about WMI dates and times, see Date and Time Format.
        /// </summary>
        public DateTime? InstallDate2 { get; set; }
        /// <summary>
        /// Location of the installed product.
        /// </summary>
        public String InstallLocation { get; set; }
        public Int16 InstallState { get; set; }
        public String HelpLink { get; set; }
        public String HelpTelephone { get; set; }
        public String InstallSource { get; set; }
        public String Language { get; set; }
        public String LocalPackage { get; set; }
        public String Name { get; set; }
        public String PackageCache { get; set; }
        public String PackageCode { get; set; }
        public String PackageName { get; set; }
        public String ProductID { get; set; }
        public String RegOwner { get; set; }
        public String RegCompany { get; set; }
        public String SKUNumber { get; set; }
        public String Transforms { get; set; }
        public String URLInfoAbout { get; set; }
        public String URLUpdateInfo { get; set; }
        public String Vendor { get; set; }
        public UInt32 WordCount { get; set; }
        public String Version { get; set; }

    }
}
