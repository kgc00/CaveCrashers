using System;
using System.Collections.Generic;
using CC.Components.Collectable;

namespace CC.Components.Inventory {
    public class InventoryComponent : IInventory {
        public List<ICollectable> Pickups { get; set; }
        public void Collect(ICollectable collectable) {
            if (Pickups.Contains(collectable)) return;

            Pickups.Add(collectable);
        }

        public void Discard(ICollectable collectable) {
            if (!Pickups.Contains(collectable)) return;

            Pickups.Remove(collectable);
        }

        public InventoryComponent(List<ICollectable> pickups = null) {
            Pickups = new List<ICollectable>(pickups ?? new List<ICollectable>());
        }
    }
}