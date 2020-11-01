using System.Collections;
using UnityEngine;

namespace CC.Board.Interfaces {
    public interface IInteractable {
        void StartInteraction(IActor actor);
        IEnumerator Interaction();
        Coroutine OngoingInteraction { get; }
    }
}