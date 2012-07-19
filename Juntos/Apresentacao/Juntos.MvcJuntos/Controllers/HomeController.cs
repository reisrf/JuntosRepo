using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Juntos.MvcJuntos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Benvindo ao Juntos!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
