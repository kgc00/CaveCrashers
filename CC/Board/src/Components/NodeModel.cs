using System;
using CC.Tiles.Helpers;
using UnityEngine;

namespace CC.Board.Components {
    public struct NodeModel {
        public Vector2 Position { get; private set; }
        public string ImagePath { get; private set; }
        public Type StartingStateType { get; }

        public NodeModel(Vector2 position, Type exploredStateType) {
            Position = position;
            ImagePath = "";
            StartingStateType = TypeEnforcer.ExploredStateTypeEnforcer(exploredStateType);
        }
    }
}