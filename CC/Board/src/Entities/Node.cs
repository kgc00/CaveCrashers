using System;
using CC.Board.Components;
using CC.Tiles;
using CC.Tiles.Helpers;
using UnityEngine;

namespace CC.Board.Entities{
    public class Node {
        public Vector2 Position { get; private set; }
        public string ImagePath { get; private set; }
        public TileFSM StateMachine { get; set; }
        public Type StartingStateType { get; private set; }
        public Node(NodeModel model) {
            Position = model.Position;
            StartingStateType = TypeEnforcer.ExploredStateTypeEnforcer(model.StartingStateType);
            StateMachine = new TileFSM(StartingStateType);
        }
    }
    
    /*
     * tiles can either start off explored or unexplored
     * once tiles are explored:
     *     they transition to some predefined state
     *
     * from one state they can transition to any other state, except unexplored
    */    
}