using System.Collections.Generic;
using CC.Actors.Components;
using CC.Components.Collectable;
using CC.Components.Location;
using CC.Components.Tool;
using CC.Gameplay.Flow;
using CC.Items;
using Moq;
using NUnit.Framework;
using Shouldly;
using UnityEngine;

namespace Gameplay.Tests.ComponentTests {
    [TestFixture]
    public class ToolUsageFlowTests {
        private GameFlow gameFlow;
        private Actor actor;
        
        [SetUp]
        public void Setup() {
            gameFlow = new GameFlow();
            actor = new Actor();
            gameFlow.AddActor(actor);
        }

        [Test]
        public void Actor_Does_Use_Items() {
            var mockedRope = new Mock<Rope>();
            var mockedTarget = new Mock<ILocation>();
            var mockedLocation = new LocationComponent(Mock.Of<IOccupiable>());
            actor.CollectorComponent.Collect(mockedRope.Object);
            
            actor.ToolUsageComponent.Use(mockedRope.Object, mockedLocation, mockedTarget.Object);
            
            mockedRope.Verify(_ => _.Use(actor.ToolUsageComponent, mockedLocation, mockedTarget.Object), Times.Once());
        }

        [Test]
        public void Rope_Usage_Does_Remove_From_Inventory() {
            Rope rope = new Rope();
            var source = gameFlow.Board.TileFromPosition(actor.Position).LocationComponent;
            var target = source;
            actor.CollectorComponent.Collect(rope);
            actor.ToolUsageComponent.Use(rope, source, target);

            actor.InventoryComponent.Pickups.ShouldNotContain(rope);
        }

        [Test]
        public void Shovel_Usage_Updates_Unexplored_To_Starting_State() {
            Shovel shovel = new Shovel();
            var source = gameFlow.Board.TileFromPosition(actor.Position).LocationComponent;
            var target = gameFlow.Board.TileFromPosition(actor.Position+Vector2.right).LocationComponent;
            actor.CollectorComponent.Collect(shovel);
            actor.ToolUsageComponent.Use(shovel, source, target);
            
            // tile.StateMachine.CurrentState.GetType().ShouldBe();
        }
        [Test]
        public void Rope_Usage_Affects_Room_State() {
            Rope rope = new Rope();
            var tile = gameFlow.Board.TileFromPosition(actor.Position);
            var source = tile.LocationComponent;
            var target = source;
            actor.CollectorComponent.Collect(rope);
            actor.ToolUsageComponent.Use(rope, source, target);
            
            // tile.StateMachine.CurrentState.GetType().ShouldBe();
        }
    }
}