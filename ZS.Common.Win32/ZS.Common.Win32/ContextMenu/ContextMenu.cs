using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace ZS.Common.Win32.ContextMenu
{

    public class ContextMenu
    {

        #region 静态方法
        /// <summary>
        /// 添加右键菜单到目录背景的Shell，既在目录空白处点击右键出现的菜单中。
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public static Boolean AddToDirBackgroundShell(ContextMenu cm)
        {
            string keyPath = @"directory\background\shell\";
            using (RegistryKey regRoot = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Default))
            {

                using (RegistryKey regDirBack = regRoot.OpenSubKey(keyPath, true))
                {
                    RegistryKey regT = regRoot.OpenSubKey(cm.RegName);
                    if (regT != null)
                    {

                    }

                    regT = regDirBack.CreateSubKey(cm.RegName);
                    regT.SetValue("", cm.ShowName); // 设置默认值
                    if (!string.IsNullOrEmpty(cm.Icon))
                    {
                        regT.SetValue("Icon", cm.Icon);
                    }
                    RegistryKey regCommand = regT.CreateSubKey("command");
                    if (!string.IsNullOrEmpty(cm.Command))
                    {
                        regCommand.SetValue("", cm.Command);
                    }

                }
            }

            return false;
        }


        #endregion

        /// <summary>
        /// 构造一个新的实例
        /// </summary>
        public ContextMenu()
        {
            this.RegName = System.Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 命令行
        /// </summary>
        public string Command { get; set; }
        /// <summary>
        /// 图标路径
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 菜单中显示名称
        /// </summary>
        public string ShowName { get; set; }
        /// <summary>
        /// 注册表中键名。默认以GUID命名
        /// </summary>
        public string RegName { get; set; }

    }
}
