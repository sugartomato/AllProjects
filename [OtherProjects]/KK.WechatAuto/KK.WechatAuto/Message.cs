using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WechatAuto
{
    public class Message
    {
        public Message() { }
        public Message(String text, Boolean isDebug, MessageType msgType)
        {
            Text = text;
            IsDebug = isDebug;
            MsgType = msgType;
        }
        public String Text { get; set; }
        public Boolean IsDebug { get; set; } = true;
        public MessageType MsgType { get; set; } = MessageType.Information;

        public enum MessageType
        {
            Information,
            Error,
            Success,
            Warning
        }
    }
}
