using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAdventureEngine.Locations;
using TextAdventureEngine.Objects.Directions;

namespace TextAdventureEngineTests
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void ShouldConnectLocationsReflexively()
        {
            var location1 = new SomeLocation();
            var location2 = new SomeLocation();
            
            location1.ConnectTo(new North(), location2);

            Assert.AreEqual(location2,location1.North);
            Assert.AreEqual(location1, location2.South);
        }

        [TestMethod]
        public void ShouldReadInitialDescriptionOnlyTheFirstTime()
        {
            var location = new LocationWithInitialDescription();
            Assert.AreEqual("Initial. Every time.", location.Description);
            Assert.AreEqual("Every time.", location.Description);
        }

        private class LocationWithInitialDescription : Location
        {
            public LocationWithInitialDescription()
                : base("Initial. ", "Every time.")
            {}
        }

        private class SomeLocation : Location
        {
            public SomeLocation():base(string.Empty, "foo")
            {

            }
        }
    }
}
