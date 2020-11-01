namespace CC.Board.Components {
    public class BoardModel {
        public int[,] Size;

        public BoardModel(int[,] size) {
            Size = size;
        }

        public BoardModel(int size) {
            Size = new int[size,size];
        }
    }
}