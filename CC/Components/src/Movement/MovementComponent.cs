using UnityEngine;

namespace CC.Components.Movement {
    public class MovementComponent {
        private IMovable Movable { get; set; }

        public MovementComponent(IMovable movable) {
            Movable = movable;
        }

        public void Move(Vector2 dir) {
            Movable.Position = Movable.Position + dir;
        }
    }
}