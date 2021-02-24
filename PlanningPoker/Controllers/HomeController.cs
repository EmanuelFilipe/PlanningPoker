using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlanningPoker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //var localHost = HttpContext.Request.Host.Value;
            //return Redirect($"https://{localHost}/swagger/index.html");
            return View();
        }
    }
}