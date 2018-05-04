using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WechatAuto
{
    public class MessageResponse
    {
        public BaseResponse BaseResponse { get; set; }
        public String MsgID { get; set; }
        public String LocalID { get; set; }
    }
}
