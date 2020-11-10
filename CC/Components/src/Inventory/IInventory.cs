using System.Collections.Generic;
using CC.Components.Collectable;

namespace CC.Components.Inventory {
    public interface IInventory {
        List<ICollectable> Pickups { get; set; }
        void Collect(ICollectable collectable);
        void Discard(ICollectable collectable);
    }
}