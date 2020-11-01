using CC.Board.Components;
using CC.Board.Entities;
using NUnit.Framework;
using Shouldly;
using UnityEngine;

namespace CC.Board.tests.Components {
    public class NodeTests {
        [Test]
        public void Node_Has_Position() {
            var nodePos = new Vector2(10,10);    
            var model = new NodeModel(nodePos);
            Node n = new Node(model);
            
            n.Position.ShouldBe(nodePos);
        }
    }
}