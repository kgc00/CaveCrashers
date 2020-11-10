using System;
using System.Collections.Generic;
using CC.Actors.Components;
using CC.Components.Collectable;
using CC.Components.Inventory;
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
                yield return new TestCaseData(null);
                yield return new TestCaseData(new Rope());
                yield return new TestCaseData(new Shovel());
                yield return new TestCaseData(new Treasure());
            }
        }

        [TestCaseSource(nameof(ItemSource))]
        public void Does_Obtain_Items(ICollectable item) {
            actor = new Actor();
            gameFlow.Actors.Add(actor);
            var inventoryComponent = new InventoryComponent(new List<ICollectable> {item});

            gameFlow.Collect(actor.InventoryComponent, inventoryComponent, item);
            
            actor.InventoryComponent.Pickups.ShouldContain(item);
        }
        
        [TestCaseSource(nameof(ItemSource))]
        public void Does_Not_Obtain_Items_Twice(ICollectable item) {
            actor = new Actor();
            gameFlow.Actors.Add(actor);
            var inventoryComponent = new InventoryComponent(new List<ICollectable> {item});
            var inventoryComponent2 = new InventoryComponent(new List<ICollectable> {item});

            gameFlow.Collect(actor.InventoryComponent, inventoryComponent, item);
            gameFlow.Collect(actor.InventoryComponent, inventoryComponent2, item);
            
            actor.InventoryComponent.Pickups.ShouldBeUnique();
        }
        
        public static IEnumerable<TestCaseData> ManyItemSource {
            get {
                yield return new TestCaseData(new List<ICollectable>());
                yield return new TestCaseData(new List<ICollectable> {new Rope()});
                yield return new TestCaseData(new List<ICollectable> {new Rope(), new Shovel()});
                yield return new TestCaseData(new List<ICollectable> {new Rope(), new Shovel(), new Treasure()});
            }
        }

        [TestCaseSource(nameof(ManyItemSource))]
        public void Does_Obtain_Many_Items(List<ICollectable> items) {
            actor = new Actor();
            gameFlow.Actors.Add(actor);
            var inventoryComponent = new InventoryComponent(items);

            gameFlow.CollectMany(actor.InventoryComponent, inventoryComponent, items);
            
            actor.InventoryComponent.Pickups.ShouldBe(items);
        }


        [TestCaseSource(nameof(ManyItemSource))]
        public void Does_Not_Obtain_Many_Items_Twice(List<ICollectable> items) {
            actor = new Actor();
            gameFlow.Actors.Add(actor);
            var inventoryComponent = new InventoryComponent(items);
            var inventoryComponent2 = new InventoryComponent(items);

            gameFlow.CollectMany(actor.InventoryComponent, inventoryComponent, items);
            gameFlow.CollectMany(actor.InventoryComponent, inventoryComponent2, items);
        
            actor.InventoryComponent.Pickups.ShouldBe(items);
        }
    }
}