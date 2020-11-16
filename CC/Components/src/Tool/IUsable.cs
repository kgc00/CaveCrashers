using CC.Components.Location;

namespace CC.Components.Tool {
    public interface IUsable {
        string Name { get; }
        void Use(IManipulator user, ILocation source, ILocation target);
    }
}