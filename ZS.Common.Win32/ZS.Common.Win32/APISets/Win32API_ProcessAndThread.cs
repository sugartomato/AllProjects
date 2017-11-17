using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ZS.Common.Win32
{
    public partial class API
    {
        /// <summary>
        /// Opens an existing local process object.
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// [in]
        ///     The access to the process object. This access right is checked against the security descriptor for the process. This parameter can be one or more of the process access rights.
        ///     If the caller has enabled the SeDebugPrivilege privilege, the requested access is granted regardless of the contents of the security descriptor.
        /// </param>
        /// <param name="bInheritHandle">
        /// [in]
        ///     If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="dwProcessId">
        /// [in]
        ///     The identifier of the local process to be opened.
        ///     If the specified process is the System Process (0x00000000), the function fails and the last error code is ERROR_INVALID_PARAMETER. If the specified process is the Idle process or one of the CSRSS processes, this function fails and the last error code is ERROR_ACCESS_DENIED because their access restrictions prevent user-level code from opening them.
        ///     If you are using GetCurrentProcessId as an argument to this function, consider using GetCurrentProcess instead of OpenProcess, for improved performance.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is an open handle to the specified process.
        ///     If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        ///     To open a handle to another local process and obtain full access rights, you must enable the SeDebugPrivilege privilege. For more information, see Changing Privileges in a Token.
        ///     The handle returned by the OpenProcess function can be used in any function that requires a handle to a process, such as the wait functions, provided the appropriate access rights were requested.
        ///     When you are finished with the handle, be sure to close it using the CloseHandle function.
        /// </remarks>
        /// <link>https://msdn.microsoft.com/en-us/library/windows/desktop/ms684320(v=vs.85).aspx</link>
        [DllImport("kernel32.dll")]
        public extern static IntPtr OpenProcess(UInt32 dwDesiredAccess, Boolean bInheritHandle, UInt32 dwProcessId);


        #region Process Security And Access Right Definition

        /// <summary>
        /// The Microsoft Windows security model enables you to control access to process objects. For more information about security, see Access-Control Model.
        /// When a user logs in, the system collects a set of data that uniquely identifies the user during the authentication process, and stores it in an access token. This access token describes the security context of all processes associated with the user. The security context of a process is the set of credentials given to the process or the user account that created the process.
        /// You can use a token to specify the current security context for a process using the CreateProcessWithTokenW function. You can specify a security descriptor for a process when you call the CreateProcess, CreateProcessAsUser, or CreateProcessWithLogonW function. If you specify NULL, the process gets a default security descriptor. The ACLs in the default security descriptor for a process come from the primary or impersonation token of the creator.
        /// To retrieve a process's security descriptor, call the GetSecurityInfo function. To change a process's security descriptor, call the SetSecurityInfo function.
        /// The valid access rights for process objects include the standard access rights and some process-specific access rights. The following table lists the standard access rights used by all objects.
        /// </summary>
        /// <link>https://msdn.microsoft.com/en-us/library/windows/desktop/ms684880(v=vs.85).aspx</link>
        public class ProcessSecurityAccessRight
        {
            /// <summary>
            /// Required to create a process.
            /// </summary>
            public const UInt32 PROCESS_CREATE_PROCESS = 0x0080;
            /// <summary>
            /// Required to create a thread.
            /// </summary>
            public const UInt32 PROCESS_CREATE_THREAD = 0x0002;
            /// <summary>
            /// Required to duplicate a handle using DuplicateHandle.
            /// </summary>
            public const UInt32 PROCESS_DUP_HANDLE = 0x0040;
            /// <summary>
            /// Required to retrieve certain information about a process, such as its token, exit code, and priority class (see OpenProcessToken).
            /// </summary>
            public const UInt32 PROCESS_QUERY_INFORMATION = 0x0400;
            public const UInt32 PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;
            public const UInt32 PROCESS_SET_INFORMATION = 0x0200;
            /// <summary>
            /// Required to set memory limits using SetProcessWorkingSetSize.
            /// </summary>
            public const UInt32 PROCESS_SET_QUOTA = 0x0100;
            /// <summary>
            /// Required to suspend or resume a process.
            /// </summary>
            public const UInt32 PROCESS_SUSPEND_RESUME = 0x0800;
            /// <summary>
            /// Required to terminate a process using TerminateProcess.
            /// </summary>
            public const UInt32 PROCESS_TERMINATE = 0x0001;
            /// <summary>
            /// Required to perform an operation on the address space of a process (see VirtualProtectEx and WriteProcessMemory).
            /// </summary>
            public const UInt32 PROCESS_VM_OPERATION = 0x0008;
            /// <summary>
            /// Required to read memory in a process using ReadProcessMemory.
            /// </summary>
            public const UInt32 PROCESS_VM_READ = 0x0010;
            /// <summary>
            /// Required to write to memory in a process using WriteProcessMemory.
            /// </summary>
            public const UInt32 PROCESS_VM_WRITE = 0x0020;
            /// <summary>
            /// Required to wait for the process to terminate using the wait functions.
            /// </summary>
            public const UInt64 SYNCHRONIZE = 0x00100000L;
        }

        #endregion

        /// <summary>
        /// Reads data from an area of memory in a specified process. The entire area to be read must be accessible or the operation fails.
        /// </summary>
        /// <param name="hProcess">
        /// [in]
        ///     A handle to the process with memory that is being read. The handle must have PROCESS_VM_READ access to the process.
        /// </param>
        /// <param name="lpBaseAddress">
        /// [in]
        ///     A pointer to the base address in the specified process from which to read. Before any data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for read access, and if it is not accessible the function fails. 
        /// </param>
        /// <param name="lpBuffer">
        /// [out]
        ///     A pointer to a buffer that receives the contents from the address space of the specified process.
        /// </param>
        /// <param name="nSize">
        /// [in]
        ///     The number of bytes to be read from the specified process.
        /// </param>
        /// <param name="lpNumberOfBytesRead">
        /// [out]
        ///     A pointer to a variable that receives the number of bytes transferred into the specified buffer. If lpNumberOfBytesRead is NULL, the parameter is ignored.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.
        ///     The function fails if the requested read operation crosses into an area of the process that is inaccessible.
        /// </returns>
        /// <remarks>
        /// ReadProcessMemory copies the data in the specified address range from the address space of the specified process into the specified buffer of the current process. Any process that has a handle with PROCESS_VM_READ access can call the function.
        /// The entire area to be read must be accessible, and if it is not accessible, the function fails.
        /// </remarks>
        /// <link>https://msdn.microsoft.com/en-us/library/windows/desktop/ms680553(v=vs.85).aspx</link>
        [DllImport("Kernel32.dll")]
        public extern static Boolean ReadProcessMemory(IntPtr hProcess,IntPtr lpBaseAddress, IntPtr lpBuffer, Int32 nSize, ref UInt32 lpNumberOfBytesRead);
        [DllImport("Kernel32.dll")]
        public extern static Boolean ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, StringBuilder lpBuffer, Int32 nSize, ref UInt32 lpNumberOfBytesRead);

        /// <summary>
        /// Writes data to an area of memory in a specified process. The entire area to be written to must be accessible or the operation fails.
        /// </summary>
        /// <param name="hProcess">
        /// [in]
        ///     A handle to the process memory to be modified. The handle must have PROCESS_VM_WRITE and PROCESS_VM_OPERATION access to the process.
        /// </param>
        /// <param name="lpBaseAddress">
        /// [in]
        ///     A pointer to the base address in the specified process to which data is written. Before data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for write access, and if it is not accessible, the function fails.
        /// </param>
        /// <param name="lpBuffer">
        /// [in]
        ///     A pointer to the buffer that contains data to be written in the address space of the specified process.
        /// </param>
        /// <param name="nSize">
        /// [in]
        ///     he number of bytes to be written to the specified process.
        /// </param>
        /// <param name="lpNumberOfBytesWritten">
        /// [out]
        ///     A pointer to a variable that receives the number of bytes transferred into the specified process. This parameter is optional. If lpNumberOfBytesWritten is NULL, the parameter is ignored.
        /// </param>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public extern static Boolean WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, Int32 nSize, ref UInt32 lpNumberOfBytesWritten);

    }
}
