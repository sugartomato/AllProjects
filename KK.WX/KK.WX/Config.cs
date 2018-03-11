using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Timers;

namespace KK.WX
{
    /// <summary>
    /// 微信接口配置
    /// </summary>
    public class Config
    {

        /// <summary>从微信服务器更新Token定时器</summary>
        private static System.Timers.Timer m_Timer_UpdateToken = null;
        /// <summary>从指定URL器更新Token定时器</summary>
        private static System.Timers.Timer m_Timer_UpdateTokenFromUrl = null;

        /// <summary>
        /// 初始化配置，访问微信服务器更新AccessToken
        /// </summary>
        /// <param name="appID">开发者ID</param>
        /// <param name="appSecret">开发者密码</param>
        /// <param name="openID">该公众号的OpenID</param>
        public static void Init(String appID, String appSecret,String openID)
        {
            AppID = appID;
            AppSecret = appSecret;
            MyOpenID = openID;

            // 定时器初始化
            m_Timer_UpdateToken = new System.Timers.Timer();
            m_Timer_UpdateToken.Elapsed += M_Timer_UpdateToken_Elapsed1; ;
            m_Timer_UpdateToken.Interval = TimeSpan.FromMinutes(110).TotalMilliseconds;
            m_Timer_UpdateToken.Start();

            UpdateAccessToken();
        }

        /// <summary>
        /// 初始化配置，访问指定的URL获取AccessToken
        /// </summary>
        /// <param name="appID">开发者ID</param>
        /// <param name="appSecret">开发者密码</param>
        /// <param name="openID">该公众号的OpenID</param>
        /// <param name="upAccessTokenUrl"></param>
        public static void Init(String appID, String appSecret, String openID, String upAccessTokenUrl)
        {
            AppID = appID;
            AppSecret = appSecret;
            MyOpenID = openID;
            UpdateTokenUrl = upAccessTokenUrl;

            // 定时器初始化
            m_Timer_UpdateTokenFromUrl = new System.Timers.Timer();
            m_Timer_UpdateTokenFromUrl.Elapsed += M_Timer_UpdateTokenFromUrl_Elapsed;
            m_Timer_UpdateTokenFromUrl.Interval = TimeSpan.FromMinutes(4).TotalMilliseconds;
            m_Timer_UpdateTokenFromUrl.Start();

            UpdateAccessTokenFromUrl(); // 启动时先更新一次
        }


        private static  String _propAccessToken = String.Empty;
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        public static String AccessToken
        {
            get
            {
                return _propAccessToken;
            }
        }

        /// <summary>获取该微信公众号的openid</summary>
        public static String MyOpenID { get; internal set; } = "";
        /// <summary>获取微信开发者APPID</summary>
        public static String AppID { get; internal set; } = "";
        /// <summary>获取Token的地址</summary>
        public static String UpdateTokenUrl { get; internal set; } = "";
        /// <summary>获取微信开发者APP密码</summary>
        public static String AppSecret { get; internal set; } = "";
        /// <summary>获取AccessToken失败时的消息 </summary>
        public static String AccessTokenError { get; internal set; } = "";

        private static void M_Timer_UpdateToken_Elapsed1(object sender, ElapsedEventArgs e)
        {
            UpdateAccessToken();
        }
        /// <summary>
        /// 线程内直接通过微信服务器更新AccessToken
        /// </summary>
        private static void UpdateAccessToken()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(Common.BaseAPIUrl + "cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", AppID, AppSecret));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    System.IO.Stream stream = response.GetResponseStream();
                    System.IO.StreamReader reader = new System.IO.StreamReader(stream, System.Text.Encoding.UTF8);
                    String strResponse = reader.ReadToEnd();
                    if (!String.IsNullOrEmpty(strResponse))
                    {
                        if (strResponse.Contains("access_token"))
                        {
                            var anonymous = new { access_token = "", expires_in = "" };
                            var o = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(strResponse, anonymous);
                            _propAccessToken = o.access_token;
                            AccessTokenError = String.Empty;
                        }
                        if (strResponse.Contains("errcode"))
                        {
                            WXError o = Newtonsoft.Json.JsonConvert.DeserializeObject<WXError>(strResponse);
                            _propAccessToken = string.Empty;
                            AccessTokenError = "错误代码：" + o.errcode + ", 错误消息：" + o.errmsg;
                        }
                    }
                }
                else
                {
                    AccessTokenError = "请求结果为：" + response.StatusCode.ToString();
                }

            }
            catch (Exception ex)
            {
                AccessTokenError = "请求执行异常：" + ex.Message;
            }
        }

        private static void M_Timer_UpdateTokenFromUrl_Elapsed(object sender, ElapsedEventArgs e)
        {
            UpdateAccessTokenFromUrl();
        }
        /// <summary>
        /// 通过URL更新AccessToken
        /// </summary>
        private static void UpdateAccessTokenFromUrl()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UpdateTokenUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    System.IO.Stream stream = response.GetResponseStream();
                    System.IO.StreamReader reader = new System.IO.StreamReader(stream, System.Text.Encoding.UTF8);
                    String strResponse = reader.ReadToEnd();
                    if (!String.IsNullOrEmpty(strResponse))
                    {
                        _propAccessToken = strResponse.Trim();
                    }
                    else
                    {
                        AccessTokenError = "获取AccessToken失败。请求返回空值";
                    }
                }
                else
                {
                    AccessTokenError = "请求结果为：" + response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                AccessTokenError = "请求执行异常：" + ex.Message;
            }
        }
    }
}
