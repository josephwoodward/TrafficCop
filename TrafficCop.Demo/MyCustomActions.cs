using TrafficCop.Core;

namespace TrafficCop.Demo
{
    public class MyCustomActions : MatchActionResult
    {
        public override void Redirect301(string url)
        {
            Context.Response.StatusCode = 301;
            Context.Response.Redirect(url);
        }

        public void GoToStackOverflow()
        {
            this.Redirect301("http://www.stackoverflow.com");
        }
    }
}