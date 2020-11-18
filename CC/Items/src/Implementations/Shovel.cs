using System;
using CC.Components.Inventory;
using CC.Components.Location;
using CC.Components.Tool;
using CC.Items.Base;
using CC.Tiles;

namespace CC.Items {
    public class Shovel : Item {
        public override string Name { get; set; } = "Shovel";
        public override string ImagePath { get; set; } = "";
        public override void Collect() { }
        public override void Discard() { }

        public override void Use(IManipulator user, ILocation source, ILocation target) {
            Console.WriteLine("Used Shovel");
            
            Tile sourceTile = Locator.FromPosition(source.Location.Position);
            Tile targetTile = Locator.FromPosition(target.Location.Position);
            
            sourceTile.StateMachine.HandleItemEffects(this, source, target, user);
            targetTile.StateMachine.HandleItemEffects(this, source, target, user);
        }

        public Shovel(IInventory inventory) : base(inventory) { }
        public Shovel():base(){}
    }
}