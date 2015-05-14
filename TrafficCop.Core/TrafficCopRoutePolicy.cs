namespace TrafficCop.Core
{
    public abstract class TrafficCopRoutePolicy
    {
        abstract public bool RequestIsGuilty(IRequestContext requestContext);

        abstract public void IssuePenalty();
    }
}