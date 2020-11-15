using System.Collections.Generic;
using CC.Actors.Components;
using CC.Board;
using CC.Gameplay.Flow;
using NUnit.Framework;
using Shouldly;
using UnityEngine;

namespace Gameplay.Tests.ComponentTests {
    [TestFixture]
    public class MovementFlowTests {
        private GameFlow gameFlow;
        private Actor actor;

        [SetUp]
        public void Setup() {
            gameFlow = new GameFlow();
        }


        public static IEnumerable<TestCaseData> LegalMoveCasesSource {
            get {
                yield return new TestCaseData(Vector2.one, Vector2.right);
                yield return new TestCaseData(Vector2.one, Vector2.left);
                yield return new TestCaseData(Vector2.one, Vector2.up);
                yield return new TestCaseData(Vector2.one, Vector2.down);
            }
        }

        [TestCaseSource(nameof(LegalMoveCasesSource))]
        public void Does_Move_Movables(Vector2 position, Vector2 dir) {
            actor = new Actor(position);
            gameFlow.AddActor(actor);

            gameFlow.Move(actor, dir);

            actor.Position.ShouldBe(position + dir);
        }

        [TestCaseSource(nameof(LegalMoveCasesSource))]
        public void Does_Add_Movable_To_New_Location(Vector2 position, Vector2 dir) {
            actor = new Actor(position);
            gameFlow.AddActor(actor);
            var desiredPos = position + dir;

            gameFlow.Move(actor, dir);

            gameFlow.Board.TileFromPosition(desiredPos).Occupants.ShouldContain(actor);
        }


        public static IEnumerable<TestCaseData> IllegalMoveCasesSource {
            get {
                yield return new TestCaseData(new Vector2(Factory.DefaultSize - 1, 0), Vector2.right);
                yield return new TestCaseData(new Vector2(0, 0), Vector2.left);
                yield return new TestCaseData(new Vector2(0, Factory.DefaultSize - 1), Vector2.up);
                yield return new TestCaseData(new Vector2(0, 0), Vector2.down);
            }
        }

        [TestCaseSource(nameof(IllegalMoveCasesSource))]
        public void Does_Not_Make_Illegal_Moves(Vector2 position, Vector2 dir) {
            actor = new Actor(position);
            gameFlow.AddActor(actor);

            Should.NotThrow(() => gameFlow.Move(actor, dir));
            actor.Position.ShouldBe(position);
        }
    }
}