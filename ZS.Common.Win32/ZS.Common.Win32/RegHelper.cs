using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSWin32 = Microsoft.Win32;

namespace ZS.Common.Win32
{
    /// <summary>
    /// 注册表操作
    /// </summary>
    public class RegHelper
    {

        /// <summary>注册表【程序列表】路径</summary>
        public const String RegPath_Uninstall = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
        /// <summary>注册表【程序列表64位】路径</summary>
        public const String RegPath_Uninstall64 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="regPath">要导出的注册表路径。需要包含根路径。跟路径简写为：HKLM\,HKCU\,HKCR\,HKU\,HKCC\</param>
        /// <param name="savePath">注册表保存路径。包含完整文件名</param>
        /// <param name="overwrite">是否覆盖已存在的文件</param>
        /// <returns></returns>
        public static Boolean Export(String regPath, String savePath, Boolean overwrite)
        {
            if (String.IsNullOrEmpty(regPath))
            {
                throw new System.ArgumentNullException("regPath", "未定义要导出的注册表路径");
            }
            if (String.IsNullOrEmpty(savePath))
            {
                throw new System.ArgumentNullException("savePath", "未定义要保存的路径");
            }

            if (System.IO.File.Exists(savePath))
            {
                System.IO.File.Delete(savePath);
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.FileName = "reg.exe";
            psi.Arguments = "export " + regPath + " " + savePath;
            psi.CreateNoWindow = false;
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;

            System.Diagnostics.Process ps = new System.Diagnostics.Process();
            ps.StartInfo = psi;
            ps.Start();

            String error = ps.StandardError.ReadToEnd();
            if (!String.IsNullOrEmpty(error))
            {
                throw new Exception(error);
            }

            String output = ps.StandardOutput.ReadToEnd();
            Console.WriteLine(output);


            return true;
        }

        /// <summary>
        /// 获取指定键值下的指定
        /// </summary>
        /// <param name="reg"></param>
        /// <param name="valName"></param>
        /// <returns></returns>
        public Object GetValue(Microsoft.Win32.RegistryKey reg, String valName)
        {
            throw new ApplicationException("未实现的方法");
        }


        #region VSTO 信息

        public static MSWin32.RegistryKey GetVstoRegKey(String vstoName)
        {
            // 64位系统，先搜索HKLM
            throw new ApplicationException("未实现的方法");
            //Microsoft.Win32.Registry.SetValue()
        }

        public static String GetVstoLocation(String vstoName)
        {
            throw new ApplicationException("未实现的方法");
        }

        public static Boolean RegVSTO()
        {
            //Microsoft.Win32.Registry.SetValue();
            throw new ApplicationException("未实现的方法");
        }



        #endregion


        #region 公共方法

        /// <summary>
        /// 获取指定注册表项的最后修改时间
        /// </summary>
        /// <param name="rootKey">注册表根项</param>
        /// <param name="subKey">注册表子健</param>
        /// <returns></returns>
        public static DateTime GetRegKeyLastWritetime(Microsoft.Win32.RegistryHive rootKey, String subKey)
        {
            DateTime result = default(DateTime);
            IntPtr keyHandle = IntPtr.Zero;
            Int32 openResult = 0;

            if (!String.IsNullOrEmpty(subKey))
            {
                subKey = subKey.TrimStart('\\').TrimStart('/');
            }

            if (System.Environment.Is64BitOperatingSystem)
            {
                openResult = API.RegOpenKeyEx((IntPtr)rootKey, subKey, 0, API.RegSamEnum.KEY_READ | API.RegSamEnum.KEY_WOW64_64KEY, ref keyHandle);

                // 尝试64位
                if (openResult != 0)
                {
                    // 尝试32位
                    openResult = API.RegOpenKeyEx((IntPtr)rootKey, subKey, 0, API.RegSamEnum.KEY_READ | API.RegSamEnum.KEY_WOW64_32KEY, ref keyHandle);
                    if (openResult != 0)
                    {
                        throw new ApplicationException("通过64位/32位均尝试打开注册表项目失败，错误代码：" + openResult.ToString());
                    }
                }
            }
            else
            {
                openResult = API.RegOpenKeyEx((IntPtr)rootKey, subKey, 0, API.RegSamEnum.KEY_READ, ref keyHandle);
                if (openResult != 0)
                {
                    throw new ApplicationException("通过64位/32位均尝试打开注册表项目失败，错误代码：" + openResult.ToString());
                }
            }

            System.Runtime.InteropServices.ComTypes.FILETIME fTime = default(System.Runtime.InteropServices.ComTypes.FILETIME);

            Int32 queryInfoResult = API.RegQueryInfoKey((IntPtr)keyHandle, null, 0, (IntPtr)0, (IntPtr)0, (IntPtr)0, (IntPtr)0, (IntPtr)0, (IntPtr)0, (IntPtr)0, (IntPtr)0, ref fTime);
            if (queryInfoResult != 0)
            {
                // 关闭注册表项
                API.RegCloseKey(keyHandle);
                throw new ApplicationException("尝试获取注册表信息失败，错误代码：" + openResult.ToString());
            }

            long hft2 = (((long)fTime.dwHighDateTime) << 32) | ((uint)fTime.dwLowDateTime);
            result = DateTime.FromFileTimeUtc(hft2);

            // 关闭注册表项
            API.RegCloseKey(keyHandle);

            return result;
        }


        #endregion

    }
}
