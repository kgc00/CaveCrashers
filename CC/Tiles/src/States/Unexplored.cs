﻿using System;
 using CC.Components.Location;
 using CC.Components.Location.Model;
 using CC.Components.Tool;
 using FSM.StateMachines;

 namespace CC.Tiles {
    public class Unexplored : TileState {
        public Unexplored(TileFSM stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; } = "test";
        public override void HandleItemEffects(IUsable item, ILocation source, ILocation target, IManipulator user) {
            if (Identifier.IsShovel(item)) {
                var isTarget = target.Location.Position == StateMachine.Tile.Position;

                if (isTarget) {
                    var sourceDir = target.Location.LocationComponent.GetDirection(source);
                    StateMachine.Tile.Wall.SetWallOpen(sourceDir);
 
                    StateMachine.ChangeState(StateMachine.States[StateMachine.ExploredStateType]);
                }
                else {
                    var targetDir = source.Location.LocationComponent.GetDirection(target);
                    StateMachine.Tile.Wall.SetWallOpen(targetDir);
                }
            }
        }
    }
}