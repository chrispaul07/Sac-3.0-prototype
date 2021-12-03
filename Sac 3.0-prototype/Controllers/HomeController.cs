using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sac_3._0_prototype.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            ViewBag.Message = "SCRIPTURE AND CANTICLE 3.0";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "SCRIPTURE AND CANTICLE 3.0";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Dazzle Softtech";

            return View();
        }
    }
}