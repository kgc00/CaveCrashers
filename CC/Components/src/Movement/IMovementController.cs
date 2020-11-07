using UnityEngine;

namespace CC.Components.Movement {
    public interface IMovementController {
        void Move(IMovable movable, Vector2 dir);
    }
}