using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Filter.ActionFilter
{
    public class MustBeLoggedInAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }

        public MustBeLoggedInAttribute(string role)
        {
            Role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (filterContext.HttpContext.Session["login"] == null && Role == "Admin")
            {
                filterContext.Result = new RedirectResult("/Login");
            }
        }
    }
}