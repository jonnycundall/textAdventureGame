using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.Objects.Directions;
using TextAdventureEngine.Objects;
using Newtonsoft.Json;
using TextAdventureEngine.Locations;

namespace TextAdventureEngine.State
{
    public interface IGameState
    {
        GameObject GetObject(string objectName);
    }

    public class GameState : IGameState
    {
        public GameState()
        {
            Inventory = new List<GameObject>();

            Directions = new List<Direction>
            {
                new North(),
                new South(),
                new East(),
                new West(),
                new Up(),
                new Down()
            };
        }

        public Location Location { get; set; }

        public List<GameObject> Inventory { get; set; }

        public IEnumerable<Direction> Directions { get; set; }

        public GameObject GetObject(string objectString)
        {
            var fromInventory = Inventory.FirstOrDefault(obj => obj.Name == objectString);

            if (fromInventory != null)
                return fromInventory;

            var fromDirection = Directions.FirstOrDefault(obj => obj.Name == objectString);

            if (fromDirection != null)
                return fromDirection;

            return Location.NearObjects.FirstOrDefault(obj => obj.Name == objectString);
        }
    }        
}
