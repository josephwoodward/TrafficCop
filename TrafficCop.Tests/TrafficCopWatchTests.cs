using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Shouldly;
using TrafficCop.Core;
using TrafficCop.Core.Exceptions;

namespace TrafficCop.Tests
{
    public class TrafficCopWatchTests : BaseUnitTest
    {
        [Test]
        public void Should_throw_exception_null_context_argument_is_supplied()
        {
            Should.Throw<ArgumentNullException>(() => { Core.TrafficCop.Watch(null); });
        }

        [Ignore]
        public void Should_throw_exception_if_no_routes_suppled()
        {
            Should.Throw<NoTrafficCopRoutesException>(() => { Core.TrafficCop.Watch(); });
        }

        [Test]
        public void Can_supply_context_override()
        {
            // Arrange
            var testRoutes = new List<TrafficCopRoutePolicy>
            {
                new GuiltyTestPolicy()
            };

            this.TestRegistration.Setup(x => x.GetRoutes()).Returns(testRoutes);
            Core.TrafficCop.Register(this.TestRegistration.Object);

            // Act
            Core.TrafficCop.Watch(this.TestRequestContext);

            // Assert
            this.TestRegistration.Verify(x => x.GetRoutes(), Times.Once);
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

        [Test]
        public void Should_allow_empty_routes()
        {
            // Arrange
            var testRoutes = new List<TrafficCopRoutePolicy>();
            this.TestRegistration.Setup(x => x.GetRoutes()).Returns(testRoutes);

            // Act
            Core.TrafficCop.Register(this.TestRegistration.Object);

            // Assert
            Should.NotThrow(() => { Core.TrafficCop.Watch(); });
        }


        [Test]
        public void Should_try_match_policy()
        {
            // Arrange
            var testRoutes = new List<TrafficCopRoutePolicy>
            {
                this.GuiltyTestPolicyMock.Object
            };
            
            this.TestRegistration.Setup(x => x.GetRoutes()).Returns(testRoutes);
            Core.TrafficCop.Register(this.TestRegistration.Object);

            // Act
            Core.TrafficCop.Watch(this.TestRequestContext);

            // Assert
            this.GuiltyTestPolicyMock.Verify(x => x.Match(this.TestRequestContext), Times.Once);
        }

        [Test]
        public void Should_execute_action_if_policy_matches()
        {
            // Arrange
            this.GuiltyTestPolicyMock.Setup(x => x.Match(this.TestRequestContext)).Returns(true);
            var testRoutes = new List<TrafficCopRoutePolicy>
            {
                this.GuiltyTestPolicyMock.Object
            };

            this.TestRegistration.Setup(x => x.GetRoutes()).Returns(testRoutes);
            Core.TrafficCop.Register(this.TestRegistration.Object);

            // Act
            Core.TrafficCop.Watch(this.TestRequestContext);

            // Assert
            this.GuiltyTestPolicyMock.Verify(x => x.MatchAction(It.IsAny<MatchActionResult>()), Times.Once);
        }

        [Test]
        public void Should_skip_action_if_policy_does_not_match()
        {
            // Arrange
            this.GuiltyTestPolicyMock.Setup(x => x.Match(this.TestRequestContext)).Returns(false);
            var testRoutes = new List<TrafficCopRoutePolicy>
            {
                this.GuiltyTestPolicyMock.Object
            };

            this.TestRegistration.Setup(x => x.GetRoutes()).Returns(testRoutes);
            Core.TrafficCop.Register(this.TestRegistration.Object);

            // Act
            Core.TrafficCop.Watch(this.TestRequestContext);

            // Assert
            this.GuiltyTestPolicyMock.Verify(x => x.MatchAction(It.IsAny<MatchActionResult>()), Times.Never);
        }

        [Test]
        public void Should_call_action_executed_callback_if_policy_matches()
        {
            // Arrange
            this.GuiltyTestPolicyMock.Setup(x => x.Match(this.TestRequestContext)).Returns(true);
            var testRoutes = new List<TrafficCopRoutePolicy>
            {
                this.GuiltyTestPolicyMock.Object
            };

            this.TestRegistration.Setup(x => x.GetRoutes()).Returns(testRoutes);
            Core.TrafficCop.Register(this.TestRegistration.Object);

            // Act
            Core.TrafficCop.Watch(this.TestRequestContext);

            // Assert
            this.GuiltyTestPolicyMock.Verify(x => x.ActionExecuted(), Times.Once);
        }

        [Test]
        public void Should_skip_action_executed_callback_if_policy_does_not_match()
        {
            // Arrange
            this.GuiltyTestPolicyMock.Setup(x => x.Match(this.TestRequestContext)).Returns(false);
            var testRoutes = new List<TrafficCopRoutePolicy>
            {
                this.GuiltyTestPolicyMock.Object
            };

            this.TestRegistration.Setup(x => x.GetRoutes()).Returns(testRoutes);
            Core.TrafficCop.Register(this.TestRegistration.Object);

            // Act
            Core.TrafficCop.Watch(this.TestRequestContext);

            // Assert
            this.GuiltyTestPolicyMock.Verify(x => x.ActionExecuted(), Times.Never);
        }
    }
}