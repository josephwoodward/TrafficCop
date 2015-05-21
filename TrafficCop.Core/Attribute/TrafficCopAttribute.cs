using System.Web;
using System.Web.Mvc;

namespace TrafficCop.Core.Attribute
{
    public class TrafficCopAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            /*if (!HttpContext.Current.Request.Browser.Crawler)
            {
                filterContext.Result = new ViewResult() {ViewName = "NotFound"};
            }*/
        }
    }
}