using CC.Board.Components;
using CC.Board.Entities;
using CC.Tiles;
using NUnit.Framework;
using Shouldly;
using UnityEngine;

namespace Board.Tests.Components {
    public class NodeTests {
        
        [TestFixture]
        public class NodeFixture {
            #region Fixture Setup

            private Node node;
            private NodeModel model;
            private Vector2 pos;

            [SetUp]
            public void SetUpFixture() {
                AssignDefaults();
            }

            private void AssignDefaults() {
                pos = new Vector2(10,10);    
                model = new NodeModel(pos, typeof(Unexplored));
                node = new Node(model);
            }
            #endregion

            [Test]
            public void Node_Has_Position() {
                node.Position.ShouldBe(pos);
                pos = Vector2.down;
            }

            [Test]
            public void Node_Has_State() {
                pos.ShouldBe(new Vector2(10,10));
                node.StateMachine.CurrentState.GetType().ShouldBe(typeof(Unexplored));
            }
        }
    }
}