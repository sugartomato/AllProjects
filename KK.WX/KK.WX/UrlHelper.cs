using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WX
{
    /// <summary>
    /// 地址帮助
    /// </summary>
    public class UrlHelper
    {
        /// <summary>
        /// 生成微信网页授权跳转链接。使用如下默认参数：response_type=code&scope=snsapi_base&state=1
        /// </summary>
        /// <param name="target">跳转地址</param>
        /// <returns></returns>
        public static String GetWXAuthRedirectUrl(String target)
        {
            if (String.IsNullOrEmpty(target) || target.Length < 3)
            {
                throw new ArgumentNullException(nameof(target), "必须指定要跳转的目标地址！");
            }

            String wxUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + Config.AppID + "&redirect_uri=$target$&response_type=code&scope=snsapi_base&state=1#wechat_redirect";
            target = Uri.EscapeDataString(target);
            return wxUrl.Replace("$target$", target);

        }

        /// <summary>
        /// 生成微信网页授权跳转链接
        /// </summary>
        /// <param name="target">跳转目标</param>
        /// <param name="scope">scope参数</param>
        /// <param name="state">state参数</param>
        /// <returns></returns>
        public static String GetWXAuthRedirectUrl(String target, String scope, String state)
        {
            if (String.IsNullOrEmpty(target) || target.Length < 3)
            {
                throw new ArgumentNullException(nameof(target), "必须指定要跳转的目标地址！");
            }

            if (String.IsNullOrEmpty(scope))
            {
                throw new ArgumentNullException(nameof(scope), "必须指定Scope参数！如：snsapi_base");
            }

            if (String.IsNullOrEmpty(state)) state = "1";

            String wxUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + Config.AppID + "&redirect_uri=$target$&response_type=code&scope=$scope$&state=$state$#wechat_redirect";
            target = Uri.EscapeDataString(target);
            return wxUrl.Replace("$target$", target).Replace("$scope$", scope).Replace("$state$", state);

        }
    }
}
