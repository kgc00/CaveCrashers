using System;
using UnityEngine;

namespace CC.Gameplay.Helpers {
    public static class GameplayHelpers {
        public static bool LogOutOfBounds(Vector2 desiredPosition, int[,] bounds) {
            Console.WriteLine($"Desired Position: {desiredPosition} - Bounds: {bounds.GetLength(0)}");
            return IsOutOfBounds(desiredPosition, bounds);
        }

        public static bool IsOutOfBounds(Vector2 desiredPosition, int[,] bounds) {
            if (desiredPosition.x >= bounds.GetLength(0) || desiredPosition.x < 0) return true;
            if (desiredPosition.y >= bounds.GetLength(1)|| desiredPosition.y < 0) return true;
            return false;
        }
    }
}