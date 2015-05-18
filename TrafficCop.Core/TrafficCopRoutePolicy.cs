using System.Net;

namespace TrafficCop.Core
{
    public abstract class TrafficCopRoutePolicy
    {
        public abstract bool Match(IRequestContext requestContext);

        public abstract void MatchAction(TrafficCopActions actions);

        public virtual void ActionExecuted()
        {
        }
    }
}