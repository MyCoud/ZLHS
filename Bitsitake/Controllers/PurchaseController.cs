using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bitBLL;
using Microsoft.AspNetCore.Cors;
using bitModel;
using System.Net.Http.Json;
using System.Threading;
using Newtonsoft.Json;
using Dapper;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.Extensions.Logging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Caching.Distributed;


namespace Bitsitake.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {


        private readonly ILogger<PurchaseController> _Logger;



        public PurchaseController(ILogger<PurchaseController> Logger)
        {
            _Logger = Logger;
        }


        SunJcBll bll = new SunJcBll();

        /// <summary>
        /// 创建供应商
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [EnableCors("kuayu")]
        [HttpPost]
        [Route("AddSupplier")]
        public IActionResult CreateSupplier([FromBody] Supplier Model)
        {


            if (bll.CreateSupplier(Model) > 0)
            {
                var dataJson = new
                {
                    Code = 0,
                    resultMsg = "保存成功",

                };
                _Logger.LogInformation("SJC....");
                return Ok(JsonConvert.SerializeObject(dataJson));
            }
            else
            {

                var dataJson = new
                {
                    Code = 1,
                    resultMsg = "保存失败",
                };
                return Ok(JsonConvert.SerializeObject(dataJson));
            }
        }   

        /// <summary>
        /// 显示供应商
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="SupplierBh"></param>
        /// <param name="CreateDate"></param>
        /// <param name="SupplierForm"></param>
        /// <param name="FuZeRen"></param>
        /// <param name="danwei"></param>
        /// <param name="Pinpai"></param>
        /// <param name="Jingying"></param>
        /// <returns></returns>
        [EnableCors("kuayu")]
        [HttpGet]
        [Route("ShowGongyingshang")]
        public IActionResult GongYingShangListShow(int page = 1, int limit = 5, string SupplierBh = null, string CreateDate = null, string SupplierForm = null, string FuZeRen = null,
         string danwei = null, string Pinpai = null, string Jingying = null)
        {

            int total;
            List<Supplier> dataPage = bll.GongYingShangListShow(out total, SupplierBh, CreateDate, SupplierForm, FuZeRen, danwei, Pinpai, Jingying).Skip((page - 1) * limit).Take(limit).ToList();
           
            var data = new
            {
                code = 0,
                msg = "显示成功",
                count = total,
                data = dataPage
            };
            return Ok(JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// 绑定下拉
        /// </summary>
        /// <returns></returns>
        [EnableCors("kuayu")]
        [HttpGet]
        [Route("BindListLobrand")]
        public List<Supplier> BindListLobirand()
        {
            return bll.BindList();
        }

        /// <summary>
        /// 反填供应商
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        [EnableCors("kuayu")]
        [HttpGet]
        [Route("ReturnGetListSupplier")]
        public IActionResult ReturnGetListSupplier(int Uid)
        {
            List<Supplier> data = bll.ReturnGetListSupplier(Uid);
            var Result = new
            {
                data = data,
                code = 0,
                resultMsg = "更新成功"
            };
            return Ok(JsonConvert.SerializeObject(Result));
        }
        /// <summary>
        /// 修改供应商
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="Uid"></param>
        /// <returns></returns>
        [EnableCors("kuayu")]
        [HttpPost]
        [Route("UpdateSupplier")]
        public IActionResult UpdateSupplier([FromBody] Supplier Model, int Uid)
        {
            if (bll.UpdateSupplier(Model, Uid) > 0)
            {
                var dataJson = new
                {
                    Code = 0,
                    resultMsg = "保存成功",

                };
                return Ok(JsonConvert.SerializeObject(dataJson));
            }
            else
            {
                var dataJson = new
                {

                    Code = 1,
                    resultMsg = "保存失败",
                };
                return Ok(JsonConvert.SerializeObject(dataJson));
            }
        }
        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        [EnableCors("kuayu")]
        [HttpPost]
        [Route("UpdateAudit")]
        public IActionResult UpdateAudit([FromBody] int Uid)
        {
            bll.UpdateAudit(Uid);
            var dataJson = new
            {
                Code = 0,
                resultMsg = "供应商已通过审核",

            };
            return Ok(JsonConvert.SerializeObject(dataJson));
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        [EnableCors("kuayu")]
        [HttpGet("GetShopTabs")]
        public IActionResult GetShopTabs(int Page = 1, int PageSize = 10)
        {
            var data1 = bll.GetShopTabs();
            var data = new
            {
                code = 0,
                msg = "",
                count = data1.Count(),
                data = data1.Skip((Page - 1) * PageSize).Take(PageSize).ToList(),
            };
            return Ok(JsonConvert.SerializeObject(data));
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        [EnableCors("kuayu")]
        [HttpPost("DeleteShopTab")]
        public IActionResult DeleteShopTab(int Uid)
        {
            bll.DeleteShopTab(Uid);
            var dataJson = new
            {
                code = 0,
                resultMsg = "删除成功"
            };
            return Ok(JsonConvert.SerializeObject(dataJson));
        }
        /// <summary>
        /// 新建请购单
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [EnableCors("kuayu")]
        [HttpPost("CreateBuying")]
        public IActionResult CreateBuying(Buying Model)
        {
            bll.CreateBuying(Model);

            var dataJson = new
            {
                Code = 0,
                resultMsg = "保存成功",

            };
            return Ok(JsonConvert.SerializeObject(dataJson));

        }
        /// <summary>
        /// 新建采购单
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [EnableCors("kuayu")]
        [HttpPost("CreatePurchase")]
        public IActionResult CreatePurchase(Purchase Model)
        {
            bll.CreatePurchase(Model);

            var dataJson = new
            {
                Code = 0,
                resultMsg = "保存成功",

            };
            return Ok(JsonConvert.SerializeObject(dataJson));
        }

        [EnableCors("kuayu")]
        [HttpGet("GetPurchase")]
        public IActionResult Getpurchase(int page = 1, int limit = 5, string PurchaseState = null, string PuchaseTime = null, string SupName = null, string Fzr = null)
        {

            int total;
            List<Purchase> dataPage = bll.GetPurchaseDate(out total,PurchaseState, PuchaseTime, SupName).Skip((page - 1) * limit).Take(limit).ToList();

            var data = new
            {
                code = 0,
                msg = "显示成功",
                count = total,
                data = dataPage
            };
            return Ok(JsonConvert.SerializeObject(data));

        }
        [EnableCors("kuayu")]
        [HttpGet("GetBuyings")]
        public IActionResult GetBuyings(int page = 1, int limit = 5)
        {

 
            List<Buying> dataPage = bll.GetBuyings().Skip((page - 1) * limit).Take(limit).ToList();

            var data = new
            {
                code = 0,
                msg = "显示成功",
                count = 0,
                data = dataPage
            };
            return Ok(JsonConvert.SerializeObject(data));

        }
    }
}

