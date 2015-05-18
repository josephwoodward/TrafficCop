using NUnit.Framework;

namespace TrafficCop.Tests
{
    [TestFixture]
    public class TrafficCopCustomRegistrationTests : BaseUnitTest
    {
        [Ignore]
        public void Should_allow_policy_registration()
        {
            this.TestRegistration.Setup(x => x.WatchRoute(new GuiltyTestPolicy()));
            var resgration = this.TestRegistration.Object;

            Assert.IsNotEmpty(resgration.RouteCommands);
        }
    }
}