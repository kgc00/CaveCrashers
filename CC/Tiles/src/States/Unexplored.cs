﻿using System;
 using CC.Components.Location;
 using CC.Components.Tool;
 using FSM.StateMachines;

 namespace CC.Tiles {
    public class Unexplored : TileState {
        public Unexplored(TileFSM stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; } = "test";
        public override void HandleItemEffects(IUsable item, ILocation source, ILocation target, IManipulator user) {
            if (Identifier.IsShovel(item)) {
                if (target == StateMachine.Tile.LocationComponent) {
                    Console.WriteLine("Changing state");
                    StateMachine.ChangeState(StateMachine.States[StateMachine.ExploredStateType]);
                    Console.WriteLine(StateMachine.CurrentState);
                }
            }
        }
    }
}