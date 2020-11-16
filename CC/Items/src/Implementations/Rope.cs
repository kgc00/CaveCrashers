using System;
using CC.Components.Inventory;
using CC.Components.Location;
using CC.Components.Tool;
using CC.Items.Base;
using CC.Tiles;

namespace CC.Items {
    public class Rope : Item {
        public override string Name { get; set; } = "Rope";
        public override string ImagePath { get; set; } = "";
        public override void Collect() { }
        public override void Discard() { }

        public override void Use(IManipulator user, ILocation source, ILocation target) {            
            Console.WriteLine("Used Rope");

            Inventory.Discard(this);
            target.Location.Inventory.Collect(this);

            Tile targetTile = Locator.FromPosition(target.Location.Position);
            
            targetTile.StateMachine.HandleItemEffects(this, source, target, user);
        }

        public Rope(IInventory inventory) : base(inventory) { }
        public Rope():base(){}
    }
}