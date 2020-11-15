using CC.Components.Inventory;

namespace CC.Components.Collectable {
    public interface ICollectable {
        IInventory Inventory { get; set; }
        void Collect();
        void Discard();
    }
}