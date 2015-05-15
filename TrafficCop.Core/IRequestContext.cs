using System;
using System.Web;

namespace TrafficCop.Core
{
    public interface IRequestContext
    {
        string IpAddress { get; }

        Uri ReferrerUrl { get; }

        HttpRequestBase HttpRequest { get; }
    }
}