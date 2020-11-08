using CC.Components.Tool;
using CC.Items.Base;

namespace CC.Items {
    public class Rope : Item {
        public override string Name { get; set; } = "Rope";
        public override string ImagePath { get; set; } = "";
        public override void Collect() { }
        public override void Use(IManipulator tool) { }
    }
}