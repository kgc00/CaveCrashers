using CC.Components.Collectable;
using CC.Components.Inventory;
using CC.Components.Location;
using CC.Components.Tool;

namespace CC.Items.Base {
    // TODO - maybe move IUsable to implementations... all item (treasure) may not be usable
    public abstract class Item : ICollectable, IUsable {
        protected Item() {
            
        }
        
        protected Item(IInventory inventory) {
            Inventory = inventory;
        }
        
        public abstract string Name { get; set; }
        public abstract string ImagePath { get; set; }
        public IInventory Inventory { get; set; }
        public abstract void Collect();
        public abstract void Discard();

        public abstract void Use(IManipulator user, ILocation source, ILocation target);
    }
}