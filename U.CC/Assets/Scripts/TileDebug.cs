using CC.Tiles;
using UnityEngine;

public class TileDebug : MonoBehaviour {
    private Tile tile;

    public void Assign(Tile t) => tile = t;
    private void OnDrawGizmos() {
        if (tile?.StartingStateType == typeof(Hallway)) Gizmos.DrawSphere(transform.position,0.25f);
    }
}