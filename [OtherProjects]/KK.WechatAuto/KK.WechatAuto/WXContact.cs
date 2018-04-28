using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WechatAuto
{
    public class WXContact
    {

        public Int64 Uin { get; set; }
        public String UserName { get; set; }
        public String NickName { get; set; }
        public String HeadImgUrl { get; set; }
        public Int32 ContactFlag { get; set; }
        public Int32 MemberCount { get; set; }
        public List<WXContact> MemberList { get; set; }
        public String RemarkName { get; set; }
        public Int32 HideInputBarFlag { get; set; }
        public Int32 Sex { get; set; }
        public String Signature { get; set; }

        public Int32 VerifyFlag { get; set; }
        public Int64 OwnerUin { get; set; }
        public String PYInitial { get; set; }
        public String PYQuanPin { get; set; }
        public String RemarkPYInitial { get; set; }
        public String RemarkPYQuanPin { get; set; }
        public Int32 StarFriend { get; set; }
        public Int32 AppAccountFlag { get; set; }
        public Int32 Statues { get; set; }
        public Int64 AttrStatus { get; set; }
        public String Province { get; set; }
        public String City { get; set; }
        public String Alias { get; set; }
        public Int32 SnsFlag { get; set; }
        public Int64 UniFriend { get; set; }
        public String DisplayName { get; set; }
        public Int64 ChatRoomId { get; set; }
        public String KeyWord { get; set; }
        public String EncryChatRoomId { get; set; }
        public Int32 IsOwner { get; set; }
    }
}
