using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32
{
    /// <summary>
    /// 信息查询
    /// </summary>
    public class Query
    {
        /// <summary>
        /// 获取计算机的序列号
        /// </summary>
        /// <returns></returns>
        public static string GetIdentifyingNumber()
        {
            List<Win32Provider.Win32_ComputerSystemProduct> l = Win32Provider.ProviderHelper<Win32Provider.Win32_ComputerSystemProduct>.GetAll();
            if (l != null && l.Count > 0)
            {
                return l[0].IdentifyingNumber;
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取计算机名
        /// </summary>
        /// <returns></returns>
        public static string GetComputerName()
        {
            return Environment.MachineName;
        }


        #region 获取安装软件列表

        /// <summary>
        /// 获取已安装的软件列表。不包含系统组件与Windows更新
        /// </summary>
        /// <returns></returns>
        public static List<InstalledApp> GetInstalledApps()
        {
            List<InstalledApp> result = new List<InstalledApp>();

            // 获取通过Installer形式安装的软件安装的软件列表
            List<Win32Provider.Win32_Product> listApps = Win32Provider.ProviderHelper<Win32Provider.Win32_Product>.GetAll();
            if (listApps != null && listApps.Count > 0)
            {
                foreach (var app in listApps)
                {
                    var tmpModel = new InstalledApp()
                    {
                        Name = app.Name,
                        IdentifyingNumber = app.IdentifyingNumber,
                        IsInstallByWindowsInstaller = true,
                        VersionString = app.Version,
                        Caption = app.Caption,
                        HelpLink = app.HelpLink,
                        HelpTelephone = app.HelpTelephone,
                        InstallLocation = app.InstallLocation,
                        InstallSource = app.InstallSource,
                        Publisher = app.Vendor,
                        URLInfoAbout = app.URLInfoAbout,
                    };

                    DateTime inDate;
                    if (!string.IsNullOrEmpty(app.InstallDate))
                    {
                        if (DateTime.TryParse(app.InstallDate, out inDate))
                        {
                            tmpModel.InstallDate = inDate;
                        }
                    }

                    result.Add(tmpModel);
                }
            }

            // 从注册表HKEY_LOCAL_MACHINE的Uninstall中获取
            using (Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(RegHelper.RegPath_Uninstall))
            {
                GetAppsFromUninstallRegKey(reg, ref result);
            }

            // 从注册表HKEY_LOCAL_MACHINE的64位Uninstall中获取
            using (Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(RegHelper.RegPath_Uninstall64))
            {
                GetAppsFromUninstallRegKey(reg, ref result);
            }

            // 从注册表HKEY_CURRENT_USER的Uninstall中获取
            using (Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegHelper.RegPath_Uninstall64))
            {
                GetAppsFromUninstallRegKey(reg, ref result);
            }

            return result;
        }

        /// <summary>
        /// 从注册表卸载项里获取安装的程序
        /// 
        /// </summary>
        private static void GetAppsFromUninstallRegKey(Microsoft.Win32.RegistryKey regKey, ref List<InstalledApp> result)
        {
            if (regKey == null) return;
            if (result == null) result = new List<InstalledApp>();

            String[] _subKeyNames = regKey.GetSubKeyNames();
            if (_subKeyNames != null && _subKeyNames.Length > 0)
            {
                foreach (var keyName in _subKeyNames)
                {
                    Microsoft.Win32.RegistryKey regTmp = regKey.OpenSubKey(keyName);
                    object displayName = regTmp.GetValue("DisplayName");
                    if (displayName != null)
                    {
                        // 检查是否已经存在
                        if (result.FirstOrDefault(c => c.Name == displayName.ToString()) == null)
                        {
                            var tmpModel = new InstalledApp()
                            {
                                Name = displayName.ToString(),
                                VersionString = regTmp.GetValue("DisplayVersion")?.ToString(),
                                InstallLocation = regTmp.GetValue("InstallLocation")?.ToString(),
                                Publisher = regTmp.GetValue("Publisher")?.ToString(),
                                UninstallString = regTmp.GetValue("UninstallString")?.ToString(),
                                HelpLink = regTmp.GetValue("HelpLink")?.ToString(),
                                HelpTelephone = regTmp.GetValue("HelpTelephone")?.ToString(),
                                InstallSource = regTmp.GetValue("InstallSource")?.ToString(),
                                ReleaseType = regTmp.GetValue("ReleaseType")?.ToString(),
                                URLInfoAbout = regTmp.GetValue("URLInfoAbout")?.ToString(),
                                Caption = regTmp.GetValue("Caption")?.ToString(),
                                Comments = regTmp.GetValue("Comments")?.ToString(),
                            };

                            // 是否为系统组件
                            Object tmpVal = regTmp.GetValue("SystemComponent");
                            if (tmpVal != null)
                            {
                                if (Convert.ToInt32(tmpVal.ToString()) == 1)
                                {
                                    tmpModel.IsSystemComponent = true;
                                }
                            }

                            // 获取安装日期
                            tmpVal = regTmp.GetValue("InstallDate");
                            if (tmpVal != null && !String.IsNullOrEmpty(tmpVal.ToString()))
                            {
                                DateTime TT = DateTime.MinValue;
                                if (DateTime.TryParse(tmpVal.ToString(), out TT))
                                {
                                    tmpModel.InstallDate = TT;
                                }
                            }

                            // 是否通过WindowsInstaller安装
                            tmpVal = regTmp.GetValue("WindowsInstaller");
                            if (tmpVal != null)
                            {
                                if (Convert.ToInt32(tmpVal.ToString()) == 1)
                                {
                                    tmpModel.IsInstallByWindowsInstaller = true;
                                }
                            }

                            // 是否为系统更新
                            // 如果键名里包含了
                            if (System.Text.RegularExpressions.Regex.IsMatch(keyName, @"KB[0-9]{6,}$"))
                            {
                                tmpModel.IsWindowsUpdate = true;
                            }

                            tmpModel.RegKeyPath = regKey.ToString();

                            result.Add(tmpModel);
                        }
                    }
                }
            }

        }

        #endregion


    }
}
