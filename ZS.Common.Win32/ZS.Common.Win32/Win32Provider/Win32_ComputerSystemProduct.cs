using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32.Win32Provider
{
    /// <summary>
    /// The Win32_ComputerSystemProduct WMI class represents a product. This includes software and hardware used on this computer system.
    /// </summary>
    /// <remarks>
    /// The Win32_ComputerSystemProduct class is derived from CIM_Product.
    /// </remarks>
    public class Win32_ComputerSystemProduct:Win32ProviderBase
    {

        /// <summary>
        /// Short textual description for the product.
        /// This property is inherited from CIM_Product.
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// Textual description of the product.
        /// This property is inherited from CIM_Product.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Product identification, such as a serial number on software, a die number on a hardware chip, or (for noncommercial products) a project number.
        /// This property is inherited from CIM_Product.
        /// </summary>
        public string IdentifyingNumber { get; set; }
        /// <summary>
        /// Product's stock-keeping unit (SKU) information.
        /// This property is inherited from CIM_Product.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Product's stock-keeping unit (SKU) information.
        /// This property is inherited from CIM_Product.
        /// </summary>
        public string SKUNumber { get; set; }
        /// <summary>
        /// Name of the product's supplier, or the entity selling the product (the manufacturer, reseller, OEM, and so on).
        /// This property is inherited from CIM_Product.
        /// </summary>
        public string Vendor { get; set; }
        /// <summary>
        /// Product version information.
        /// This property is inherited from CIM_Product.
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Universally unique identifier (UUID) for this product. A UUID is a 128-bit identifier that is guaranteed to be different from other generated UUIDs. If a UUID is not available, a UUID of all zeros is used.
        /// This value comes from the UUID member of the System Information structure in the SMBIOS information.
        /// </summary>
        public string UUID { get; set; }
    }
}
