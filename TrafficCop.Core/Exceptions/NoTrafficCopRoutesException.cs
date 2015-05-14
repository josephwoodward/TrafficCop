using System;

namespace TrafficCop.Core.Exceptions
{
    public class NoTrafficCopRoutesException : Exception
    {
        public NoTrafficCopRoutesException()
        {
        }

        public NoTrafficCopRoutesException(string message) : base(message)
        {
        }
    }
}