using CC.Components.Collectable;

namespace CC.Items.Base {
    public abstract class Item : ICollectable {
        public abstract string Name { get; set; }
        public abstract string ImagePath { get; set; }
        public abstract void Collect();
    }
}