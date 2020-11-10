using System;
using CC.Components.Location;
using CC.Components.Tool;
using CC.Items.Base;

namespace CC.Items {
    public class Shovel : Item {
        public override string Name { get; set; } = "Shovel";
        public override string ImagePath { get; set; } = "";
        public override void Collect() { }

        public override void Use(IManipulator user, ILocation location, ITarget target) {
            Console.WriteLine("Used Shovel");
        }
    }
}