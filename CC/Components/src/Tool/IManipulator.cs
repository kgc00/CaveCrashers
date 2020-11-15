using CC.Components.Location;

namespace CC.Components.Tool {
    public interface IManipulator {
        void Use(IUsable tool, ILocation location, ILocation target);
    }
}