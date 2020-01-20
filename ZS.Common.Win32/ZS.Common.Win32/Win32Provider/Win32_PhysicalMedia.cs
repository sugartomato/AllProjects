using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Win32Provider
{
    /// <summary>
    /// 
    /// </summary>
    public class Win32_PhysicalMedia : Win32ProviderBase
    {
        /// <summary>
        ///     Short, one-line textual description of the object.
        /// </summary>
        public String Caption { get; set; }
        public String Description { get; set; }
        public DateTime InstallDate { get; set; }

        /// <summary>
        ///     Label by which the object is known. 
        ///     When subclassed, the Name property can be overridden to be a Key property.
        /// </summary>
        public String Name { get; set; }

        public String Status { get; set; }
        public String CreationClassName { get; set; }
        public String Manufacturer { get; set; }
        public String Model { get; set; }
        public String SKU { get; set; }
        public String SerialNumber { get; set; } = null;
        public String Tag { get; set; } = null;
        public String Version { get; set; }
        public String PartNumber { get; set; }
        public String OtherIdentifyingInfo { get; set; }
        public Boolean PoweredOn { get; set; }
        public Boolean Removable { get; set; }
        public Boolean Replaceable { get; set; }
        public Boolean HotSwappable { get; set; }
        public UInt64 Capacity { get; set; }
        public UInt16 MediaType { get; set; }
        public String MediaDescription { get; set; }
        public Boolean WriteProtectOn { get; set; }

        /// <summary>
        ///     If TRUE, the physical media is used for cleaning purposes and not data storage.
        /// </summary>
        public Boolean CleanerMedia { get; set; }

    }
}
