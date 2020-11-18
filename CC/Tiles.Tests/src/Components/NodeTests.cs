using CC.Components.Location.Model;
using CC.Tiles;
using NUnit.Framework;
using Shouldly;
using UnityEngine;

namespace Tiles.Tests {
    public class TileTests {
        
        [TestFixture]
        public class TileFixtureUnexploredState {
            #region Fixture Setup

            private Tile node;
            private TileModel model;
            private Vector2 pos;

            [SetUp]
            public void SetUpFixture() {
                AssignDefaults();
            }

            private void AssignDefaults() {
                pos = new Vector2(10,10);    
                model = new TileModel(pos, typeof(Unexplored));
                node = new Tile(model);
            }
            #endregion

            [Test]
            public void Tile_Has_Position() {
                node.Position.ShouldBe(pos);
            }

            [Test]
            public void Tile_Has_State() {
                node.StateMachine.CurrentState.GetType().ShouldBe(typeof(Unexplored));
            }

            [Test]
            public void Tile_Can_Set_Wall_Open() {
                node.Wall.SetWallOpen(Directions.West);
                
                node.Wall.GetWall(Directions.West).ShouldBeTrue();
            }
        }
        
        [TestFixture]
        public class TileFixtureCornerState {
            #region Fixture Setup

            private Tile node;
            private TileModel model;
            private Vector2 pos;

            [SetUp]
            public void SetUpFixture() {
                AssignDefaults();
            }

            private void AssignDefaults() {
                pos = new Vector2(10,10);    
                model = new TileModel(pos, typeof(Corner));
                node = new Tile(model);
            }
            #endregion

            [Test]
            public void Tile_Has_Position() {
                node.Position.ShouldBe(pos);
            }

            [Test]
            public void Tile_Has_State() {
                node.StateMachine.CurrentState.GetType().ShouldBe(typeof(Corner));
            }
        }
    }
}