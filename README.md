# TrafficCop

TrafficCop is super simple way of analyzing incoming traffic and imposing rules or policies on requests.

TrafficCop was initially created as a means of combatting website referral spam but its application can also be used for other means such as traffic shaping or IP blocking/white listing.

Getting Started
-------

Getting started with TrafficCop is painless. After referencing the source .dll in your ASP.NET MVC project (NuGet package is on its way!) follow the following steps.

**Step 1: Create a custom TrafficCop registry**

A TrafficCop Registry is a simply class that you use to register your policies. So for instance, if you wanted to block traffic from a certain website or IP address you would create a registry and then add your traffic policies to your newly created registry.

    public class MyCustomRegistry : TrafficCopRegistration
    {
        public MyCustomRegistry()
        {
            this.RegisterRoutePolicy(new BlockBadWebsite1Policy());
            this.RegisterRoutePolicy(new RedirectReallyBadWebsitePolicy());
        }
    }

**Register TrafficCop**

Register TrafficCop in your `global.asax.cs` file within the `Application_Start()` method like so:

    protected void Application_Start()
    {
        ...
        Core.TrafficCop.Register(new MyCustomRegistry());
        ...
    }

Coming soon.

License
-------
All files are under the [The MIT License (MIT) license][license].

[license]:http://en.wikipedia.org/wiki/MIT_License
