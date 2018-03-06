using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net;


namespace KK.WX.Messages
{
    public class MessageBase
    {

        /// <summary>接收方</summary>
        public String ToUserName { get; set; }
        /// <summary>发送方</summary>
        public String FromUserName { get; set; }
        /// <summary>创建时间</summary>
        public Int32 CreateTime { get; set; }
        /// <summary>消息类型</summary>
        public String MsgType { get; set; }

        #region MyRegion


        /// <summary>
        /// 尝试将XML文档转换为基本消息类型对象
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Boolean Parse(String msg, out MessageBase o)
        {
            XElement root = null;
            try
            {
                root = XElement.Parse(msg);
                MessageBase result = new MessageBase();
                if (root.HasElements)
                {
                    IEnumerable<XElement> elements = root.Elements();
                    foreach (XElement e in elements)
                    {
                        if (e.Name == "ToUserName") result.ToUserName = e.Value;
                        if (e.Name == "FromUserName") result.FromUserName = e.Value;
                        if (e.Name == "CreateTime") result.CreateTime = Int32.Parse(e.Value);
                        if (e.Name == "MsgType") result.MsgType = e.Value;
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
