using BiharITI.DATA;
using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace BiharITI.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
           
            using (kernels1_itiEntities dc = new kernels1_itiEntities())
            {
                var data = dc.attendances.OrderByDescending(a => a.id).ToList().Take(1).SingleOrDefault();
                string attandance_Status = data.status;
                int? attenance_fingerid = data.fingerid;
                ViewBag.attendance_Status = attandance_Status;
                ViewBag.attendance_fingerid = attenance_fingerid;
                DateTime dt = DateTime.ParseExact(data.updatedDate.ToString(), "M/d/yyyy h:m:s tt", CultureInfo.InvariantCulture);
                ViewBag.attendance_time = dt.ToString("h:m:s tt", CultureInfo.InvariantCulture);
                ViewBag.attendance_date = dt.ToString("d-MM-yyyy", CultureInfo.InvariantCulture);

                //electricity data
                var Electricity_data = dc.ElectricityMeters.OrderByDescending(a => a.id).ToList().Take(1).SingleOrDefault();
                ViewBag.Electric_Meter_Voltage = Electricity_data.voltage;
                ViewBag.Electric_Meter_Current = Electricity_data.currentamp;
                ViewBag.Electric_Meter_units = Electricity_data.Units;
               DateTime Electric_time = DateTime.ParseExact(Electricity_data.updatedDate.ToString(), "MM/d/yyyy h:m:s tt", CultureInfo.InvariantCulture);
                ViewBag.Electric_Meter_time = Electric_time.ToString("h:m:s tt", CultureInfo.InvariantCulture);
                ViewBag.Electric_Meter_date = Electric_time.ToString("d-M-yyyy", CultureInfo.InvariantCulture);


                //smart energy
                var Smartenergy_data = dc.SmartEnergies.OrderByDescending(a => a.id).ToList().Take(1).SingleOrDefault();
                ViewBag.Smartenergy_Voltage = Smartenergy_data.voltage;
                ViewBag.Smartenergy_Current = Smartenergy_data.currentamp;
                ViewBag.Smartenergy_units = Smartenergy_data.frequency;
                ViewBag.Smartenergy_powerfactor = Smartenergy_data.powerfactor;

                DateTime Smartenergy_time = DateTime.ParseExact(Smartenergy_data.updatedDate.ToString(), "MM/d/yyyy h:m:s tt", CultureInfo.InvariantCulture);
                ViewBag.Smartenergy_time = Smartenergy_time.ToString("h:m:s tt", CultureInfo.InvariantCulture);
                ViewBag.Smartenergy_date = Smartenergy_time.ToString("d-M-yyyy", CultureInfo.InvariantCulture);


                //smart temperature
                var SmartTemperature_data = dc.Temperatures.OrderByDescending(a => a.id).ToList().Take(1).SingleOrDefault();
                ViewBag.SmartTemperature_Temp = SmartTemperature_data.temp;
                ViewBag.SmartTemperature_faht = SmartTemperature_data.faht;
              

                DateTime Smarttemptime = DateTime.ParseExact(SmartTemperature_data.updatedDate.ToString(), "MM/d/yyyy h:m:s tt", CultureInfo.InvariantCulture);
                ViewBag.SmartTemperature_time = Smarttemptime.ToString("h:m:s tt", CultureInfo.InvariantCulture);
                ViewBag.SmartTemperature_date = Smarttemptime.ToString("d-M-yyyy", CultureInfo.InvariantCulture);




                //Vehicle tracker
                var SmartTracker_data = dc.VehicleTrackings.OrderByDescending(a => a.id).ToList().Take(1).SingleOrDefault();
                ViewBag.SmartTracker_lat = SmartTracker_data.Latitude;
                ViewBag.SmartTracker_long = SmartTracker_data.Longitude;


                DateTime SmartVehclletracker = DateTime.ParseExact(SmartTracker_data.updatedDate.ToString(), "MM/d/yyyy h:m:s tt", CultureInfo.InvariantCulture);
                ViewBag.SmartTracker_time = SmartVehclletracker.ToString("h:m:s tt", CultureInfo.InvariantCulture);
                ViewBag.SmartTracker_date = SmartVehclletracker.ToString("d-M-yyyy", CultureInfo.InvariantCulture);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                ViewBag.executiontime = elapsedMs;
                return View();
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculator(int? num1, int? num2)
        {
            int? sum = num1 + num2;
            ViewBag.num1 = num1;
            ViewBag.num2 = num2;
            ViewBag.sum = sum;
            return View();
        }
    }
}