using CC.Components.Tool;
using CC.Items.Base;

namespace CC.Items {
    public class Treasure : Item {
        public override string Name { get; set; } = "Treasure";
        public override string ImagePath { get; set; } = "";
        public override void Collect() { }
        public override void Use(IManipulator tool) { }
    }
}