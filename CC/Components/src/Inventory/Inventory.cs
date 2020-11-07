using System.Collections.Generic;
using CC.Components.Collectable;

namespace CC.Components.Inventory {
    public class Inventory : IInventory {
        public List<ICollectable> Pickups { get; set; }
    }
}