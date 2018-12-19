using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiharITI.Controllers
{
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Energy()
        {
            return View();
        }

        public ActionResult ElectricMeter()
        {
            return View();
        }
    }
}