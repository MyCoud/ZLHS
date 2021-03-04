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
    

using Microsoft.AspNetCore.Builder;

namespace Bitsitake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefunctController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DefunctController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
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
        [HttpGet("GetShop")]
        //获取商品列表所有数据
        public List<ShopTab> GetShopTabs(int ShopCoutID, string ShopName, int Shop_Pid, int ShopSpState)
        {
            return bll.GetShopTabs(ShopCoutID, ShopName, Shop_Pid, ShopSpState);
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
        public int GetReuslt([FromBody] string LoginPhone, string LoginPass)
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
    }
}
