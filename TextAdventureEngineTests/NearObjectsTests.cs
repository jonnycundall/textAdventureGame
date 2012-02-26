using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAdventureEngine.Locations;
using TextAdventureEngine.Objects;

namespace TextAdventureEngineTests
{
    [TestClass]
    public class NearObjectsTests
    {
        [TestMethod]
        public void ShouldDescribeAllObjects()
        {
            var nearObjects = new NearObjects{ new Thing() };
            Assert.AreEqual("There is a thing here. ", nearObjects.Description);
        }

        private class Thing : GameObject
        {
            public Thing() : base("thing") { }
        }
    }
}
