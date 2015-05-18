using System.Web;

namespace TrafficCop.Core
{
    public abstract class TrafficCopActions
    {
        public virtual void Redirect301(string url)
        {
            HttpContext.Current.Response.StatusCode = 301;
            HttpContext.Current.Response.Redirect(url);
        }

        public virtual void PageNotFound404(string url)
        {
            HttpContext.Current.Response.StatusCode = 404;
            HttpContext.Current.Response.Redirect(url);
        }
    }
}