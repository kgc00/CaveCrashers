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
        private CollectorComponent collectorComponent;

        [SetUp]
        public void Setup() {
            collectable = new Mock<ICollectable>();
            inventory = Mock.Of<IInventory>(_ => _.Pickups == new List<ICollectable>());
            collectorComponent = new CollectorComponent(inventory);
        }

        [Test]
        public void Does_Add_Collectable() {
            collectorComponent.Collect(collectable.Object);

            inventory.Pickups.ShouldContain(collectable.Object);
        }

        [Test]
        public void Does_Call_Collect() {
            collectorComponent.Collect(collectable.Object);

            collectable.Verify(_ => _.Collect(), Times.Once);
        }
    }


    public class InventoryInitializationTests {
        private Mock<ICollectable> collectable = new Mock<ICollectable>();
        private CollectorComponent collectorComponent;

        public static IEnumerable<TestCaseData> InventorySource {
            get {
                yield return new TestCaseData(Mock.Of<IInventory>(_ => _.Pickups == new List<ICollectable>()));
            }
        }

        [TestCaseSource(nameof(InventorySource))]
        public void DoesInitialize(IInventory inventory) {
            collectorComponent = new CollectorComponent(inventory);
            collectorComponent.Inventory.Pickups.Count.ShouldBe(0);
        }
    }
}