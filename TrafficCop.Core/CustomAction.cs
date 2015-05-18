namespace TrafficCop.Core
{
    public class CustomAction : ActionContext
    {
        public override void Redirect301(string url)
        {
            Context.Response.StatusCode = 301;
            Context.Response.Redirect("http://google.com/");
        }

        public void MyCustomAction()
        {
            Context.Response.StatusCode = 301;
            Context.Response.Redirect("http://google.com/");
        }
    }
}