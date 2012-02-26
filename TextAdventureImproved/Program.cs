using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine;

namespace TextAdventureImproved
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new AdventureGame(new MineAdventure.State.GameStateFactory());
            
            //for the first go, input nothing. Here assuming that the AdventureGame is expecting this behaviour
            Console.Write(game.Input(null) + System.Environment.NewLine);
            
            while (game.InPlay)
            {
                var userInput = Console.ReadLine();
                Console.WriteLine(System.Environment.NewLine);
                Console.Write(game.Input(userInput) + System.Environment.NewLine);
            }
        }
    }
}
