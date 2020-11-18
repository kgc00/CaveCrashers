﻿using CC.Components.Location;
 using CC.Components.Tool;
 using FSM.StateMachines;

 namespace CC.Tiles {
    public class Intersection : TileState {
        public Intersection(TileFSM stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; }
        public override void HandleItemEffects(IUsable item, ILocation source, ILocation target, IManipulator user) {
            if (Identifier.IsShovel(item))
                if (source == StateMachine.Tile.LocationComponent)
                    StateMachine.ChangeState(StateMachine.States[typeof(Crossroads)]);
        }
    }
}