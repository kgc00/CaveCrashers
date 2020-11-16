﻿using FSM.StateMachines;

 namespace CC.Tiles {
    public class Corner: TileState {
        public Corner(TileFSM stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; }
    }
}