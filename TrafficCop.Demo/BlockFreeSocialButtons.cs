using TrafficCop.Core;

namespace TrafficCop.Demo
{
    public class BlockFreeSocialButtons : TrafficCopRoutePolicy
    {
        public override bool Match(IRequestContext requestContext)
        {
            bool isLocal = (requestContext.IpAddress == "127.0.0.1");

            return isLocal;
        }

        public override void MatchAction(TrafficCopActions actions)
        {
            actions.Redirect301("http://www.google.co.uk");
        }
    }
}