using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WechatAuto
{
    class MessageRequest
    {
        public BaseRequest BaseRequest { get; set; }
        public Msg Msg { get; set; }
        public Int32 Scene { get; set; }
    }
}
