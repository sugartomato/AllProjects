using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace KK.WX.WebService
{
    public class Authorize : WXBase
    {

        public static WebAccessToken GetWebAccessToken(String code)
        {
            String requestURL = String.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", Config.AppID, Config.AppSecret, code);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestURL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            System.IO.Stream stream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(stream, Encoding.UTF8);
            String responseText = reader.ReadToEnd();

            // 返回信息
            AppDebugError.Append(new AppDebugError("Authorize", "WebAccessToken", "获取授权返回内容：" + responseText));

            var a = new { access_token = "", expires_in = 0, refresh_token = "", openid = "", scope = "" };
            var b=  Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(responseText, a);
            WebAccessToken result = new WebAccessToken()
            {
                AccessToken = b.access_token,
                ExpiresIn = b.expires_in,
                OpenID = b.openid,
                RefreshToken = b.refresh_token,
                Scope = b.scope
            };
            response.Close();
            return result;
        }


    }

}
