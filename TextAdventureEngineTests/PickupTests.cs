using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAdventureEngine.Objects;
using TextAdventureEngine.State;
using TextAdventureEngine.Verbs;
using TextAdventureEngine.Locations;

namespace TextAdventureEngineTests
{
    [TestClass]
    public class PickupTests
    {
        [TestMethod]
        public void ShouldNotPickUpUnPickableObjects()
        {
            var obj = new UnPickableThing();
            var gameState = new GameState();
            gameState.Location = new StubLocation();
            gameState.Location.NearObjects = new NearObjects { obj };
            var pickup = new PickUp();

            pickup.Do(null, obj, gameState);

            Assert.IsFalse(gameState.Inventory.Contains(obj));
            Assert.IsTrue(gameState.Location.NearObjects.Contains(obj));
        }

        [TestMethod]
        public void ShouldPickUpPortableObjects()
        {
            var obj = new PickableThing();
            var gameState = new GameState();
            gameState.Location = new StubLocation();
            gameState.Location.NearObjects = new NearObjects { obj };
            var pickup = new PickUp();

            pickup.Do(null, obj, gameState);

            Assert.IsTrue(gameState.Inventory.Contains(obj));
            Assert.IsFalse(gameState.Location.NearObjects.Contains(obj));
        }

        private class PickableThing : GameObject
        {
            public PickableThing() : base("thang")
            {
                IsPortable = true;
            }
        }

        private class UnPickableThing : GameObject
        {
            public UnPickableThing() : base("thing")
            {
                IsPortable = false;
            }
        }
    }
}
