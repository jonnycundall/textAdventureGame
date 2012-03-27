using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.Verbs;
using TextAdventureEngine.Objects;

namespace TextAdventureEngine.Parsing
{
    public abstract class WordToCommandPartLink
    {
        protected WordToCommandPartLink(int argumentPostion)
        {
            ArgumentPostion = argumentPostion;
        }

        public int ArgumentPostion { get; private set; }

        public abstract bool Matches(IWord word);
    }

    public class IsVerbLink : WordToCommandPartLink
    {
        public IsVerbLink(int argumentPosition) : base(argumentPosition) { }

        public override bool  Matches(IWord word)
        {
            return word is IVerb;
        }
    }

    public class IsGameObjectLink : WordToCommandPartLink
    {
        public IsGameObjectLink(int argumentPosition) : base(argumentPosition){}

        public override bool Matches(IWord word)
        {
            return word is GameObject;
        }
    }

    public class WordPattern : IEnumerable<WordToCommandPartLink>
    {
        private List<WordToCommandPartLink> _items;

        public void Add(WordToCommandPartLink link)
        {
            _items.Add(link);
        }

        public IEnumerator<WordToCommandPartLink> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }

    }


    public class CommandPatternMatcher
    {
        private static IEnumerable<WordPattern> patterns;

        static CommandPatternMatcher()
        {
            patterns = new List<WordPattern>
            {
                new WordPattern{new IsVerbLink(0), new IsGameObjectLink(2)}
            };
        }

        public MeaningfulCommand GetCommand(List<IWord> parsedCommand)
        {
            foreach (var pattern in patterns)
            {
                var command = _GetMeaningfulCommand(pattern, parsedCommand);
                if (command != null)
                    return command;
            }

            throw new CouldNotUnderstandException();
        }

        private MeaningfulCommand _GetMeaningfulCommand(WordPattern links, IEnumerable<IWord> words)
        {
            var arguments = new IWord[2];

            var wordsNeededToMatchPattern = links.Count();

            if (words.Count() < wordsNeededToMatchPattern)
                return null;

            for(int i =0; i < links.Count(); i++)
            {
                var link = links.ElementAt(i);
                var word= words.ElementAt(i);
                if(link.Matches(word))
                {
                    arguments[link.ArgumentPostion] = word;
                }
            }

            if (arguments.All(arg => arg != null))
                return null;

            return new MeaningfulCommand((IVerb)arguments[0], (GameObject)arguments[1], (GameObject)arguments[2]);
        }

        private WordToCommandPartLink _GetPart(IEnumerable<WordToCommandPartLink> links, int position)
        {
            return links.FirstOrDefault(link => link.ArgumentPostion == position);
        }
    }
}
