using System;
using CC.Tiles.Components;
using UnityEngine;

namespace CC.Board.Systems {
    public static class TileCreator {
        public static TileModel TileFromModel(Vector2 position, Type startingType) {
            return new TileModel(position, startingType);
        }
    }
}