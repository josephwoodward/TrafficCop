using TrafficCop.Core;

namespace TrafficCop.Demo
{
    public class MyCustomRegistry : TrafficCopRegistration
    {
        public MyCustomRegistry()
        {
            this.WatchRoute(new BlockFreeSocialButtons());
        }
    }
}