using bitBLL;
using bitModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace Bitsitake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuaController : Controller
    {
        Huabll bll = new Huabll();

        //获取订单数据

        //显示订单的所有数据
        [EnableCors("kuayu")]
        [HttpGet("GetShop")]
        public object GetShopDetail( int page=1,int limit=5,string bid="", string name="", string statid="", string sourid="")
        {
            //定义变量总条数
            int totalcount;
            List<ShopDetail> data1= bll.GetShopDetail(out totalcount,bid,name, statid, sourid).Skip((page-1)*limit).Take(limit).ToList();
            var data = new
            {
                code=0,
                msg="",
                count= totalcount,
                data=data1
            };
            return Json(data);
        }

        //确认收获页面显示
        [EnableCors("kuayu")]
        [HttpGet("GetConfig")]
        public object GetConfig(int page = 1, int limit = 5, string bid = "", string name = "", string statid = "", string sourid = "")
        {
            //定义变量总条数
            int totalcount;
            List<ShopDetail> data1 = bll.GetShopDetail(out totalcount, bid, name, statid, sourid).Skip((page - 1) * limit).Take(limit).ToList();
            var data = new
            {
                code = 0,
                msg = "",
                count = totalcount,
                data = data1
            };
            return Json(data);
        }

        //显示订单(添加)
        [EnableCors("kuayu")]
        [HttpPost("AddShop")]
        public IActionResult AddShopDetail([FromBody] ShopDetail sp)
        {
            //定义变量总条数
            int data1 = bll.AddShopDetail(sp);
            if (data1 > 0)
            {
                return Ok(data1);
            }
            else
                return Ok(0);

        }

        //确认收货(删除)
        [EnableCors("kuayu")]
        [HttpPost("DelConfirm")]
        public IActionResult DelConfirm(string id)
        {
            //定义变量总条数
            int data = bll.DelConfirm(id);
            if (data > 0)
            {
                return Ok(data);
            }
            else
                return Ok(0);

        }

        //确认收货(修改)
        [EnableCors("kuayu")]
        [HttpPut("UpdateConfirm")]
        public IActionResult UpdateConfirm(string ids)
        {
          string  id = ids.ToString();
            //定义变量总条数
            int data = bll.UpdateConfirm(id);
            if (data > 0)
            {
                return Ok(data);
            }
            else
                return Ok(0);

        }


        //绑定下拉状态
        [EnableCors("kuayu")]
        [HttpGet("Bindstat")]
        public List<Stat> BindStat()
        {
            return bll.BindState();
        }

        //绑定下拉来源
        [EnableCors("kuayu")]
        [HttpGet("BindSource")]
        public List<Source> BindSource()
        {
            return bll.BindSource();
        }

        //确认收获的反填
        [EnableCors("kuayu")]
        [HttpGet("FanConfirm")]
        public object FanConfirm( string idd)
        {
            //定义变量总条数
            List<ShopDetail> data1 = bll.FanConfirm(idd);
            var data = new
            {
                code = 0,
                msg = "",
                data = data1
            };
            return Json(data);
        }



    }
}
