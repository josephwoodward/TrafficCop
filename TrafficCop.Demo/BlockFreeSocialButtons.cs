using System.Web;
using TrafficCop.Core;

namespace TrafficCop.Demo
{
    public class BlockFreeSocialButtons : TrafficCopRoutePolicy
    {
        public override bool RequestIsGuilty(IRequestContext requestContext)
        {
            bool isLocal = (requestContext.IpAddress == "127.0.0.1");

            return isLocal;
        }

        public override void IssuePenalty()
        {
            //HttpContext.Current.Response.StatusCode = 404;
            HttpContext.Current.Response.Redirect("http://www.google.co.uk");
        }
    }
}