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
        public List<IMovable> Occupants { get; private set; }
        public void AddOccupant(IMovable occupant) {
            if (Occupants.Contains(occupant)) return;
            
            Occupants.Add(occupant);
            LocationComponent.Enter(occupant);
        }

        public void RemoveOccupant(IMovable occupant) {
            if (!Occupants.Contains(occupant)) return;
            
            Occupants.Remove(occupant);
            LocationComponent.Exit(occupant);
        }

        public LocationComponent LocationComponent { get; }
        public string ImagePath { get; private set; }
        public InventoryComponent Inventory { get; set; }
        public TileFSM StateMachine { get; set; }
        public Type StartingStateType { get; private set; }
        public Type ExploredStateType { get; private set; }

        public Tile(TileModel model) {
            Position = model.Position;
            Occupants = new List<IMovable>();
            LocationComponent = new LocationComponent(this);
            StartingStateType = TypeEnforcer.TileStateEnforcer(model.StartingStateType);
            StateMachine = new TileFSM(StartingStateType, ExploredStateType);
        }
        
        public Tile(TileModel model, List<IMovable> occupants) {
            Position = model.Position;
            Occupants = new List<IMovable>(occupants);
            LocationComponent = new LocationComponent(this);
            StartingStateType = TypeEnforcer.TileStateEnforcer(model.StartingStateType);
            StateMachine = new TileFSM(StartingStateType, ExploredStateType);
        }
    }
}