using System;

namespace CC.Tiles {
    public static class TypeEnforcer {
        public static Type TileStateEnforcer(Type tileState) {
            if (tileState == null) return null;
            return tileState.BaseType == typeof(TileState)
                ? tileState
                : throw new ArgumentException(
                    $"Unsupported type.  Input {tileState} must be typeof(TileState)");
        }
    }
}