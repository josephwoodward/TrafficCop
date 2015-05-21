using System;
using System.Collections.Generic;
using TrafficCop.Core.Exceptions;

namespace TrafficCop.Core
{
    public class TrafficCop
    {
        public static IList<TrafficCopRoutePolicy> Routes { get; set; }
        public static MatchActionResult Actions { get; set; }

        public static void Register(TrafficCopRegistration registry)
        {
            if (registry == null)
                throw new ArgumentNullException("registry");

            Routes = registry.GetRoutes();
            Actions = registry.PolicyMatchActions;
        }

        public static void Watch()
        {
            WatchTraffic(new RequestContext());
        }

        public static void Watch(IRequestContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            WatchTraffic(context);
        }

        private static void WatchTraffic(IRequestContext context)
        {
            ThrowIfNoRoutes();

            foreach (TrafficCopRoutePolicy route in Routes)
            {
                if (route.Match(context))
                {
                    route.MatchAction(Actions);
                    route.ActionExecuted();
                }
            }
        }

        private static void ThrowIfNoRoutes()
        {
            if (Routes == null)
                throw new NoTrafficCopRoutesException("No routes specified");
        }
    }
}