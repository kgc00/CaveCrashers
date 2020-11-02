using NUnit.Framework;
using Shouldly;

namespace Board.Tests.Helpers {
    public class FactoryTests {
        [Test]
        public void Does_Not_Throw() {
            Should.NotThrow(CC.Board.Helpers.Factory.DefaultConfiguration);
        }
    }
}