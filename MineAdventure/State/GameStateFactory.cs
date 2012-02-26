using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.Objects;
using TextAdventureEngine.Locations;
using TextAdventureEngine.State;

namespace MineAdventure.State
{
    public class GameStateFactory : TextAdventureEngine.State.IGameStateFactory
    {
        public GameState Create()
        {
            var state = new GameState();

            var mainShaft0 = new MainShaft0();
            var mainShaft1 = new MainShaft1();
            var mainShaft2 = new MainShaft2();
            var mainShaft3 = new MainShaft3();
            var mainShaft4 = new MainShaft4();

            var eastShaft0 = new EastShaft0();
            var eastShaft1 = new EastShaft1();

            mainShaft0.North = mainShaft1;
            mainShaft1.South = mainShaft0;

            mainShaft1.North = mainShaft2;
            mainShaft2.South = mainShaft1;

            mainShaft2.North = mainShaft3;
            mainShaft3.South = mainShaft2;

            mainShaft3.North = mainShaft4;
            mainShaft4.South = mainShaft3;

            mainShaft3.East = eastShaft0;
            eastShaft0.West = mainShaft3;

            eastShaft0.East = eastShaft1;
            eastShaft1.West = eastShaft0;

            state.Location = mainShaft1;

            var locations = new List<Location>
            {
                mainShaft2,
                mainShaft1
            };

            state.Location = mainShaft1;

            state.Inventory = new List<GameObject>();

            return state;
        }
    }
}
