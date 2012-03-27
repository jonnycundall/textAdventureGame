using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.State;
using TextAdventureEngine.Objects;
using TextAdventureEngine;

namespace TextAdventureEngine.Parsing
{
    public class CommandParser
    {
        IVerbRepository _verbRepository;
        GameState gameState;

        public CommandParser(IVerbRepository verbRepository, GameState gameState)
        {
            _verbRepository = verbRepository;
            this.gameState = gameState;
        }

        public MeaningfulCommand Parse(string userInput)
        {
            
            var asWords = userInput.Split(' ').Select(str => new UnknownWord(str)).Cast<IWord>();

            var twoWordWindow = asWords.AdjacentPairs();
            //first scan for verbs

            foreach (var wordPair in twoWordWindow)
            {
                var verb = _verbRepository.FindMatch(wordPair);
                if (verb != null)
                {
                    //replace two words that make up pair with some kind of verb object
                    asWords = asWords.Substitute(wordPair, verb);
                    return new MeaningfulCommand(verb, null, GetFirstMatchingObject(asWords));
                }
            }

            foreach (var word in asWords)
            {
                var verb = _verbRepository.FindMatch(word);
                if (verb != null)
                {
                    asWords.Substitute(word, verb);
                    return new MeaningfulCommand(verb, null, GetFirstMatchingObject(asWords));
                }
            }

            throw new CouldNotUnderstandException();
        }

        private GameObject GetFirstMatchingObject(IEnumerable<IWord> words)
        {
            var with = words.FirstOrDefault(w => w.Word == "with");
            if (with != null)
            {
                words.Substitute(with, new With());
            }

            var afterWith = words.SkipWhile(w => w.Word != "with").Skip(1);
            if (afterWith.Any() && gameState.GetObject(afterWith.ElementAt(0).Word) != null )
            {

                var withObject = gameState.GetObject(afterWith.ElementAt(0).Word);
                if (withObject != null)
                    return withObject;
            }

            return words.Select(word => gameState.GetObject(word.Word)).FirstOrDefault(gotObject => gotObject != null);
        }
    }

    public interface IWord
    {
        string Word { get; }
    }

    public class UnknownWord : IWord
    {
        public override bool Equals(object obj)
        {
            if (obj is IWord)
                return ((IWord)obj).Word == Word;
            return false;
        }

        public override int GetHashCode()
        {
            return Word.GetHashCode();
        }

        private string _userWord;

        public string Word { get { return _userWord; } }

        public UnknownWord(string word)
        {
            _userWord = word;
        }
    }

    public class With : IWord
    {
        public string Word { get { return "with"; } }
    }

    public class CouldNotUnderstandException : Exception
    {
    }
}
