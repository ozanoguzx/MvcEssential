using MVC_Filter.Models;
using System.Web.Mvc;

namespace MVC_Filter.ActionFilter
{
    public class CheckUser : ActionFilterAttribute
    {
        public static bool actionResult { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            TCKimlikDogrulama.KPSPublicSoapClient service = new TCKimlikDogrulama.KPSPublicSoapClient();

            User user = filterContext.ActionParameters["user"] as User;
            bool result = false;
            try
            {
                result = service.TCKimlikNoDogrula(
                        long.Parse(user.TCKN),
                        user.FirstName.ToUpper(),
                        user.LastName.ToUpper(),
                        int.Parse(user.BirthYear)
                        );
            }
            catch
            {
                result = false;
            }
            filterContext.Result = new RedirectResult("/Users/Create/" + result);
        }
    }
}