using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiharITI.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult calculator()
        {
            return View();
        }


        [HttpPost]
        public ActionResult calculator( int a, int b)
        {
            return View();
        }
    }
}