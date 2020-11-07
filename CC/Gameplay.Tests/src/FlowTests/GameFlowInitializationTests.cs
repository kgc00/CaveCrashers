using CC.Actors.Components;
using CC.Gameplay.Flow;
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
            gameFlow.Actors.Add(actor);

            gameFlow.Actors.ShouldContain(actor);
        }

        // TODO test ctorp for gameflow
    }
}