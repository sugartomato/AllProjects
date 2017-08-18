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
        private const String m_Ant_360 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\360SD\";
        private const String m_Ant_360_64bit = @"SOFTWARE\WOW6432Node\360SD\";

        // 金山毒霸
        private const String m_Ant_JinShanDuBa = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Kingsof\";
        private const String m_Ant_JinShanDuBa_64bit = "SOFTWARE\\WOW6432Node\\Kingsoft\\antivirus\\";

        // 江民
        private const String m_Ant_JiangMin = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\JiangMin\";
        private const String m_Ant_JiangMin_64bit = "SOFTWARE\\WOW6432Node\\JiangMin\\";

        // 卡巴

        // 瑞星
        private const String m_Ant_RuiXing = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\RAV";
        private const String m_Ant_RuiXing_64bit = "SOFTWARE\\WOW6432Node\\RAV\\";

        // 诺顿
        private const String m_Ant_Norton = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\NS";
        private const String m_Ant_Norton_64bit = "SOFTWARE\\WOW6432Node\\NS\\";

        // 百度杀毒
        private const String m_Ant_BaiDuShaDu = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\百度杀毒";
        private const String m_Ant_BaiDuShaDu_64bit = "SOFTWARE\\WOW6432Node\\Baidu Security\\Antivirus\\";

        // 小红伞
        private const String m_Ant_Avira = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Avira Antivirus";
        private const String m_Ant_Avira_64bit = "SOFTWARE\\WOW6432Node\\Avira Antivirus\\";


        /*====================
            Office 
        ====================*/
        // 金山WPS
        // WPS是先检测专业版再检测个人版。安装专业版，wps会自动卸载个人版。
        // 个人版是检测CurrentUser键值下
        private const String m_Office_WPS_Personal = @"SOFTWARE\Kingsoft\Office\6.0\Common\";
        private const String m_Office_WPS_Pro = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Kingsoft Office\";
        private const String m_Office_WPS_Pro_64bit = "SOFTWARE\\WOW6432Node\\kingsoft\\Office\\6.0\\Common\\";

        // 永中Office
        // 从卸载列表中检测是否存在


        private const String m_RegUninstall = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
        private const String m_RegUninstall_64bit = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\";

        #endregion

        #region 杀毒软件检测

        /// <summary>
        /// 是否存在360杀毒
        /// </summary>
        /// <returns></returns>
        public Boolean HasAnt360()
        {
            if (IsRegValueExists(m_Ant_360, "DisplayName", null))
            {
                return true;
            }
            if (IsRegExists(m_Ant_360_64bit, Microsoft.Win32.Registry.LocalMachine))
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
            if (IsRegValueExists(m_Ant_JinShanDuBa, "DisplayName", null))
            {
                return true;
            }
            if (IsRegExists(m_Ant_JinShanDuBa_64bit, Microsoft.Win32.Registry.LocalMachine))
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
            if (IsRegValueExists(m_Ant_JiangMin, "DisplayName", null))
            {
                return true;
            }
            if (IsRegExists(m_Ant_JiangMin_64bit, Microsoft.Win32.Registry.LocalMachine))
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
            if (IsRegValueExists(m_Ant_RuiXing, "DisplayName", null))
            {
                return true;
            }
            if (IsRegExists(m_Ant_RuiXing_64bit, Microsoft.Win32.Registry.LocalMachine))
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
            if (IsRegValueExists(m_Ant_Norton, "DisplayName", null))
            {
                return true;
            }
            if (IsRegExists(m_Ant_Norton_64bit, Microsoft.Win32.Registry.LocalMachine))
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
            using (MSWin32.RegistryKey regPro1 = MSWin32.Registry.LocalMachine.OpenSubKey(m_Office_WPS_Pro))
            {
                if (regPro1 != null && IsRegValueExists(m_Office_WPS_Pro, "DisplayName", MSWin32.Registry.LocalMachine))
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

            using (MSWin32.RegistryKey regPro2 = MSWin32.Registry.LocalMachine.OpenSubKey(m_Office_WPS_Pro_64bit))
            {
                if (regPro2 != null && IsRegValueExists(m_Office_WPS_Pro, "DisplayName", MSWin32.Registry.LocalMachine))
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
            using (MSWin32.RegistryKey regKey = MSWin32.Registry.CurrentUser.OpenSubKey(m_Office_WPS_Personal))
            {
                if (regKey != null && IsRegValueExists(m_Office_WPS_Pro, "DisplayName", MSWin32.Registry.LocalMachine))
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
            string regPath = GetRegPathByValue(m_RegUninstall, "DisplayName", "永中Office", null);
            return !string.IsNullOrEmpty(regPath);
        }

        public String GetMSOfficeVersion()
        {

            String offVer = GetMSOfficeVersionFromUninstall(m_RegUninstall) + "," + GetMSOfficeVersionFromUninstall(m_RegUninstall_64bit);
            return offVer.Trim(',');

        }

        private String GetMSOfficeVersionFromUninstall(string regKey)
        {
            List<String> __offList = new List<string>();

            // 获取年份
            using (MSWin32.RegistryKey reg = MSWin32.Registry.LocalMachine.OpenSubKey(regKey))
            {
                if (reg != null)
                {
                    // 获取所有卸载项并遍历
                    string[] regSubKeys = reg.GetSubKeyNames();
                    for (Int32 m = 0; m < regSubKeys.Length; m++)
                    {

                        string subKeyText = regSubKeys[m];
                        // 检查是否存在DisplayName
                        if (IsRegValueExists(m_RegUninstall + subKeyText, "DisplayName", null))
                        {
                            MSWin32.RegistryKey regTmp = reg.OpenSubKey(subKeyText);
                            String appName = regTmp.GetValue("DisplayName")?.ToString();
                            String appVer = regTmp.GetValue("DisplayVersion")?.ToString();
                            String appLocation = regTmp.GetValue("InstallLocation")?.ToString();
                            String offVerText = String.Empty;
                            String offBuildLab = String.Empty;
                            if (String.IsNullOrEmpty(appName) || String.IsNullOrEmpty(appVer) || String.IsNullOrEmpty(appLocation))
                            {
                                continue;
                            }
                            // 如果名成立包含了Office并且路径物理地址存在，继续检测
                            if (appName.Contains("Microsoft Office") && System.IO.Directory.Exists(appLocation))
                            {
                                if (appVer.Contains("11."))
                                {
                                    offVerText = "Microsoft Office 2003";
                                }
                                else if (appVer.Contains("12."))
                                {
                                    offVerText = "Microsoft Office 2007";
                                }
                                else if (appVer.Contains("14."))
                                {
                                    offVerText = "Microsoft Office 2010";
                                }
                                else if (appVer.Contains("15."))
                                {
                                    offVerText = "Microsoft Office 2013";
                                }
                                else if (appVer.Contains("16."))
                                {
                                    offVerText = "Microsoft Office 2016";
                                }


                                // 获取版本类型
                                offBuildLab = GetMSOfficeBuildLab(appName);
                                if (!__offList.Contains(offVerText + "_" + offBuildLab))
                                {
                                    __offList.Add(offVerText + "_" + offBuildLab);
                                }

                            }
                        }
                    }

                }

            }

            if (__offList != null && __offList.Count > 0)
            {
                String result = String.Empty;
                foreach (String t in __offList)
                {
                    result += t + ",";
                }
                return result.Trim(',');
            }

            return String.Empty;
        }



        /// <summary>
        /// 根据Office显示名称识别Office版本
        /// </summary>
        /// <param name="officeDisplayName"></param>
        /// <returns></returns>
        private String GetMSOfficeBuildLab(String officeDisplayName)
        {
            String offLab = String.Empty;
            if (officeDisplayName.Contains("Microsoft Office"))
            {
                String oName = officeDisplayName.ToLower();
                if (oName.Contains("starter") || oName.Contains("入门级"))
                {
                    offLab = "入门级";
                }
                else if ((oName.Contains("student") && oName.Contains("teacher")) || oName.Contains("学生教师版"))
                {
                    offLab = "学生教师版";
                }
                else if (oName.Contains("standard") || oName.Contains("标准版"))
                {
                    offLab = "标准版";
                }
                else if (oName.Contains("small business") || oName.Contains("小型企业版"))
                {
                    offLab = "小型企业版";
                }
                else if (oName.Contains("professional plus") || oName.Contains("专业增强版"))
                {
                    offLab = "专业增强版";
                }
                else if (oName.Contains("professional") || oName.Contains("专业版"))
                {
                    offLab = "专业版";
                }
                else if (oName.Contains("enterprise") || oName.Contains("企业版"))
                {
                    offLab = "企业版";
                }
                else if (oName.Contains("basic") || oName.Contains("基础版"))
                {
                    offLab = "基础版";
                }
                else if ((oName.Contains("home") && oName.Contains("student")) || oName.Contains("家庭学生版"))
                {
                    offLab = "家庭学生版";
                }
                else if (oName.Contains("academic") || oName.Contains("学术版"))
                {
                    offLab = "学术版";
                }
                else if (oName.Contains("ultimate") || oName.Contains("旗舰版"))
                {
                    offLab = "旗舰版";
                }
                else if ((oName.Contains("home") && oName.Contains("business")) || oName.Contains("家庭企业版"))
                {
                    offLab = "家庭企业版";
                }
            }

            return offLab;
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
