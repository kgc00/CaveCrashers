using System;
using System.Collections.Generic;
using CC.Components.Collectable;
using CC.Components.Location;
using CC.Components.Tool;
using FSM.StateMachines;

namespace CC.Tiles {
    public class TileFSM : IFiniteStateMachine<TileState>, ITarget {
        public Type ExploredStateType { get; private set; }
        public Tile Tile { get; private set; }
        public Dictionary<Type, TileState> States { get; private set; }
        public TileState CurrentState { get; private set; }
        
        public TileFSM(Tile tile, Type startingType = null, Type exploredType = null) {
            InitializeStates();
            
            ExploredStateType = exploredType == null
                ? Randomizer.ExploredTileType()
                : TypeEnforcer.TileStateEnforcer(startingType);
            ChangeState(States[startingType == null ? typeof(Unexplored) : TypeEnforcer.TileStateEnforcer(startingType)]);

            tile.StartingStateType = CurrentState.GetType();
            tile.ExploredStateType = ExploredStateType;
            
            tile.Inventory.collectableAdded += HandleCollectableAdded;
            tile.Inventory.collectableRemoved += HandleCollectableRemoved;

            Tile = tile;
        }

        private void HandleCollectableAdded(ICollectable collectable, List<ICollectable> pickups) {
            CurrentState.HandleCollectableAdded(collectable, pickups);
        }

        private void HandleCollectableRemoved(ICollectable obj, List<ICollectable> pickups) {
            CurrentState.HandleCollectableRemoved(obj, pickups);
        }

        public void InitializeStates() {
            States = new Dictionary<Type, TileState> {
                { typeof(Unexplored), new Unexplored(this) },
                { typeof(CaveIn), new CaveIn(this) },
                { typeof(Corner), new Corner(this) },
                { typeof(Crossroads), new Crossroads(this) },
                { typeof(Hallway), new Hallway(this) },
                { typeof(Pit), new Pit(this) },
                { typeof(PitAndRope), new PitAndRope(this) },
                { typeof(Intersection), new Intersection(this) }
            };
        }


        public void ChangeState(TileState newState) {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState?.Enter();
        }

        public void HandleItemEffects(IUsable item, ILocation source, ILocation target, IManipulator user) {
            CurrentState.HandleItemEffects(item, source, target, user);
        }
    }
}