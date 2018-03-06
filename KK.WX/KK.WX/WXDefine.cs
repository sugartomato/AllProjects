using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WX
{
    /// <summary>
    /// 微信定义
    /// </summary>
    public class WXDefine
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public class MsgType
        {
            /// <summary>消息类型-文本</summary>
            public const String Text = "text";
            /// <summary>消息类型-事件</summary>
            public const String Event = "event";
        }

        /// <summary>
        /// 事件类型
        /// </summary>
        public class Event
        {
            /// <summary>事件-订阅</summary>
            public const String Subscribe = "subscribe";
            /// <summary>事件-取消订阅</summary>
            public const String Unsubscribe = "unsubscribe";
            /// <summary>事件-点击</summary>
            public const String Click = "CLICK";
        }

        public class Scope
        {
            public const String snsapi_base = "snsapi_base";
            public const String snsapi_userinfo = "snsapi_userinfo";
        }

    }
}
