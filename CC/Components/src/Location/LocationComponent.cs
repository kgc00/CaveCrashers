using System.Collections.Generic;
using CC.Components.Movement;
using CC.Components.Tool;
using UnityEngine;

namespace CC.Components.Location {
    public class LocationComponent : ILocation {
        public void Enter(IMovable movable) { }
        public void Exit(IMovable movable) { }
        public IOccupiable Location { get; }
        public void HandleItemUsage(IUsable tool) {
            
        }

        public LocationComponent(IOccupiable location) {
            Location = location;
        }
    }
}