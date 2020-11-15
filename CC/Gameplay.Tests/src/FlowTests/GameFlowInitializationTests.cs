using CC.Actors.Components;
using CC.Gameplay.Flow;
using CC.Tiles;
using NUnit.Framework;
using Shouldly;
using UnityEngine;

namespace Gameplay.Tests.FlowTests {
    [TestFixture]
    public class GameFlowInitializationTests {
        private GameFlow gameFlow;
        private Actor actor;

        [SetUp]
        public void Setup() {
            gameFlow = new GameFlow();
            actor = new Actor(Vector2.zero);
        }

        [Test]
        public void Does_Add_Actors() {
            gameFlow.AddActor(actor);

            gameFlow.Actors.ShouldContain(actor);
        }

        // [Test]
        // public void Does_Add_Actors_To_Location() {
        //     gameFlow.AddActor(actor);
        //
        //     gameFlow.Board.TileFromPosition(actor.Position).Occupants.ShouldContain(actor);
        // }
        
        [Test]
        public void Locator_Does_Initialize() {
            Locator.Nodes.ShouldBe(gameFlow.Board.Nodes);
        }
        
        // TODO test ctorp for gameflow
    }
}