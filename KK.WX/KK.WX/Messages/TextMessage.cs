using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Net;

namespace KK.WX.Messages
{
   public class TextMessage:MessageBase
    {
        public String Content { get; set; }

        /// <summary>
        /// 将消息对象转换为微信回复的文本消息
        /// </summary>
        /// <returns></returns>
        public String ToReplyXML()
        {
            XElement root = new XElement("xml");
            root.Add(new XElement("ToUserName", this.ToUserName));
            root.Add(new XElement("FromUserName", this.FromUserName));
            root.Add(new XElement("CreateTime", (Int32)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds));
            root.Add(new XElement("MsgType", "text"));
            root.Add(new XElement("Content", this.Content));
            return root.ToString();
        }

        public static Boolean Parse(String msg, out TextMessage o)
        {
            XElement root = null;
            try
            {
                root = XElement.Parse(msg);
                TextMessage result = new TextMessage();
                if (root.HasElements)
                {
                    IEnumerable<XElement> elements = root.Elements();
                    foreach (XElement e in elements)
                    {
                        if (e.Name == "ToUserName") result.ToUserName = e.Value;
                        if (e.Name == "FromUserName") result.FromUserName = e.Value;
                        if (e.Name == "CreateTime") result.CreateTime = Int32.Parse(e.Value);
                        if (e.Name == "MsgType") result.MsgType = e.Value;
                        if (e.Name == "Content") result.Content = e.Value;
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


        /// <summary>
        /// 创建回复消息文本
        /// </summary>
        /// <param name="content">消息内容</param>
        /// <param name="toUser">接收人ID</param>
        /// <returns></returns>
        public static String CreateReply(String content,String toUser)
        {
            KK.WX.Messages.TextMessage msgReply = new KK.WX.Messages.TextMessage()
            {
                FromUserName = Config.MyOpenID,
                ToUserName = toUser,
                CreateTime = (Int32)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                Content = content,
                MsgType = KK.WX.WXDefine.MsgType.Text
            };
            return msgReply.ToReplyXML();
        }


        /// <summary>
        /// 给指定的微信账号推送消息发送文本类型的客服消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Boolean SendCustomMsg(TextMessage msg)
        {
            if (msg == null) return false;

            var a = new { touser = msg.ToUserName, msgtype="text", text = new { content=msg.Content } };

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Common.BaseAPIUrl + "cgi-bin/message/custom/send?access_token=" + Config.AccessToken);
            request.Method = "POST";

            String jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(a);
            byte[] b = System.Text.Encoding.UTF8.GetBytes(jsonStr);
            request.ContentLength = b.Length;
            System.IO.Stream stream = request.GetRequestStream();
            stream.Write(b, 0, b.Length);
            stream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.IO.Stream s = response.GetResponseStream();
            System.IO.StreamReader r = new System.IO.StreamReader(s,System.Text.Encoding.UTF8);
            String responseStr = r.ReadToEnd();
            AppDebugError.Append(new AppDebugError("TextMessage", "SendCustomMsg", "发送客服消息返回：" + responseStr));
            response.Close();
            return true;
        }


        /// <summary>
        /// 给指定的微信账号推送消息发送文本类型的客服消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static Boolean SendCustomMsg(String msg,String openid)
        {
            if (msg == null) return false;

            var a = new { touser = openid, msgtype = "text", text = new { content = msg } };

            // 创建HTTP请求
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Common.BaseAPIUrl + "cgi-bin/message/custom/send?access_token=" + Config.AccessToken);
            request.Method = "POST";

            // 写参数到请求流
            String jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(a);
            byte[] b = System.Text.Encoding.UTF8.GetBytes(jsonStr);
            request.ContentLength = b.Length;
            System.IO.Stream stream = request.GetRequestStream();
            stream.Write(b, 0, b.Length);
            stream.Close();

            // 获取返回
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                System.IO.Stream s = response.GetResponseStream();
                System.IO.StreamReader r = new System.IO.StreamReader(s, System.Text.Encoding.UTF8);
                String responseStr = r.ReadToEnd();
                AppDebugError.Append(new AppDebugError("TextMessage", "SendCustomMsg", "发送客服消息返回：" + responseStr));
                response.Close();
                return true;
            }
        }

    }
}
