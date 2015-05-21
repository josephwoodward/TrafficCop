using TrafficCop.Core;

namespace TrafficCop.Demo
{
    public class MyCustomActions : MatchActionResult
    {
        public void GoToStackOverflow()
        {
            this.MovedPermanently301("http://www.stackoverflow.com");
        }
    }
}