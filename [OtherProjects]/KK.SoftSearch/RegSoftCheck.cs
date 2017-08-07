using System;
using System.Collections.Generic;
using System.Text;
using MSWin32 = Microsoft.Win32;

namespace KK.SoftSearch
{
    /// <summary>
    /// 注册表检查
    /// </summary>
    internal class RegSoftCheck
    {

        #region 注册表定义

        /*====================
        杀毒
        ====================*/
        // 360杀毒
        private const String _Ant_360 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\360SD\";
        private const String _Ant_360_64bit = @"SOFTWARE\WOW6432Node\360SD\";

        // 金山毒霸
        private const String _Ant_JinShanDuBa = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Kingsof\";
        private const String _Ant_JinShanDuBa_64bit = "SOFTWARE\\WOW6432Node\\Kingsoft\\antivirus\\";

        // 江民
        private const String _Ant_JiangMin = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\JiangMin\";
        private const String _Ant_JiangMin_64bit = "SOFTWARE\\WOW6432Node\\JiangMin\\";

        // 卡巴

        // 瑞星
        private const String _Ant_RuiXing = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\RAV";
        private const String _Ant_RuiXing_64bit = "SOFTWARE\\WOW6432Node\\RAV\\";

        // 诺顿
        private const String _Ant_Norton = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\NS";
        private const String _Ant_Norton_64bit = "SOFTWARE\\WOW6432Node\\NS\\";

        // 百度杀毒
        private const String _Ant_BaiDuShaDu = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\百度杀毒";
        private const String _Ant_BaiDuShaDu_64bit = "SOFTWARE\\WOW6432Node\\Baidu Security\\Antivirus\\";

        // 小红伞
        private const String _Ant_Avira = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Avira Antivirus";
        private const String _Ant_Avira_64bit = "SOFTWARE\\WOW6432Node\\Avira Antivirus\\";


        /*====================
            Office 
        ====================*/
        // 金山WPS
        // WPS是先检测专业版再检测个人版。安装专业版，wps会自动卸载个人版。
        // 个人版是检测CurrentUser键值下
        private const String _Office_WPS_Personal = @"SOFTWARE\Kingsoft\Office\6.0\Common\";
        private const String _Office_WPS_Pro = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Kingsoft Office\";
        private const String _Office_WPS_Pro_64bit = "SOFTWARE\\WOW6432Node\\kingsoft\\Office\\6.0\\Common\\";

        // 永中Office
        // 从卸载列表中检测是否存在


        private const String _RegUninstall = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
        private const String _RegUninstall_64bit = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\";

        #endregion

        #region 杀毒软件检测

        /// <summary>
        /// 是否存在360杀毒
        /// </summary>
        /// <returns></returns>
        public Boolean HasAnt360()
        {
            if (IsRegValueExists(_Ant_360, "DisplayName", null))
            {
                return true;
            }
            if (IsRegExists(_Ant_360_64bit, Microsoft.Win32.Registry.LocalMachine))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否存在金山毒霸
        /// </summary>
        /// <returns></returns>
        public Boolean HasAntJinShan()
        {
            if (IsRegValueExists(_Ant_JinShanDuBa, "DisplayName", null))
            {
                return true;
            }
            if (IsRegExists(_Ant_JinShanDuBa_64bit, Microsoft.Win32.Registry.LocalMachine))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否存在江民杀毒
        /// </summary>
        /// <returns></returns>
        public Boolean HasAntJiangMin()
        {
            if (IsRegValueExists(_Ant_JiangMin, "DisplayName", null))
            {
                return true;
            }
            if (IsRegExists(_Ant_JiangMin_64bit, Microsoft.Win32.Registry.LocalMachine))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否存在瑞星
        /// </summary>
        /// <returns></returns>
        public Boolean HasAntRuiXing()
        {
            if (IsRegValueExists(_Ant_RuiXing, "DisplayName", null))
            {
                return true;
            }
            if (IsRegExists(_Ant_RuiXing_64bit, Microsoft.Win32.Registry.LocalMachine))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否存在诺顿
        /// </summary>
        /// <returns></returns>
        public Boolean HasAntNorton()
        {
            if (IsRegValueExists(_Ant_Norton, "DisplayName", null))
            {
                return true;
            }
            if (IsRegExists(_Ant_Norton_64bit, Microsoft.Win32.Registry.LocalMachine))
            {
                return true;
            }
            return false;
        }

        #endregion

        #region  Office存在检测

        /// <summary>
        /// 检测是否存在WPS专业版
        /// </summary>
        /// <returns></returns>
        public Boolean HasOffice_WPSPro()
        {
            using (MSWin32.RegistryKey regPro1 = MSWin32.Registry.LocalMachine.OpenSubKey(_Office_WPS_Pro))
            {
                if (regPro1 != null && IsRegValueExists(_Office_WPS_Pro, "DisplayName", MSWin32.Registry.LocalMachine))
                {
                    string verName = regPro1.GetValue("DisplayName")?.ToString();
                    if (verName.Contains("(8."))
                    {
                        return true;
                    }
                    else if (verName.Contains("9."))
                    {
                        return true;
                    }
                    else if (verName.Contains("10."))
                    {
                        return true;
                    }
                }
            }

            using (MSWin32.RegistryKey regPro2 = MSWin32.Registry.LocalMachine.OpenSubKey(_Office_WPS_Pro_64bit))
            {
                if (regPro2 != null && IsRegValueExists(_Office_WPS_Pro, "DisplayName", MSWin32.Registry.LocalMachine))
                {
                    string verName = regPro2.GetValue("DisplayName")?.ToString();
                    if (verName.Contains("(8."))
                    {
                        return true;
                    }
                    else if (verName.Contains("9."))
                    {
                        return true;
                    }
                    else if (verName.Contains("10."))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 检测是否存在WPS个人版
        /// </summary>
        /// <returns></returns>
        public Boolean HasOffice_WPSPersonal()
        {
            using (MSWin32.RegistryKey regKey = MSWin32.Registry.CurrentUser.OpenSubKey(_Office_WPS_Personal))
            {
                if (regKey != null && IsRegValueExists(_Office_WPS_Pro, "DisplayName", MSWin32.Registry.LocalMachine))
                {
                    string verName = regKey.GetValue("DisplayName")?.ToString();
                    if (verName.Contains("(8."))
                    {
                        return true;
                    }
                    else if (verName.Contains("9."))
                    {
                        return true;
                    }
                    else if (verName.Contains("10."))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 是否存在永中Office
        /// </summary>
        /// <returns></returns>
        public Boolean HasOffice_YongZhong()
        {
            string regPath = GetRegPathByValue(_RegUninstall, "DisplayName", "永中Office", null);
            return !string.IsNullOrEmpty(regPath);
        }

        public String GetMSOfficeVersion()
        {

            // 获取年份
            using (MSWin32.RegistryKey reg = MSWin32.Registry.LocalMachine.OpenSubKey(_RegUninstall))
            {
                if (reg != null)
                {
                    // 获取所有卸载项并遍历
                    string[] regSubKeys = reg.GetSubKeyNames();
                    for (Int32 m = 0; m < regSubKeys.Length; m++)
                    {

                        string subKeyText = regSubKeys[m];
                        // 检查是否存在DisplayName
                        if (IsRegValueExists(_RegUninstall + subKeyText, "DisplayName", null))
                        {
                            MSWin32.RegistryKey regTmp = reg.OpenSubKey(subKeyText);
                            string appName = regTmp.GetValue("DisplayName")?.ToString();
                            string appVer = regTmp.GetValue("DisplayVersion")?.ToString();
                            string appLocation = regTmp.GetValue("InstallLocation")?.ToString();

                            if(string.IsNullOrEmpty(appName) || string.IsNullOrEmpty(appVer) || string.IsNullOrEmpty(appLocation))
                            {
                                continue;
                            }
                            // 如果名成立包含了Office并且路径物理地址存在，继续检测
                            if (appName.Contains("Microsoft Office") && System.IO.Directory.Exists(appLocation))
                            {
                                if (appVer.Contains("11."))
                                {

                                }
                            }
                        }
                    }

                }

            }



        }


        #endregion

        #region 公共方法

        /// <summary>
        /// 检测注册表项是否存在
        /// </summary>
        /// <param name="regPath"></param>
        /// <param name="regRoot"></param>
        /// <returns></returns>
        private Boolean IsRegExists(string regPath, Microsoft.Win32.RegistryKey regRoot)
        {
            if (regRoot == null) regRoot = Microsoft.Win32.Registry.LocalMachine;
            Microsoft.Win32.RegistryKey regToTest = regRoot.OpenSubKey(regPath);
            return regToTest == null;
        }

        /// <summary>
        /// 检测注册表下的值是否存在
        /// </summary>
        /// <param name="regPath"></param>
        /// <param name="valName"></param>
        /// <param name="regRoot"></param>
        /// <returns></returns>
        private Boolean IsRegValueExists(string regPath, string valName, Microsoft.Win32.RegistryKey regRoot = null)
        {
            if (regRoot == null) regRoot = Microsoft.Win32.Registry.LocalMachine;
            Microsoft.Win32.RegistryKey regToCheck = regRoot.OpenSubKey(regPath);
            if (regToCheck != null)
            {
                string[] valNames = regToCheck.GetValueNames();
                if (valNames != null && valName.Contains(valName))
                {
                    regRoot.Close();
                    return true;
                }
            }

            regRoot.Close();
            return false;
        }

        /// <summary>
        /// 获取指定键值下存在某个值的子键
        /// </summary>
        /// <param name="regParentText">父键值路径</param>
        /// <param name="valName">值名称</param>
        /// <param name="val">值</param>
        /// <param name="regRoot">根键值。默认为LocalMachine</param>
        /// <returns></returns>
        private String GetRegPathByValue(string regParentText, string valName, string val, MSWin32.RegistryKey regRoot = null)
        {
            if (regRoot == null) regRoot = MSWin32.Registry.LocalMachine;
            using (MSWin32.RegistryKey reg = regRoot.OpenSubKey(regParentText))
            {
                if (reg != null)
                {
                    string[] subKeyNames = reg.GetSubKeyNames();
                    if (subKeyNames != null && subKeyNames.Length > 0)
                    {
                        for (Int32 m = 0; m < subKeyNames.Length; m++)
                        {
                            string subKeyPath = regParentText + subKeyNames[m] + "\\";
                            if (IsRegValueExists(subKeyPath, valName, null))
                            {
                                string tmpVal = MSWin32.Registry.LocalMachine.OpenSubKey(subKeyPath).GetValue(valName)?.ToString();
                                if (tmpVal != null && tmpVal.Contains(val))
                                {
                                    return subKeyPath;
                                }
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }

        #endregion


    }
}
