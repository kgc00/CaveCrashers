using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input {
    [CreateAssetMenu(fileName = "Input Reader", menuName = "CC/Input Reader")]
    public class InputReader : ScriptableObject, PlayerInput.IGameplayActions {
        private PlayerInput input;
        public Action<Vector2> MoveEvent = delegate { };
        public Action InteractEvent = delegate { };

        private void OnEnable() {
            if (input == null) {
                input = new PlayerInput();
                input.Gameplay.SetCallbacks(this);
            }

            input.Gameplay.Enable();
        }

        private void OnDisable() {
            input.Gameplay.Disable();
        }

        public void OnMove(InputAction.CallbackContext context) {
            if (context.phase != InputActionPhase.Performed) return;
            MoveEvent(context.ReadValue<Vector2>());
        }

        public void OnInteract(InputAction.CallbackContext context) {
            if (context.phase != InputActionPhase.Performed) return;
            InteractEvent();
        }
    }
}