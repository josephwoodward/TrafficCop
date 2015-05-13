using System;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace TrafficCop.Tests
{
    [TestFixture]
    internal class TrafficCopRegisterTests : BaseUnitTest
    {
        [Test]
        public void Should_throw_exception_if_argument_is_null()
        {
            Should.Throw<ArgumentNullException>(() => { Core.TrafficCop.Register(null); });
        }

        [Test]
        public void Should_not_throw_exception_if_argument_is_suppled()
        {
            Should.NotThrow(() => { Core.TrafficCop.Register(this.TestRegistration.Object); });
        }

        [Test]
        public void Should_get_registration_routes()
        {
            Core.TrafficCop.Register(this.TestRegistration.Object);

            this.TestRegistration.Verify(x => x.GetRoutes(), Times.Once);
        }
    }
}