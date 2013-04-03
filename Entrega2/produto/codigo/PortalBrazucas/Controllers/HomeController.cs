using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalBrazucas.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Index/

        public ActionResult Index()
        {
            ViewBag.Message = "Esse é o novo";
            return View();
        }
    }
}
