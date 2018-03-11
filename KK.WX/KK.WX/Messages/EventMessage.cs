using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net;

namespace KK.WX.Messages
{
    /// <summary>
    /// 事件消息
    /// </summary>
    public class EventMessage : MessageBase
    {
        /// <summary>
        /// 事件类型。
        /// </summary>
        public String Event { get; set; }
        /// <summary>事件Key</summary>
        public String EventKey { get; set; }

        #region 静态方法

        /// <summary>
        /// 尝试将XML文档转换为消息类型对象
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Boolean Parse(String msg, out EventMessage o)
        {
            XElement root = null;
            try
            {
                root = XElement.Parse(msg);
                EventMessage result = new EventMessage();
                if (root.HasElements)
                {
                    IEnumerable<XElement> t = from g in root.Elements("MsgType")
                            select g;

                    if (t == null || t.Count() == 0)
                        throw new Exception("无效的事件消息：不包含消息类型定义节点MsgType");

                    if (t.ToList().First().Value.ToLower() != WXDefine.MsgType.Event)
                    {
                        throw new Exception("该消息不是事件类型消息，而是" + t.ToList().First().Value.ToLower());
                    }

                    IEnumerable < XElement > elements = root.Elements();
                    foreach (XElement e in elements)
                    {
                        if (e.Name == "ToUserName") result.ToUserName = e.Value;
                        if (e.Name == "FromUserName") result.FromUserName = e.Value;
                        if (e.Name == "CreateTime") result.CreateTime = Int32.Parse(e.Value);
                        if (e.Name == "MsgType") result.MsgType = e.Value;
                        if (e.Name == "Event") result.Event = e.Value;
                        if (e.Name == "EventKey") result.EventKey = e.Value;
                    }
                }
                o = result;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion
    }
}
