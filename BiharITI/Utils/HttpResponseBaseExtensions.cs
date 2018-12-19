using Newtonsoft.Json;
using BiharITI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BiharITI.Utils
{
    public static class HttpResponseBaseExtensions
    {
        public static int SetAuthCookie<T>(this HttpResponseBase responseBase, string name, bool rememberMe, T userData)
        {
            try
            {
                /// In order to pickup the settings from config, we create a default cookie and use its values to create a 
                /// new one.
                var cookie = FormsAuthentication.GetAuthCookie(name, rememberMe);
                var ticket = FormsAuthentication.Decrypt(cookie.Value);


                var data = JsonConvert.SerializeObject(userData, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration,
                    ticket.IsPersistent, data, ticket.CookiePath);
                var encTicket = FormsAuthentication.Encrypt(newTicket);

                /// Use existing cookie. Could create new one but would have to copy settings over...
                cookie.Value = encTicket;

                responseBase.Cookies.Add(cookie);

                return encTicket.Length;
            }
            catch (Exception Ex)
            {   
                return 0;
            }
        }

        public static UserDetails GetAuthCookie(this HttpResponseBase responseBase)
        {
            try
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                string cookiePath = ticket.CookiePath;
                DateTime expiration = ticket.Expiration;
                bool expired = ticket.Expired;
                bool isPersistent = ticket.IsPersistent;
                DateTime issueDate = ticket.IssueDate;
                string name = ticket.Name;
                UserDetails userDetail = (UserDetails)JsonConvert.DeserializeObject(ticket.UserData, typeof(UserDetails));
                string version = ticket.Version.ToString();

                return userDetail;
            }
            catch (Exception Ex)
            {   
                return new UserDetails();
            }
        }

        public static int UserID(this HttpResponseBase responseBase)
        {
            return responseBase.GetAuthCookie().UserID;
        }
    }
}