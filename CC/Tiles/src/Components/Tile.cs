using System;
using System.Collections.Generic;
using CC.Components.Collectable;
using CC.Components.Inventory;
using CC.Components.Location;
using CC.Components.Movement;
using UnityEngine;

namespace CC.Tiles{
    public class Tile : IOccupiable {
        public Vector2 Position { get; private set; }
        public List<IMovable> Occupants { get; set; }
        public LocationComponent LocationComponent { get; }
        public string ImagePath { get; private set; }
        public InventoryComponent Inventory { get; set; }
        public TileFSM StateMachine { get; set; }
        public Type StartingStateType { get; private set; }

        public Tile(TileModel model) {
            Position = model.Position;
            LocationComponent = new LocationComponent(this);
            StartingStateType = TypeEnforcer.ExploredStateTypeEnforcer(model.StartingStateType);
            StateMachine = new TileFSM(StartingStateType);
        }
    }
}