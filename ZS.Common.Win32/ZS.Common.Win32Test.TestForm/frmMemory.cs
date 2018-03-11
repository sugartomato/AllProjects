using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZS.Common.Win32;
using System.Runtime.InteropServices;

namespace ZS.Common.Win32Test.TestForm
{
    public partial class frmMemory : Form
    {
        public frmMemory()
        {
            InitializeComponent();
        }

        [StructLayout(LayoutKind.Sequential)]
        public class Point
        {
            public Int32 X;
            public Int32 Y;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr handle = API.FindWindow("Progman", "Program Manager");
            handle = API.FindWindowEx(handle, IntPtr.Zero, "SHELLDLL_DefView", null);
            handle = API.FindWindowEx(handle, IntPtr.Zero, "SysListView32", "FolderView");
            Int32 itemCount = API.SendMessage(handle, SystemDefinedMessages.CommonControl.LVM_GETITEMCOUNT, 0, 0);
            MessageBox.Show("图标数：" + itemCount);
            Int32 processID = 0;
            API.GetWindowThreadProcessId(handle, out processID);
            MessageBox.Show("进程ID：" + processID);

            IntPtr pro = API.OpenProcess(API.ProcessSecurityAccessRight.PROCESS_VM_OPERATION | API.ProcessSecurityAccessRight.PROCESS_VM_READ | API.ProcessSecurityAccessRight.PROCESS_VM_WRITE, false, (UInt32)processID);
            MessageBox.Show("打开进程：" + pro.ToString());

            // 分配内存
            IntPtr locationPointer = IntPtr.Zero;
            Point location = new Point();
            locationPointer = API.VirtualAllocEx(pro, IntPtr.Zero, System.Runtime.InteropServices.Marshal.SizeOf(location), API.MemoryAllocationType.MEM_COMMIT, API.MemoryProtectionConstants.PAGE_READWRITE);

            MessageBox.Show("内存分配完成！地址：" + locationPointer.ToString());
            Int32 sendResult = API.SendMessage(handle, SystemDefinedMessages.CommonControl.LVM_GETITEMPOSITION, 30, locationPointer);

            if (sendResult == 0)
            {
                Int32 errCode = API.GetLastError();
                MessageBox.Show(errCode.ToString());
            }
            MessageBox.Show("发送消息完成！结果：" + sendResult);


            // 内存中读取内容
            UInt32 pref = 0;
            IntPtr locPtr = Marshal.AllocHGlobal(Marshal.SizeOf(location));
            Marshal.StructureToPtr(location, locPtr, false);
            Boolean result = API.ReadProcessMemory(pro, locationPointer, locPtr, Marshal.SizeOf(location), ref pref);
            MessageBox.Show(result.ToString());
            if (result)
            {
                Marshal.PtrToStructure(locPtr, location);
                MessageBox.Show(location.X + "," + location.Y);
            }


            API.CloseHandle(pro);
            MessageBox.Show("关闭进程！");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String[] files = System.IO.Directory.GetFiles(path);
            foreach (String f in files)
            {
                txtConsole.AppendText(f + "\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IntPtr handle = API.FindWindow(null, "123.txt - 记事本");
            Int32 proID = 0;
            API.GetWindowThreadProcessId(handle, out proID);
            WriteDebug("进程ID：" + proID);
            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(proID);
            WriteDebug(p.MainModule.BaseAddress.ToString());
            WriteDebug(IntPtr.Add(p.MainModule.BaseAddress, p.MainModule.ModuleMemorySize).ToString());

        }

        private void WriteDebug(String msg)
        {
            txtConsole.AppendText(msg + "\r\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Desktop d = new Desktop(Desktop.GetDefaultIntptr());
            for (Int32 i = 0; i < d.GetItemsCount(); i++)
            {
                System.Drawing.Point tmpLocation = d.GetItemLocation(i);
                WriteDebug(i + ":" + tmpLocation.X + "," + tmpLocation.Y);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                Desktop d = new Desktop(Desktop.GetDefaultIntptr());
                for (Int32 i = 0; i < d.GetItemsCount(); i++)
                {
                    String text = d.GetItemText(i);
                    WriteDebug(text);
                }
            }
        }

        List<String> icons = null; // new string[] { "腾讯QQ", "Google Chrome", "VMware Workstation Pro" };
        private void button6_Click(object sender, EventArgs e)
        {
            icons = new List<string>();
            icons.Add("TeamViewer 11");
            icons.Add("腾讯QQ");
            icons.Add("Google Chrome");
            icons.Add("VMware Workstation Pro");
            icons.Add("FlashFXP");
            icons.Add("HyperSnap 7");
            icons.Add("UltraEdit");
            icons.Add("Visual Studio Code");
            icons.Add("SKUser");
            icons.Add("计算机");
            icons.Add("网络");
            icons.Add("回收站");
            icons.Add("微信");
            icons.Add("ILSpy");
            icons.Add("winbox");
            icons.Add("工具");

            Desktop d = new Desktop(Desktop.GetDefaultIntptr());
            for (Int32 i = 0; i < d.GetItemsCount(); i++)
            {
                String text = d.GetItemText(i);
                if (icons.Contains(text))
                {
                    d.SetItemLocation(i, new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width, 10));
                }
            }
        }
    }
}
