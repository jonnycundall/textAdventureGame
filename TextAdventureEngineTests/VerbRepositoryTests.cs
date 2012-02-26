using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAdventureEngine.Parsing;
using TextAdventureEngine.Verbs;
using TextAdventureEngine;

namespace TextAdventureEngineTests
{
    [TestClass]
    public class VerbRepositoryTests
    {
        [TestMethod]
        public void ShouldFindVerbWhenInitialized()
        {
            var repo = new VerbRepository(new List<IVerb> {new Go() });
            var verb = repo.FindVerb("go", "north");
            Assert.IsInstanceOfType(verb, typeof(Go));
        }

        [TestMethod]
        public void ShouldRegisterTheTwoWordsPickUpAsOneVerb()
        {
            var repo = new VerbRepository(new List<IVerb> { new PickUp() });
            var verb = repo.FindMatch(new Pair<IWord,IWord>(new UnknownWord("pick"),new UnknownWord("up")));
            Assert.IsInstanceOfType(verb, typeof(PickUp));
        }
    }
}
