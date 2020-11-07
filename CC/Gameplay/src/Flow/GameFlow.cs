using System;
using System.Collections.Generic;
using CC.Actors.Components;
using CC.Actors.Interfaces;
using CC.Board;
using CC.Board.Components;
using CC.Components.Collectable;
using CC.Components.Inventory;
using CC.Components.Movement;
using CC.Gameplay.Helpers;
using UnityEngine;

namespace CC.Gameplay.Flow {
    public class GameFlow : IActorController, IMovementController, ICollectableController {
        public BoardCreator BoardCreator { get; }
        public Board.Components.Board Board { get; }
        public BoardModel Model { get; }

        public List<Actor> Actors { get; private set; }

        public GameFlow(BoardCreator boardCreator, Board.Components.Board board, BoardModel model, List<Actor> actors) {
            BoardCreator = boardCreator;
            Board = board;
            Model = model;
            Actors = actors;
        }

        public GameFlow() {
            Model = Factory.DefaultConfiguration();
            BoardCreator = new BoardCreator(Model);
            Board = BoardCreator.Create();
            Actors = new List<Actor>();
        }

        public void Move(IMovable movable, Vector2 dir) {
            var desiredPosition = movable.Position + dir;
            
            // TODO handle game logic for OOB case
            if (GameplayHelpers.IsOutOfBounds(desiredPosition, Model.Size)) return;
            
            movable.MovementComponent.Move(dir);
        }

        public void Collect(IInventory inventory, ICollectable collectable) {
            if (!inventory.Pickups.Contains(collectable))
                inventory.Pickups.Add(collectable);
        }
    }
}