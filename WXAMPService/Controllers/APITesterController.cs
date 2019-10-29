using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WXAMPService.Controllers
{
    public class APITesterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TestPost()
        {
            return View();
        }
    }
}