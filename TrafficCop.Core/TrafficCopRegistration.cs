using System.Collections.Generic;

namespace TrafficCop.Core
{
    public abstract class TrafficCopRegistration
    {
        public IList<TrafficCopRoutePolicy> RoutePolicies = new List<TrafficCopRoutePolicy>();

        public MatchActionResult PolicyMatchActions { get; set; }

        protected TrafficCopRegistration()
        {
            this.PolicyMatchActions = new TrafficCopActions();
        }

        public void RegisterRoutePolicy(TrafficCopRoutePolicy routePolicy)
        {
            this.RoutePolicies.Add(routePolicy);
        }

        public virtual IList<TrafficCopRoutePolicy> GetRoutes()
        {
            return this.RoutePolicies;
        }
    }
}