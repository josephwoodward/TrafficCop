using TrafficCop.Core;

namespace TrafficCop.Demo
{
    public class MyCustomRegistry : TrafficCopRegistration
    {
        public MyCustomRegistry()
        {
            this.WatchRoute(new BlockFreeSocialButtons());
            // this.WatchRoute(x => x.IpAddress == "127.0.0.1");
        }
    }
}