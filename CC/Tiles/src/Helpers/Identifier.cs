using CC.Components.Collectable;
using CC.Components.Tool;

namespace CC.Tiles {
    public static class Identifier {
        public static bool IsRope(IUsable item) => item.Name == "Rope";
        public static bool IsShovel(IUsable item) => item.Name == "Shovel";
        public static bool IsTreasure(IUsable item) => item.Name == "Treasure";
        public static bool IsRope(ICollectable item) => item.Name == "Rope";
        public static bool IsShovel(ICollectable item) => item.Name == "Shovel";
        public static bool IsTreasure(ICollectable item) => item.Name == "Treasure";
    }
}