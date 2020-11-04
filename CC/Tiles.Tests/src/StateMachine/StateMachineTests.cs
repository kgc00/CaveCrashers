using System;
using CC.Tiles;
using NUnit.Framework;
using Shouldly;

namespace Tiles.Tests.StateMachine {
    public class StateMachineTests {
        [Test]
        public void Can_Initialize() {
            var tfsm = new TileFSM();

            Should.NotThrow(() => tfsm.InitializeStates());
        }

        [TestCase(typeof(Corner)),
         TestCase(typeof(Hallway)),
         TestCase(typeof(Unexplored))]
        public void Initialize_To_Proper_State(Type startingType) {
            var tfsm = new TileFSM(startingType);
            tfsm.InitializeStates();

            tfsm.CurrentState.GetType().ShouldBe(startingType);
        }

        [Test]
        public void Throws_For_Null_Case() {
            var tfsm = new TileFSM(null);
            tfsm.InitializeStates();

            tfsm.CurrentState.GetType().ShouldBe(typeof(Unexplored));
        }

        [TestCase(typeof(string)),
         TestCase(typeof(TileFSM))]
        public void Handles_Invalid_Input(Type startingType) {
            Should.Throw<ArgumentException>(() => new TileFSM(startingType));
        }

        [Test]
        public void Can_Change_State() {
            var tfsm = new TileFSM();
            tfsm.InitializeStates();

            tfsm.CurrentState.GetType().ShouldBe(typeof(Unexplored));
        }
    }
}