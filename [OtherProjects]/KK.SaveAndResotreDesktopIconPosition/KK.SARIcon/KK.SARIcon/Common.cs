using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KK.SARIcon
{
    public class Common
    {

        public static String DefaultXmlPath
        {
            get
            {
                String xmlFileName = "DesktopIconLocation.xml";
                return AppRoot + xmlFileName;
            }
        }

        public static String AppRoot
        {
            get
            {
                String appRootPath = AppDomain.CurrentDomain.BaseDirectory;
                if (!appRootPath.EndsWith("\\"))
                {
                    appRootPath += "\\";
                }
                return appRootPath;
            }
        }

    }
}
