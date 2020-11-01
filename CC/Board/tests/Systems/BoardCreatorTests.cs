using CC.Board.Components;
using CC.Board.Systems;
using NUnit.Framework;
using Shouldly;

namespace CC.Board.tests.Systems {
    public class BoardCreatorTests {
        [Test]
        public void BoardCreator_Contains_Model() {
            var gm = new BoardModel(10);
            var gc = new BoardCreator(gm);
            
            gc.Model.Size.ShouldBe(gm.Size);
        }

        [Test]
        public void BoardCreator_Creates_Board() {
            var gm = new BoardModel(10);
            var gc = new BoardCreator(gm);

            var board = gc.Create();
            
            board.ShouldNotBeNull();
            board.Nodes.Length.ShouldBe(gm.Size.Length);
        }
    }
}