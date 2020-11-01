using CC.Board.Components;
using CC.Board.Systems;
using NUnit.Framework;
using Shouldly;

namespace CC.Board.tests.Entities {
    public class BoardTests {
        [Test]
        public void Board_Creates_ModelSize_Of_Nodes() {
            BoardModel model = new BoardModel(10);
            BoardCreator bc = new BoardCreator(model);
            Board.Entities.Board b = bc.Create();

            b.Nodes.Length.ShouldBe(model.Size.Length);
            foreach (var node in b.Nodes) {
                node.ShouldNotBeNull();
            }
        }
    }
}