using System;
using UnityEngine;

namespace CC.Tiles {
    public static class TileCreator {
        public static TileModel TileFromModel(Vector2 position, Type startingType) {
            return new TileModel(position, startingType);
        }
    }
}