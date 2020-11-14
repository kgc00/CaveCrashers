using System;
using CC.Actors.Components;
using Input;
using UnityEngine;

namespace Explorer {
    public class Explorer : MonoBehaviour {
        public Actor actor;
        private void OnDrawGizmos() {
            Gizmos.DrawCube(transform.position, Vector3.one);
        }

        private void Update() {
            transform.position = actor.Position.Vector3();
        }

        public GameObject Assign(Actor a) {
            actor = a;
            return gameObject;
        }
    }
}