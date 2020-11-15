using System;
using CC.Components.Inventory;

namespace CC.Components.Collectable {
    public class CollectorComponent {
        public IInventory Inventory { get; private set; }
        
        public CollectorComponent(IInventory inventory) {
            Inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
        }

        public void Collect(ICollectable collectable) {
            Inventory.Pickups.Add(collectable);
            collectable.Inventory = Inventory;
            collectable.Collect();
        }
    }
}