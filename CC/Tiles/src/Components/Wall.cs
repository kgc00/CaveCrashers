using System.Collections.Generic;
using CC.Components.Location.Model;

namespace CC.Tiles {
    public class Wall {
        private readonly Dictionary<Directions, bool> walls = new Dictionary<Directions, bool> {
            {Directions.North, false},
            {Directions.West, false},
            {Directions.South, false},
            {Directions.East, false},
            {Directions.None, false},
        };

        public void SetWallOpen(Directions dir) => walls[dir] = true;
        public void SetWallClosed(Directions dir) => walls[dir] = false;
        public bool GetWall(Directions dir) => walls[dir];
        public Dictionary<Directions, bool> GetWalls() => walls;
    }
}