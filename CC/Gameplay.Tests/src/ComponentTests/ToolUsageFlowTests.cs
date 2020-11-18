using System;
using System.Collections.Generic;
using CC.Actors.Components;
using CC.Components.Collectable;
using CC.Components.Location;
using CC.Components.Location.Model;
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
        
        public static IEnumerable<TestCaseData> ShovelSourceCasesSource {
            get {
                yield return new TestCaseData(typeof(Hallway), typeof(Intersection));
                yield return new TestCaseData(typeof(Corner), typeof(Intersection));
                yield return new TestCaseData(typeof(Intersection), typeof(Crossroads));
            }
        }
        
        [TestCaseSource(nameof(ShovelSourceCasesSource))]
        public void Shovel_Usage_Updates_Source_To_Proper_State(Type tileState, Type excpectedState) {
            Shovel shovel = new Shovel();
            var tileSource = gameFlow.Board.TileFromPosition(actor.Position);
            tileSource.StateMachine.ChangeState(tileSource.StateMachine.States[tileState]);
            var source = tileSource.LocationComponent;
            var tileTarget = gameFlow.Board.TileFromPosition(actor.Position+Vector2.right);
            var target = tileTarget.LocationComponent;
            actor.CollectorComponent.Collect(shovel);
            
            actor.ToolUsageComponent.Use(shovel, source, target);
            
            tileSource.StateMachine.CurrentState.GetType().ShouldBe(excpectedState);
        }
        
        public static IEnumerable<TestCaseData> ShovelSourceDirCasesSource {
            get {
                yield return new TestCaseData(Vector2.one, Vector2.up, Directions.North);
                yield return new TestCaseData(Vector2.one, Vector2.right, Directions.East);
                yield return new TestCaseData(Vector2.one, Vector2.down, Directions.South);
                yield return new TestCaseData(Vector2.one, Vector2.left, Directions.West);
            }
        }
        
        [TestCaseSource(nameof(ShovelSourceDirCasesSource))]
        public void Shovel_Usage_Updates_Source_Wall_State_To_Open(Vector2 tileSourcePos, Vector2 dir, Directions wallDir) {
            var tileSource = gameFlow.Board.TileFromPosition(tileSourcePos);
            var source = tileSource.LocationComponent;
            var tileTarget = gameFlow.Board.TileFromPosition(tileSourcePos + dir);
            var target = tileTarget.LocationComponent;
            Shovel shovel = new Shovel();
            actor.CollectorComponent.Collect(shovel);
            actor.ToolUsageComponent.Use(shovel, source, target);
            
            tileSource.Wall.GetWall(wallDir).ShouldBeTrue();
        }
        
        public static IEnumerable<TestCaseData> ShovelTargetDirCasesSource {
            get {
                yield return new TestCaseData(Vector2.one, Vector2.up, Directions.South);
                yield return new TestCaseData(Vector2.one, Vector2.right, Directions.West);
                yield return new TestCaseData(Vector2.one, Vector2.down, Directions.North);
                yield return new TestCaseData(Vector2.one, Vector2.left, Directions.East);
            }
        }
        
        [TestCaseSource(nameof(ShovelTargetDirCasesSource))]
        public void Shovel_Usage_Updates_Target_Wall_State_To_Open(Vector2 tileSourcePos, Vector2 dir, Directions wallDir) {
            var tileSource = gameFlow.Board.TileFromPosition(tileSourcePos);
            var source = tileSource.LocationComponent;
            var tileTarget = gameFlow.Board.TileFromPosition(tileSourcePos + dir);
            var target = tileTarget.LocationComponent;
            Shovel shovel = new Shovel();
            actor.CollectorComponent.Collect(shovel);
            actor.ToolUsageComponent.Use(shovel, source, target);


            foreach (var wall in tileTarget.Wall.GetWalls()) {
                Console.WriteLine(wall.Key + " " + wall.Value);
            }
            
            tileTarget.Wall.GetWall(wallDir).ShouldBeTrue();
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