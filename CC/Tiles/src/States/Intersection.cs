﻿using FSM.StateMachines;

 namespace CC.Tiles {
    public class Intersection : TileState {
        public Intersection(IFiniteStateMachine<TileState> stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; }
    }
}