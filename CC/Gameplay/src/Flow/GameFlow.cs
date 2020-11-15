using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CC.Actors.Components;
using CC.Actors.Interfaces;
using CC.Board;
using CC.Board.Components;
using CC.Components.Collectable;
using CC.Components.Inventory;
using CC.Components.Location;
using CC.Components.Movement;
using CC.Components.Tool;
using CC.Gameplay.Helpers;
using CC.Tiles;
using UnityEngine;

namespace CC.Gameplay.Flow {
    public class GameFlow : IActorController, IMovementController, ICollectableController {
        public BoardCreator BoardCreator { get; }
        public Board.Components.Board Board { get; }
        public BoardModel Model { get; }

        private readonly List<Actor> actors;
        public ReadOnlyCollection<Actor> Actors { get; private set; }

        public GameFlow(BoardCreator boardCreator, Board.Components.Board board, BoardModel model, List<Actor> actors) {
            BoardCreator = boardCreator;
            Board = board;
            Model = model;
            this.actors = actors;
            Actors = actors.AsReadOnly();
        }

        public GameFlow() {
            Model = Factory.DefaultConfiguration();
            BoardCreator = new BoardCreator(Model);
            Board = BoardCreator.Create();
            actors = new List<Actor>();
            Actors = actors.AsReadOnly();
        }

        public void AddActor(Actor actor) {
            if (actors.Contains(actor)) return;
            
            actors.Add(actor);
            AddTileOccupant(actor);
        }

        private void AddTileOccupant(IMovable movable) => Board.TileFromPosition(movable.Position).AddOccupant(movable);

        public void RemoveActor(Actor actor) {
            if (!actors.Contains(actor)) return;
            
            actors.Remove(actor);
            RemoveTileOccupant(actor);
        }

        private void RemoveTileOccupant(IMovable movable) => Board.TileFromPosition(movable.Position).RemoveOccupant(movable);

        public void Move(IMovable movable, Vector2 dir) {
            var desiredPosition = movable.Position + dir;
            
            // TODO handle game logic for OOB case
            if (GameplayHelpers.IsOutOfBounds(desiredPosition, Model.Size)) return;
            
            RemoveTileOccupant(movable);
            movable.MovementComponent.Move(dir);
            AddTileOccupant(movable);
        }

        public void Use(IManipulator manipulator, IUsable tool, ILocation source, ILocation target) {
            manipulator.Use(tool, source, target);
        }
        
        #region Inventory Systems
        
        public void Collect(IInventory collector, IInventory source, ICollectable collectable) {
            if(collectable == null) return;
            
            source.Discard(collectable);
            collector.Collect(collectable);
        }

        public void CollectMany(IInventory collector, IInventory source, List<ICollectable> collectables) {
            var copy = new List<ICollectable>(collectables);

            foreach (var collectable in copy) Collect(collector, source, collectable);
        }

        #endregion
    }
}