using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PhonemikeServer.Host.Controllers
{
    public class PhoneClientController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}