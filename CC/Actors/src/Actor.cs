using CC.Components.Movement;
using UnityEngine;

namespace CC.Actors {
    public class Actor : IMovable {
        public Vector2 Position { get; set; }

        // private bool IsOutOfBounds(Vector2 dir) {
        //     if (dir.x + Position.x > bounds.GetLength(0)) return true;
        //     if (dir.y + Position.y > bounds.GetLength(1)) return true;
        //     return false;
        // }
    }
}