﻿using FSM.StateMachines;

 namespace CC.Tiles {
    public class CaveIn : TileState {
        public CaveIn(TileFSM stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; }
    }
}