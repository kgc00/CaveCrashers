using System;
using UnityEngine;

namespace CC.Tiles {
    public class TileModel {
        public Vector2 Position { get; private set; }
        public string ImagePath { get; private set; }
        public Type StartingStateType { get; }

        public TileModel(Vector2 position, Type exploredStateType) {
            Position = position;
            ImagePath = "";
            StartingStateType = TypeEnforcer.ExploredStateTypeEnforcer(exploredStateType);
        }
    }
}