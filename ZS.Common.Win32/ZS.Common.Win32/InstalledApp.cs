using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32
{
    public class InstalledApp
    {

        public InstalledApp()
        {
            this.DisplayName = String.Empty;
        }


        #region 属性
        /// <summary>程序名</summary>
        public String DisplayName { get; set; }
        /// <summary>版本号</summary>
        public String DisplayVersion { get; set; }
        /// <summary>版本号</summary>
        public String InstallLocation { get; set; }
        /// <summary>制作公司</summary>
        public String Publisher { get; set; }
        /// <summary>卸载路径</summary>
        public String UninstallString { get; set; }
        /// <summary>支持电话</summary>
        public String HelpTelephone { get; set; }
        /// <summary>支持网站</summary>
        public String HelpLink { get; set; }
        /// <summary>关于链接</summary>
        public String URLInfoAbout { get; set; }
        /// <summary>安装日期</summary>
        public DateTime? InstallDate { get; set; }
        /// <summary>是否为系统组件</summary>
        public Boolean IsSystemComponent { get; set; }

        #endregion



    }
}
