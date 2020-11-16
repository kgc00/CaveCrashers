using CC.Components.Location;
using CC.Components.Tool;
 using FSM.StateMachines;

 namespace CC.Tiles {
    public class Pit : TileState {
        public Pit(TileFSM stateMachine) : base(stateMachine) { }
        public override string ImagePath { get; }
        public override void HandleItemEffects(IUsable item, ILocation source, ILocation target, IManipulator user) {
            if (Identifier.IsRope(item)) 
                StateMachine.ChangeState(StateMachine.States[typeof(PitAndRope)]);
        }
    }
}