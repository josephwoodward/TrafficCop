using NUnit.Framework;

namespace TrafficCop.Tests
{
    [TestFixture]
    public class TrafficCopCustomRegistrationTests : BaseUnitTest
    {
        [Ignore]
        public void Should_allow_policy_registration()
        {
            this.TestRegistration.Setup(x => x.RegisterRoutePolicy(new GuiltyTestPolicy()));
            var resgration = this.TestRegistration.Object;

            Assert.IsNotEmpty(resgration.RoutePolicies);
        }
    }
}