using CC.Components.Collectable;
using CC.Components.Tool;

namespace CC.Items.Base {
    // TODO - maybe move IUsable to implementations... all item (treasure) may not be usable
    public abstract class Item : ICollectable, IUsable {
        public abstract string Name { get; set; }
        public abstract string ImagePath { get; set; }
        public abstract void Collect();
        public abstract void Use(IManipulator tool);
    }
}