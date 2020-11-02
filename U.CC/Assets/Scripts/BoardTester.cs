using System;
using CC.Board.Components;
using CC.Board.Entities;
using CC.Board.Systems;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

public class BoardTester : MonoBehaviour {
    private BoardCreator creator;
    private BoardModel model = CC.Board.Helpers.Factory.DefaultConfiguration();
    private Board board;
    private void Start() {
        creator = new BoardCreator(model);
        board = creator.Create();
        print(board.Nodes.Length);
        foreach (var node in board.Nodes) {
            var go = Instantiate(Resources.Load<GameObject>("TilePrefab"), node.Position.Vector3(), quaternion.identity);
            go.AddComponent<TileDebug>().Assign(node);
            go.transform.SetParent(transform);
        }
    }
}