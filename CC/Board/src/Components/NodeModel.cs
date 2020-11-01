using System;
using CC.Tiles;
using JetBrains.Annotations;
using UnityEngine;

namespace CC.Board.Components {
    public struct NodeModel {
        public Vector2 Position { get; private set; }
        public string ImagePath { get; private set; }
        public Type StartingType { get; private set; }

        public NodeModel(Vector2 position, Type startingType) {
            Position = position;
            ImagePath = "";
            StartingType = startingType.BaseType == typeof(TileState)
                ? startingType
                : throw new Exception("Unsupported type");
        }
    }
}