using System;
using CC.Board.Components;
using CC.Tiles;

namespace CC.Board {
    public static class Factory {
        public const int DefaultSize = 9;
        public static BoardModel DefaultConfiguration() {
            var size = DefaultSize;
            
            // in order for the middle hallways to be centered, the size should be some odd number
            var states = new Type[size, size];
            for (int i = 0; i < states.GetLength(0); i++) {
                for (int j = 0; j < states.GetLength(1); j++) {
                    states[i, j] = typeof(Unexplored);
                }
            }


            for (int i = size / 4; i < states.GetLength(0) - size / 4; i++) {
                for (int j = size / 4; j < states.GetLength(1) - size / 4; j++) {
                    if (i != (size / 2) && j != (size / 2)) continue;
                    states[i, j] = typeof(Hallway);
                }
            }

            BoardModel model = new BoardModel(size, states);
            return model;
        }
    }
}