using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureEngine.Verbs
{
    public class PickUp : IVerb
    {
        public string Word { get { return "pick up"; } }

        public bool Means(string word)
        {
            return new[] { "pick", "grab", "take" }.Contains(word.ToLowerInvariant());
        }

        public void Do(TextAdventureEngine.Objects.GameObject verbSubject, TextAdventureEngine.Objects.GameObject verbObject, TextAdventureEngine.State.GameState state)
        {
            if (verbObject.IsPortable)
            {
                state.Inventory.Add(verbObject);
                state.Location.NearObjects.Remove(verbObject);
            }

        }
    }
}
