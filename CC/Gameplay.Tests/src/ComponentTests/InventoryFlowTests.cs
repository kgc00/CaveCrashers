using System.Collections.Generic;
using CC.Actors.Components;
using CC.Components.Collectable;
using CC.Gameplay.Flow;
using CC.Items;
using NUnit.Framework;
using Shouldly;

namespace Gameplay.Tests.ComponentTests {
    [TestFixture]
    public class InventoryFlowTests {
        private GameFlow gameFlow;
        private Actor actor;

        [SetUp]
        public void Setup() {
            gameFlow = new GameFlow();
        }


        public static IEnumerable<TestCaseData> ItemSource {
            get {
                yield return new TestCaseData(new List<ICollectable>());
                yield return new TestCaseData(new List<ICollectable> {new Rope()});
                yield return new TestCaseData(new List<ICollectable> {new Rope(), new Shovel()});
                yield return new TestCaseData(new List<ICollectable> {new Rope(), new Shovel(), new Treasure()});
            }
        }

        [TestCaseSource(nameof(ItemSource))]
        public void Does_Obtain_Items(List<ICollectable> items) {
            actor = new Actor();
            gameFlow.Actors.Add(actor);

            foreach (var item in items) 
                gameFlow.Collect(actor.InventoryComponent, item);
            
            actor.InventoryComponent.Pickups.ShouldBe(items);
        }
        
        
        [TestCaseSource(nameof(ItemSource))]
        public void Does_Not_Obtain_Items_Twice(List<ICollectable> items) {
            actor = new Actor();
            gameFlow.Actors.Add(actor);

            foreach (var item in items) 
                gameFlow.Collect(actor.InventoryComponent, item);
            
            foreach (var item in items) 
                gameFlow.Collect(actor.InventoryComponent, item);
            
            actor.InventoryComponent.Pickups.ShouldBe(items);
        }
    }
}