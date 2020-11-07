using System;
using CC.Components.Inventory;

namespace CC.Components.Collectable {
    public class CollectorComponent {
        public IInventory Inventory { get; private set; }
        
        public CollectorComponent(IInventory inventory) {
            Inventory = inventory;
        }

        public void Collect(ICollectable collectable) {
            collectable.Collect();
            Inventory.Pickups.Add(collectable);
        }
    }
}