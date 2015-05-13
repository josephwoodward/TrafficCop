using System;
using System.Collections.Generic;

namespace TrafficCop.Core
{
    public abstract class TrafficCopRegistration
    {
        public IList<ITrafficCopInspection> RouteCommands = new List<ITrafficCopInspection>();

        public void WatchRoute(ITrafficCopInspection trafficCopRequest)
        {
            this.RouteCommands.Add(trafficCopRequest);
        }

        public void WatchRoute(Func<IRequestContext, bool> action)
        {
        }

        public virtual IList<ITrafficCopInspection> GetRoutes()
        {
            return this.RouteCommands;
        }
    }
}