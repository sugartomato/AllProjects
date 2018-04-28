using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WechatAuto
{
    public class Msg
    {
        public Int32 Type { get; set; }
        public String Content { get; set; }
        public String FromUserName { get; set; }
        public String ToUserName { get; set; }
        public String LocalID { get; set; }
        public String MediaId { get; set; }
        public String ClientMsgId { get; set; }
    }
}
