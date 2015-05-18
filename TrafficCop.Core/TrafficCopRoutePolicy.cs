namespace TrafficCop.Core
{
    public abstract class TrafficCopRoutePolicy
    {
        public abstract bool Match(IRequestContext requestContext);

        public abstract void MatchAction(object action);

        public virtual void ActionExecuted()
        {
        }
    }
}