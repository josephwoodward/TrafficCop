using TrafficCop.Core;

namespace TrafficCop.Demo
{
    public class MyCustomRegistry : TrafficCopRegistration
    {
        public MyCustomRegistry()
        {
            //this.PolicyMatchActions = new MyCustomActions();
            this.RegisterRoutePolicy(new BlockFreeSocialButtons());
        }
    }
}