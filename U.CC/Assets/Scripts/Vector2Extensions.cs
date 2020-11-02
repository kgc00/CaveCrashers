using UnityEngine;

public static class Vector2Extensions {
    public static Vector3 Vector3(this Vector2 vector2) => new Vector3(vector2.x, vector2.y, 0f);
}