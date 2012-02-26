using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.Locations;

namespace TextAdventureEngineTests
{
    internal class StubLocation : Location
    {
        public StubLocation()
            : base(string.Empty, "foo")
        {
            
        }
    }
}
