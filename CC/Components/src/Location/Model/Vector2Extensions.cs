using System;
using UnityEngine;

namespace CC.Components.Location.Model {
    public static class Vector2Extensions {
        public static Directions ToDirections(this Vector2 v) {
            if (v == Vector2.up)
                return Directions.North;
            if (v == Vector2.down)
                return Directions.South;
            if (v == Vector2.right)
                return Directions.East;
            if (v == Vector2.left)
                return Directions.West;
            throw new ArgumentException("Must be a v2  of 0's or 1's.  e.g. (0,1) - north ");
        }
    }
}