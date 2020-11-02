using System;
using CC.Board.Components;
using CC.Tiles;

namespace CC.Board.Helpers {
    public static class Factory {
        public static BoardModel DefaultConfiguration() {
            var size = 10;
            var states = new Type[size, size];
            for (int i = 0; i < states.GetLength(0); i++) {
                for (int j = 0; j < states.GetLength(1); j++) {
                    states[i, j] = typeof(Unexplored);
                }
            }
            
            
            for (int i = size / 3; i < states.GetLength(0) - size / 3; i++) {
                for (int j = size / 3; j < states.GetLength(1) - size / 3; j++) {
                    states[i, j] = typeof(Hallway);
                }
            }
            
            BoardModel model = new BoardModel(size, states);
            return model;
        }
    }
}