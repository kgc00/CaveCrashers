﻿using FSM.StateMachines;

 namespace CC.Tiles {
    public class Corner: TileState {
        public Corner(IFiniteStateMachine<TileState> stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; }
    }
}