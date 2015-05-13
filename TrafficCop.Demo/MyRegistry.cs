using TrafficCop.Core;

namespace TrafficCop.Demo
{
    public class MyRegistry : TrafficCopRegistration
    {
        public MyRegistry()
        {
            this.WatchRoute("route1");
            this.WatchRoute("route2");
        }
    }
}