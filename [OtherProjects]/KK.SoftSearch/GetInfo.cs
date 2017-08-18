//using Microsoft.Win32;
//using SICT.Logic;
//using System;
//using System.IO;
//using System.Linq;
//using System.Xml.Linq;

//namespace SICT.Class
//{
//    public class GetPcInfo
//    {
//        public string documents = Tools.GetXmlPath();

//        public string GetSystemInfo()
//        {
//            XElement xElement = XElement.Load(this.documents + "\\AppConfig.xml");
//            string name = Tools.GetString(xElement.Element("SystemInfo").Value).Trim();
//            string name2 = Tools.GetString(xElement.Element("SystemInformation").Value).Trim();
//            string[] array = Tools.GetString(xElement.Element("InformationName").Value).Trim().Split(new char[]
//            {
//                ','
//            });
//            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(name);
//            string @string = Tools.GetString(registryKey.GetValue("ProductName"));
//            string text = this.ReSystemVersion(@string);
//            if (!text.Contains("Windows XP"))
//            {
//                Microsoft.Win32.RegistryKey registryKey2 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(name2);
//                string[] valueNames = registryKey2.GetValueNames();
//                bool flag = true;
//                int num = 0;
//                while (num < array.Length && flag)
//                {
//                    if (!(Tools.GetString(array[num]) == ""))
//                    {
//                        string[] array2 = valueNames;
//                        for (int i = 0; i < array2.Length; i++)
//                        {
//                            string name3 = array2[i];
//                            string string2 = Tools.GetString(registryKey2.GetValue(name3));
//                            if (string2.Contains(Tools.GetString(array[num])))
//                            {
//                                text = text + "(" + Tools.GetString(array[num]) + ")";
//                                flag = false;
//                                break;
//                            }
//                        }
//                    }
//                    num++;
//                }
//            }
//            return text;
//        }

//        public string GetOffice()
//        {
//            string text = "";
//            text += this.GetMicrosoftOfficeInfo();
//            text = text + ((this.Get金山WPSInfo() != "" && text != "") ? "/" : "") + this.Get金山WPSInfo();
//            return text + ((this.Get永中OfficeInfo() != "" && text != "") ? "/" : "") + this.Get永中OfficeInfo();
//        }

//        public string GetAntivirus()
//        {
//            string text = "";
//            text += this.Get360杀毒Info();
//            text = text + ((this.Get金山毒霸Info() != "" && text != "") ? "/" : "") + this.Get金山毒霸Info();
//            text = text + ((this.Get江民Info() != "" && text != "") ? "/" : "") + this.Get江民Info();
//            text = text + ((this.Get卡巴斯基Info() != "" && text != "") ? "/" : "") + this.Get卡巴斯基Info();
//            text = text + ((this.Get瑞星Info() != "" && text != "") ? "/" : "") + this.Get瑞星Info();
//            text = text + ((this.Get诺顿Info() != "" && text != "") ? "/" : "") + this.Get诺顿Info();
//            text = text + ((this.Get百度杀毒Info() != "" && text != "") ? "/" : "") + this.Get百度杀毒Info();
//            return text + ((this.Get小红伞Info() != "" && text != "") ? "/" : "") + this.Get小红伞Info();
//        }

//        private string GetMicrosoftOfficeInfo()
//        {
//            XElement xElement = XElement.Load(this.documents + "\\AppConfig.xml");
//            XElement xElement2 = xElement.Element("程序和功能");
//            XElement xElement3 = xElement.Element("程序和功能64");
//            string text = Tools.GetString(xElement2.Value).Trim();
//            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine;
//            Microsoft.Win32.RegistryKey registryKey2 = registryKey.OpenSubKey(text);
//            string text2 = "";
//            string text3 = "";
//            if (registryKey2 != null)
//            {
//                string[] subKeyNames = registryKey2.GetSubKeyNames();
//                string[] array = subKeyNames;
//                for (int i = 0; i < array.Length; i++)
//                {
//                    string str = array[i];
//                    if (this.IsKeyNameExist(text + str, "DisplayName"))
//                    {
//                        text2 = "";
//                        registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(text + str);
//                        if (registryKey != null)
//                        {
//                            string @string = Tools.GetString(registryKey.GetValue("DisplayVersion"));
//                            string string2 = Tools.GetString(registryKey.GetValue("DisplayName"));
//                            string string3 = Tools.GetString(registryKey.GetValue("InstallLocation"));
//                            if (string2.Contains("Microsoft Office") && System.IO.Directory.Exists(string3))
//                            {
//                                if (@string.Contains("11."))
//                                {
//                                    text2 = "Microsoft Office 2003";
//                                }
//                                else if (@string.Contains("12."))
//                                {
//                                    text2 = "Microsoft Office 2007";
//                                }
//                                else if (@string.Contains("14."))
//                                {
//                                    text2 = "Microsoft Office 2010";
//                                }
//                                else if (@string.Contains("15."))
//                                {
//                                    text2 = "Microsoft Office 2013";
//                                }
//                                else if (@string.Contains("16."))
//                                {
//                                    text2 = "Microsoft Office 2016";
//                                }
//                                string microsoftOfficeVer = this.GetMicrosoftOfficeVer(text);
//                                if (string.IsNullOrEmpty(microsoftOfficeVer))
//                                {
//                                    microsoftOfficeVer = this.GetMicrosoftOfficeVer(xElement3.Value);
//                                }
//                                if (!string.IsNullOrEmpty(text2) && !text3.Contains(text2 + " " + microsoftOfficeVer))
//                                {
//                                    string text4 = text3;
//                                    text3 = string.Concat(new string[]
//                                    {
//                                        text4,
//                                        (text3 != "") ? "/" : "",
//                                        text2,
//                                        " ",
//                                        microsoftOfficeVer
//                                    });
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            try
//            {
//                if (text3 == "")
//                {
//                    Microsoft.Win32.RegistryKey registryKey3 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\Excel.exe");
//                    if (registryKey3 != null)
//                    {
//                        string text5 = registryKey3.GetValue("Path").ToString();
//                        string text6 = text5.Substring(0, text5.Length - 1);
//                        string text7 = text6.Substring(text6.LastIndexOf("\\") + 1);
//                        string key;
//                        switch (key = text7)
//                        {
//                            case "Office11":
//                                text2 = "Microsoft Office 2003";
//                                break;
//                            case "OFFICE11":
//                                text2 = "Microsoft Office 2003";
//                                break;
//                            case "Office12":
//                                text2 = "Microsoft Office 2007";
//                                break;
//                            case "OFFICE12":
//                                text2 = "Microsoft Office 2007";
//                                break;
//                            case "Office14":
//                                text2 = "Microsoft Office 2010";
//                                break;
//                            case "OFFICE14":
//                                text2 = "Microsoft Office 2010";
//                                break;
//                            case "Office15":
//                                text2 = "Microsoft Office 2013";
//                                break;
//                            case "OFFICE15":
//                                text2 = "Microsoft Office 2013";
//                                break;
//                            case "Office16":
//                                text2 = "Microsoft Office 2016";
//                                break;
//                            case "OFFICE16":
//                                text2 = "Microsoft Office 2016";
//                                break;
//                        }
//                    }
//                    string microsoftOfficeVer2 = this.GetMicrosoftOfficeVer(text);
//                    if (string.IsNullOrEmpty(microsoftOfficeVer2))
//                    {
//                        microsoftOfficeVer2 = this.GetMicrosoftOfficeVer(xElement3.Value);
//                    }
//                    if (!string.IsNullOrEmpty(text2))
//                    {
//                        string text8 = text3;
//                        text3 = string.Concat(new string[]
//                        {
//                            text8,
//                            (text3 != "") ? "/" : "",
//                            text2,
//                            " ",
//                            microsoftOfficeVer2
//                        });
//                    }
//                }
//            }
//            catch
//            {
//            }
//            return text3;
//        }

//        public string GetMicrosoftOfficeVer(string url)
//        {
//            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine;
//            Microsoft.Win32.RegistryKey registryKey2 = registryKey.OpenSubKey(url);
//            string result = "";
//            if (registryKey2 != null)
//            {
//                string[] subKeyNames = registryKey2.GetSubKeyNames();
//                string[] array = subKeyNames;
//                for (int i = 0; i < array.Length; i++)
//                {
//                    string str = array[i];
//                    if (this.IsKeyNameExist(url + str, "DisplayName"))
//                    {
//                        registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(url + str);
//                        if (registryKey != null)
//                        {
//                            Tools.GetString(registryKey.GetValue("DisplayVersion"));
//                            string @string = Tools.GetString(registryKey.GetValue("DisplayName"));
//                            if (@string.Contains("Microsoft Office"))
//                            {
//                                if (@string.ToLower().Contains("starter"))
//                                {
//                                    result = "入门级";
//                                    break;
//                                }
//                                if (@string.Contains("入门级"))
//                                {
//                                    result = "入门级";
//                                    break;
//                                }
//                                if (@string.ToLower().Contains("student") && @string.ToLower().Contains("teacher"))
//                                {
//                                    result = "学生教师版";
//                                    break;
//                                }
//                                if (@string.Contains("学生教师版"))
//                                {
//                                    result = "学生教师版";
//                                    break;
//                                }
//                                if (@string.ToLower().Contains("standard"))
//                                {
//                                    result = "标准版";
//                                    break;
//                                }
//                                if (@string.Contains("标准版"))
//                                {
//                                    result = "标准版";
//                                    break;
//                                }
//                                if (@string.ToLower().Contains("small business"))
//                                {
//                                    result = "小型企业版";
//                                    break;
//                                }
//                                if (@string.Contains("小型企业版"))
//                                {
//                                    result = "小型企业版";
//                                    break;
//                                }
//                                if (@string.ToLower().Contains("professional plus"))
//                                {
//                                    result = "专业增强版";
//                                    break;
//                                }
//                                if (@string.Contains("专业增强版"))
//                                {
//                                    result = "专业增强版";
//                                    break;
//                                }
//                                if (@string.ToLower().Contains("professional"))
//                                {
//                                    result = "专业版";
//                                    break;
//                                }
//                                if (@string.Contains("专业版"))
//                                {
//                                    result = "专业版";
//                                    break;
//                                }
//                                if (@string.ToLower().Contains("enterprise"))
//                                {
//                                    result = "企业版";
//                                    break;
//                                }
//                                if (@string.Contains("企业版"))
//                                {
//                                    result = "企业版";
//                                    break;
//                                }
//                                if (@string.ToLower().Contains("basic"))
//                                {
//                                    result = "基础版";
//                                    break;
//                                }
//                                if (@string.Contains("基础版"))
//                                {
//                                    result = "基础版";
//                                    break;
//                                }
//                                if (@string.ToLower().Contains("home") && @string.ToLower().Contains("student"))
//                                {
//                                    result = "家庭学生版";
//                                    break;
//                                }
//                                if (@string.Contains("家庭学生版"))
//                                {
//                                    result = "家庭学生版";
//                                    break;
//                                }
//                                if (@string.ToLower().Contains("academic"))
//                                {
//                                    result = "学术版";
//                                    break;
//                                }
//                                if (@string.Contains("学术版"))
//                                {
//                                    result = "学术版";
//                                    break;
//                                }
//                                if (@string.ToLower().Contains("ultimate"))
//                                {
//                                    result = "旗舰版";
//                                    break;
//                                }
//                                if (@string.Contains("旗舰版"))
//                                {
//                                    result = "旗舰版";
//                                    break;
//                                }
//                                if (@string.ToLower().Contains("home") && @string.ToLower().Contains("business"))
//                                {
//                                    result = "家庭企业版";
//                                    break;
//                                }
//                                if (@string.Contains("家庭企业版"))
//                                {
//                                    result = "家庭企业版";
//                                    break;
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            return result;
//        }

//        private string Get金山WPSInfo()
//        {
//            XElement xElement = XElement.Load(this.documents + "\\AppConfig.xml");
//            XElement xElement2 = xElement.Elements("金山WPS个人版").FirstOrDefault<XElement>();
//            XElement xElement3 = xElement.Elements("金山WPS企业版").FirstOrDefault<XElement>();
//            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(xElement2.Value.Trim());
//            Microsoft.Win32.RegistryKey registryKey2 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(xElement3.Value.Trim());
//            Microsoft.Win32.RegistryKey registryKey3 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\kingsoft\\Office\\6.0\\Common\\");
//            string result = "";
//            if (registryKey2 != null)
//            {
//                string @string = Tools.GetString(registryKey2.GetValue("DisplayName"));
//                if (!string.IsNullOrEmpty(@string))
//                {
//                    if (@string.IndexOf("(8.") != -1)
//                    {
//                        result = "WPS Office 2012 专业版";
//                    }
//                    else if (@string.IndexOf("(9.") != -1)
//                    {
//                        result = "WPS Office 2013 专业版";
//                    }
//                    else if (@string.IndexOf("(10.") != -1)
//                    {
//                        result = "WPS Office 2016 专业版";
//                    }
//                    else
//                    {
//                        result = @string;
//                    }
//                }
//            }
//            if (registryKey3 != null)
//            {
//                string string2 = Tools.GetString(registryKey3.GetValue("DisplayName"));
//                if (!string.IsNullOrEmpty(string2))
//                {
//                    if (string2.IndexOf("(8.") != -1)
//                    {
//                        result = "WPS Office 2012 专业版";
//                    }
//                    else if (string2.IndexOf("(9.") != -1)
//                    {
//                        result = "WPS Office 2013 专业版";
//                    }
//                    else if (string2.IndexOf("(10.") != -1)
//                    {
//                        result = "WPS Office 2016 专业版";
//                    }
//                    else
//                    {
//                        result = string2;
//                    }
//                }
//            }
//            if (registryKey != null)
//            {
//                string string3 = Tools.GetString(registryKey.GetValue("DisplayName"));
//                if (!string.IsNullOrEmpty(string3))
//                {
//                    if (string3.IndexOf("(8.") != -1)
//                    {
//                        result = "WPS Office 2012 个人版";
//                    }
//                    else if (string3.IndexOf("(9.") != -1)
//                    {
//                        result = "WPS Office 2013 个人版";
//                    }
//                    else if (string3.IndexOf("(10.") != -1)
//                    {
//                        result = "WPS Office 2016 个人版";
//                    }
//                    else
//                    {
//                        result = string3;
//                    }
//                }
//            }
//            return result;
//        }

//        private string Get永中OfficeInfo()
//        {
//            XElement xElement = XElement.Load(this.documents + "\\AppConfig.xml");
//            XElement xElement2 = xElement.Elements("永中Office").FirstOrDefault<XElement>();
//            string registryUrl = this.GetRegistryUrl(xElement2.Value.Trim(), "永中Office");
//            string result = "";
//            if (!string.IsNullOrEmpty(registryUrl))
//            {
//                Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(registryUrl);
//                if (this.IsRegeditItemExist(registryUrl, "DisplayName") && Tools.GetString(registryKey.GetValue("DisplayName")).Contains("永中Office"))
//                {
//                    result = Tools.GetString(registryKey.GetValue("DisplayName"));
//                }
//            }
//            return result;
//        }

//        private string Get360杀毒Info()
//        {
//            XElement xElement = XElement.Load(this.documents + "\\AppConfig.xml");
//            XElement xElement2 = xElement.Elements("Antivirus360杀毒").FirstOrDefault<XElement>();
//            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(xElement2.Value.Trim());
//            string text = "";
//            if (this.IsRegeditItemExist(xElement2.Value.Trim(), "DisplayName"))
//            {
//                text = "360杀毒软件";
//            }
//            if (string.IsNullOrEmpty(text))
//            {
//                registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\360SD\\");
//                if (registryKey != null)
//                {
//                    text = "360杀毒软件";
//                }
//            }
//            return text;
//        }

//        private string Get金山毒霸Info()
//        {
//            XElement xElement = XElement.Load(this.documents + "\\AppConfig.xml");
//            XElement xElement2 = xElement.Elements("金山毒霸").FirstOrDefault<XElement>();
//            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(xElement2.Value.Trim());
//            string text = "";
//            if (this.IsRegeditItemExist(xElement2.Value.Trim(), "DisplayName"))
//            {
//                text = "金山毒霸杀毒软件";
//            }
//            if (string.IsNullOrEmpty(text))
//            {
//                registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Kingsoft\\antivirus\\");
//                if (registryKey != null)
//                {
//                    text = "金山毒霸杀毒软件";
//                }
//            }
//            return text;
//        }

//        private string Get江民Info()
//        {
//            XElement xElement = XElement.Load(this.documents + "\\AppConfig.xml");
//            XElement xElement2 = xElement.Elements("江民").FirstOrDefault<XElement>();
//            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(xElement2.Value.Trim());
//            string text = "";
//            if (this.IsRegeditItemExist(xElement2.Value.Trim(), "DisplayName"))
//            {
//                text = "江民杀毒软件";
//            }
//            if (string.IsNullOrEmpty(text))
//            {
//                registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\JiangMin\\");
//                if (registryKey != null)
//                {
//                    text = "江民杀毒软件";
//                }
//            }
//            return text;
//        }

//        private string Get卡巴斯基Info()
//        {
//            XElement xElement = XElement.Load(this.documents + "\\AppConfig.xml");
//            XElement xElement2 = xElement.Elements("卡巴斯基").FirstOrDefault<XElement>();
//            string result = "";
//            string registryUrl = this.GetRegistryUrl(xElement2.Value.Trim(), "卡巴斯基");
//            if (!string.IsNullOrEmpty(registryUrl))
//            {
//                result = "卡巴斯基杀毒软件";
//            }
//            return result;
//        }

//        private string Get瑞星Info()
//        {
//            XElement xElement = XElement.Load(this.documents + "\\AppConfig.xml");
//            XElement xElement2 = xElement.Elements("瑞星").FirstOrDefault<XElement>();
//            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(xElement2.Value.Trim());
//            string text = "";
//            if (this.IsRegeditItemExist(xElement2.Value.Trim(), "DisplayName"))
//            {
//                text = "瑞星杀毒软件";
//            }
//            if (string.IsNullOrEmpty(text))
//            {
//                registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\RAV\\");
//                if (registryKey != null)
//                {
//                    text = "瑞星杀毒软件";
//                }
//            }
//            return text;
//        }

//        private string Get诺顿Info()
//        {
//            XElement xElement = XElement.Load(this.documents + "\\AppConfig.xml");
//            XElement xElement2 = xElement.Elements("诺顿").FirstOrDefault<XElement>();
//            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(xElement2.Value.Trim());
//            string text = "";
//            if (this.IsRegeditItemExist(xElement2.Value.Trim(), "DisplayName"))
//            {
//                text = "诺顿杀毒软件";
//            }
//            if (string.IsNullOrEmpty(text))
//            {
//                registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\NS\\");
//                if (registryKey != null)
//                {
//                    text = "诺顿杀毒软件";
//                }
//            }
//            return text;
//        }

//        private string Get百度杀毒Info()
//        {
//            XElement xElement = XElement.Load(this.documents + "\\AppConfig.xml");
//            XElement xElement2 = xElement.Elements("百度杀毒").FirstOrDefault<XElement>();
//            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(xElement2.Value.Trim());
//            string text = "";
//            if (this.IsRegeditItemExist(xElement2.Value.Trim(), "DisplayName"))
//            {
//                text = "百度杀毒软件";
//            }
//            if (string.IsNullOrEmpty(text))
//            {
//                registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Baidu Security\\Antivirus\\");
//                if (registryKey != null)
//                {
//                    text = "百度杀毒软件";
//                }
//            }
//            return text;
//        }

//        private string Get小红伞Info()
//        {
//            XElement xElement = XElement.Load(this.documents + "\\AppConfig.xml");
//            XElement xElement2 = xElement.Elements("小红伞").FirstOrDefault<XElement>();
//            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(xElement2.Value.Trim());
//            string text = "";
//            if (this.IsRegeditItemExist(xElement2.Value.Trim(), "DisplayName"))
//            {
//                text = "小红伞杀毒软件";
//            }
//            if (string.IsNullOrEmpty(text))
//            {
//                registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Avira Antivirus\\");
//                if (registryKey != null)
//                {
//                    text = "小红伞杀毒软件";
//                }
//            }
//            return text;
//        }

//        private bool IsRegeditItemExist(string url, string val)
//        {
//            Microsoft.Win32.RegistryKey localMachine = Microsoft.Win32.Registry.LocalMachine;
//            Microsoft.Win32.RegistryKey registryKey = localMachine.OpenSubKey(url);
//            if (registryKey != null)
//            {
//                string[] valueNames = registryKey.GetValueNames();
//                string[] array = valueNames;
//                for (int i = 0; i < array.Length; i++)
//                {
//                    string a = array[i];
//                    if (a == val)
//                    {
//                        localMachine.Close();
//                        return true;
//                    }
//                }
//            }
//            localMachine.Close();
//            return false;
//        }

//        private bool IsKeyNameExist(string url, string val)
//        {
//            Microsoft.Win32.RegistryKey localMachine = Microsoft.Win32.Registry.LocalMachine;
//            Microsoft.Win32.RegistryKey registryKey = localMachine.OpenSubKey(url);
//            if (registryKey != null)
//            {
//                string[] valueNames = registryKey.GetValueNames();
//                string[] array = valueNames;
//                for (int i = 0; i < array.Length; i++)
//                {
//                    string a = array[i];
//                    if (a == val)
//                    {
//                        localMachine.Close();
//                        return true;
//                    }
//                }
//            }
//            localMachine.Close();
//            return false;
//        }

//        private string GetRegistryUrl(string url, string name)
//        {
//            Microsoft.Win32.RegistryKey localMachine = Microsoft.Win32.Registry.LocalMachine;
//            Microsoft.Win32.RegistryKey registryKey = localMachine.OpenSubKey(url);
//            if (registryKey != null)
//            {
//                string[] subKeyNames = registryKey.GetSubKeyNames();
//                string[] array = subKeyNames;
//                for (int i = 0; i < array.Length; i++)
//                {
//                    string str = array[i];
//                    if (this.IsKeyNameExist(url + str, "DisplayName") && Tools.GetString(localMachine.OpenSubKey(url + str).GetValue("DisplayName")).Contains(name))
//                    {
//                        localMachine.Close();
//                        return url + str;
//                    }
//                }
//            }
//            localMachine.Close();
//            return "";
//        }

//        private string ReSystemVersion(string SystemVersion)
//        {
//            if (SystemVersion.Contains("Windows XP Home"))
//            {
//                SystemVersion = "Windows XP 家庭版";
//            }
//            else if (SystemVersion.Contains("Windows XP Professional"))
//            {
//                SystemVersion = "Windows XP 专业版";
//            }
//            else if (SystemVersion.Contains("Windows XP Server"))
//            {
//                SystemVersion = "Windows XP 服务器版";
//            }
//            else if (SystemVersion.Contains("Windows XP Advanced Server"))
//            {
//                SystemVersion = "Windows XP 高级服务器版";
//            }
//            else if (SystemVersion.Contains("Windows XP Data Center Server"))
//            {
//                SystemVersion = "Windows XP 数据中心服务器版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2003 Web"))
//            {
//                SystemVersion = "Windows Server 2003 Web版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2003 Standard"))
//            {
//                SystemVersion = "Windows Server 2003 标准版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2003 Enterprise"))
//            {
//                SystemVersion = "Windows Server 2003 企业版";
//            }
//            else if (SystemVersion.Contains("Windows 2003 Datacenter"))
//            {
//                SystemVersion = "Windows Server 2003 数据中心版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2003 R2 Web"))
//            {
//                SystemVersion = "Windows Server 2003 R2 Web版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2003 R2 Standard"))
//            {
//                SystemVersion = "Windows Server 2003 R2 标准版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2003 R2 Enterprise"))
//            {
//                SystemVersion = "Windows Server 2003 R2 企业版";
//            }
//            else if (SystemVersion.Contains("Windows 2003 R2 Datacenter"))
//            {
//                SystemVersion = "Windows Server 2003 R2 数据中心版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2008 Standard"))
//            {
//                SystemVersion = "Windows Server 2008 标准版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2008 Enterprise"))
//            {
//                SystemVersion = "Windows Server 2008 企业版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2008 Datacenter"))
//            {
//                SystemVersion = "Windows Server 2008 数据中心版";
//            }
//            else if (SystemVersion.Contains("Windows Web Server 2008"))
//            {
//                SystemVersion = "Windows Server 2008 web应用程序服务器";
//            }
//            else if (SystemVersion.Contains("Windows Server 2008 R2 Standard"))
//            {
//                SystemVersion = "Windows Server 2008 R2 标准版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2008 R2 Enterprise"))
//            {
//                SystemVersion = "Windows Server 2008 R2 企业版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2008 R2 Datacenter"))
//            {
//                SystemVersion = "Windows Server 2008 R2 数据中心版";
//            }
//            else if (SystemVersion.Contains("Windows Web Server 2008 R2"))
//            {
//                SystemVersion = "Windows Server 2008 R2 web应用程序服务器";
//            }
//            else if (SystemVersion.Contains("Windows Server 2012 Foundation"))
//            {
//                SystemVersion = "Windows Server 2012 基础版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2012 Essentials"))
//            {
//                SystemVersion = "Windows Server 2012 中小企业版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2012 Standard"))
//            {
//                SystemVersion = "Windows Server 2012 标准版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2012 Datacenter"))
//            {
//                SystemVersion = "Windows Server 2012 数据中心版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2012 R2 Foundation"))
//            {
//                SystemVersion = "Windows Server 2012 R2 基础版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2012 R2 Essentials"))
//            {
//                SystemVersion = "Windows Server 2012 R2 中小企业版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2012 R2 Standard"))
//            {
//                SystemVersion = "Windows Server 2012 R2 标准版";
//            }
//            else if (SystemVersion.Contains("Windows Server 2012 R2 Datacenter"))
//            {
//                SystemVersion = "Windows Server 2012 R2 数据中心版";
//            }
//            else if (SystemVersion.Contains("Windows 7 Starter"))
//            {
//                SystemVersion = "Windows 7 初级版";
//            }
//            else if (SystemVersion.Contains("Windows 7 Home Basic"))
//            {
//                SystemVersion = "Windows 7 家庭普通版";
//            }
//            else if (SystemVersion.Contains("Windows 7 Home Premium"))
//            {
//                SystemVersion = "Windows 7 家庭高级版";
//            }
//            else if (SystemVersion.Contains("Windows 7 Professional"))
//            {
//                SystemVersion = "Windows 7 专业版";
//            }
//            else if (SystemVersion.Contains("Windows 7 Enterprise"))
//            {
//                SystemVersion = "Windows 7 企业版";
//            }
//            else if (SystemVersion.Contains("Windows 7 Ultimate"))
//            {
//                SystemVersion = "Windows 7 旗舰版";
//            }
//            else if (SystemVersion.Contains("Windows 8 Professional"))
//            {
//                SystemVersion = "Windows 8 专业版";
//            }
//            else if (SystemVersion.Contains("Windows 8 Enterprise"))
//            {
//                SystemVersion = "Windows 8 企业版";
//            }
//            else if (SystemVersion.Contains("Windows 8.1 Professional"))
//            {
//                SystemVersion = "Windows 8.1 专业版";
//            }
//            else if (SystemVersion.Contains("Windows 8.1 Enterprise"))
//            {
//                SystemVersion = "Windows 8.1 企业版";
//            }
//            else if (SystemVersion.Contains("Windows 8.1"))
//            {
//                SystemVersion = "Windows 8.1 标准版";
//            }
//            else if (SystemVersion.Contains("Windows 8"))
//            {
//                SystemVersion = "Windows 8 标准版";
//            }
//            else if (SystemVersion.Contains("Windows 10 Home"))
//            {
//                SystemVersion = "Windows 10 家庭版";
//            }
//            else if (SystemVersion.Contains("Windows 10 Pro"))
//            {
//                SystemVersion = "Windows 10 专业版";
//            }
//            else if (SystemVersion.Contains("Windows 10 Enterprise"))
//            {
//                SystemVersion = "Windows 10 企业版";
//            }
//            else if (SystemVersion.Contains("Windows 10 Education"))
//            {
//                SystemVersion = "Windows 10 教育版";
//            }
//            else if (SystemVersion.Contains("Windows XP"))
//            {
//                SystemVersion = "Windows XP";
//            }
//            else if (SystemVersion.Contains("Windows Server 2003 R2"))
//            {
//                SystemVersion = "Windows Server 2003 R2";
//            }
//            else if (SystemVersion.Contains("Windows Server 2003"))
//            {
//                SystemVersion = "Windows Server 2003";
//            }
//            else if (SystemVersion.Contains("Windows Server 2008 R2"))
//            {
//                SystemVersion = "Windows Server 2008 R2";
//            }
//            else if (SystemVersion.Contains("Windows Server 2008"))
//            {
//                SystemVersion = "Windows Server 2008";
//            }
//            else if (SystemVersion.Contains("Windows Server 2012 R2"))
//            {
//                SystemVersion = "Windows Server 2012 R2";
//            }
//            else if (SystemVersion.Contains("Windows Server 2012"))
//            {
//                SystemVersion = "Windows Server 2012";
//            }
//            else if (SystemVersion.Contains("Windows 7"))
//            {
//                SystemVersion = "Windows 7";
//            }
//            else if (SystemVersion.Contains("Windows 10"))
//            {
//                SystemVersion = "Windows 10";
//            }
//            else
//            {
//                SystemVersion = "";
//            }
//            return SystemVersion;
//        }
//    }
//}
