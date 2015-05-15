using System;
using System.Web;
using TrafficCop.Core;

namespace TrafficCop.Tests
{
    public class DummyContext : IRequestContext
    {
        public DummyContext()
        {
            this.IpAddress = "127.0.0.1";
            this.ReferrerUrl = new Uri("http://www.github.com");
            this.HttpRequest = new DummyHttpRequestBase();
        }

        public string IpAddress { get; private set; }

        public Uri ReferrerUrl { get; private set; }

        public HttpRequestBase HttpRequest { get; private set; }
    }

    public class DummyHttpRequestBase : HttpRequestBase
    {
    }
}