using System;
using CC.Tiles;

namespace CC.Board.Components {
    public class BoardModel {
        public int[,] Size;
        public Type[,] TileTypes;

        public BoardModel(int[,] size, Type[,] states = null) {
            Assign(size, states);
        }

        public BoardModel(int size, Type[,] states = null) {
            Assign(new int[size, size], states);
        }

        private void Assign(int[,] size, Type[,] states = null) {
            Size = size;

            if (states == null) {
                TileTypes = DefaultToUnexploredType(size);
            } else {
                TileTypes = !IsPopulated(states)
                    ? PopulateWithUnexploredType(states)
                    : states;
            }
        }

        private bool IsPopulated(Type[,] states) {
            if (states == null) return false;

            for (int i = 0; i < states.GetLength(0); i++) {
                for (int j = 0; j < states.GetLength(1); j++) {
                    if (states[i, j] == null) states[i, j] = typeof(Unexplored);
                }
            }

            return true;
        }

        private Type[,] PopulateWithUnexploredType(Type[,] states) {
            for (int i = 0; i < states.GetLength(0); i++) {
                for (int j = 0; j < states.GetLength(1); j++) {
                    if (states[i, j] == null || states[i, j].BaseType != typeof(TileState)) states[i, j] = typeof(Unexplored);
                }
            }

            return states;
        }

        private Type[,] DefaultToUnexploredType(int[,] size) {
            var states = new Type [size.GetLength(0), size.GetLength(1)];
            PopulateWithUnexploredType(states);

            return states;
        }
    }
}