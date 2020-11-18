using UnityEngine;

namespace CC.Components.Location.Model {
    public static class DirectionsExtensions {
        public static Directions GetDirection (this ILocation source, ILocation target) {
            if (source.Location.Position.y < target.Location.Position.y)
                return Directions.North;
            if (source.Location.Position.x < target.Location.Position.x)
                return Directions.East;
            if (source.Location.Position.y > target.Location.Position.y)
                return Directions.South;
            if (source.Location.Position.x > target.Location.Position.x)
                return Directions.West;
            return Directions.None;
        }

        public static Vector2 ToVector2 (this Directions d) {
            switch (d) {
                case Directions.North:
                    return new Vector2 (0, 1);
                case Directions.South:
                    return new Vector2 (0, -1);
                case Directions.West:
                    return new Vector2 (1, 0);
                case Directions.East:
                    return new Vector2 (-1, 0);
                default:
                    return new Vector2 (0, 0);
            }
        }
    }
}