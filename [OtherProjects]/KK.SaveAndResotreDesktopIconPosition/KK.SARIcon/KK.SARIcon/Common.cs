using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KK.SARIcon
{
    public class Common
    {

        public static String XMLPath
        {
            get
            {
                String xmlFileName = "DesktopIconLocation.xml";
                String appRootPath = AppDomain.CurrentDomain.BaseDirectory;
                if (!appRootPath.EndsWith("\\"))
                {
                    appRootPath += "\\";
                }
                return appRootPath + xmlFileName;
            }
        }


    }
}
