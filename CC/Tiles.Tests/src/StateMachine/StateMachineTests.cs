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

        [Test]
        public void Initialize_To_Proper_State() {
            var tfsm = new TileFSM();
            tfsm.InitializeStates();
            
            tfsm.CurrentState.GetType().ShouldBe(typeof(Unexplored));
        } 
    }
}