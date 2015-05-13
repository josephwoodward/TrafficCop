using Moq;
using NUnit.Framework;

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
}