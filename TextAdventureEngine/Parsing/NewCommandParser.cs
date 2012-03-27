using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventureEngine.State;
using TextAdventureEngine;
using TextAdventureEngine.Verbs;

namespace TextAdventureEngine.Parsing
{
    public class NewCommandParser
    {
        private IVerbRepository _verbRepository;
        private IGameState _state;

        public NewCommandParser(IVerbRepository verbrepository, IGameState state)
        {
            _verbRepository = verbrepository;
            _state = state;
        }

        public IEnumerable<IWord> Parse(string input)
        {
            var basicWords = input.Split(' ');

            var processedWords = basicWords.Select(word => new UnknownWord(word)).Cast<IWord>();

            processedWords = _AddTwoWordVerbs(processedWords);

            processedWords = _AddOneWordVerbs(processedWords);

            processedWords = _FindAnyMatchingObjects(processedWords);

            processedWords = processedWords.Where(word => !(word is UnknownWord));

            return processedWords;
        }

        private IEnumerable<IWord> _FindAnyMatchingObjects(IEnumerable<IWord> processedWords)
        {
            foreach (var word in processedWords)
            {
                if (word is UnknownWord)
                {
                    var matchedObject = _state.GetObject(word.Word);
                    if (matchedObject != null)
                    {
                        processedWords = processedWords.Substitute(word, matchedObject);
                    }
                }
            }
            return processedWords;
        }

        private IEnumerable<IWord> _AddOneWordVerbs(IEnumerable<IWord> unknownWords)
        {
            foreach (var word in unknownWords)
            {
                var verb = _verbRepository.FindMatch(word);
                if (verb != null)
                {
                    unknownWords = unknownWords.Substitute(word, verb);
                }
            }

            return unknownWords;
        }

        private IEnumerable<IWord> _AddTwoWordVerbs(IEnumerable<IWord> unknownWords)
        {
            var twoWordWindow = unknownWords.AdjacentPairs();
            //first scan for verbs

            foreach (var wordPair in twoWordWindow)
            {
                var verb = _verbRepository.FindMatch(wordPair);
                if (verb != null)
                {
                    //replace two words that make up pair with some kind of verb object
                    unknownWords = unknownWords.Substitute(wordPair, verb);
                }
            }
            return unknownWords;
        }
    }
}
