﻿using FSM.StateMachines;

 namespace CC.Tiles {
    public class Hallway : TileState {
        public Hallway(IFiniteStateMachine<TileState> stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; }
    }
}