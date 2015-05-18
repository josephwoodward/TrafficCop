using System;
using System.Web;

namespace TrafficCop.Core
{
    public abstract class ActionContext
    {
        private readonly Func<HttpContextBase> _contextMaker = () => new HttpContextWrapper(HttpContext.Current);

        protected ActionContext()
        {
        }

        protected ActionContext(Func<HttpContextBase> context)
        {
            _contextMaker = context ?? _contextMaker;
        }

        public HttpContextBase Context
        {
            get { return _contextMaker.Invoke(); }
        }

        public virtual void Redirect301(string url)
        {
            Context.Response.StatusCode = 301;
            Context.Response.Redirect(url);
        }

        public virtual void PageNotFound404(string url)
        {
            Context.Response.StatusCode = 404;
            Context.Response.Redirect(url);
        }
    }
}