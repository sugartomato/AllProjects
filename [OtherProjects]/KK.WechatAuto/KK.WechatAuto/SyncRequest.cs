using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WechatAuto
{

    /// <summary>
    /// webwxsync请求参数对象
    /// </summary>
    public class SyncRequest
    {
        public BaseRequest BaseRequest { get; set; }
        public SyncKey SyncKey { get; set; }
        public String rr { get; set; }
    }
}
