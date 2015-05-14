using System;

namespace TrafficCop.Core
{
    public interface IRequestContext
    {
        string IpAddress { get; }

        Uri ReferrerUrl { get; }
    }
}