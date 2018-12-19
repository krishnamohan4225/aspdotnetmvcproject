using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace smartpond.Utils
{
    public static class CommonHelper
    {
        public static string ActiveTab(this HtmlHelper helper, string activeController, string[] activeActions, string cssClass)
        {
            string currentAction = helper.ViewContext.Controller.
                ValueProvider.GetValue("action").RawValue.ToString();
            string currentController = helper.ViewContext.Controller.
                ValueProvider.GetValue("controller").RawValue.ToString();

            string cssClassToUse = currentController.ToLower() == activeController.ToLower() && Array.FindIndex(activeActions, t => t.Equals(currentAction, StringComparison.InvariantCultureIgnoreCase)) != -1 ? cssClass : string.Empty;
            return cssClassToUse;
        }

        private const string DefaultCssClass = "current";

        public static string ActiveTab(this HtmlHelper helper, string activeController, string[] activeActions)
        {
            return helper.ActiveTab(activeController, activeActions, DefaultCssClass);
        }

        public static string ActiveTab(this HtmlHelper helper, string activeController, string activeAction)
        {
            return helper.ActiveTab(activeController, new string[] { activeAction }, DefaultCssClass);
        }

        public static string ActiveTab(this HtmlHelper helper, string activeController, string activeAction, string cssClass)
        {
            return helper.ActiveTab(activeController, new string[] { activeAction }, cssClass);
        }
    }
}