using Moq;
using NUnit.Framework;
using TrafficCop.Core;

namespace TrafficCop.Tests
{
    [TestFixture]
    public class BaseUnitTest
    {
        protected Mock<TestRegistration> TestRegistration { get; set; }
        protected Mock<TrafficCopRoutePolicy> GuiltyTestPolicyMock { get; set; }
        protected IRequestContext TestRequestContext { get; set; }

        [SetUp]
        public void TestSetup()
        {
            this.TestRequestContext = new DummyContext();
            this.TestRegistration = new Mock<TestRegistration>();
            this.GuiltyTestPolicyMock = new Mock<TrafficCopRoutePolicy>();
        }
    }

    public class GuiltyTestPolicy : TrafficCopRoutePolicy
    {
        public override bool Match(IRequestContext requestContext)
        {
            return true;
        }

        public override void MatchAction(object actions)
        {
        }
    }

    public class InnocentTestPolicy : TrafficCopRoutePolicy
    {
        public override bool Match(IRequestContext requestContext)
        {
            return false;
        }

        public override void MatchAction(object actions)
        {
        }
    }
}