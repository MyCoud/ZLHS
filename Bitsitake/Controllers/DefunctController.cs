using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bitModel;
using bitDal;
using bitBLL;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Xml.Linq;
using bitibll;
using Newtonsoft.Json;
using Common;
using Microsoft.AspNetCore.Hosting;
using System.IO;

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Builder;
using System.Text;
using System.Net;
using Microsoft.EntityFrameworkCore.Storage;
namespace Bitsitake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefunctController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDatabase _redis;
        public DefunctController(IWebHostEnvironment webHostEnvironmen)
        {
            _webHostEnvironment = webHostEnvironmen;

        }
        LictBLL bll = new LictBLL();
        ZhsbLL bat = new ZhsbLL();
        //[EnableCors("any")]  //局部的
        //[HttpPost("mename")]
        //public int getusers([FromBody] users s)
        //{
        //    string sql = $"insert into users values ('{s.name}','{s.age}')";
        //    return conn.Execute(sql);
        //}

        [EnableCors("kuayu")]
        [HttpGet("GetShopTabs")]
        //获取商品列表所有数据
        public object GetShopTabs(int Page = 1, int PageSize = 10, int ShopId = 0, string ShopName = "", string Name = "", int ShopSpState = 0)
        {
            var data1 = bll.GetShopTabs(ShopId, ShopName, Name, ShopSpState);
            var data = new
            {
                code = 0,
                msg = "",
                count = data1.Count(),
                data = data1.Skip((Page - 1) * PageSize).Take(PageSize).ToList(),
            };
            return Ok(JsonConvert.SerializeObject(data));
        }

        [EnableCors("kuayu")]
        [HttpPost("AddShops")]
        //添加商品信息
        public int AddShops([FromBody] ShopTab t)
        {
            return bll.AddShops(t);
        }
        [EnableCors("kuayu")]
        [HttpPost("AddImgs")]
        //上传图片
        public int AddImgs([FromBody] ShopImg s)
        {
            return bll.AddImgs(s);
        }


        /// <summary>
        /// 上传图片,通过Form表单提交
        /// </summary>
        /// <returns></returns>
        //[EnableCors("kuayu")]
        //[HttpPost("UploadImg")]

        //public object TuPin()
        //{

        //    var pic = Request.Form.Files[0];
        //    if (pic != null)
        //    {
        //        var fil = Base.MapPath("/img/");
        //        var per = fil + pic.FileName;
        //        pic.SaveAs(per);
        //        var url = @"/img/" + pic.FileName;
        //        return JsonConvert.SerializeObject(new
        //        {
        //            Result = url,
        //            code = 0,
        //        });
        //    }
        //    return null;
        //}
        [EnableCors("kuayu")]
        [HttpPost("addtext")]
        //添加商品说明
        public int Addtext([FromBody] ShopImg s)
        {
            return bll.Addtext(s);
        }
        [EnableCors("kuayu")]
        [HttpPost("Deltext")]
        //删除商品属性
        public int Deltext(int id)
        {
            return bll.Deltext(id);
        }
        [EnableCors("kuayu")]
        [HttpPost("Zhuce")]
        //注册
        public int Zhuce([FromBody] PLogins s)
        {
            var md = HttpContext.Session.GetString("checkCode");
            //if (!s.LoginCode.Equals(md))
            //{
            //    HttpContext.Session.SetString("checkcode", s.LoginCode);
            //    return -3;
            //}
            int row = bat.Zhuce(s);
            return row;
        }
        [EnableCors("kuayu")]
        [HttpGet("GetValidateImage")]
        //验证码
        public ActionResult GetValidateImage()
        {

            //实例化图片类
            ValidateCode code = new ValidateCode();
            string Users = code.Text.ToLower();
            //保存到对话框
            HttpContext.Session.SetString("checkCode", Users);
            byte[] bytes = code.GetImageBytes();
            return File(bytes, @"image/jpeg");
        }
        [EnableCors("kuayu")]
        [HttpPost("GetReuslt")]
        //登录
        public int GetReuslt(string LoginPhone, string LoginPass)
        {
            return bat.GetReuslt(LoginPhone, LoginPass);
        }

        ////验证码
        //public ActionResult GetValidateImage()
        //{

        //    //实例化图片类
        //    ValidateCode code = new ValidateCode();
        //    string Users = code.Text.ToLower();
        //    //保存到对话框
        //    HttpContext.Session.SetString(Users, "1000");

        //    byte[] bytes = code.GetImageBytes();
        //    return File(bytes, @"image/jpeg");

        [EnableCors("kuayu")]
        [HttpPost("AddOnTe")]
        //添加商品属性
        public int AddOnTe([FromBody] ShopFen s)
        {
            return bll.AddOnTe(s);
        }
        [EnableCors("kuayu")]
        [HttpGet("GetFens")]
        //获取商品属性
        public object GetFens()
        {
            var data1 = bll.GetFens();
            var data = new
            {
                code = 0,
                msg = "",
                data = data1
            };
            return Ok(JsonConvert.SerializeObject(data));
        }
        [EnableCors("kuayu")]
        [HttpPost("AddFens")]
        //商品分类编辑
        public int AddFens([FromBody] ShopFen s)
        {
            return bll.AddFens(s);
        }
        [EnableCors("kuayu")]
        [HttpGet("GetToFens")]
        //获取商品分类编辑
        public object GetToFens(int Page = 1, int PageSize = 10, string Fname = "")
        {
            var data1 = bll.GetToFens(Fname);
            var data = new
            {
                code = 0,
                msg = "",
                count = data1.Count(),
                data = data1.Skip((Page - 1) * PageSize).Take(PageSize).ToList(),
            };
            return Ok(JsonConvert.SerializeObject(data));
        }
        [EnableCors("kuayu")]
        [HttpPost("DelToFens")]
        //删除商品属性
        public int DelToFens(int id)
        {
            return bll.DelToFens(id);
        }
        [EnableCors("kuayu")]
        [HttpPost("EditToFens")]
        //编辑商品
        public int EditToFens([FromBody] ShopFen s)
        {

            return bll.EditToFens(s);
        }
        [EnableCors("kuayu")]
        [HttpGet("SeleToFenId")]
        //反填商品信息
        public ShopFen SeleToFenId(int id)
        {

            return bll.SeleToFenId(id);
        }
        [EnableCors("kuayu")]
        [HttpGet("GetSaxFens")]
        //获取商品每个价格、所属品牌
        public object GetSaxFens(int Page = 1, int PageSize = 10, string ShopName = "")
        {
            var data1 = bll.GetSaxFens(ShopName);
            var data = new
            {
                code = 0,
                msg = "",
                count = data1.Count(),
                data = data1.Skip((Page - 1) * PageSize).Take(PageSize).ToList(),
            };
            return Ok(JsonConvert.SerializeObject(data));
        }
        [EnableCors("kuayu")]
        [HttpPost("AddSaxFens")]
        //添加商品价格信息
        public int AddSaxFens([FromBody] ShopTab s)
        {
            return bll.AddSaxFens(s);
        }
        [EnableCors("kuayu")]
        [HttpGet("SaxFensid")]
        //获取商品每个价格、所属品牌
        public ShopTab SaxFensid(int id)
        {
            return bll.SaxFensid(id);
        }
        [EnableCors("kuayu")]
        [HttpPost("UptSaxFens")]
        //修改
        public int UptSaxFens([FromBody] ShopTab s)
        {
            return bll.UptSaxFens(s);
        }
        [EnableCors("kuayu")]
        [HttpPost("SangToJia")]
        public int SangToJia(int id)
        {
            return bll.SangToJia(id);
        }
        //手机发送验证码
        public static string PostUrl = "http://106.ihuyi.cn/webservice/sms.php?method=Submit";
        /// <summary>
        /// 进行手机验证码验证查询 从而重置密码
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        [EnableCors("kuayu")]
        [HttpPost("Yzm")]
        public IActionResult Yzm(string Phone)
        {
            string account = "C72839206";//用户名是登录用户中心->验证码、通知短信->帐户及签名设置->APIID
            string password = "a4423689fc96480c10218c9891eb10df"; //密码是请登录用户中心->验证码、通知短信->帐户及签名设置->APIKEY

            Random rad = new Random();
            int mobile_code = rad.Next(1000, 10000);
            string content = "您的验证码是：" + mobile_code + " 。请不要把验证码泄露给其他人。";

            //Session["mobile"] = mobile;
            //Session["mobile_code"] = mobile_code;

            string postStrTpl = "account={0}&password={1}&mobile={2}&content={3}";

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, account, password, Phone, content));

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

                //Response.Write(reader.ReadToEnd());

                string res = reader.ReadToEnd();
                int len1 = res.IndexOf("</code>");
                int len2 = res.IndexOf("<code>");
                string code = res.Substring((len2 + 6), (len1 - len2 - 6));
                //Response.Write(code);

                int len3 = res.IndexOf("</msg>");
                int len4 = res.IndexOf("<msg>");
                string msg = res.Substring((len4 + 5), (len3 - len4 - 5));

                return Ok(mobile_code);
            }
            else
            {
                return Ok(0);
            }
        }
        [EnableCors("kuayu")]
        [HttpPost("IsLogin")]
        public bool IsLogin()
        {

            string userId = null;
            if (HttpContext.Session.TryGetValue("UserId", out byte[] bytes))
            {
                userId = Encoding.UTF8.GetString(bytes);
            }
            return !string.IsNullOrWhiteSpace(userId);

        }
    }
}



