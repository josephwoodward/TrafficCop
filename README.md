# TrafficCop

TrafficCop is super simple way of analyzing incoming traffic and imposing rules or policies on requests.

TrafficCop was initially created as a means of combatting website referral spam but its application can also be used for other means such as traffic shaping or IP blocking/white listing.

Getting Started
-------

Getting started with TrafficCop is painless. After referencing the source .dll in your ASP.NET MVC project (NuGet package is on its way!) follow the following steps.

**Create a custom TrafficCop registry **

A registry is a logical grouping or profile that you can register with TrafficCop.

    **MyCustomRegistry.cs**
    public class MyCustomRegistry : TrafficCopRegistration
    {
        public MyCustomRegistry()
        {
            this.RegisterRoutePolicy(new BlockFreeSocialButtons());
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
