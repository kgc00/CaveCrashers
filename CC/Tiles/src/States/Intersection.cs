﻿using FSM.StateMachines;

 namespace CC.Tiles {
    public class Intersection : TileState {
        public Intersection(TileFSM stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; }
    }
}