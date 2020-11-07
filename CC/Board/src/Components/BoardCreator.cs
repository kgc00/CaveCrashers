using CC.Tiles;
using UnityEngine;

namespace CC.Board.Components {
    public class BoardCreator {
        public BoardModel Model { get; private set; }

        public BoardCreator(BoardModel model) {
            Model = model;
        }

        public Components.Board Create() {
            var nodes = NodesFromModel();
            Components.Board board = new Components.Board(nodes);
            return board;
        }

        private Tile[,] NodesFromModel() {
            var nodes = new Tile[Model.Size.GetLength(0), Model.Size.GetLength(1)];
            for (int i = 0; i < Model.Size.GetLength(0); i++) {
                for (int j = 0; j < Model.Size.GetLength(1); j++) {
                    nodes[i, j] = new Tile(TileCreator.TileFromModel(new Vector2(i, j), Model.TileStartingTypes[i,j]));
                }
            }

            return nodes;
        }
    }
}