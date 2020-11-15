using System.Collections.Generic;
using System.Collections.ObjectModel;
using CC.Actors.Components;

namespace CC.Actors.Interfaces {
    public interface IActorController {
        ReadOnlyCollection<Actor> Actors { get; }
        void AddActor(Actor actor);
        void RemoveActor(Actor actor);
    }
}