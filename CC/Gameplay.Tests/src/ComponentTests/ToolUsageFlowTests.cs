using System.Collections.Generic;
using CC.Actors.Components;
using CC.Components.Collectable;
using CC.Components.Location;
using CC.Components.Tool;
using CC.Gameplay.Flow;
using CC.Items;
using CC.Tiles;
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
        public void Shovel_Usage_Updates_Target_Unexplored_To_Starting_State() {
            Shovel shovel = new Shovel();
            var tileSource = gameFlow.Board.TileFromPosition(actor.Position);
            var source = tileSource.LocationComponent;
            var tileTarget = gameFlow.Board.TileFromPosition(actor.Position+Vector2.right);
            var target = tileTarget.LocationComponent;
            actor.CollectorComponent.Collect(shovel);
            actor.ToolUsageComponent.Use(shovel, source, target);
            
            tileTarget.StateMachine.CurrentState.GetType().ShouldBe(tileTarget.ExploredStateType);
        }
        
        [Test]
        public void Rope_Usage_Updates_Pit() {
            Rope rope = new Rope();
            var tile = gameFlow.Board.TileFromPosition(actor.Position);
            var source = tile.LocationComponent;
            var target = source;
            tile.StateMachine.ChangeState(tile.StateMachine.States[typeof(Pit)]);
            actor.CollectorComponent.Collect(rope);
            actor.ToolUsageComponent.Use(rope, source, target);
            
            tile.StateMachine.CurrentState.GetType().ShouldBe(typeof(PitAndRope));
        }
        
        [Test]
        public void Rope_Usage_Adds_Rope_To_Pit() {
            Rope rope = new Rope();
            var tile = gameFlow.Board.TileFromPosition(actor.Position);
            var source = tile.LocationComponent;
            var target = source;
            tile.StateMachine.ChangeState(tile.StateMachine.States[typeof(Pit)]);
            actor.CollectorComponent.Collect(rope);
            actor.ToolUsageComponent.Use(rope, source, target);
            
            target.Location.Inventory.Pickups.ShouldContain(rope);
        }
        
        [Test]
        public void Rope_Collection_Updates_PitAndRope() {
            Rope rope = new Rope();
            var tile = gameFlow.Board.TileFromPosition(actor.Position);
            tile.Inventory.Collect(rope);
            tile.StateMachine.ChangeState(tile.StateMachine.States[typeof(PitAndRope)]);
            gameFlow.Collect(actor.CollectorComponent.Inventory, tile.Inventory, rope);
            
            tile.StateMachine.CurrentState.GetType().ShouldBe(typeof(Pit));
        }
    }
}