namespace TrafficCop.Core
{
    public interface ITrafficCopInspection
    {
        bool RequestIsGuilty(IRequestContext requestContext);

        void Penalty();
    }
}