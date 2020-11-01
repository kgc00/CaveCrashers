using CC.Board.Components;
using UnityEngine;

namespace CC.Board.Entities{
    public class Node {
        public Vector2 Position { get; private set; }
        public string ImagePath { get; private set; }

        public Node(NodeModel model) {
            this.Position = model.Position;
        }
    }
}