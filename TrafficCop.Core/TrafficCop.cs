using System.Collections.Generic;

namespace TrafficCop.Core
{
    public class TrafficCop
    {
        public static void Register(TrafficCopRegistration customRegistry)
        {
            IList<string> routes = customRegistry.GetRoutes();
        }

        public static void Watch()
        {
        }
    }
}