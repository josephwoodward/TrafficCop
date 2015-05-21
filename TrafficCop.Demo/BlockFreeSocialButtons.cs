using TrafficCop.Core;

namespace TrafficCop.Demo
{
    public class BlockFreeSocialButtons : TrafficCopRoutePolicy
    {
        public override bool Match(IRequestContext requestContext)
        {
            bool isLocal = (requestContext.IpAddress == "127.0.0.1" || requestContext.IpAddress == "::1");

            return isLocal;
        }

        public override void MatchAction(object actions)
        {
            var act = actions as MyCustomActions;
            if (act != null) act.GoToStackOverflow();
        }
    }
}