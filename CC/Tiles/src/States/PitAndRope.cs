using System.Collections.Generic;
using System.Linq;
using CC.Components.Collectable;
using FSM.StateMachines;

namespace CC.Tiles {
    public class PitAndRope : TileState {
        public PitAndRope(TileFSM stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; }
        public override void HandleCollectableRemoved(ICollectable collectable, List<ICollectable> collectables) {
            if (!Identifier.IsRope(collectable)) return;
            
            if (collectables.FirstOrDefault(Identifier.IsRope) != null) return;
            
            StateMachine.ChangeState(StateMachine.States[typeof(Pit)]);
        }
    }
}