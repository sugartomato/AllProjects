using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace KK.WechatAuto
{
    public class SyncList
    {
        public SyncList() { }
        public SyncList(Int32 key, Int64 val)
        {
            Key = key;
            Val = val;
        }
        public Int32 Key { get; set; }
        public Int64 Val { get; set; }

    }
}
