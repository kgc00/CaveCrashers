using System;
using System.Collections.Generic;
using FSM.StateMachines;
using FSM.States;

namespace CC.Tiles {
    public class TileFSM : IFiniteStateMachine<TileState> {
        public TileFSM(Type startingType = null) {
            InitializeStates();
            ChangeState(States[startingType == null ? typeof(Unexplored) : TypeEnforcer.ExploredStateTypeEnforcer(startingType)]);
        }
        
        public void InitializeStates() {
            States = new Dictionary<Type, IEntityState<TileState>> {
                { typeof(Unexplored), new Unexplored(this) },
                { typeof(CaveIn), new CaveIn(this) },
                { typeof(Corner), new Corner(this) },
                { typeof(Crossroads), new Crossroads(this) },
                { typeof(Hallway), new Hallway(this) },
                { typeof(Pit), new Pit(this) },
                { typeof(Intersection), new Intersection(this) }
            };
        }

        public void ChangeState(IEntityState<TileState> newState) {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState?.Enter();
        }

        public Dictionary<Type, IEntityState<TileState>> States { get; private set; }
        public IEntityState<TileState> CurrentState { get; private set; }
    }
}