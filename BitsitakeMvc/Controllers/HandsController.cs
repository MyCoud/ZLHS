using Microsoft.AspNetCore.Mvc;

namespace BitsitakeMvc.Controllers
{
    public class HandsController : Controller
    {
        //首页-
        public IActionResult Indexs()
        {
            return View();
        }
        //商品列表
        public IActionResult FWork()
        {
            return View();
        }
        //商品管理
        public IActionResult AddShops()
        {
            return View();
        }
        //登录
        public IActionResult UserDeng()
        {
            return View();
        }
        //注册
        public IActionResult UserZhuCe()
        {

            return View();
        }
        public IActionResult AddOnFen(int id)
        {
            ViewBag.Fid = id;
            return View();

        }
        public IActionResult SaxPrice()
        {
            return View();
        }
        public IActionResult Show()
        {
            return View();
        }

    }
}
