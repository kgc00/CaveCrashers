using System.Collections.Generic;
using CC.Components.Movement;

namespace CC.Components.Location {
    public interface ILocation {
        void Enter(IMovable movable);
        void Exit(IMovable movable);
        IOccupiable Location { get; }
    }
}