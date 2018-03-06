using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WX.WebService
{
    public class WebAccessToken
    {
        public String AccessToken { get; set; }
        public Int32 ExpiresIn { get; set; }
        public String RefreshToken { get; set; }
        public String OpenID { get; set; }
        public String Scope { get; set; }
    }
}
