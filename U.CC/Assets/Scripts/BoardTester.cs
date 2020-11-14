using CC.Actors.Components;
using CC.Board.Components;
using Unity.Mathematics;
using UnityEngine;

public class BoardTester : MonoBehaviour {
    private BoardCreator creator;
    private BoardModel model = CC.Board.Factory.DefaultConfiguration();
    private Board board;
    
    private void Start() {
        creator = new BoardCreator(model);
        board = creator.Create();
        
        foreach (var node in board.Nodes) {
            var go = Instantiate(Resources.Load<GameObject>("TilePrefab"), node.Position.Vector3(), quaternion.identity);
            go.AddComponent<TileDebug>().Assign(node);
            go.transform.SetParent(transform);
        }
    }
}