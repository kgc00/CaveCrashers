using System.Collections.Generic;
using CC.Actors.Components;

namespace CC.Actors.Interfaces {
    public interface IActorController {
        List<Actor> Actors { get; }
    }
}