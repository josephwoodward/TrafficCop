using System;
using System.Collections.Generic;
using System.Web;

namespace TrafficCop.Core
{
    public class TrafficCop
    {
        public static IList<ITrafficCopInspection> Routes { get; set; }

        public static void Register(TrafficCopRegistration customRegistry)
        {
            if (customRegistry == null)
                throw new ArgumentNullException("customRegistry");

            Routes = customRegistry.GetRoutes();
        }

        public static void Watch()
        {

            string ipAddress = HttpContext.Current.Request.UserHostAddress;

            IRequestContext context = new RequestContext { IpAddress = ipAddress };

            foreach (ITrafficCopInspection route in Routes)
            {
                if (route.RequestIsGuilty(context))
                {
                    route.Penalty();
                }
            }
        }
    }
}