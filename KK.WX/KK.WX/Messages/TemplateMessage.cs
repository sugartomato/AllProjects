using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KK.WX.Messages
{
    /// <summary>
    /// 模板消息
    /// </summary>
    public class TemplateMessage
    {

        #region 模板ID定义

        /// <summary>
        /// 会议发起成功通知。k1：主题，k2:地点，k3:时间,k4:会议室
        /// </summary>
        public const String TemplateID_HYFQCGTZ = "anFE-1hFp18I-e7XPnfJgtKgo5ml4hG2ms86CWorY-8";
        /// <summary>
        /// 会议通知。k1:会议时间，k2:会议地点
        /// </summary>
        public const String TemplateID_HYTZ = "4RSW0KVY7yYM3Rzv_UOZutvJX4c96eJetbzCYjp9ZZg";
        /// <summary>
        /// 处理结果通知。k1:处理状态,k2:处理时间
        /// </summary>
        public const String TemplateID_CLJGTZ = "bZmM5ZN-7-gcKGPfMNJeDIZZOMg9xZFlXHFwMSNkDBY";
        /// <summary>
        /// 服务申请提醒。k1:类型,k2:时间,k3:会议室
        /// </summary>
        public const String TemplateID_FWSQTX = "ElTLvTdaLzGoCvDpZ2VSQduGKQEoNVS4GbB01V5v5DM";
        /// <summary>
        /// 任务开始提醒。k1:项目名称,k2:任务名称,k3:任务开始日期
        /// </summary>
        public const String TemplateID_RWKSTX = "wFGS0V-E0fh3QBaPyBSyBh1c2WipC_UidexqfyDpDlk";
        /// <summary>
        /// 值班提醒。k1:带班领导，k2:值班人员，k3:值班时间
        /// </summary>
        public const String TemplateID_ZBTX = "_a5HLzS1-DjaNOviSvZvUYhiegNWGUhZsPsDs1qfQs4";
        /// <summary>
        /// 工作任务提醒。k1:提醒内容,k2:时间
        /// </summary>
        public const String TemplateID_GZRWTX = "TLOrhW_x3v_rU3T--jwXAmkE2bfx4gJuyNUpJirRPRE";

        /// <summary>
        /// 会议室登记提醒。k1:会议主题，k2:会议时间，k3:会议地点，k4:与会人员，k5:登记人
        /// </summary>
        public const String TemplateID_My_HYSDJTX = "shkKIPMLK3_Yf7O2w3u5wX0I4uQHDq1EqrH-2z5Xmq4";
        /// <summary>
        /// 会议通知。K1:主题，k2:时间,k3:地点，k4:召集人
        /// </summary>
        public const String TemplateID_My_HYTZ = "JEJWDZYuW32OhwHVbz_IiRyb6J67bGEr6wigfBwa5VY";
        #endregion


        /// <summary>接收人ID，必须</summary>
        public String ToUser { get; set; } = String.Empty;
        /// <summary>模板ID，必须</summary>
        public String TemplateID { get; set; } = String.Empty;
        /// <summary>模板跳转链接。</summary>
        public String Url { get; set; } = String.Empty;
        /// <summary>跳小程序所需数据，不需跳小程序可不用传该数据。</summary>
        public String MiniProgram { get; set; } = String.Empty;
        /// <summary>模板数据的Json字符串格式</summary>
        public String Data { get; set; } = String.Empty;

        /// <summary>
        /// 生成模板消息的data部分json
        /// </summary>
        /// <param name="first"></param>
        /// <param name="remark"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static String GenerateDataJson(DataValue first, DataValue remark, params DataValue[] keys)
        {
            if (first == null) throw new ArgumentNullException(nameof(first), "参数是必须的！");
            if (remark == null) throw new ArgumentNullException(nameof(remark), "参数是必须的！");
            if(keys == null || keys.Length == 0) throw new ArgumentNullException(nameof(keys), "参数是必须的！");

            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            //sb.Append("\"data\":{");
            sb.Append("\"first\":{");
            sb.AppendFormat("\"value\":\"{0}\",", first.Value + "\\n");
            sb.AppendFormat("\"color\":\"{0}\"", first.Color);
            sb.Append("},");

            for (Int32 i = 0; i < keys.Length; i++)
            {
                sb.Append("\"keyword" + (i + 1) + "\":{");
                sb.AppendFormat("\"value\":\"{0}\",", keys[i].Value);
                sb.AppendFormat("\"color\":\"{0}\"",  keys[i].Color);
                sb.Append("},");
            }

            sb.Append("\"remark\":{");
            sb.AppendFormat("\"value\":\"{0}\",", "\\n" + remark.Value);
            sb.AppendFormat("\"color\":\"{0}\"", remark.Color);
            sb.Append("}");

            sb.Append("}");

            return sb.ToString();
        }

        /// <summary>
        /// 生成模板消息miniprogram部分JSON
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="pagePath"></param>
        /// <returns></returns>
        public static String GenerateMiniProgramJson(String appid,String pagePath)
        {
            String result = "{";
            result += "\"appid\":\"" + appid + "\",";
            result += "\"pagepath\":\"" + pagePath + "\"";
            result += "}";
            return result;
        }

        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static Boolean Send(TemplateMessage msg, ref String errMsg)
        {
            if (msg == null) throw new ArgumentNullException(nameof(msg), "参数是必须的！");


            String objJson = "{";
            objJson += "\"touser\":\"" + msg.ToUser + "\",";
            objJson += "\"template_id\":\"" + msg.TemplateID + "\",";
            objJson += "\"url\":\"" + msg.Url + "\",";
            if (!String.IsNullOrEmpty(msg.MiniProgram) && msg.MiniProgram.Length > 1)
            {
                objJson += "\"miniprogram\":" + msg.MiniProgram + ",";
            }
            objJson += "\"data\":" + msg.Data;
            objJson += "}";

            AppDebugError.Append(new AppDebugError(nameof(TemplateMessage), nameof(Send), "发送模板消息内容：" + objJson));

            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(Common.BaseAPIUrl + "cgi-bin/message/template/send?access_token=" + Config.AccessToken);
            request.Method = "POST";

            Byte[] bytes = System.Text.Encoding.UTF8.GetBytes(objJson);
            request.ContentLength = bytes.Length;

            System.IO.Stream stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();

            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(),System.Text.Encoding.UTF8);
            String responseStr = reader.ReadToEnd();
            reader.Close();
            response.Close();

            if (responseStr.Contains("errcode"))
            {
                var r = new { errcode = 0, errmsg = "", msgid = "" };
                var m = JsonConvert.DeserializeAnonymousType(responseStr, r);
                if (m.errcode == 0)
                {
                    return true;
                }
                else
                {
                    errMsg = m.errcode + ":" + m.errmsg;
                    AppDebugError.Append(new AppDebugError(nameof(TemplateMessage), nameof(Send), "发送模板消息返回错误：" + errMsg));
                    return false;
                }
            }
            else
            {
                errMsg = "服务器返回的字符串为：" + responseStr;
                AppDebugError.Append(new AppDebugError(nameof(TemplateMessage), nameof(Send), "发送模板消息返回：" + errMsg));
                return false;
            }
        }

        /// <summary>
        /// 模板消息值对
        /// </summary>
        public class DataValue
        {

            /// <summary>
            /// 构造
            /// </summary>
            public DataValue() { }
            /// <summary>
            /// 构造
            /// </summary>
            public DataValue(String value)
            {
                Value = value;
            }
            /// <summary>
            /// 构造
            /// </summary>
            /// <param name="value"></param>
            /// <param name="color"></param>
            public DataValue(String value, String color)
            {
                Value = value;
                Color = color;
            }
            /// <summary>
            /// 构造
            /// </summary>
            /// <param name="value"></param>
            /// <param name="color"></param>
            public DataValue(String value, System.Drawing.Color color)
            {
                Value = value;
                Color = System.Drawing.ColorTranslator.ToHtml(color);
            }
            /// <summary>
            /// 值
            /// </summary>
            public String Value { get; set; } = "";
            private String _Color = String.Format("#{0:x2}{1:x2}{2:x2}", System.Drawing.Color.Blue.R, System.Drawing.Color.Blue.G, System.Drawing.Color.Blue.B);
            /// <summary>
            /// 文本颜色。 默认为蓝色
            /// </summary>
            public String Color {
                get {
                    return _Color;
                }
                set
                {
                    System.Drawing.Color c1 = System.Drawing.Color.Black ;
                    if (!String.IsNullOrEmpty(value) && value.Length > 0)
                    {
                        c1 = System.Drawing.ColorTranslator.FromHtml(value);
                    }
                    _Color = String.Format("#{0:x2}{1:x2}{2:x2}", c1.R, c1.G, c1.B);
                }
            } 
        }


    }
}
