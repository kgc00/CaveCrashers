using System.Collections.Generic;
using CC.Components.Collectable;
using CC.Components.Inventory;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Components.Tests.Inventory {
    public class InventoryTests {
        private Mock<ICollectable> collectable;
        private IInventory inventory;
        private CollectableComponent collectableComponent;

        [SetUp]
        public void Setup() {
            collectable = new Mock<ICollectable>();
            inventory = Mock.Of<IInventory>(_ => _.Pickups == new List<ICollectable>() );
            collectableComponent = new CollectableComponent(inventory);
        }

        [Test]
        public void DoesInitialize() {
            inventory.Pickups.Count.ShouldBe(0);
        }
        
        [Test]
        public void Does_Add_Collectable() {
            collectableComponent.Collect(collectable.Object);
            
            inventory.Pickups.ShouldContain(collectable.Object);
        }

        [Test] public void Does_Call_Collect() {
            collectableComponent.Collect(collectable.Object);
            
            collectable.Verify(_ => _.Collect(), Times.Once);
        }
    }
}