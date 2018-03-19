using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KK.FileBackup
{
    public class SMTPSetting
    {
        public SMTPSetting() { }
        public SMTPSetting(String host, Int32 port)
        {
            this.Host = host;
            this.Port = port;
        }
        public SMTPSetting(String host, Int32 port,String account,String password)
        {
            this.Host = host;
            this.Port = port;
            this.Account = account;
            this.Password = password;
        }

        public String Host { get; set; }
        public Int32 Port { get; set; }
        public String Account { get; set; }
        public String Password { get; set; }

    }
}
