namespace TrafficCop.Core
{
    public abstract class TrafficCopRoutePolicy
    {
        abstract public bool Match(IRequestContext requestContext);

        abstract public void MatchAction();

        public virtual void ActionExecuted()
        {
        }
    }
}