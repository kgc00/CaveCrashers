using System;

namespace CC.Tiles {
    public static class Randomizer {
        private static readonly Type[] ExploredTileTypes = {
            // no unexplored...
            // typeof(Unexplored),
            // no cave in (should only be accessible from bombs)
            // typeof(CaveIn),
            typeof(Corner),
            typeof(Crossroads),
            typeof(Hallway),
            typeof(Pit),
            typeof(Intersection)
        };

        public static Type ExploredTileType() {
            Random rand = new Random();    
            int index = rand.Next(ExploredTileTypes.Length);
            return TypeEnforcer.TileStateEnforcer(ExploredTileTypes[index]);
        }
    }
}