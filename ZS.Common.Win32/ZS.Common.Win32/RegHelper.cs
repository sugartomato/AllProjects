﻿using System;
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


    }
}