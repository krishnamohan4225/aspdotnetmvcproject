using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BiharITI.DATA;
using BiharITI.Models;
using BiharITI.Utils;
using System.Web.Security;

namespace smartpond.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password, bool? IsRememberMe)
        {
            try
            {
                using (kernels1_itiEntities DB = new kernels1_itiEntities())
                {
                    IsRememberMe = IsRememberMe == null ? false : (bool)IsRememberMe;
                    var user = DB.Users.FirstOrDefault(x => x.Username == Username && x.Password == Password);
                    if (user != null)
                    {
                        UserDetails userDetails = new UserDetails();
                        userDetails.UserID = user.UserID;
                       // userDetails.DisplayName = user.FullName;
                        Response.SetAuthCookie(userDetails.UserID.ToString(), (bool)IsRememberMe, userDetails);
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ViewBag.Error = "Error";
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.error = Ex.Message;

            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

      

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}