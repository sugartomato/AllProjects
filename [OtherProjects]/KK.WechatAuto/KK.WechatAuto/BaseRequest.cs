using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WechatAuto
{
    public class BaseRequest
    {
        public Int64 Uin { get; set; }
        public String Sid { get; set; }
        public String Skey { get; set; }
        public String DeviceID { get; set; }


        public static BaseRequest Get(Session session)
        {
            return new BaseRequest()
            {
                Sid = session.wxsid,
                Uin = Int64.Parse(session.wxuin),
                Skey = session.skey,
                DeviceID = Common.GetDeviceID()
            };
        }
    }
}
