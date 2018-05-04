using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WechatAuto
{
    public class BaseResponse
    {
        public Int32 Ret { get; set; } = -9999;
        public String ErrMsg { get; set; }
    }
}
