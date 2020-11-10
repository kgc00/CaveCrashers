using CC.Components.Inventory;

namespace CC.Components.Collectable {
    public interface ICollectableController {
        void Collect(IInventory collector, IInventory source, ICollectable collectable);
    }
}