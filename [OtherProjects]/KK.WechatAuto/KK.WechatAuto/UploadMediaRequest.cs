using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KK.WechatAuto
{
    public class UploadMediaRequest
    {

        public Int32 UploadType { get; set; }
        public BaseRequest BaseRequest { get; set; }
        public Int64 ClientMediaId { get; set; }
        public Int64 TotalLen { get; set; }
        public Int32 StartPos { get; set; }
        public Int64 DataLen { get; set; }
        public Int32 MediaType { get; set; }
        public String FromUserName { get; set; }
        public String ToUserName { get; set; }
        public String FileMd5 { get; set; }


        public static UploadMediaRequest Get(String toUser, Session session,String filePath)
        {
            UploadMediaRequest result = new UploadMediaRequest();
            result.BaseRequest = session.BaseRequest;
            result.FromUserName = session.CurrentUser.UserName;
            result.ToUserName = toUser;
            result.UploadType = 2;
            result.ClientMediaId = Common.GetTimeStamp();

            System.IO.FileInfo finfo = new System.IO.FileInfo(filePath);
            result.TotalLen = finfo.Length;
            result.MediaType = 4;
            result.StartPos = 0;
            result.DataLen = finfo.Length;
            result.FileMd5 = GetMD5HashFromFile(filePath).ToLower();
            return result;
        }

        private static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }
    }
}
