using CC.Components.Inventory;

namespace CC.Components.Collectable {
    public interface ICollectable {
        string Name { get; }
        IInventory Inventory { get; set; }
        void Collect();
        void Discard();
    }
}