using TrafficCop.Core;

namespace TrafficCop.Demo
{
    public class MyCustomRegistry : TrafficCopRegistration
    {
        public MyCustomRegistry()
        {
            this.MatchActions = new MyCustomActions();
            this.WatchRoute(new BlockFreeSocialButtons());
        }
    }
}