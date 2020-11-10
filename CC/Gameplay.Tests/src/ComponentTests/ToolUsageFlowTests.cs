using System.Collections.Generic;
using CC.Actors.Components;
using CC.Components.Collectable;
using CC.Components.Location;
using CC.Components.Tool;
using CC.Gameplay.Flow;
using CC.Items;
using Moq;
using NUnit.Framework;

namespace Gameplay.Tests.ComponentTests {
    [TestFixture]
    public class ToolUsageFlowTests {
        private GameFlow gameFlow;
        private Actor actor;
        private Mock<Rope> mockedRope;
        private LocationComponent locationComponent;
        private Mock<ITarget> target;
        [SetUp]
        public void Setup() {
            gameFlow = new GameFlow();
            mockedRope = new Mock<Rope>();
            target = new Mock<ITarget>();
            locationComponent = new LocationComponent(Mock.Of<IOccupiable>());
            actor = new Actor(new List<ICollectable>{mockedRope.Object});
            gameFlow.Actors.Add(actor);
        }

        [Test]
        public void Actor_Does_Use_Items() {
            actor.ToolUsageComponent.Use(mockedRope.Object, locationComponent, target.Object);
            
            mockedRope.Verify(_ => _.Use(actor.ToolUsageComponent, locationComponent, target.Object), Times.Once());
        }
    }
}