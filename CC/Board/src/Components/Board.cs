using CC.Tiles;
using UnityEngine;

namespace CC.Board.Components {
    public class Board {
        public Tile[,] Nodes { get; private set; }

        public Board(Tile[,] nodes) {
            Nodes = nodes;
        }

        public Tile TileFromPosition(Vector2 pos) => Nodes[(int) pos.x, (int) pos.y];
    }
}