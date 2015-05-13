using NUnit.Framework;

namespace TrafficCop.Tests
{
    [TestFixture]
    internal class TrafficCopRegisterTests
    {
        [Test]
        public void ExampleTest()
        {
            var registry = new TestRegistration();

            Core.TrafficCop.Register(registry);
        }
    }
}