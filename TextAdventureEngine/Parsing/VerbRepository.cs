using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.Verbs;

namespace TextAdventureEngine.Parsing
{
    public interface IVerbRepository
    {
        IVerb FindVerb(params string[] words);
        IVerb FindMatch(IWord word);
        IVerb FindMatch(Pair<IWord, IWord> wordpair);
    }

    public class VerbRepository : IVerbRepository
    {
        IEnumerable<IVerb> _verbs;

        public VerbRepository()
        {
            _verbs = new IVerb[]
            {
                new Go(),
                new PickUp(),
            };
        }

        public VerbRepository(IEnumerable<IVerb> verbs)
        {
            _verbs = verbs;
        }

        public IVerb FindVerb(params string[] words)
        {
            try
            {
                var firstMatch = _verbs.First(verb => words.Any(word => verb.Means(word)));
                return firstMatch;
            }
            catch (InvalidOperationException)
            {
                throw new NoVerbException();
            }
        }

        public IVerb FindVerb(IEnumerable<IWord> words)
        {
            try
            {
                var firstMatch = _verbs.First(verb => words.Any(word => verb.Means(word.Word)));
                return firstMatch;
            }
            catch (InvalidOperationException)
            {
                throw new NoVerbException();
            }
        }

        public IVerb FindMatch(Pair<IWord, IWord> wordPair)
        {
            return _verbs.First(verb => verb.Means(string.Format("{0} {1}", wordPair.First.Word, wordPair.Second.Word)));
        }

        public IVerb FindMatch(IWord word)
        {
            return _verbs.First(verb => verb.Means(word.Word));
        }
    }

    public class NoVerbException : Exception
    {
    }
}
