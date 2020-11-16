﻿using FSM.StateMachines;

 namespace CC.Tiles {
    public class Crossroads : TileState {
        public Crossroads(TileFSM stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; }
    }
}