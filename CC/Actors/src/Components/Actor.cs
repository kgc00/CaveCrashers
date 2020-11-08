using System.Collections.Generic;
using CC.Components.Collectable;
using CC.Components.Inventory;
using CC.Components.Movement;
using CC.Components.Tool;
using UnityEngine;

namespace CC.Actors.Components {
    public class Actor : IMovable {
        public Vector2 Position { get; set; }

        // TODO maybe move inventory to actor bc multiple components will want its data
        public MovementComponent MovementComponent { get; set; }
        public CollectorComponent CollectorComponent { get; set; }
        public InventoryComponent InventoryComponent { get; set; }

        public ToolUsageComponent ToolUsageComponent { get; set; }
        public Actor() {
            MovementComponent = new MovementComponent(this, Vector2.zero);
            InventoryComponent = new InventoryComponent();
            CollectorComponent = new CollectorComponent(InventoryComponent);
            ToolUsageComponent = new ToolUsageComponent();
        }

        public Actor(Vector2 position) {
            MovementComponent = new MovementComponent(this, position);
            InventoryComponent = new InventoryComponent();
            CollectorComponent = new CollectorComponent(InventoryComponent);
            ToolUsageComponent = new ToolUsageComponent();
        }
        
        public Actor(List<ICollectable> items) {
            MovementComponent = new MovementComponent(this, Vector2.zero);
            InventoryComponent = new InventoryComponent(items);
            CollectorComponent = new CollectorComponent(InventoryComponent);
            ToolUsageComponent = new ToolUsageComponent();
        }
    }
}