using System.Web;
using TrafficCop.Core;

namespace TrafficCop.Demo
{
    public class BlockFreeSocialButtons : ITrafficCopInspection
    {
        public bool RequestIsGuilty(IRequestContext requestContext)
        {
            return true;
        }

        public void Penalty()
        {
            HttpContext.Current.Response.StatusCode = 301;
            HttpContext.Current.Response.Redirect("http://www.google.co.uk");
        }
    }
}