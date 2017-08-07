using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZS.Common.Win32.ContextMenu;
namespace ZS.Common.Win32Tests.ContextMenu
{
    [TestClass]
    public class ContextMenuTests
    {

        [TestMethod]
        public void AddToDirBackgroundShellTest()
        {
            ZS.Common.Win32.ContextMenu.ContextMenu c = new Win32.ContextMenu.ContextMenu();
            c.RegName = "DLLTest";
            c.ShowName = "@xxxx";
            //c.Command = "\"C:\\Program Files\\Git\\git-bash.exe\" \"--cd=%v.\"";
            ZS.Common.Win32.ContextMenu.ContextMenu.AddToDirBackgroundShell(c);
        }

    }
}
