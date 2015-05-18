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

        public override void MatchAction(object action)
        {
            var act = action as CustomAction;
            if (act != null) act.MyCustomAction();
        }
    }
}