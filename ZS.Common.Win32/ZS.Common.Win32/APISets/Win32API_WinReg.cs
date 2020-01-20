using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ZS.Common.Win32
{

    public partial class API
    {

        [DllImport(DLLNameDef.advapi32, CharSet=CharSet.Auto, SetLastError =true)]
        public static extern Int32 RegQueryInfoKey(
            IntPtr hkey,
            StringBuilder lpClass,
            UInt32 lpcbClass,
            IntPtr lpReserved,
            IntPtr lpcSubKeys,
            IntPtr lpcbMaxSubKeyLen,
            IntPtr lpcbMaxClassLen,
            IntPtr lpcValues,
            IntPtr lpcbMaxValueNameLen,
            IntPtr lpcbMaxValueLen,
            IntPtr lpcbSecurityDescriptor,
            ref System.Runtime.InteropServices.ComTypes.FILETIME lpftLastWriteTime
            );


        /// <summary>
        ///     Opens the specified registry key. Note that key names are not case sensitive.
        ///     To perform transacted registry operations on a key, call the RegOpenKeyTransacted function.
        /// </summary>
        /// <param name="hKey">
        ///     A handle to an open registry key. This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function, 
        ///     or it can be one of the following predefined keys:
        ///     HKEY_CLASSES_ROOT HKEY_CURRENT_CONFIG HKEY_CURRENT_USER HKEY_LOCAL_MACHINE HKEY_USERS
        /// </param>
        /// <param name="lpSubKey"></param>
        /// <param name="ulOptions">
        ///     Specifies the option to apply when opening the key. Set this parameter to zero or the following:
        /// </param>
        /// <param name="samDesired">
        ///     A mask that specifies the desired access rights to the key to be opened. 
        ///     The function fails if the security descriptor of the key does not permit the requested access for the calling process. 
        ///     For more information, see Registry Key Security and Access Rights.
        /// </param>
        /// <param name="phkResult"></param>
        /// <returns></returns>
        [DllImport(DLLNameDef.advapi32, CharSet=CharSet.Auto, SetLastError = true)]
        public static extern Int32 RegOpenKeyEx(
            IntPtr hKey,
            String lpSubKey,
            Int32 ulOptions,
            RegSamEnum samDesired,
            ref IntPtr phkResult
            );


        /// <summary>
        ///     Closes a handle to the specified registry key.
        /// </summary>
        /// <param name="hKey">
        ///     A handle to the open key to be closed. The handle must have been opened by the RegCreateKeyEx, RegCreateKeyTransacted, RegOpenKeyEx, RegOpenKeyTransacted, or RegConnectRegistry function.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is ERROR_SUCCESS.
        ///     If the function fails, the return value is a nonzero error code defined in Winerror.h. 
        ///     You can use the FormatMessage function with the FORMAT_MESSAGE_FROM_SYSTEM flag to get a generic description of the error.
        /// </returns>
        /// <remarks>
        ///     The handle for a specified key should not be used after it has been closed, because it will no longer be valid. Key handles should not be left open any longer than necessary.
        ///     The RegCloseKey function does not necessarily write information to the registry before returning; it can take as much as several seconds for the cache to be flushed to the hard disk. If an application must explicitly write registry information to the hard disk, it can use the RegFlushKey function. RegFlushKey, however, uses many system resources and should be called only when necessary.
        /// </remarks>
        [DllImport(DLLNameDef.advapi32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Int32 RegCloseKey(IntPtr hKey);


        /// <summary>
        ///     The Windows security model enables you to control access to registry keys. For more information about security, see Access-Control Model.
        ///     You can specify a security descriptor for a registry key when you call the RegCreateKeyEx or RegSetKeySecurity function. If you specify NULL, the key gets a default security descriptor. The ACLs in a default security descriptor for a key are inherited from its direct parent key.
        ///     To get the security descriptor of a registry key, call the RegGetKeySecurity, GetNamedSecurityInfo, or GetSecurityInfo function.
        ///     The valid access rights for registry keys include the DELETE, READ_CONTROL, WRITE_DAC, and WRITE_OWNER standard access rights. Registry keys do not support the SYNCHRONIZE standard access right.
        ///     When you call the RegOpenKeyEx function, the system checks the requested access rights against the key's security descriptor. If the user does not have the correct access to the registry key, the open operation fails. If an administrator needs access to the key, the solution is to enable the SE_TAKE_OWNERSHIP_NAME privilege and open the registry key with WRITE_OWNER access. For more information, see Enabling and Disabling Privileges.
        ///     You can request the ACCESS_SYSTEM_SECURITY access right to a registry key if you want to read or write the key's system access control list (SACL). For more information, see Access-Control Lists (ACLs) and SACL Access Right.
        ///     To view the current access rights for a key, including the predefined keys, use the Registry Editor (Regedt32.exe). After navigating to the desired key, go to the Edit menu and select Permissions.
        /// </summary>
        [Flags]
        public enum RegSamEnum :Int32
        {
            /// <summary>
            ///     Combines the STANDARD_RIGHTS_REQUIRED, KEY_QUERY_VALUE, KEY_SET_VALUE, KEY_CREATE_SUB_KEY, KEY_ENUMERATE_SUB_KEYS, KEY_NOTIFY, and KEY_CREATE_LINK access rights.
            /// </summary>
            KEY_ALL_ACCESS = 0xF003F,
            /// <summary>
            ///     Reserved for system use.
            /// </summary>
            KEY_CREATE_LINK = 0x0020,
            /// <summary>
            ///     Required to create a subkey of a registry key.
            /// </summary>
            KEY_CREATE_SUB_KEY = 0x0004,
            /// <summary>
            /// Required to enumerate the subkeys of a registry key.
            /// </summary>
            KEY_ENUMERATE_SUB_KEYS = 0x0008,
            /// <summary>
            ///     Equivalent to KEY_READ.
            /// </summary>
            KEY_EXECUTE = 0x20019,
            /// <summary>
            ///     Required to request change notifications for a registry key or for subkeys of a registry key.
            /// </summary>
            KEY_NOTIFY = 0x0010,
            /// <summary>
            ///     Required to query the values of a registry key.
            /// </summary>
            KEY_QUERY_VALUE = 0x0001,
            /// <summary>
            ///     Combines the STANDARD_RIGHTS_READ, KEY_QUERY_VALUE, KEY_ENUMERATE_SUB_KEYS, and KEY_NOTIFY values.
            /// </summary>
            KEY_READ = 0x20019,
            /// <summary>
            ///     Required to create, delete, or set a registry value.
            /// </summary>
            KEY_SET_VALUE = 0x0002,
            /// <summary>
            ///     Indicates that an application on 64-bit Windows should operate on the 32-bit registry view. This flag is ignored by 32-bit Windows. For more information, see Accessing an Alternate Registry View.
            ///     This flag must be combined using the OR operator with the other flags in this table that either query or access registry values.
            /// </summary>
            KEY_WOW64_32KEY = 0x0200,
            /// <summary>
            ///     Indicates that an application on 64-bit Windows should operate on the 64-bit registry view. This flag is ignored by 32-bit Windows. For more information, see Accessing an Alternate Registry View.
            ///     This flag must be combined using the OR operator with the other flags in this table that either query or access registry values.
            /// </summary>
            KEY_WOW64_64KEY = 0x0100,
            /// <summary>
            ///     Combines the STANDARD_RIGHTS_WRITE, KEY_SET_VALUE, and KEY_CREATE_SUB_KEY access rights.
            /// </summary>
            KEY_WRITE = 0x20006
        }
    }
}
