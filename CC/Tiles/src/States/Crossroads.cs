﻿using FSM.StateMachines;

 namespace CC.Tiles {
    public class Crossroads : TileState {
        public Crossroads(IFiniteStateMachine<TileState> stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; }
    }
}