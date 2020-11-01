using System;
using CC.Board.Components;
using CC.Tiles;
using UnityEngine;

namespace CC.Board.Entities{
    public class Node {
        public Vector2 Position { get; private set; }
        public string ImagePath { get; private set; }
        public TileFSM StateMachine { get; set; }
        public Type StartingType { get; private set; }
        public Node(NodeModel model) {
            Position = model.Position;
            StartingType = model.StartingType;
            StateMachine = new TileFSM();
        }
    }
}