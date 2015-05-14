using Moq;
using NUnit.Framework;
using TrafficCop.Core;

namespace TrafficCop.Tests
{
    [TestFixture]
    public class BaseUnitTest
    {
        protected Mock<TestRegistration> TestRegistration { get; set; }

        [SetUp]
        public void TestSetup()
        {
            this.TestRegistration = new Mock<TestRegistration>();
        }
    }

    public class GuiltyTestPolicy : TrafficCopRoutePolicy
    {
        public override bool RequestIsGuilty(IRequestContext requestContext)
        {
            return true;
        }

        public override void IssuePenalty()
        {
            
        }
    }

    public class InnocentTestPolicy : TrafficCopRoutePolicy
    {
        public override bool RequestIsGuilty(IRequestContext requestContext)
        {
            return false;
        }

        public override void IssuePenalty()
        {

        }
    }

}