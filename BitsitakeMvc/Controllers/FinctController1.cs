using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitsitakeMvc.Controllers
{
    public class FinctController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
