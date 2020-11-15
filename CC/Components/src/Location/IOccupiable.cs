using System.Collections.Generic;
using CC.Components.Inventory;
using CC.Components.Movement;
using UnityEngine;

namespace CC.Components.Location {
    public interface IOccupiable {
        Vector2 Position { get; }
        List<IMovable> Occupants { get; }
        void AddOccupant(IMovable occupant);
        void RemoveOccupant(IMovable occupant);
        LocationComponent LocationComponent { get; }
        InventoryComponent Inventory { get; }
    }
}