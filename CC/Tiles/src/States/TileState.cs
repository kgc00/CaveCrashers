using FSM.StateMachines;
using FSM.States;

namespace CC.Tiles {
    public abstract class TileState : IEntityState<TileState> {
        public virtual void Enter() { }

        public virtual void Update() { }

        public virtual void LateUpdate() { }

        public virtual void FixedUpdate() { }

        public virtual void Exit() { }
        public IFiniteStateMachine<TileState> StateMachine { get; }
        public abstract string ImagePath { get; }

        protected TileState(IFiniteStateMachine<TileState> stateMachine) {
            StateMachine = stateMachine;
        }
    }
}