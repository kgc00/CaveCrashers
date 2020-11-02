using System;
using CC.Board.Components;
using CC.Board.Systems;
using CC.Tiles;
using NUnit.Framework;
using Shouldly;

namespace Board.Tests.Systems {
    public class BoardCreatorTests {
        [TestFixture]
        public class CreatorFixtureNoState {
            private BoardModel model;
            private BoardCreator creator;

            [SetUp]
            public void Setup() {
                model = new BoardModel(10);
                creator = new BoardCreator(model);
            }

            [Test]
            public void BoardCreator_Contains_Model() {
                creator.Model.Size.ShouldBe(model.Size);
            }

            [Test]
            public void BoardCreator_Creates_Board() {
                var board = creator.Create();

                board.Nodes.Length.ShouldBe(model.Size.Length);
            }
        }

        [TestFixture]
        public class CreatorFixtureWithState {
            private BoardModel model;
            private int size = 10;
            private Type[,] states;
            private BoardCreator creator;
            private CC.Board.Entities.Board board;

            [SetUp]
            public void Setup() {
                states = new Type[size, size];
                states[size / 2, size / 2] = typeof(Corner);
                model = new BoardModel(size, states);
                creator = new BoardCreator(model);
                board = creator.Create();
            }

            [Test]
            public void Model_Contains_Corner_State() {
                board.Nodes[size / 2, size / 2].StartingType.ShouldBe(typeof(Corner));
            }
            
            [Test]
            public void Creator_Contains_Corner_State() {
                creator.Model.TileTypes[size / 2, size / 2].ShouldBe(typeof(Corner));
            }
            
            [Test]
            public void Creator_Contains_Unexplored_State() {
                board.Nodes[size / 4, size / 4].StartingType.ShouldBe(typeof(Unexplored));
            }
        }
    }
}