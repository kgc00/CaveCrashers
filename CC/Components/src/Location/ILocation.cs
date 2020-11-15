using System.Collections.Generic;
using CC.Components.Movement;
using CC.Components.Tool;

namespace CC.Components.Location {
    public interface ILocation {
        void Enter(IMovable movable);
        void Exit(IMovable movable);
        IOccupiable Location { get; }
        void HandleItemUsage(IUsable tool);
    }
}