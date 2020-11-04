using System;
using CC.Tiles;
using CC.Tiles.Helpers;
using NUnit.Framework;
using Shouldly;

namespace Tiles.Tests.Helpers {
    public class HelperTests {
        [TestCase(typeof(string)),
         TestCase(typeof(TileFSM)),
         TestCase(null)]
        public void TypeEnforcer_Handles_Invalid_Input(Type inputType) {
            Should.Throw<ArgumentException>(() => TypeEnforcer.ExploredStateTypeEnforcer(inputType));
        }
    }
}