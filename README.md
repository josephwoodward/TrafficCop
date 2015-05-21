# TrafficCop

TrafficCop is super simple way of analyzing incoming traffic and imposing rules or policies on requests.

TrafficCop was initially created as a means of combatting website referral spam but its application can also be used for other means such as traffic shaping or IP blocking/white listing.

Getting Started
-------

Getting started with TrafficCop is painless. After referencing the source .dll in your ASP.NET MVC project (NuGet package is on its way!) follow the following steps.

**Step 1: Create a custom TrafficCop registry**

Before setting up TrafficCop you must first create a custom registry and register it with TrafficCop.

A TrafficCop Registry is a simply class that you use to register your traffic policies/rules via the `RegisterRoutePolicy()` method as demonstrated below.

    public class MyCustomRegistry : TrafficCopRegistration
    {
        public MyCustomRegistry()
        {
            this.RegisterRoutePolicy(new BlockBadWebsitePolicy());
            this.RegisterRoutePolicy(new RedirectReallyBadWebsitePolicy());
        }
    }

**Step 2: Create your custom policy**

A policy is a set of rules that once registered gets enforced on incoming HTTP traffic. The following action demonstrates how you could block all incoming traffic from the IP address of `22.231.113.64`. You can implement your own rules within the `Match()` method using the properties within the `IRequestContext` parameter.

    public class BlockBadWebsitePolicy : TrafficCopRoutePolicy
    {
        public override bool Match(IRequestContext requestContext)
        {
            bool isBadTraffic = (requestContext.IpAddress == "22.231.113.64");
            return isBadTraffic;
        }

        public override void MatchAction(object actions)
        {
            var act = actions as TrafficCopActions;
            if (act != null) act.PageNotFound404();
        }
    }
    
The `MatchAction` method is called when the traffic within your `Match` method is successfully matched. By default there are a set of actions available via the supplied `TrafficCopActions` paramter, however custom actions can be added by extending the TrafficCopActions base class.
    
The default actions are:
* `MovedPermanently301(string redirectUrl)`
* `Forbibben403()`
* `PageNotFound404()`
* `PageNotFound404(string redirectUrl)`
* `Gone410()`
    


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
