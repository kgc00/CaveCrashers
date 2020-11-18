using System;
using System.Collections.Generic;
using CC.Components.Collectable;
using CC.Components.Inventory;
using CC.Components.Location;
using CC.Components.Movement;
using CC.Components.Tool;
using UnityEngine;

namespace CC.Tiles{
    public class Tile : IOccupiable {
        public Vector2 Position { get; private set; }
        private readonly Wall wall;

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
        public Type StartingStateType { get; set; }
        public Type ExploredStateType { get; set; }

        public Wall Wall => wall;

        public Tile(TileModel model) {
            wall = new Wall();
            Position = model.Position;
            Occupants = new List<IMovable>();
            LocationComponent = new LocationComponent(this);
            Inventory = new InventoryComponent();
            StartingStateType = TypeEnforcer.TileStateEnforcer(model.StartingStateType);
            StateMachine = new TileFSM(this, startingType: StartingStateType, exploredType: ExploredStateType);
        }
        
        public Tile(TileModel model, List<IMovable> occupants, List<ICollectable> pickups) {
            wall = new Wall();
            Position = model.Position;
            Occupants = new List<IMovable>(occupants);
            LocationComponent = new LocationComponent(this);
            Inventory = new InventoryComponent(pickups);
            StartingStateType = TypeEnforcer.TileStateEnforcer(model.StartingStateType);
            StateMachine = new TileFSM(this, startingType: StartingStateType, exploredType: ExploredStateType);
        }
    }
}