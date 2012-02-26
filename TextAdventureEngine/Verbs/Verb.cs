using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.Objects;
using TextAdventureEngine.State;
using TextAdventureEngine.Parsing;

namespace TextAdventureEngine.Verbs
{
    public interface IVerb : IWord
    {
        bool Means(string word);

        void Do(GameObject verbSubject, GameObject verbObject, GameState state);
    }
}
