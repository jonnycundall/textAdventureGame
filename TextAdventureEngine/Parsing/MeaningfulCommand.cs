using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.Verbs;
using TextAdventureEngine.State;
using TextAdventureEngine.Objects;

namespace TextAdventureEngine.Parsing
{
    public class MeaningfulCommand{
        public IVerb Verb
        {
            get; private set;
        }

        public GameObject VerbTool
        {
            get;
            private set;
        }

        public GameObject VerbObject
        {
            get;
            private set;
        }

        public MeaningfulCommand(IVerb verb, GameObject verbTool, GameObject verbObject)
        {
            Verb = verb;
            VerbObject = verbObject;
            VerbTool = verbTool;
        }

        public void Execute(GameState state)
        {
            Verb.Do(VerbTool, VerbObject, state);
        }
    }
}
