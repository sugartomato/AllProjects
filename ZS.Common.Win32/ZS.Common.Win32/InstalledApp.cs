using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32
{
    public class InstalledApp : ObjectBase
    {

        public InstalledApp()
        {
            this.Name = String.Empty;
        }



        #region 属性
        /// <summary>设置或获取标识符</summary>
        public UInt16 AssignmentType { get; set; }
        /// <summary>设置或获取标识符</summary>
        public String IdentifyingNumber { get; set; }
        /// <summary>设置或获取程序名</summary>
        public String Name { get; set; }
        /// <summary>设置或获取版本号字符串</summary>
        public String VersionString { get; set; }
        /// <summary>设置或获取版本号</summary>
        public String Caption { get; set; }
        /// <summary>设置或获取软件描述</summary>
        public String Description { get; set; }
        /// <summary>设置或获取制作公司</summary>
        public String Publisher { get; set; }
        /// <summary>设置或获取卸载路径</summary>
        public String UninstallString { get; set; }
        /// <summary>设置或获取支持电话</summary>
        public String HelpTelephone { get; set; }
        /// <summary>设置或获取支持网站</summary>
        public String HelpLink { get; set; }
        /// <summary>设置或获取关于链接</summary>
        public String URLInfoAbout { get; set; }
        /// <summary>设置或获取安装路径</summary>
        public String InstallLocation { get; set; }
        /// <summary>设置或获取安装日期</summary>
        public DateTime? InstallDate { get; set; }
        /// <summary>设置或获取安装源</summary>
        public String InstallSource { get; set; }
        /// <summary>设置或获取是否为系统组件</summary>
        public Boolean IsSystemComponent { get; set; }
        /// <summary>设置或获取通过WindowsInstaller安装的程序</summary>
        public Boolean IsInstallByWindowsInstaller { get; set; }
        /// <summary>是否为更新。例如Windows更新或者Office更新</summary>
        public Boolean IsUpdate { get; set; }
        /// <summary>设置或获取是否为系统更新</summary>
        public Boolean IsWindowsUpdate { get; set; }
        /// <summary>设置或获取发布类型</summary>
        public String ReleaseType { get; set; }
        /// <summary>设置或获取说明</summary>
        public String Comments { get; set; }
        /// <summary>获取该程序的注册表查找位置</summary>
        public String RegKeyPath { get; internal set; }

        #endregion



    }
}
