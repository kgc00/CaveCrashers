using CC.Actors.Components;
using CC.Gameplay.Flow;
using Input;
using Unity.Mathematics;
using UnityEngine;

public class GameFlowTester : MonoBehaviour {
    private GameFlow flow;
    private Actor actor;
    [SerializeField] private InputReader inputReader;
    private void Awake() {
        actor = new Actor();
        
        GameObject explorer = new GameObject("explorer").AddComponent<Explorer.Explorer>().Assign(actor);
        
        flow = new GameFlow();
        flow.Actors.Add(actor);
        
        foreach (var node in flow.Board.Nodes) {
            var go = Instantiate(Resources.Load<GameObject>("TilePrefab"), node.Position.Vector3(), quaternion.identity);
            go.AddComponent<TileDebug>().Assign(node);
            go.transform.SetParent(transform);
        }
    }

    private void OnEnable() {
        inputReader.MoveEvent += OnMove;
    }

    private void OnDisable() {
        inputReader.MoveEvent -= OnMove;
    }

    public void OnMove(Vector2 dir) {
        flow.Move(actor, dir);
        print(actor.Position);
    }
}