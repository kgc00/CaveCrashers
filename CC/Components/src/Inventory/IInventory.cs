using System.Collections.Generic;
using CC.Components.Collectable;

namespace CC.Components.Inventory {
    public interface IInventory {
        List<ICollectable> Pickups { get; set; }
    }
}