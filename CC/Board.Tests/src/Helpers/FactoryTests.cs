using CC.Board;
using NUnit.Framework;
using Shouldly;

namespace Board.Tests.Helpers {
    public class FactoryTests {
        [Test]
        public void Does_Not_Throw() {
            Should.NotThrow(Factory.DefaultConfiguration);
        }

        public void HallwaysNumber8() {
            // Factory.DefaultConfiguration().TileTypes
        }
    }
}