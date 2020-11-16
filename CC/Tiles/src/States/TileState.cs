using System.Collections.Generic;
using CC.Components.Collectable;
using CC.Components.Location;
using CC.Components.Tool;
using FSM.StateMachines;
using FSM.States;

namespace CC.Tiles {
    public abstract class TileState : IState<TileFSM, TileState>, ITarget {
        public virtual void Enter() { }

        public virtual void Update() { }

        public virtual void LateUpdate() { }

        public virtual void FixedUpdate() { }

        public virtual void Exit() { }
        public TileFSM StateMachine { get; }
        public abstract string ImagePath { get; }

        protected TileState(TileFSM stateMachine) {
            StateMachine = stateMachine;
        }

        public virtual void HandleItemEffects(IUsable item, ILocation source, ILocation target, IManipulator user) { }

        public virtual void HandleCollectableAdded(ICollectable collectable, List<ICollectable> collectables) { }

        public virtual void HandleCollectableRemoved(ICollectable collectable, List<ICollectable> collectables) { }
    }
}