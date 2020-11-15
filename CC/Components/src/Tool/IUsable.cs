using CC.Components.Location;

namespace CC.Components.Tool {
    public interface IUsable {
        void Use(IManipulator user, ILocation source, ILocation target);
    }
}