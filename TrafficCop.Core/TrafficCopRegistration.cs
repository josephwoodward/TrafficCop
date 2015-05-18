using System.Collections.Generic;

namespace TrafficCop.Core
{
    public abstract class TrafficCopRegistration
    {
        public IList<TrafficCopRoutePolicy> RouteCommands = new List<TrafficCopRoutePolicy>();

        public void WatchRoute(TrafficCopRoutePolicy trafficCopRequest)
        {
            this.RouteCommands.Add(trafficCopRequest);
        }

        public virtual IList<TrafficCopRoutePolicy> GetRoutes()
        {
            return this.RouteCommands;
        }
    }
}