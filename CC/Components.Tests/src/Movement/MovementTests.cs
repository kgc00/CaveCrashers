using CC.Components.Movement;
using Moq;
using NUnit.Framework;
using Shouldly;
using UnityEngine;

namespace Components.Tests.Movement {
    public class MovementTests {
        private IMovable movable;
        private MovementComponent movementComponent;

        [SetUp]
        public void Setup() {
            movable = Mock.Of<IMovable>();
            movementComponent = new MovementComponent(movable);
        }

        [Test]
        public void DoesInitialize() {
            movable.Position.ShouldBe(Vector2.zero);
        }
        
        [Test]
        public void DoesMove() {
            movementComponent.Move(Vector2.right);

            movable.Position.ShouldBe(new Vector2(1, 0));
        }
    }
}