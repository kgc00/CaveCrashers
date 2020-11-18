using CC.Components.Location;
using UnityEngine;

namespace CC.Tiles {
    public static class Locator {
        public static Tile[,] Nodes;

        public static void AssignNodes(Tile[,] board) => Nodes = board;
        public static Tile FromPosition(Vector2 position) {
            return Nodes[(int) position.x, (int) position.y];
        }
    }
}