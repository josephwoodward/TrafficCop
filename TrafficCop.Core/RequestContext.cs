using System;
using System.Linq;
using System.Web;

namespace TrafficCop.Core
{
    public class RequestContext : IRequestContext
    {
        private readonly Func<HttpContextBase> _contextMaker = () => new HttpContextWrapper(HttpContext.Current);

        internal RequestContext()
        {
        }

        internal RequestContext(Func<HttpContextBase> context)
        {
            _contextMaker = context ?? _contextMaker;
        }

        private HttpContextBase Context
        {
            get { return _contextMaker.Invoke(); }
        }

        public string IpAddress
        {
            get { return this.GetIpAddress(); }
        }

        public Uri ReferrerUrl
        {
            get { return this.Context.Request.UrlReferrer; }
        }

        public HttpRequestBase HttpRequest
        {
            get { return this.Context.Request; }
        }

        private string GetIpAddress()
        {
            string ip = (Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? "").Split(',').Last().Trim();
            if (string.IsNullOrEmpty(ip))
            {
                ip = Context.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
        }
    }
}