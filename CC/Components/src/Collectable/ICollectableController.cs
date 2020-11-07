using CC.Components.Inventory;

namespace CC.Components.Collectable {
    public interface ICollectableController {
        void Collect(IInventory inventory, ICollectable collectable);
    }
}