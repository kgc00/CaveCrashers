using System;
using CC.Tiles;
using NUnit.Framework;
using Shouldly;

namespace Tiles.Tests.Helpers {
    public class HelperTests {
        [TestCase(typeof(string)),
         TestCase(typeof(TileFSM))]
        public void TypeEnforcer_Handles_Invalid_Input(Type inputType) {
            Should.Throw<ArgumentException>(() => TypeEnforcer.TileStateEnforcer(inputType));
        }
        
        [Test]
        public void TypeEnforcer_Handles_Null() {
            Should.NotThrow(() => TypeEnforcer.TileStateEnforcer(null));
        }

        [Test]
        public void Randomizer_Returns_TileType() {
            var tileType = Randomizer.ExploredTileType();
            
            Console.WriteLine(tileType);
        }

    }
}