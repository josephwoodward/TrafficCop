using System;
using System.Collections.Generic;

namespace TrafficCop.Core
{
    public class TrafficCop
    {
        public static void Register(TrafficCopRegistration customRegistry)
        {
            if (customRegistry == null) throw new ArgumentNullException("customRegistry");

            IList<string> routes = customRegistry.GetRoutes();
        }

        public static void Watch()
        {
        }
    }
}