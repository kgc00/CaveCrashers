using CC.Tiles;

namespace CC.Board.Components {
    public class Board {
        public Tile[,] Nodes { get; private set; }

        public Board(Tile[,] nodes) {
            Nodes = nodes;
        }
    }
}