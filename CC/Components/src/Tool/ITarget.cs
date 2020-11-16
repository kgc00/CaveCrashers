using CC.Components.Location;

namespace CC.Components.Tool {
    public interface ITarget {
        void HandleItemEffects(IUsable item, ILocation source, ILocation target, IManipulator user);
    }
}