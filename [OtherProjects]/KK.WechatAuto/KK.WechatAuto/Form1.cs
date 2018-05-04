using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KK.WechatAuto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Session m_Session = null;
        private Timer m_Timer_OutputLog = null;
        private Boolean m_IsRunSyncCheck = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                txtState.Text = String.Empty;
                listFiles.Items.Clear();
                txtUseragent.Text = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.117 Safari/537.36";
                txtState.Text = "";
                txtReceivers.Clear();
                txtMessage.Clear();
                txtConsole.Clear();

                dataGridView1.DoubleBufferedGrid(true);

                m_Timer_OutputLog = new Timer();
                m_Timer_OutputLog.Interval = 20;
                m_Timer_OutputLog.Tick += M_Timer_OutputLog_Tick;
                m_Timer_OutputLog.Enabled = true;

                this.SetStyle(ControlStyles.ResizeRedraw, true);

                Login();
            }
            catch (Exception ex)
            {
                WriteLog("[初始化]异常：" + ex.Message + ex.StackTrace);
            }
        }

        private void Login()
        {

            pictureBox1.Image = null;
            dataGridView1.DataSource = null;
            SetStateText("");
            m_IsRunSyncCheck = false;

            m_Session = new Session();
            // 浏览器标识
            if (!String.IsNullOrEmpty(txtUseragent.Text))
            {
                m_Session.UserAgent = txtUseragent.Text;
            }
            else
            {
                m_Session.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.117 Safari/537.36";
            }

            HttpWebRequest _request = m_Session.CreateRequest("https://login.wx.qq.com/jslogin?appid=wx782c26e4c19acffb&redirect_uri=https%3A%2F%2Fwx.qq.com%2Fcgi-bin%2Fmmwebwx-bin%2Fwebwxnewloginpage&fun=new&lang=zh_CN&_=" + Common.GetTimeStamp().ToString());
            HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();
            if (_response.StatusCode != HttpStatusCode.OK)
            {
                WriteLog("[登陆地址]HTTP加载错误，http请求状态：" + _response.StatusCode);
            }
            String _responseText = m_Session.GetResponseString(_response);
            WriteLog("[登陆地址]HTTP请求返回结果：" + _responseText);

            // 获取二维码
            if (_responseText.Contains("window.QRLogin.uuid"))
            {
                string qrCodeUrl = "https://login.weixin.qq.com/qrcode/";
                m_Session.uuid = Regex.Match(_responseText, "(?<=window\\.QRLogin\\.uuid = \").{1,}(?=\";)").Value;
                WriteLog("获取到的二维码标识：" + m_Session.uuid, true);

                // 获取二维码
                _request = m_Session.CreateRequest(qrCodeUrl + m_Session.uuid);
                using (_response = (HttpWebResponse)_request.GetResponse())
                {
                    Image qrImage = Image.FromStream(_response.GetResponseStream());
                    pictureBox1.Image = qrImage;
                    SetStateText("等待扫描");
                    _response.Close();
                };

                // 加载登陆访问线程
                Task.Factory.StartNew(delegate { LoadScanState(); });
            }
            else
            {
                WriteLog("请求中未能获取到二维码标识！");
            }
        }

        /// <summary>
        /// 加载二维码扫描信息
        /// </summary>
        private void LoadScanState()
        {
            HttpWebRequest _request = null;
            HttpWebResponse _response = null;
            String _responseText = String.Empty;
            String _requestUrl = String.Empty;

            while (true)
            {
                try
                {
                    Int64 _stamp = Common.GetTimeStamp();
                    String _stampf = Common.GetTimeStampF(_stamp);
                    _requestUrl = $"https://login.wx.qq.com/cgi-bin/mmwebwx-bin/login?loginicon=true&uuid={ m_Session.uuid }&tip=0&r={_stampf}&_={_stamp.ToString()}";
#if LOCALTEST
                    WriteLog(_requestUrl);
#endif

                    _request = m_Session.CreateRequest(_requestUrl);
                    using (_response = (HttpWebResponse)_request.GetResponse())
                    {
                        _responseText = m_Session.GetResponseString(_response);
                        WriteLog("[登陆检查]HTTP请求返回结果：" + _responseText);
                        if (_response.StatusCode != HttpStatusCode.OK)
                        {
                            WriteLog("[登陆检查]HTTP加载错误，http请求状态：" + _response.StatusCode);
                        }

                        // window.code
                        // 400 二维码已过期
                        String code = Regex.Match(_responseText, "(?<=window\\.code=).{1,}?(?=;)").Value;
                        switch (code)
                        {
                            case "201": // 已扫码，等待确认。window.userAvatar为已扫描的用户的头像
                                String imgStr = Regex.Match(_responseText, "(?<=;window\\.userAvatar = \').{1,}(?=\';)").Value;
                                imgStr = imgStr.Replace("data:img/jpg;base64,", "");
                                pictureBox1.Image = Common.ConvertFromBase64String(imgStr);
                                SetStateText("已扫描，等待移动端确认！");
                                break;
                            case "200": // 移动端已确认，执行登陆。
                                SetStateText("移动端已确认，开始登录！");
                                String redirectUrl = Regex.Match(_responseText, "(?<=window\\.redirect_uri=\").{1,}(?=\";)").Value;
                                if (redirectUrl.StartsWith("https://wx.qq.com/"))
                                {
                                    m_Session.WXVer = "wx";
                                }
                                else
                                {
                                    m_Session.WXVer = "wx2";
                                }
                                try
                                {
                                    WriteLog(redirectUrl);
                                    redirectUrl += "&fun=new&version=v2";
                                    _request = m_Session.CreateRequest(redirectUrl);
                                    using (_response = (HttpWebResponse)_request.GetResponse())
                                    {
                                        if (_response.StatusCode != HttpStatusCode.OK)
                                        {
                                            WriteLog("[登陆后跳转]HTTP加载错误，http请求状态：" + _response.StatusCode);
                                        }
                                        _responseText = m_Session.GetResponseString(_response);
                                        _response.Close();
                                        WriteLog("[登陆后跳转]HTTP请求返回结果：" + _responseText);
                                    }

                                    // 尝试将值转换为xml
                                    XElement root = XElement.Parse(_responseText);
                                    String errCode = root.Element("ret").Value;
                                    WriteLog(errCode);
                                    if (errCode != "0")
                                    {
                                        WriteLog("登陆失败，错误消息：" + root.Element("message").Value, false);
                                        SetStateText("登陆失败！");
                                        return;
                                    }
                                    else
                                    {
                                        // 获取成功相关的值
                                        m_Session.skey = root.Element("skey").Value;
                                        m_Session.wxsid = root.Element("wxsid").Value;
                                        m_Session.wxuin = root.Element("wxuin").Value;
                                        m_Session.pass_ticket = root.Element("pass_ticket").Value;
                                        m_Session.isgrayscale = root.Element("isgrayscale").Value;

                                        // 获取初始化数据
                                        System.Threading.Thread.Sleep(3000);
                                        _requestUrl = $"https://{m_Session.WXVer}.qq.com/cgi-bin/mmwebwx-bin/webwxinit?r={Common.GetTimeStampF()}&lang=zh_CN&pass_ticket={m_Session.pass_ticket}";
                                        WriteLog(_requestUrl);

                                        _request = m_Session.CreateRequest(_requestUrl);
                                        _request.Method = "POST";


                                        String reqStr = JsonConvert.SerializeObject(m_Session.BaseRequest);
                                        reqStr = "{\"BaseRequest\":" + reqStr + "}";
                                        byte[] b = System.Text.Encoding.UTF8.GetBytes(reqStr);
                                        _request.ContentLength = b.Length;
                                        using (System.IO.Stream s = _request.GetRequestStream())
                                        {
                                            s.Write(b, 0, b.Length);
                                            s.Close();
                                        };

                                        using (_response = (HttpWebResponse)_request.GetResponse())
                                        {
                                            if (_response.StatusCode != HttpStatusCode.OK)
                                            {
                                                WriteLog("[微信初始化信息]加载错误，http请求状态：" + _response.StatusCode);
                                            }
                                            _responseText = m_Session.GetResponseString(_response);
                                            WriteLog("[微信初始化信息]HTTP请求返回结果：" + _responseText);
                                            _response.Close();
                                        };

                                        if (_responseText.Contains("BaseResponse\":"))
                                        {
                                            // 转换为json对象
                                            // 获取当前用户数据
                                            JObject obj = JsonConvert.DeserializeObject<JObject>(_responseText);
                                            if (obj["User"] != null)
                                            {
                                                m_Session.CurrentUser = JsonConvert.DeserializeObject<WXContact>(obj["User"].ToString());
                                                WriteLog("获取到当前用户对象。用户ID：" + m_Session.CurrentUser.UserName);

                                                LoadContacts();
                                                this.Invoke(new EventHandler(delegate { dataGridView1.DataSource = m_Session.Contacts; }));
                                            }

                                            // 初始化Sync数据
                                            if (obj["SyncKey"] != null)
                                            {
                                                m_Session.SyncKey = JsonConvert.DeserializeObject<SyncKey>(obj["SyncKey"].ToString());
                                                WriteLog("获取到SyncKey数据");
                                            }

                                            // 加载登陆访问线程
                                            m_IsRunSyncCheck = true;
                                            Task.Factory.StartNew(delegate { SyncCheck(); });

                                            SetStateText("已登陆！");
                                        }

                                    }

                                }
                                catch (Exception ex)
                                {
                                    WriteLog("[微信跳转HTTP请求]异常：" + ex.Message + ex.StackTrace);
                                }
                                finally
                                {
                                    // 释放资源
                                }
                                return;
                            case "408": // 等待扫描
                                break;
                            case "400": // 二维码失效
                                WriteLog("二维码失效，重新加载。");
                                Login();
                                return;
                        }
                        _response.Close();
                    };


                    System.Threading.Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    WriteLog(ex.Message + ex.StackTrace);
                }
            }

        }

        /// <summary>
        /// 登陆成功之后，持续检查信息
        /// </summary>
        private void SyncCheck()
        {
            HttpWebRequest _request = null;
            HttpWebResponse _response = null;
            String _responseText = String.Empty;
            String _url = String.Empty;
            Int32 _errCount = 0;
            while (m_IsRunSyncCheck)
            {
                try
                {
                    _url = $"https://{m_Session.WXVer}.qq.com/cgi-bin/mmwebwx-bin/webwxsync?sid={m_Session.wxsid}&skey={m_Session.skey}&lang=zh_CN&pass_ticket={m_Session.pass_ticket}";
                    _request = m_Session.CreateRequest(_url);
                    _request.Method = "POST";

                    SyncRequest postObj = new SyncRequest() { BaseRequest = m_Session.BaseRequest, rr = Common.GetTimeStampF(), SyncKey = m_Session.SyncKey };
                    String postStr = JsonConvert.SerializeObject(postObj);
                    byte[] b = System.Text.Encoding.UTF8.GetBytes(postStr);
                    _request.ContentLength = b.Length;
                    using (System.IO.Stream s = _request.GetRequestStream())
                    {
                        s.Write(b, 0, b.Length);
                        s.Close();
                    };

                    using (_response = (HttpWebResponse)_request.GetResponse())
                    {
                        if (_response.StatusCode != HttpStatusCode.OK)
                        {
                            WriteLog("[轮询检查]加载错误，http请求状态：" + _response.StatusCode);
                        }
                        _responseText = m_Session.GetResponseString(_response);
                        WriteLog("[轮询检查]HTTP请求返回结果：" + _responseText);
                    };

                    if (_responseText.Contains("BaseResponse\":"))
                    {
                        // 转换为json对象
                        // 获取当前用户数据
                        JObject obj = JsonConvert.DeserializeObject<JObject>(_responseText);
                        if (obj["BaseResponse"] != null && obj["BaseResponse"]["Ret"] != null)
                        {
                            Int32 ret = Int32.Parse(obj["BaseResponse"]["Ret"].ToString());
                            if (ret != 0)
                            {
                                SetStateText("错误代码：" + ret);
                                WriteLog($"轮询失败第{_errCount + 1}次，错误代码：{ret}", false);
                                if (_errCount + 1 > 5)
                                {
                                    WriteLog("多次尝试失败，重新登陆！", false);
                                    SetStateText("等待扫码");
                                    this.Invoke(new EventHandler(delegate { Login(); }));
                                    return;
                                }
                                _errCount += 1;
                            }
                            else
                            {
                                // 初始化Sync数据
                                if (obj["SyncKey"] != null)
                                {
                                    m_Session.SyncKey = JsonConvert.DeserializeObject<SyncKey>(obj["SyncKey"].ToString());
                                    WriteLog("获取到SyncKey数据");
                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    WriteLog("[轮询检查]执行异常：" + ex.Message);
                }

                System.Threading.Thread.Sleep((Int32)TimeSpan.FromSeconds(25).TotalMilliseconds);
            }

        }


        /// <summary>
        /// 加载联系人
        /// </summary>
        private void LoadContacts()
        {
            WriteLog("开始获取联系人信息...", false);
            Application.DoEvents();
            try
            {
                String _responseText = String.Empty;
                String requestUrl = $"https://{m_Session.WXVer}.qq.com/cgi-bin/mmwebwx-bin/webwxgetcontact?pass_ticket={m_Session.pass_ticket}&r={Common.GetTimeStamp()}&seq=0&skey={m_Session.skey}";
                HttpWebRequest _request = m_Session.CreateRequest(requestUrl);
                using (HttpWebResponse _response = (HttpWebResponse)_request.GetResponse())
                {
                    if (_response.StatusCode != HttpStatusCode.OK)
                    {
                        WriteLog("联系人加载错误，http请求状态：" + _response.StatusCode);
                    }
                    _responseText = m_Session.GetResponseString(_response);
                    WriteLog("联系人HTTP请求返回结果：" + _responseText);
                    _response.Close();
                }

                // 解析JSON
                if (_responseText.Contains("MemberList\": ["))
                {
                    Newtonsoft.Json.Linq.JObject jobj = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(_responseText);
                    m_Session.Contacts = JsonConvert.DeserializeObject<List<WXContact>>(jobj["MemberList"].ToString());
                }
                else
                {
                    m_Session.Contacts = null;
                }
                WriteLog("联系人信息获取完毕！", false);
            }
            catch (Exception ex)
            {
                WriteLog("联系人信息获取失败！", false);
                WriteLog("[联系人信息获取]异常：" + ex.Message + ex.StackTrace);
            }
            Application.DoEvents();
        }



        /// <summary>
        /// 上传媒体文件,如果上传成功，返回获取到的MediaID，否则，返回String.Empty
        /// </summary>
        private String UploadMedia(String file, String receiver, Int32 fileIndex = 0)
        {
            String toUser = receiver;
            System.Net.ServicePointManager.DefaultConnectionLimit = 100;
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            String _result = String.Empty;
            String _url = $"https://file.{m_Session.WXVer}.qq.com/cgi-bin/mmwebwx-bin/webwxuploadmedia?f=json";
            HttpWebRequest _request = WebRequest.CreateHttp(_url);
            System.IO.FileStream fs = System.IO.File.Open(file, System.IO.FileMode.Open);
            byte[] content = new byte[fs.Length];
            fs.Read(content, 0, content.Length);
            fs.Close();

            //_request.KeepAlive = false;
            _request.CookieContainer = m_Session.CookieContainer;
            _request.Timeout = (Int32)TimeSpan.FromSeconds(20).TotalMilliseconds;
            _request.ProtocolVersion = HttpVersion.Version10;
            _request.Method = "POST";
            _request.UserAgent = m_Session.UserAgent;
            _request.Accept = "*/*";


            String boundary = "----WebKitFormBoundaryXfoMzS2vayvACSgy";

            //_request.ContentType = "application/x-www-form-urlencoded";
            _request.ContentType = "multipart/form-data; boundary=" + boundary;
            //_request.ContentType = "multipart/form-data;";
            //_request.ContentLength = content.Length;
            System.IO.FileInfo finfo = new System.IO.FileInfo(file);
            Dictionary<string, object> paras = new Dictionary<string, object>();
            paras.Add("id", "WU_FILE_" + fileIndex);
            paras.Add("name", finfo.Name);
            paras.Add("lastModifiedDate", finfo.LastWriteTimeUtc);
            paras.Add("size", finfo.Length);
            paras.Add("mediatype", "pic");
            paras.Add("uploadmediarequest", JsonConvert.SerializeObject(UploadMediaRequest.Get(toUser, m_Session, file)));
            paras.Add("webwx_data_ticket", m_Session.GetCookie("webwx_data_ticket"));
            paras.Add("pass_ticket", m_Session.pass_ticket);
            paras.Add("filename", new FileParameter(content, finfo.Name, "image/jpeg"));

            byte[] postData = GetMultipartFormData(paras, boundary);

            System.IO.Stream _stream = _request.GetRequestStream();
            _stream.Write(postData, 0, postData.Length);
            _stream.Close();



            HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
            m_Session.AddCookies(response.Cookies);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                WriteLog("[上传文件]HTTP加载错误，HTTP请求状态：" + response.StatusCode);
            }

            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
            String _responseText = sr.ReadToEnd();
            sr.Close();
            response.Close();
            WriteLog("[上传文件]HTTP请求返回结果：" + _responseText);

            if (_responseText.Contains("\"MediaId\":"))
            {
                String mediaID = Regex.Match(_responseText, "(?<=\"MediaId\":).{1,}(?=\",)").Value;
                _result = mediaID;
            }

            return _result;
        }

        private String SendImageMsg(String receiver, String file, Int32 fileIndex = 0)
        {
            String mediaID = UploadMedia(file, receiver, fileIndex);
            String _responseText = String.Empty;
            if (String.IsNullOrEmpty(mediaID) || mediaID.Length == 0)
            {
                return "文件[" + file + "]上传失败！";
            }

            //String _url = m_Session.WXUrlStart + "cgi-bin/mmwebwx-bin/webwxsendmsgimg?fun=async&f=json&lang=zh_CN&pass_ticket=" + m_Session.pass_ticket;
            String _url = $"https://{m_Session.WXVer}.qq.com/cgi-bin/mmwebwx-bin/webwxsendmsgimg?fun=async&f=json&lang=zh_CN&pass_ticket={m_Session.pass_ticket}";
            HttpWebRequest _request = m_Session.CreateRequest(_url);
            _request.Method = "POST";

            MessageRequest reqPar = new MessageRequest();
            reqPar.Scene = 0;
            reqPar.BaseRequest = m_Session.BaseRequest;
            string msgID = Common.GetTimeStamp().ToString() + Common.GetRandom(4);
            reqPar.Msg = new Msg() { Type = 3, Content = "", ToUserName = receiver, FromUserName = m_Session.CurrentUser.UserName, ClientMsgId = msgID, LocalID = msgID, MediaId = mediaID };
            String reqParStr = JsonConvert.SerializeObject(reqPar);

            byte[] b = System.Text.Encoding.UTF8.GetBytes(reqParStr);
            _request.ContentLength = b.Length;
            System.IO.Stream reStream = _request.GetRequestStream();
            reStream.Write(b, 0, b.Length);
            reStream.Close();


            using (HttpWebResponse response = (HttpWebResponse)_request.GetResponse()) {
                _responseText = m_Session.GetResponseString(response);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return "[发送图片消息]加载错误，http请求状态：" + response.StatusCode;
                }

                // 尝试请求结果转换为对象
                if (_responseText.Contains("BaseResponse"))
                {
                    MessageResponse repObj = JsonConvert.DeserializeObject<MessageResponse>(_responseText);
                    if (repObj.BaseResponse.Ret != 0)
                    {
                        return "图片消息发送失败。服务器返回错误代码：" + repObj.BaseResponse.Ret;
                    }
                }

                response.Close();
            }

            return string.Empty;
        }

        /// <summary>
        /// 微信发送消息
        /// </summary>
        /// <param name="toUser"></param>
        /// <param name="content"></param>
        private String SendTextMsg(String toUser, String content)
        {
            String _responseText = String.Empty;
            HttpWebRequest _request = WebRequest.CreateHttp($"https://{m_Session.WXVer}.qq.com/cgi-bin/mmwebwx-bin/webwxsendmsg?lang=zh_CN&pass_ticket=" + m_Session.pass_ticket);
            _request.CookieContainer = m_Session.CookieContainer;
            _request.Method = "POST";

            // 创建请求参数
            MessageRequest reqPar = new MessageRequest();
            reqPar.Scene = 0;
            reqPar.BaseRequest = m_Session.BaseRequest;
            string msgID = Common.GetTimeStamp().ToString() + Common.GetRandom(4);
            reqPar.Msg = new Msg() { Type = 1, Content = content, ToUserName = toUser, FromUserName = m_Session.CurrentUser.UserName, ClientMsgId = msgID, LocalID = msgID };
            String reqParStr = JsonConvert.SerializeObject(reqPar);

            byte[] b = System.Text.Encoding.UTF8.GetBytes(reqParStr);
            _request.ContentLength = b.Length;
            System.IO.Stream reStream = _request.GetRequestStream();
            reStream.Write(b, 0, b.Length);
            reStream.Close();

            using (HttpWebResponse response = (HttpWebResponse)_request.GetResponse())
            {
                _responseText = m_Session.GetResponseString(response);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return "[发送文本消息]加载错误，http请求状态：" + response.StatusCode;
                }

                // 尝试请求结果转换为对象
                if (_responseText.Contains("BaseResponse"))
                {
                    MessageResponse repObj = JsonConvert.DeserializeObject<MessageResponse>(_responseText);
                    if (repObj.BaseResponse.Ret != 0)
                    {
                        return "[发送文本消息]失败。服务器返回错误代码：" + repObj.BaseResponse.Ret;
                    }
                }

                response.Close();
            }

            return string.Empty;
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        #region 界面消息

        private void WriteLog(String msg, Boolean isDebug = true)
        {
            Common.DebugMessage.Enqueue(msg);
            if (!isDebug)
            {
                Common.UserMessage.Enqueue(msg);
            }
        }

        private void M_Timer_OutputLog_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Common.DebugMessage.Count > 0)
                {
                    txtConsole.AppendText(Common.DebugMessage.Dequeue() + "\r\n");
                }
                if (Common.UserMessage.Count > 0)
                {
                    txtState.AppendText(Common.UserMessage.Dequeue() + "\r\n");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 设置用户状态消息
        /// </summary>
        /// <param name="state"></param>
        private void SetStateText(String state)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate { lblState.Text = state; }));
            }
            else
            {
                lblState.Text = state;
            }
        }

        private void btnClearConsole_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }
        #endregion

        #region 单步调试

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Login();
            }
            catch (Exception ex)
            {
                WriteLog("[登陆]异常：" + ex.Message + ex.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                LoadContacts();
            }
            catch (Exception ex)
            {
                WriteLog("加载联系人异常：" + ex.Message);
            }


        }

        private void OnClick_Test_SendImageMsg(object sender, EventArgs e)
        {
            try
            {
                Dictionary<String, String> users = GetSelReceivers();
                List<String> files = GetSelFiles();
                if (users != null && files != null)
                {
                    foreach (var user in users)
                    {
                        foreach (string file in files)
                        {
                            SendImageMsg(user.Key, file);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                WriteLog("[发送图片消息]异常：" + ex.Message + ex.StackTrace);
            }
        }


        private void OnClick_Test_SendTextMsg(object sender, EventArgs e)
        {
            try
            {
                Dictionary<String, String> users = GetSelReceivers();
                if (users != null)
                {
                    foreach (var user in users)
                    {
                        SendTextMsg(user.Key, txtMessage.Text);
                    }
                }

            }
            catch (Exception ex)
            {
                WriteLog("[发送文本消息]异常：" + ex.Message + ex.StackTrace);
            }
        }

        #endregion



        private static readonly Encoding encoding = Encoding.UTF8;
        private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
        {
            System.IO.Stream formDataStream = new System.IO.MemoryStream();
            bool needsCLRF = false;

            foreach (var param in postParameters)
            {
                // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
                // Skip it on the first parameter, add it to subsequent parameters.
                if (needsCLRF)
                    formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

                needsCLRF = true;

                if (param.Value is FileParameter)
                {
                    FileParameter fileToUpload = (FileParameter)param.Value;

                    // Add just the first part of this param, since we will write the file data directly to the Stream
                    string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n",
                        boundary,
                        param.Key,
                        fileToUpload.FileName ?? param.Key,
                        fileToUpload.ContentType ?? "application/octet-stream");

                    formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

                    // Write the file data directly to the Stream, rather than serializing it to a string.
                    formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                }
                else
                {
                    string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                        boundary,
                        param.Key,
                        param.Value);
                    formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
                }
            }

            // Add the end of the request.  Start with a newline
            string footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

            // Dump the Stream into a byte[]
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();

            return formData;
        }

        public class FileParameter
        {
            public byte[] File { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
            public FileParameter(byte[] file) : this(file, null) { }
            public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
            public FileParameter(byte[] file, string filename, string contenttype)
            {
                File = file;
                FileName = filename;
                ContentType = contenttype;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                listFiles.Items.Clear();
                foreach (var f in ofd.FileNames)
                {
                    listFiles.Items.Add(f);
                }
            }
        }

        #region 消息发送


        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Factory.StartNew(SendMessage);

            }
            catch (Exception ex)
            {
                WriteLog("[执行发送]异常：" + ex.Message);
            }
        }

        private void SendMessage()
        {
            try
            {
                WriteLog("开始发送消息。。。", false);
                String _errMsg = String.Empty;
                // 验证登陆状态

                // 获取文本
                String _txtMsg = String.Empty;
                this.Invoke(new EventHandler(delegate { _txtMsg = txtMessage.Text; }));

                // 获取文件
                List<String> _files = GetSelFiles();

                // 获取接收人
                Dictionary<String, String> _receivers = GetSelReceivers();

                // 执行发送
                if (_receivers != null && _receivers.Count > 0)
                {
                    WriteLog($"共有[{_receivers.Count}]个接收人,[{(_files != null ? _files.Count : 0)}]个文件", false);
                    foreach (var receiver in _receivers)
                    {
                        WriteLog($"向[{receiver.Value}]发送文件。", false);
                        // 发送图片
                        if (_files != null && _files.Count > 0)
                        {
                            for (Int32 i = 0; i < _files.Count; i++)
                            {
                                // 判断文件类型，选择按照图片发送还是文件发送
                                WriteLog($"开始发送文件[{_files[i]}]。", false);
                                _errMsg = SendImageMsg(receiver.Key, _files[i], i);
                                if (!String.IsNullOrEmpty(_errMsg))
                                {
                                    WriteLog($"文件[{_files[i]}]发送失败:" + _errMsg, false);
                                }
                                else
                                {
                                    WriteLog($"文件[{_files[i]}]发送成功！", false);
                                }
                                System.Threading.Thread.Sleep(Common.RandomSleep());
                            }
                        }
                        WriteLog($"向[{receiver.Value}]发送文本消息。", false);
                        System.Threading.Thread.Sleep(Common.RandomSleep());
                        // 发送文本
                        if (!String.IsNullOrEmpty(_txtMsg) && _txtMsg.Length > 0)
                        {
                            _errMsg = SendTextMsg(receiver.Key, _txtMsg);
                            if (!String.IsNullOrEmpty(_errMsg))
                            {
                                WriteLog($"文本消息发送失败:" + _errMsg, false);
                            }
                            else
                            {
                                WriteLog($"文本消息发送成功！", false);
                            }
                        }

                        System.Threading.Thread.Sleep(Common.RandomSleep());
                    }

                    WriteLog("发送完毕！", false);
                }
            }
            catch (Exception ex)
            {
                WriteLog("消息发送线程内异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 获取设置的联系人。
        /// </summary>
        /// <returns></returns>
        private Dictionary<String, String> GetSelReceivers()
        {
            Dictionary<String, String> result = new Dictionary<String, String>();
            String all = String.Empty;
            this.Invoke(new EventHandler(delegate { all = txtReceivers.Text; }));
            String[] allARr = all.Split(new char[] { '\r', '\n' });

            if (allARr != null && allARr.Length > 0)
            {
                foreach (var remarkName in allARr)
                {
                    if (remarkName.Length > 0)
                    {
                        String userName = m_Session.Contacts.FirstOrDefault(x => x.RemarkName == remarkName || x.NickName == remarkName)?.UserName;
                        if (!String.IsNullOrEmpty(userName))
                        {
                            result.Add(userName, remarkName);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取选择的文件
        /// </summary>
        /// <returns></returns>
        private List<String> GetSelFiles()
        {
            List<String> _files = new List<string>();
            ListBox.ObjectCollection coll = null;
            this.Invoke(new EventHandler(delegate { coll = listFiles.Items; }));
            if (coll.Count > 0)
            {
                foreach (var item in coll)
                {
                    _files.Add(item.ToString());
                }
            }
            return _files;
        }

        /// <summary>
        /// 获取文本消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetText_Click(object sender, EventArgs e)
        {
            HttpWebRequest _request = null;
            HttpWebResponse _response = null;
            String _responseText = String.Empty;

            try
            {
                _request = m_Session.CreateRequest(txtMessageUrl.Text);
                using (_response = (HttpWebResponse)_request.GetResponse())
                {
                    _responseText = m_Session.GetResponseString(_response);
                    if (_response.StatusCode == HttpStatusCode.OK)
                    {
                        txtMessage.Text = _responseText;
                    }
                    _response.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog("[获取消息]异常：" + ex.Message);
            }
        }

        #endregion



        private void CheckedChanged_ContactType(object sender, EventArgs e)
        {
            try
            {
                if (m_Session == null || m_Session.Contacts == null || m_Session.Contacts.Count == 0) return;

                RadioButton rbt = sender as RadioButton;
                if (rbt.Tag != null)
                {
                    String key = rbt.Tag.ToString().ToLower();
                    switch (rbt.Tag.ToString().ToLower())
                    {
                        case "all":
                            dataGridView1.DataSource = m_Session.Contacts;
                            break;
                        case "group":
                            dataGridView1.DataSource = m_Session.Contacts.FindAll(x => x.UserName.StartsWith("@@"));
                            break;
                        case "friend":
                            dataGridView1.DataSource = m_Session.Contacts.FindAll(x => !x.UserName.StartsWith("@@"));
                            break;
                        case "subscribe":
                            //dataGridView1.DataSource = m_Session.Contacts.All(x=>x.VerifyFlag);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("[切换联系人分组]异常：" + ex.Message + ex.StackTrace);
            }
        }

        private void btnViewSession_Click(object sender, EventArgs e)
        {
            frmSessionView frm = new frmSessionView();
            frm.Session = m_Session;
            frm.Show();
        }

    }
}
