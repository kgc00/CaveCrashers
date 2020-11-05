using System;

namespace CC.Tiles {
    public static class TypeEnforcer {
        public static Type ExploredStateTypeEnforcer(Type tileState) {
            if (tileState == null) throw new ArgumentNullException($"tilestate must not be null");
            return tileState.BaseType == typeof(TileState)
                ? tileState
                : throw new ArgumentException(
                    $"Unsupported type.  Input {tileState} must be typeof(TileState)");
        }
    }
}