using System;
using CC.Components.Inventory;
using CC.Components.Location;

namespace CC.Components.Tool {
    public class ToolUsageComponent : IManipulator {
        public IInventory Inventory { get; private set; }
        public ToolUsageComponent(IInventory inventory) {
            Inventory = inventory  ?? throw new ArgumentNullException(nameof(inventory));
        }
        
        public void Use(IUsable tool, ILocation location, ITarget target) {
            tool.Use(this, location, target);
        }
    }
}