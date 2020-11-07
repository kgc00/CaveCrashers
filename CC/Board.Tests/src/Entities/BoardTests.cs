using CC.Board.Components;
using NUnit.Framework;
using Shouldly;

namespace Board.Tests.Entities {
    public class BoardTests {
        [Test]
        public void Board_Creates_ModelSize_Of_Nodes() {
            BoardModel model = new BoardModel(10);
            BoardCreator bc = new BoardCreator(model);
            CC.Board.Components.Board b = bc.Create();

            b.Nodes.Length.ShouldBe(model.Size.Length);
            foreach (var node in b.Nodes) {
                node.ShouldNotBeNull();
            }
        }
    }
}