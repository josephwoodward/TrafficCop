using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using TrafficCop.Core;
using TrafficCop.Core.Exceptions;

namespace TrafficCop.Tests
{
    public class TrafficCopWatchTests : BaseUnitTest
    {
        [Test]
        public void Should_throw_exception_if_argument_is_null()
        {
            Should.Throw<ArgumentNullException>(() => { Core.TrafficCop.Watch(null); });
        }

        [Test]
        public void Should_throw_exception_if_no_routes_suppled()
        {
            Should.Throw<NoTrafficCopRoutesException>(() => { Core.TrafficCop.Watch(); });
        }

        [Test]
        public void Should_not_throw_exception_if_routes_are_supplied()
        {
            // Arrange
            var testRoutes = new List<TrafficCopRoutePolicy>
            {
                new GuiltyTestPolicy()
            };

            this.TestRegistration.Setup(x => x.GetRoutes()).Returns(testRoutes);

            // Act
            Core.TrafficCop.Register(this.TestRegistration.Object);

            // Assert
            Should.NotThrow(() => { Core.TrafficCop.Watch(); });
        }
 
    }
}