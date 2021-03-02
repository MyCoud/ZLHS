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
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Wordprocessing;
using bitibll;


namespace Bitsitake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefunctController : ControllerBase
    {
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
            return bll.GetShopTabs(ShopCoutID,ShopName,Shop_Pid,ShopSpState);
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
        public int Zhuce([FromBody]  PLogin s)
        {
            var md = HttpContext.Session.GetString("checkCode");
            if (!s.LoginCode.Equals(StringComparison.CurrentCultureIgnoreCase))
            {
                HttpContext.Session.SetString("checkCode", s.LoginCode);
                return -3;
            }
            int row = bat.Zhuce(s);
            return row;
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
        //}
    }
}
