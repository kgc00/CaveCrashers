using CC.Board.Components;
using CC.Board.Entities;
using CC.Tiles.Entities;
using UnityEngine;

namespace CC.Board.Systems {
    public class BoardCreator {
        public BoardModel Model { get; private set; }

        public BoardCreator(BoardModel model) {
            Model = model;
        }

        public Entities.Board Create() {
            var nodes = NodesFromModel();
            Entities.Board board = new Entities.Board(nodes);
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