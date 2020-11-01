using UnityEngine;

namespace CC.Board.Components {
    public struct NodeModel {
        public Vector2 Position { get; private set; }
        public string ImagePath { get; private set; }

        public NodeModel(Vector2 position) {
            Position = position;
            ImagePath = "";
        }
    }
}