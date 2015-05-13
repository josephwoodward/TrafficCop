using System.Collections.Generic;

namespace TrafficCop.Core
{
    public abstract class TrafficCopRegistration
    {
        public IList<string> RoutesList = new List<string>();

        public void WatchRoute(string route)
        {
            this.RoutesList.Add(route);
        }

        public virtual IList<string> GetRoutes()
        {
            return this.RoutesList;
        }
    }
}