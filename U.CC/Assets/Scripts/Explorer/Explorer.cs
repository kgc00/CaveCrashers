using System;
using Input;
using UnityEngine;

namespace Explorer {
    public class Explorer : MonoBehaviour {
        [SerializeField]
        private InputReader inputReader;
        
        private void OnEnable() {
            inputReader.InteractEvent += OnInteract;
            inputReader.MoveEvent += OnMove;
        }

        private void OnInteract() {
            // throw new NotImplementedException();
        }

        private void OnMove(Vector2 moveDir) {
            
        }

        private void OnDrawGizmos() {
            Gizmos.DrawCube(transform.position, Vector3.one);
        }
    }
}