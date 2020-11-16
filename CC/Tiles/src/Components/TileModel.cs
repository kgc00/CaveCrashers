using System;
using UnityEngine;

namespace CC.Tiles {
    public class TileModel {
        public Vector2 Position { get; private set; }
        public string ImagePath { get; private set; }
        public Type StartingStateType { get; }

        public Type ExploredStateType { get; }
        public TileModel(Vector2 position, Type startingStateType = null, Type exploredStateType = null) {
            Position = position;
            ImagePath = "";
            StartingStateType = TypeEnforcer.TileStateEnforcer(startingStateType);
            ExploredStateType = TypeEnforcer.TileStateEnforcer(exploredStateType);
        }
    }
}