using System;
using System.Collections.Generic;
using CC.Components.Collectable;

namespace CC.Components.Inventory {
    public class InventoryComponent : IInventory {
        public List<ICollectable> Pickups { get; set; }
        public Action<ICollectable, List<ICollectable>> collectableAdded = delegate {  };
        public Action<ICollectable, List<ICollectable>> collectableRemoved = delegate {  };
        public void Collect(ICollectable collectable) {
            if (Pickups.Contains(collectable) || collectable == null) return;

            Pickups.Add(collectable);
            collectable.Inventory = this;
            collectableAdded(collectable, Pickups);
        }

        public void Discard(ICollectable collectable) {
            if (!Pickups.Contains(collectable) || collectable == null) return;

            Pickups.Remove(collectable);
            collectable.Inventory = null;
            collectableRemoved(collectable, Pickups);
        }

        public InventoryComponent(List<ICollectable> pickups = null) {
            Pickups = new List<ICollectable>(pickups ?? new List<ICollectable>());
        }
    }
}