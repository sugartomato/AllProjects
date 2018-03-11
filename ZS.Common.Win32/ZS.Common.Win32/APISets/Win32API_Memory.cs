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
        /// Reserves, commits, or changes the state of a region of memory within the virtual address space of a specified process. The function initializes the memory it allocates to zero.
        /// </summary>
        /// <param name="hProcess">
        ///  [in]
        ///     The handle to a process. The function allocates memory within the virtual address space of this process.
        ///     The handle must have the PROCESS_VM_OPERATION access right. For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="lpAddress">
        /// [in, optional]
        ///     The pointer that specifies a desired starting address for the region of pages that you want to allocate.
        ///     If you are reserving memory, the function rounds this address down to the nearest multiple of the allocation granularity.
        ///     If you are committing memory that is already reserved, the function rounds this address down to the nearest page boundary. To determine the size of a page and the allocation granularity on the host computer, use the GetSystemInfo function.
        ///     If lpAddress is NULL, the function determines where to allocate the region.
        ///     If this address is within an enclave that you have not initialized by calling InitializeEnclave, VirtualAllocEx allocates a page of zeros for the enclave at that address. The page must be previously uncommitted, and will not be measured with the EEXTEND instruction of the Intel Software Guard Extensions programming model.
        ///     If the address in within an enclave that you initialized, then the allocation operation fails with the ERROR_INVALID_ADDRESS error.
        /// </param>
        /// <param name="dwSize">
        /// [in]
        ///     The size of the region of memory to allocate, in bytes.
        ///     If lpAddress is NULL, the function rounds dwSize up to the next page boundary.
        ///     If lpAddress is not NULL, the function allocates all pages that contain one or more bytes in the range from lpAddress to lpAddress+dwSize. This means, for example, that a 2-byte range that straddles a page boundary causes the function to allocate both pages.
        /// </param>
        /// <param name="flAllocationType">
        /// [in]
        ///     The type of memory allocation. This parameter must contain one of the following values.
        /// </param>
        /// <param name="flProtect">
        /// [in]
        ///     The memory protection for the region of pages to be allocated. If the pages are being committed, you can specify any one of the memory protection constants.
        ///     If lpAddress specifies an address within an enclave, flProtect cannot be any of the following values:
        ///     PAGE_NOACCESS,PAGE_GUARD,PAGE_NOCACHE,PAGE_WRITECOMBINE
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the base address of the allocated region of pages.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// 
        /// </remarks>
        /// <link>https://msdn.microsoft.com/en-us/library/aa366890%28VS.85%29.aspx?f=255&MSPPError=-2147217396</link>
        [DllImport("Kernel32.dll")]
        public extern static IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, Int32 dwSize, UInt32 flAllocationType, UInt32 flProtect);

        /// <summary>
        /// Releases, decommits, or releases and decommits a region of memory within the virtual address space of a specified process.
        /// </summary>
        /// <param name="hProcess">
        /// [in]
        ///     A handle to a process. The function frees memory within the virtual address space of the process.
        ///     The handle must have the PROCESS_VM_OPERATION access right. For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="lpAddress">
        /// [in]
        ///     A pointer to the starting address of the region of memory to be freed.
        ///     If the dwFreeType parameter is MEM_RELEASE, lpAddress must be the base address returned by the VirtualAllocEx function when the region is reserved.
        /// </param>
        /// <param name="dwSize">
        /// [in]
        ///     The size of the region of memory to free, in bytes.
        ///     If the dwFreeType parameter is MEM_RELEASE, dwSize must be 0 (zero). The function frees the entire region that is reserved in the initial allocation call to VirtualAllocEx.
        ///     If dwFreeType is MEM_DECOMMIT, the function decommits all memory pages that contain one or more bytes in the range from the lpAddress parameter to (lpAddress+dwSize). This means, for example, that a 2-byte region of memory that straddles a page boundary causes both pages to be decommitted. If lpAddress is the base address returned by VirtualAllocEx and dwSize is 0 (zero), the function decommits the entire region that is allocated by VirtualAllocEx. After that, the entire region is in the reserved state.
        /// </param>
        /// <param name="dwFreeType">
        /// [in]
        ///     The type of free operation. This parameter can be one of the following values.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a nonzero value.
        ///     If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// </remarks>
        /// <link>https://msdn.microsoft.com/en-us/library/windows/desktop/aa366894%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396</link>
        [DllImport("Kernel32.dll")]
        public extern static IntPtr VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, Int32 dwSize, Int32 dwFreeType);

        /// <summary>
        /// 内存分配类型
        /// </summary>
        /// <link>https://msdn.microsoft.com/en-us/library/aa366890%28VS.85%29.aspx?f=255&MSPPError=-2147217396</link>
        public class MemoryAllocationType
        {
            /// <summary>
            /// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages. The function also guarantees that when the caller later initially accesses the memory, the contents will be zero. Actual physical pages are not allocated unless/until the virtual addresses are actually accessed.
            /// To reserve and commit pages in one step, call VirtualAllocEx with MEM_COMMIT | MEM_RESERVE.
            /// Attempting to commit a specific address range by specifying MEM_COMMIT without MEM_RESERVE and a non-NULL lpAddress fails unless the entire range has already been reserved. The resulting error code is ERROR_INVALID_ADDRESS.
            /// An attempt to commit a page that is already committed does not cause the function to fail. This means that you can commit pages without first determining the current commitment state of each page.
            /// If lpAddress specifies an address within an enclave, flAllocationType must be MEM_COMMIT.
            /// </summary>
            public const Int32 MEM_COMMIT = 0x00001000;

            /// <summary>
            /// Reserves a range of the process's virtual address space without allocating any actual physical storage in memory or in the paging file on disk.
            /// You commit reserved pages by calling VirtualAllocEx again with MEM_COMMIT. To reserve and commit pages in one step, call VirtualAllocEx with MEM_COMMIT | MEM_RESERVE.
            /// Other memory allocation functions, such as malloc and LocalAlloc, cannot use reserved memory until it has been released.
            /// </summary>
            public const Int32 MEM_RESERVE = 0x00002000;

            /// <summary>
            /// Indicates that data in the memory range specified by lpAddress and dwSize is no longer of interest. The pages should not be read from or written to the paging file. However, the memory block will be used again later, so it should not be decommitted. This value cannot be used with any other value.
            /// Using this value does not guarantee that the range operated on with MEM_RESET will contain zeros. If you want the range to contain zeros, decommit the memory and then recommit it.
            /// When you use MEM_RESET, the VirtualAllocEx function ignores the value of fProtect. However, you must still set fProtect to a valid protection value, such as PAGE_NOACCESS.
            /// VirtualAllocEx returns an error if you use MEM_RESET and the range of memory is mapped to a file. A shared view is only acceptable if it is mapped to a paging file.
            /// </summary>
            public const Int32 MEM_RESET = 0x00080000;

            /// <summary>
            /// MEM_RESET_UNDO should only be called on an address range to which MEM_RESET was successfully applied earlier. It indicates that the data in the specified memory range specified by lpAddress and dwSize is of interest to the caller and attempts to reverse the effects of MEM_RESET. If the function succeeds, that means all data in the specified address range is intact. If the function fails, at least some of the data in the address range has been replaced with zeroes.
            /// This value cannot be used with any other value. If MEM_RESET_UNDO is called on an address range which was not MEM_RESET earlier, the behavior is undefined. When you specify MEM_RESET, the VirtualAllocEx function ignores the value of flProtect. However, you must still set flProtect to a valid protection value, such as PAGE_NOACCESS.
            /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  The MEM_RESET_UNDO flag is not supported until Windows 8 and Windows Server 2012.
            /// </summary>
            public const Int32 MEM_RESET_UNDO = 0x1000000;

            /// <summary>
            /// Allocates memory using large page support.
            /// The size and alignment must be a multiple of the large-page minimum. To obtain this value, use the GetLargePageMinimum function.
            /// If you specify this value, you must also specify MEM_RESERVE and MEM_COMMIT.
            /// </summary>
            public const Int32 MEM_LARGE_PAGES = 0x20000000;

            /// <summary>
            /// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.
            /// This value must be used with MEM_RESERVE and no other values.
            /// </summary>
            public const Int32 MEM_PHYSICAL = 0x00400000;

            /// <summary>
            /// Allocates memory at the highest possible address. This can be slower than regular allocations, especially when there are many allocations.
            /// </summary>
            public const Int32 MEM_TOP_DOWN = 0x00100000;

        }

        /// <summary>
        /// The following are the memory-protection options; you must specify one of the following values when allocating or protecting a page in memory. Protection attributes cannot be assigned to a portion of a page; they can only be assigned to a whole page.
        /// </summary>
        /// <link>https://msdn.microsoft.com/en-us/library/aa366786%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396</link>
        public class MemoryProtectionConstants
        {
            /// <summary>
            /// Enables execute access to the committed region of pages. An attempt to write to the committed region results in an access violation.
            /// This flag is not supported by the CreateFileMapping function.
            /// </summary>
            public const Int32 PAGE_EXECUTE = 0x10;
            public const Int32 PAGE_EXECUTE_READ = 0x20;
            public const Int32 PAGE_EXECUTE_READWRITE = 0x40;
            public const Int32 PAGE_EXECUTE_WRITECOPY = 0x80;
            public const Int32 PAGE_NOACCESS = 0x01;
            public const Int32 PAGE_READONLY = 0x02;
            public const Int32 PAGE_READWRITE = 0x04;
            public const Int32 PAGE_WRITECOPY = 0x08;
            public const Int32 PAGE_TARGETS_INVALID = 0x40000000;
            public const Int32 PAGE_TARGETS_NO_UPDATE = 0x40000000;
        }

        /// <summary>
        /// 内存释放类型
        /// </summary>
        public class MemoryFreeType
        {
            /// <summary>
            /// Decommits the specified region of committed pages. After the operation, the pages are in the reserved state.
            /// The function does not fail if you attempt to decommit an uncommitted page. This means that you can decommit a range of pages without first determining their current commitment state.
            /// Do not use this value with MEM_RELEASE.
            /// The MEM_DECOMMIT value is not supported when the lpAddress parameter provides the base address for an enclave.
            /// </summary>
            public const Int32 MEM_DECOMMIT = 0x4000;
            /// <summary>
            /// Releases the specified region of pages. After the operation, the pages are in the free state.
            /// If you specify this value, dwSize must be 0 (zero), and lpAddress must point to the base address returned by the VirtualAllocEx function when the region is reserved. The function fails if either of these conditions is not met.
            /// If any pages in the region are committed currently, the function first decommits, and then releases them.
            /// The function does not fail if you attempt to release pages that are in different states, some reserved and some committed. This means that you can release a range of pages without first determining the current commitment state.
            /// Do not use this value with MEM_DECOMMIT.
            /// </summary>
            public const Int32 MEM_RELEASE = 0x8000;
        }

    }
}
