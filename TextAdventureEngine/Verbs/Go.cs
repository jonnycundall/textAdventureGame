using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.Objects.Directions;
using TextAdventureEngine.Objects;

namespace TextAdventureEngine.Verbs
{
    public class Go : IVerb
    {
        public string Word { get { return "go"; } }

        private static string[] synonyms = { "go", "walk", "shimmy" };

        public bool Means(string word)
        {
            return synonyms.Contains(word.ToLowerInvariant());
        }

        public void Do(GameObject verbSubject, GameObject verbObject, TextAdventureEngine.State.GameState state)
        {
            if (!(verbObject is Direction))
                throw new DirectionNotRecognisedException();
            
            var newLocation = state.Location.Move((Direction)verbObject);

            if (newLocation == null)
                throw new NoWayThereException();

            state.Location = newLocation;
        }
    }

    public class NoWayThereException : Exception { }
}
