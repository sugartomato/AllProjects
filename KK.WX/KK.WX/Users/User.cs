using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WX.Users
{
    /// <summary>
    /// 微信用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// 是否已订阅
        /// </summary>
        public Boolean IsSubscribe { get; set; } = false;
        /// <summary>
        /// 微信标识
        /// </summary>
        public String OpenID { get; set; } = String.Empty;
        /// <summary>
        /// 昵称
        /// </summary>
        public String Nickname { get; set; } = String.Empty;
        /// <summary>
        /// 所在城市
        /// </summary>
        public String City { get; set; } = String.Empty;
    }
}
