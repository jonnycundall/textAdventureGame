using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TextAdventureEngine.Objects.Directions;
using TextAdventureEngine.Objects;

namespace TextAdventureEngine.Locations
{
    [JsonObject(IsReference = true)]
    public class Location
    {
        private string everyTimeDescription;
        private string initialDescription;
        private bool firstTime = true;

        protected Location(string initialDescription, string everyTimeDescription)
        {
            this.everyTimeDescription = everyTimeDescription;
            this.initialDescription = initialDescription;
        }

        public string Description
        {
            get
            {
                if (firstTime)
                {
                    firstTime = false;
                    return initialDescription + everyTimeDescription;
                }
                return everyTimeDescription;
            }
        }

        public Location North { get; set; }
        public Location South { get; set; }
        public Location East { get; set; }
        public Location West { get; set; }
        public Location Up { get; set; }
        public Location Down { get; set; }
        private NearObjects nearObjects;
        
        public NearObjects NearObjects
        {
            get
            {
                if (nearObjects == null)
                    nearObjects = new NearObjects();
                return nearObjects;
            }
            set { nearObjects = value; }
        }

        public Location Move(Direction direction)
        {
            return direction.Way(this);
        }

        public void ConnectTo(Direction direction, Location otherLocation)
        {
            var dir = direction.Way(this);
            dir = otherLocation;
            var dirOp = direction.OppositeWay(otherLocation);
            dirOp = this;
        }
    }
}
