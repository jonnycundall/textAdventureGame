using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAdventureEngine.Objects;
using TextAdventureEngine.State;
using TextAdventureEngine.Locations;
using TextAdventureEngine.Objects.Directions;

namespace TextAdventureEngineTests
{
    [TestClass]
    public class GameStateTests
    {
        [TestMethod]
        public void ShouldFindFromInventory()
        { 
            var state = new GameState();
            state.Location = new StubLocation();
            var bar = new BarObject();
            state.Inventory.Add(bar);

            Assert.AreEqual(bar, state.GetObject("bar"));
        }

        [TestMethod]
        public void ShouldFindDirection()
        {
            var state = new GameState();
            state.Location = new StubLocation();
            var north = new North();
            state.Directions = new List<Direction> { north };
            
            Assert.AreEqual(north, state.GetObject("north"));
        }

        private class BarObject : GameObject
        {
            public BarObject () : base("bar")
	        {
	        }
        }

        
    }
}
