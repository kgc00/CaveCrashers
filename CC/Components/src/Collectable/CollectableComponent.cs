using System;
using CC.Components.Inventory;

namespace CC.Components.Collectable {
    public class CollectableComponent {
        public IInventory Inventory { get; private set; }
        
        public CollectableComponent(IInventory inventory) {
            Inventory = inventory;
        }

        public void Collect(ICollectable collectable) {
            collectable.Collect();
            Inventory.Pickups.Add(collectable);
        }
    }
}