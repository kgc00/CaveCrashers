using System;
using CC.Tiles.Components;
using CC.Tiles.Helpers;
using UnityEngine;

namespace CC.Tiles.Entities{
    public class Tile {
        public Vector2 Position { get; private set; }
        public string ImagePath { get; private set; }
        public TileFSM StateMachine { get; set; }
        public Type StartingStateType { get; private set; }
        public Tile(TileModel model) {
            Position = model.Position;
            StartingStateType = TypeEnforcer.ExploredStateTypeEnforcer(model.StartingStateType);
            StateMachine = new TileFSM(StartingStateType);
        }
    }
}