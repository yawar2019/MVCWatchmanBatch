using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRockersBatch.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}