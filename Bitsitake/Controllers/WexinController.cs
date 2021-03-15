//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net.Http;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Mvc;
//using System.Xml;
//using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
//using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
//using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
//using RouteAttribute = System.Web.Mvc.RouteAttribute;

//namespace Bitsitake.Controllers
//{
//    [Route("api/[controller]")]

//    public class WexinController : ControllerBase
//    {
//        [EnableCors("kuayu")]
//        [HttpGet]
//        public HttpResponseMessage Get([FromUri] VerifyModel verifyModel)
//        {
//            try
//            {
//                if (WxApiAuthorization.CheckSignature(verifyModel))
//                    return ResponseMessage(verifyModel.echostr);
//                else
//                    return ResponseMessage("微信签名与系统签名不一致");
//            }
//            catch (Exception ex)
//            {
//                return ResponseMessage(ex.Message);

//            }

//        }
//        [EnableCors("kuayu")]
//        [HttpPost]
//        public HttpResponseMessage Post()
//        {
//            try
//            {
//                var buffer = new MemoryStream();
//                Stream requestStream = Request.Body;
//                byte[] requestByte = new byte[requestStream.Length];
//                requestStream.Read(requestByte, 0, (int)requestStream.Length);

//                string reqXml = Encoding.UTF8.GetString(requestByte);

//                if (string.IsNullOrEmpty(reqXml))
//                    return ResponseMessage("success");
//                var wxXmlSerialize = new WxXmlSerialize(reqXml);
//                WxXmlModel WxXmlModel = wxXmlSerialize.GetBaseModel();
//                switch (WxXmlModel.MsgType)
//                {
//                    case "text"://文本
//                        WxXmlModel.Content = wxXmlSerialize.GetValue("Content");
//                        var xml = WxResponseMessage.GetText(WxXmlModel.FromUserName, WxXmlModel.ToUserName, WxXmlModel.Content);
//                        return ResponseMessage(xml);
//                    case "event"://事件
//                        BaseEventEntity entity = new BaseEventEntity();
//                        entity.FromUserName = WxXmlModel.FromUserName;
//                        entity.ToUserName = WxXmlModel.ToUserName;
//                        entity.CreateTime = long.Parse(WxXmlModel.CreateTime);
//                        entity.MsgType = WxXmlModel.MsgType;

//                        entity.Event = wxXmlSerialize.GetValue("Event");
//                        entity.EventKey = wxXmlSerialize.GetValue("EventKey");
//                        entity.Ticket = wxXmlSerialize.GetValue("Ticket");

//                        return ResponseMessage("success");
//                    default:
//                        return ResponseMessage("success");
//                }
//            }
//            catch (Exception ex)
//            {
//                return ResponseMessage("success");
//                throw;
//            }
//            //回复消息的时候也需要验证消息，这个很多开发者没有注意这个，存在安全隐患
//            //微信中 谁都可以获取信息 所以 关系不大 对于普通用户 但是对于某些涉及到验证信息的开发非常有必要
//            //接收消息
//        }
//        private HttpResponseMessage ResponseMessage(string xml)
//        {
//            return new HttpResponseMessage { Content = new StringContent(xml, Encoding.GetEncoding("UTF-8"), "text/plain") };
//        }
//    }
    
//    public class WxXmlSerialize
//    {
//        private XmlElement _rootElement;

//        public WxXmlSerialize(string xml)
//        {
//            XmlDocument requestDocXml = new XmlDocument();
//            requestDocXml.LoadXml(xml);
//            _rootElement = requestDocXml.DocumentElement;
//        }

//        public WxXmlModel GetBaseModel()
//        {
//            return new WxXmlModel()
//            {
//                ToUserName = GetValue("ToUserName"),
//                FromUserName = GetValue("FromUserName"),
//                CreateTime = GetValue("CreateTime"),
//                MsgType = GetValue("MsgType")
//            };
//        }

//        public string GetValue(string key)
//        {
//            return _rootElement.SelectSingleNode(key)?.InnerText;
//        }
//    }

//    public class BaseEventEntity
//    {
//        public string ToUserName { get; set; } //开发者微信号
//        public string FromUserName { get; set; } //发送方帐号（一个OpenID）
//        public long CreateTime { get; set; }    //消息创建时间 （整型）

//        public string MsgType { get; set; }

//        public string Event { get; set; }        // 事件类型，subscribe

//        public string EventKey { get; set; }    //事件KEY值，qrscene_为前缀，后面为二维码的参数值
//        public string Ticket { get; set; }    // 二维码的ticket，可用来换取二维码图片
//    }

//    public class WxXmlModel
//    {
//        public string ToUserName { get; set; }
//        public string FromUserName { get; set; }
//        public string CreateTime { get; set; }
//        public string MsgType { get; set; }
//        public string Content { get; set; }
//        public string MsgId { get; set; }

//    }

//    public class WxApiAuthorization
//    {
//        /// <summary>
//        /// token
//        /// </summary>
//        private const string access_token = "WeiXinAuthorization";
//        /// <summary>
//        /// 验证微信签名
//        /// </summary>
//        /// <returns></returns>
//        /// * 将token、timestamp、nonce三个参数进行字典序排序
//        /// * 将三个参数字符串拼接成一个字符串进行sha1加密
//        /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
//        public static bool CheckSignature(VerifyModel verifyModel)
//        {
//            var arr = new[] { access_token, verifyModel.timestamp, verifyModel.nonce }.OrderBy(z => z).ToArray();
//            var arrString = string.Join("", arr);
//            var sha1 = System.Security.Cryptography.SHA1.Create();
//            var sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(arrString));
//            StringBuilder enText = new StringBuilder();
//            foreach (var b in sha1Arr)
//            {
//                enText.AppendFormat("{0:x2}", b);
//            }
//            return verifyModel.signature == enText.ToString();
//        }
//        /// <summary>
//        /// SHA1 加密，返回大写字符串
//        /// </summary>
//        /// <param name="content">需要加密字符串</param>
//        /// <param name="encode">指定加密编码</param>
//        /// <returns>返回40位大写字符串</returns>
//        private static string SHA1(string content, Encoding encode)
//        {
//            try
//            {
//                SHA1 sha1 = new SHA1CryptoServiceProvider();
//                byte[] bytes_in = encode.GetBytes(content);
//                byte[] bytes_out = sha1.ComputeHash(bytes_in);
//                sha1.Dispose();
//                string result = BitConverter.ToString(bytes_out);
//                result = result.Replace("-", "");
//                return result;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("SHA1加密出错：" + ex.Message);
//            }
//        }
//    }

//    public class WxResponseMessage
//    {
//        public static string GetText(string FromUserName, string ToUserName, string Content)
//        {
//            string XML = "";
//            XML = ReText(FromUserName, ToUserName, "您好，您的消息已转至工作人员，我们会尽快做出回复！谢谢您的反馈！");
//            return XML;
//        }
//        public static string ReText(string FromUserName, string ToUserName, string Content)
//        {
//            string XML = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName>";//发送给谁(openid)，来自谁(公众账号ID)
//            XML += "<CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";//回复时间戳
//            XML += "<MsgType><![CDATA[text]]></MsgType>";//回复类型文本
//            XML += "<Content><![CDATA[" + Content + "]]></Content><FuncFlag>0</FuncFlag></xml>";//回复内容 FuncFlag设置为1的时候，自动星标刚才接收到的消息，适合活动统计使用
//            return XML;
//        }
//        public static int ConvertDateTimeInt(DateTime time)
//        {
//            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
//            return (int)(time - startTime).TotalSeconds;
//        }
//    }

//    public class VerifyModel
//    {
//        public string signature { get; set; }//微信加密签名，signature结合了开发者填写的token参数和请求中的  timestamp参数、nonce参数。
//        public string timestamp { get; set; } //时间戳
//        public string nonce { get; set; }  //随机数
//        public string echostr { get; set; }  //随机数
//    }

//}

