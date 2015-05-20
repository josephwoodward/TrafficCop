using System.Collections.Generic;

namespace TrafficCop.Core
{
    public abstract class TrafficCopRegistration
    {
        public IList<TrafficCopRoutePolicy> RouteCommands = new List<TrafficCopRoutePolicy>();

        public MatchActionResult MatchActions { get; set; }

        protected TrafficCopRegistration()
        {
            this.MatchActions = new TrafficCopActions();
        }

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