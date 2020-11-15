using System;
using CC.Components.Inventory;
using CC.Components.Location;
using CC.Components.Tool;
using CC.Items.Base;

namespace CC.Items {
    public class Treasure : Item {
        public override string Name { get; set; } = "Treasure";
        public override string ImagePath { get; set; } = "";
        public override void Collect() { }
        public override void Discard() { }

        public override void Use(IManipulator user, ILocation source, ILocation target) {
            Console.WriteLine("Used Treasure");
        }

        public Treasure(IInventory inventory) : base(inventory) { }
        public Treasure():base(){}
    }
}