using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;
namespace KK.WechatAuto
{
    public class Session
    {
        public Session()
        {
            this.CookieContainer = new System.Net.CookieContainer();
            this.CurrentUser = new WXContact();
        }
        public System.Net.CookieContainer CookieContainer { get; set; }

        public String skey { get; set; } = string.Empty;
        public String wxsid { get; set; } = string.Empty;
        public String wxuin { get; set; } = "0";
        public String pass_ticket { get; set; } = string.Empty;
        public String isgrayscale { get; set; } = string.Empty;

        public SyncKey SyncKey { get; set; }

        public WXContact CurrentUser { get; set; }

        public BaseRequest BaseRequest
        {
            get {
                return new BaseRequest() { Sid = wxsid, Uin = Int64.Parse(wxuin), Skey = skey, DeviceID = Common.GetDeviceID() };
            }
        }

        public String uuid { get; set; }

        private List<WXContact> _Contacts = null;
        public List<WXContact> Contacts { get
            {
                if (_Contacts != null && _Contacts.Count > 0)
                {
                    _Contacts = _Contacts.OrderBy(x => x.NickName).ToList();
                }
                return _Contacts;
            }
            set
            {
                _Contacts = value;
            }
        }

        
        public String UserAgent{ get; set; }

        public String WXVer { get; set; }

        public String GetCookie(String key)
        {
            return Cookies[key].Value;
        }

        private System.Net.CookieCollection _Cookies = new System.Net.CookieCollection();
        public System.Net.CookieCollection Cookies {
            get
            {
                return _Cookies;
            }
        }

        public void AddCookies(System.Net.CookieCollection cookies)
        {
            if (cookies != null && cookies.Count > 0)
            {
                foreach (System.Net.Cookie cookie in cookies)
                {
                    Cookies.Add(cookie);
                }
            }
            this.CookieContainer.Add(cookies);
        }

        public System.Net.HttpWebRequest CreateRequest(String url)
        {
            if (url.Contains("?"))
            {
                url += "&trand=" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            }
            else
            {
                url += "?trand=" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            }
            System.Net.HttpWebRequest req = System.Net.HttpWebRequest.CreateHttp(url);
            req.UserAgent = this.UserAgent;
            //System.Net.Cache.HttpRequestCachePolicy policy = new System.Net.Cache.HttpRequestCachePolicy(System.Net.Cache.HttpRequestCacheLevel.NoCacheNoStore);
            //req.CachePolicy = policy;
            req.CookieContainer = this.CookieContainer;
            return req;
        }

        public String GetResponseString(System.Net.HttpWebResponse response)
        {
            String result = String.Empty;
            if (response == null) return String.Empty;
            AddCookies(response.Cookies);
            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }

            return result;

        }


    }
}
