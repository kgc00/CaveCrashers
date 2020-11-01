﻿using FSM.StateMachines;

 namespace CC.Tiles {
    public class Unexplored : TileState {
        public Unexplored(IFiniteStateMachine<TileState> stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; } = "test";
    }
}