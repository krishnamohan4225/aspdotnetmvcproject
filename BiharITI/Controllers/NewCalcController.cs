using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiharITI.Controllers
{
    public class NewCalcController : Controller
    {
        // GET: NewCalc
        //methods are of 2 types 1. get 2. post
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult calculatorPost( int? num1, int? num2)
        {
            return View();
        }
    }
}