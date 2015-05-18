using TrafficCop.Core;

namespace TrafficCop.Demo
{
    public class CustomAction : ActionContext
    {
        public void Redirect301()
        {
            Context.Response.StatusCode = 301;
            Context.Response.Redirect("http://google.com/");
        }
    }
}