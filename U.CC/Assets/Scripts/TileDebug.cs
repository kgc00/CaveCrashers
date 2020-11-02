using CC.Board.Entities;
using CC.Tiles;
using UnityEngine;

public class TileDebug : MonoBehaviour {
    private Node node;

    public void Assign(Node node) => this.node = node;
    private void OnDrawGizmos() {
        if (node.StartingType == typeof(Hallway)) Gizmos.DrawSphere(transform.position,0.25f);
    }
}