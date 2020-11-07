using System;
using System.Collections.Generic;
using CC.Components.Collectable;

namespace CC.Components.Inventory {
    public class InventoryComponent : IInventory {
        public List<ICollectable> Pickups { get; set; }
        public InventoryComponent(List<ICollectable> pickups = null) {
            Pickups = pickups ?? new List<ICollectable>();
        }
    }
}