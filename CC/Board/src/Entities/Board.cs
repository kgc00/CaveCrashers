namespace CC.Board.Entities {
    public class Board {
        public Node[,] Nodes { get; private set; }

        public Board(Node[,] nodes) {
            Nodes = nodes;
        }
    }
}