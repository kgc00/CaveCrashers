using CC.Items.Base;

namespace CC.Items {
    public class Shovel : Item {
        public override string Name { get; set; } = "Shovel";
        public override string ImagePath { get; set; } = "";
        public override void Collect() { }
    }
}