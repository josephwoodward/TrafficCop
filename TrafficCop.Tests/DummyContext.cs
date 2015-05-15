using System;
using TrafficCop.Core;

namespace TrafficCop.Tests
{
    public class DummyContext : IRequestContext
    {
        public DummyContext()
        {
            this.IpAddress = "127.0.0.1";
            this.ReferrerUrl = new Uri("http://www.github.com");
        }

        public string IpAddress { get; private set; }

        public Uri ReferrerUrl { get; private set; }
    }
}