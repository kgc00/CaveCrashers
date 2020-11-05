using System;
using CC.Tiles;

namespace CC.Board.Components {
    public class BoardModel {
        public int[,] Size;
        public Type[,] TileStartingTypes;

        public BoardModel(int[,] size, Type[,] states = null) {
            Assign(size, states);
        }

        public BoardModel(int size, Type[,] states = null) {
            Assign(new int[size, size], states);
        }

        private void Assign(int[,] size, Type[,] states = null) {
            Size = size;

            TileStartingTypes = PopulateWithUnexploredType(states, size);
        }

        private Type[,] PopulateWithUnexploredType(Type[,] states, int[,] size) {
            if (states == null) states = new Type [size.GetLength(0), size.GetLength(1)];

            for (int i = 0; i < states.GetLength(0); i++) {
                for (int j = 0; j < states.GetLength(1); j++) {
                    if (states[i, j] == null) states[i, j] = typeof(Unexplored);
                    else states[i, i] = TypeEnforcer.ExploredStateTypeEnforcer(states[i, j]);
                }
            }

            return states;
        }
    }
}