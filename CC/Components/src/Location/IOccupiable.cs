using System.Collections.Generic;
using CC.Components.Movement;
using UnityEngine;

namespace CC.Components.Location {
    public interface IOccupiable {
        Vector2 Position { get; }
        List<IMovable> Occupants { get; set; }
        LocationComponent LocationComponent { get; }
    }
}