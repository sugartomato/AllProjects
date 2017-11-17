using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace ZS.Common.Win32
{
    public class Desktop
    {
        /// <summary>桌面窗口句柄</summary>
        private IntPtr m_hWnd = IntPtr.Zero;
        /// <summary>ListView控件句柄</summary>
        private IntPtr m_ListViewHandle = IntPtr.Zero;
        /// <summary>改ListView所属的进程ID</summary>
        private Int32 m_ProcessID = 0;
        public Desktop(IntPtr hWnd)
        {
            this.m_hWnd = hWnd;
            if (hWnd != IntPtr.Zero)
            {
                m_ListViewHandle = API.GetWindow(m_hWnd, API.GetWindowTypeEnum.GW_CHILD);
                m_ListViewHandle = API.GetWindow(m_ListViewHandle, API.GetWindowTypeEnum.GW_CHILD);
                API.GetWindowThreadProcessId(m_ListViewHandle, out m_ProcessID);

            }
        }

        /// <summary>
        /// 获取桌面上的选择的数量
        /// </summary>
        /// <returns></returns>
        public Int32 GetSelectedCount()
        {
            Int32 count = API.SendMessage(m_ListViewHandle, SystemDefinedMessages.CommonControl.LVM_GETSELECTEDCOUNT, 0, 0);
            return count;
        }

        /// <summary>
        /// 获取桌面上的图标数量
        /// </summary>
        /// <returns></returns>
        public Int32 GetItemsCount()
        {
            Int32 count = API.SendMessage(m_ListViewHandle, SystemDefinedMessages.CommonControl.LVM_GETITEMCOUNT, 0, 0);
            return count;
        }

        /// <summary>
        /// 获取制定图标的文本
        /// </summary>
        /// <returns></returns>
        public String GetItemText(Int32 itemIndex)
        {
            String result = String.Empty;
            WinCtrlAPI.ListView.LVITEM lv = new WinCtrlAPI.ListView.LVITEM();
            UInt32 pref = 0;
            // 打开进程
            IntPtr proPtr = API.OpenProcess(API.ProcessSecurityAccessRight.PROCESS_VM_OPERATION | API.ProcessSecurityAccessRight.PROCESS_VM_READ | API.ProcessSecurityAccessRight.PROCESS_VM_WRITE, false, (UInt32)m_ProcessID);

            // 给文本分配一个地址
            IntPtr textPtr = API.VirtualAllocEx(proPtr, IntPtr.Zero, 260, API.MemoryAllocationType.MEM_COMMIT, API.MemoryProtectionConstants.PAGE_EXECUTE_READWRITE);
            lv.pszText = textPtr;

            lv.mask = SystemDefinedMessages.CommonControl.LVIF_TEXT;
            lv.iSubItem = 0;
            lv.cchTextMax = 260;

            // 给LVItem分配一段内存
            IntPtr lvPtr = API.VirtualAllocEx(proPtr, IntPtr.Zero, Marshal.SizeOf(lv), API.MemoryAllocationType.MEM_COMMIT, API.MemoryProtectionConstants.PAGE_EXECUTE_READWRITE);

            IntPtr memTPtr = Marshal.AllocHGlobal(Marshal.SizeOf(lv));
            Marshal.StructureToPtr(lv, memTPtr, false);

            Boolean writeResult = API.WriteProcessMemory(proPtr, lvPtr, memTPtr, Marshal.SizeOf(lv), ref pref);
            if (!writeResult)
                throw new ApplicationException("写入内存错误：" + API.GetLastError().ToString());

            Int32 msgResult = API.SendMessage(this.m_ListViewHandle, SystemDefinedMessages.CommonControl.LVM_GETITEMTEXT, itemIndex, lvPtr);
            if (msgResult == 0)
                throw new ApplicationException(API.GetLastError().ToString());

            // 在本程序分配一段内存空间，将桌面进程的内存读取到本进程，然后在转换为文本。
            IntPtr tmpPtr2 = Marshal.AllocHGlobal(260);
            Boolean readResult = API.ReadProcessMemory(proPtr, textPtr, tmpPtr2, 260, ref pref);
            if (readResult)
            {
                result = Marshal.PtrToStringAuto(tmpPtr2);
            }
             
            //StringBuilder sb = new StringBuilder(260);
            //Boolean readResult = API.ReadProcessMemory(proPtr, textPtr, sb, 260, ref pref);
            //if (readResult)
            //{
            //    result = sb.ToString();
            //}
            // 关闭进程
            API.CloseHandle(proPtr);

            return result;
            //WinCtrlAPI.ListView.LVITEM listView = new WinCtrlAPI.ListView.LVITEM();
            //listView.mask = SystemDefinedMessages.CommonControl.LVIF_TEXT;
            //listView.cchTextMax = 512;
            //listView.iItem = itemIndex;
            //listView.iSubItem = 0;
            //listView.pszText = Marshal.AllocHGlobal(512);

            //IntPtr listViewPtr = Marshal.AllocHGlobal(Marshal.SizeOf(listView));
            //Marshal.StructureToPtr(listView, listViewPtr, false);

            //Int32 r = API.SendMessage(m_ListViewHandle, SystemDefinedMessages.CommonControl.LVM_GETITEM, 0, listViewPtr);
            //Int32 errCode = API.GetLastError();
            //String itemText = Marshal.PtrToStringAuto(listView.pszText);

            //Marshal.FreeHGlobal(listView.pszText);
            //Marshal.FreeHGlobal(listViewPtr);

            //if (errCode != 0)
            //{
            //    throw new ApplicationException(errCode.ToString());
            //}

            //return itemText;
        }

        /// <summary>
        /// 获取指定图标的坐标
        /// </summary>
        /// <param name="itemIndex"></param>
        /// <returns></returns>
        public API.POINT GetItemLocation(Int32 itemIndex)
        {

            // 打开进程
            IntPtr proPtr = API.OpenProcess(API.ProcessSecurityAccessRight.PROCESS_VM_OPERATION | API.ProcessSecurityAccessRight.PROCESS_VM_READ | API.ProcessSecurityAccessRight.PROCESS_VM_WRITE, false, (UInt32)m_ProcessID);

            API.POINT location = new API.POINT();
            IntPtr locationPtr = IntPtr.Zero;

            // 在进程中分配内存空间，用来存储坐标数据
            locationPtr = API.VirtualAllocEx(proPtr, IntPtr.Zero, Marshal.SizeOf(location), API.MemoryAllocationType.MEM_COMMIT, API.MemoryProtectionConstants.PAGE_EXECUTE_READWRITE);

            // 发送系统消息，将图标坐标数据写入分配的内存中
            Int32 msgResult = API.SendMessage(m_ListViewHandle, SystemDefinedMessages.CommonControl.LVM_GETITEMPOSITION, itemIndex, locationPtr);

            if (msgResult == 0)
                throw new ApplicationException("发送消息执行失败。返回结果：0");

            // 在本进程中开辟一段非托管内存空间，并把结构体写入到非托管内存中。
            IntPtr tmpPtr = Marshal.AllocHGlobal(Marshal.SizeOf(location));
            Marshal.StructureToPtr(location, tmpPtr, false);

            // 将内存数据读取到开辟的内存空间中
            UInt32 pref = 0;
            Boolean readResult = API.ReadProcessMemory(proPtr, locationPtr, tmpPtr, Marshal.SizeOf(location), ref pref);
            if (!readResult)
            {
                throw new ApplicationException("读取内存失败");
            }

            // 将内存中的结构体转化出来
            API.POINT result = (API.POINT)Marshal.PtrToStructure(tmpPtr, typeof(API.POINT));

            // 关闭进程
            API.CloseHandle(proPtr);

            return result;

        }


        /// <summary>
        /// 设置图标坐标
        /// </summary>
        /// <param name="itemIndex"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public Boolean SetItemLocation(Int32 itemIndex, System.Drawing.Point location)
        {
            API.SendMessage(m_ListViewHandle, SystemDefinedMessages.CommonControl.LVM_SETITEMPOSITION, itemIndex, MakeLParam(location.X, location.Y));
            return true;
        }

        public IntPtr MakeLParam(int wLow, int wHigh)
        {
            return (IntPtr)(((short)wHigh << 16) | (wLow & 0xffff));
        }

        /// <summary>
        /// 选择指定项
        /// </summary>
        /// <param name="itemIndex"></param>
        public void SelectItem(Int32 itemIndex)
        {
            WinCtrlAPI.ListView.LVITEM listView = new WinCtrlAPI.ListView.LVITEM();
            //listView.iItem = itemIndex;
            listView.mask = SystemDefinedMessages.CommonControl.LVIF_STATE;
            listView.stateMask = SystemDefinedMessages.CommonControl.LVIS_FOCUSED | SystemDefinedMessages.CommonControl.LVIS_SELECTED;
            listView.state = SystemDefinedMessages.CommonControl.LVIS_FOCUSED | SystemDefinedMessages.CommonControl.LVIS_SELECTED;
            listView.cchTextMax = 0;
            listView.iImage = 0;

            IntPtr listViewPtr = Marshal.AllocHGlobal(Marshal.SizeOf(listView));
            Marshal.StructureToPtr(listView, listViewPtr, false);
            Int32 re = API.SendMessage(m_ListViewHandle, SystemDefinedMessages.CommonControl.LVM_SETITEMSTATE, itemIndex, listViewPtr.ToInt32());
            Marshal.FreeHGlobal(listViewPtr);
        }

        /// <summary>
        /// 获取默认桌面句柄
        /// </summary>
        /// <returns></returns>
        public static IntPtr GetDefaultIntptr()
        {
            IntPtr hwnd = API.FindWindow("ProgMan", null);
            return hwnd;
        }
        [DllImport("user32.dll",EntryPoint ="SendMessage",CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessageLVItem(IntPtr hWnd, Int32 message, Int32 wParam, ref WinCtrlAPI.ListView.LVITEM liv);
    }
}
