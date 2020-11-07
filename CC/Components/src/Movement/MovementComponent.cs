using UnityEngine;

namespace CC.Components.Movement {
    public class MovementComponent {
        private IMovable Movable { get; set; }

        public MovementComponent(IMovable movable, Vector2 position = new Vector2()) {
            Movable = movable;
            Movable.Position = position;
        }

        public void Move(Vector2 dir) {
            Movable.Position = Movable.Position + dir;
        }
    }
}