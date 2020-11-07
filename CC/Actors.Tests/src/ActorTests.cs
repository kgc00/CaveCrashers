using System;
using System.Collections.Generic;
using CC.Actors.Components;
using CC.Components.Collectable;
using CC.Items;
using NUnit.Framework;
using Shouldly;
using UnityEngine;

namespace Actors.Tests {
    [TestFixture]
    public class Tests {
        public class ActorInitializationTests {
            public static IEnumerable<TestCaseData> ActorSource {
                get {
                    yield return new TestCaseData(new Actor(), Vector2.zero);
                    yield return new TestCaseData(new Actor(Vector2.zero), Vector2.zero);
                    yield return new TestCaseData(new Actor(Vector2.up), Vector2.up);
                }
            }
        
            [TestCaseSource(nameof(ActorSource))]
            public void Does_Initialize_Position(Actor actor, Vector2 position) {
                actor.Position.ShouldBe(position);
            }
            
            public static IEnumerable<TestCaseData> ItemSource {
                get {
                    yield return new TestCaseData(new List<ICollectable>());
                    yield return new TestCaseData(new List<ICollectable>{new Rope()});
                    yield return new TestCaseData(new List<ICollectable>{new Rope(), new Shovel()});
                    yield return new TestCaseData(new List<ICollectable>{new Rope(), new Shovel(), new Treasure()});
                }
            }

            [TestCaseSource(nameof(ItemSource))]
            public void Does_Initialize_Items(List<ICollectable> items) {
                var actor = new Actor(items);

                actor.InventoryComponent.Pickups.ShouldBe(items);
            }
            
            [Test]
            public void Does_Initialize_Items_Edge_Case() {
                List<ICollectable> items = null;
                var actor = new Actor(items);

                actor.InventoryComponent.Pickups.ShouldNotBeNull();
            }
        }
    }
}