using System;
using CC.Tiles;
using NUnit.Framework;
using Shouldly;
using UnityEngine;

namespace Tiles.Tests.StateMachine {
    public class StateMachineTests {
        private Tile tile;

        [SetUp]
        public void Setup() {
            tile = new Tile(new TileModel(Vector2.zero));
        }
        

        [Test]
        public void Can_Initialize() {
            var tfsm = new TileFSM(tile);

            Should.NotThrow(() => tfsm.InitializeStates());
        }

        [TestCase(typeof(Corner)),
         TestCase(typeof(Hallway)),
         TestCase(typeof(Unexplored))]
        public void Initialize_To_Proper_State(Type startingType) {
            var tfsm = new TileFSM(tile, startingType: startingType);
            tfsm.InitializeStates();

            tfsm.CurrentState.GetType().ShouldBe(startingType);
        }

        [Test]
        public void Throws_For_Null_Case() {
            var tfsm = new TileFSM(tile, startingType: null);
            tfsm.InitializeStates();

            tfsm.CurrentState.GetType().ShouldBe(typeof(Unexplored));
        }

        [TestCase(typeof(string)),
         TestCase(typeof(TileFSM))]
        public void Handles_Invalid_Input(Type startingType) {
            Should.Throw<ArgumentException>(() => new TileFSM(tile, startingType: startingType));
        }

        [Test]
        public void Can_Change_State() {
            var tfsm = new TileFSM(tile);
            tfsm.InitializeStates();

            tfsm.CurrentState.GetType().ShouldBe(typeof(Unexplored));
        }
    }
}