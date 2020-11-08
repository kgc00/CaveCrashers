namespace CC.Components.Tool {
    public class ToolUsageComponent : IManipulator {
        public void Use(IUsable tool) {
            tool.Use(this);
        }
    }
}