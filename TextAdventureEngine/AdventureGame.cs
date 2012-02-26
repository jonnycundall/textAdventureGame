using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.State;
using TextAdventureEngine.Parsing;
using TextAdventureEngine.Verbs;

namespace TextAdventureEngine
{
    public class AdventureGame
    {
        public AdventureGame(IGameStateFactory gameStateFactory)
        {
            factory = gameStateFactory;
        }

        private bool _inPlay = true;
        private GameState state;
        private IGameStateFactory factory;
        private CommandParser commandParser;
        
        public bool InPlay
        { get { return _inPlay; } }

        public string Input(string userCommand)
        {
           if (userCommand == "exit")
            {_inPlay = false;
                return null;}

            if (state == null)
            {
                //it must be the first go!
                state = factory.Create();
                commandParser = new CommandParser(new VerbRepository(), state);
                return state.Location.Description;
            }

            try
            {
                var meaningfulCommand = commandParser.Parse(userCommand);
                meaningfulCommand.Execute(state);
                return state.Location.Description + state.Location.NearObjects.Description;
            }
            catch (NoVerbException)
            {
                return "I couldn't find a verb in that sentence, perhaps you are using a verb outside my limited vocabulary";
            }
            catch (NoWayThereException)
            {
                return "That way is blocked";
            }
        }
        
    }
}
