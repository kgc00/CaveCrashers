using CC.Actors.Components;
using CC.Gameplay.Flow;
using NUnit.Framework;

namespace Gameplay.Tests.FlowTests {
    [TestFixture]
    public class TileFlowTests {
        private GameFlow gameFlow;
        private Actor actor;

        [SetUp]
        public void Setup() {
            gameFlow = new GameFlow();
            actor = new Actor();
            gameFlow.AddActor(actor);
        }
    }
}