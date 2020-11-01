﻿using FSM.StateMachines;

 namespace CC.Tiles {
    public class Pit : TileState {
        public Pit(IFiniteStateMachine<TileState> stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; }
    }
}