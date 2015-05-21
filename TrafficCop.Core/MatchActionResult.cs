using System;
using System.Web;

namespace TrafficCop.Core
{
    public abstract class MatchActionResult
    {
        private readonly Func<HttpContextBase> _contextMaker = () => new HttpContextWrapper(HttpContext.Current);

        public object CustomActions { get; set; }

        protected MatchActionResult()
        {
        }

        protected MatchActionResult(Func<HttpContextBase> context)
        {
            _contextMaker = context ?? _contextMaker;
        }

        public HttpContextBase Context
        {
            get { return _contextMaker.Invoke(); }
        }

        public virtual void MovedPermanently301(string redirectUrl)
        {
            Context.Response.StatusCode = 301;
            Context.Response.Redirect(redirectUrl);
        }

        public virtual void Forbibben403()
        {
            Context.Response.StatusCode = 403;
        }

        public virtual void PageNotFound404()
        {
            Context.Response.StatusCode = 404;
        }

        public virtual void PageNotFound404(string redirectUrl)
        {
            Context.Response.StatusCode = 404;
            Context.Response.Redirect(redirectUrl);
        }

        public virtual void Gone410()
        {
            Context.Response.StatusCode = 410;
        }
    }
}