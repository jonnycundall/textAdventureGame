using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TextAdventureEngine.Parsing;
using TextAdventureEngine.Verbs;
using TextAdventureEngine;
using TextAdventureEngine.State;
using TextAdventureEngine.Objects;
namespace TextAdventureEngineTests
{
    [TestClass]
    public class NewCommandParserTests
    {
        private IVerbRepository _verbRepository;
        private IGameState _state;
        [TestInitialize]
        public void Setup()
        {
            _verbRepository = MockRepository.GenerateStub<IVerbRepository>();
            _state = MockRepository.GenerateStub<IGameState>();
        }

        [TestMethod]
        public void ShouldGetVerbFromRepository()
        {
            _verbRepository.Stub(vr => vr.FindMatch(new UnknownWord("go"))).Return(new Go());
            var parser = new NewCommandParser(_verbRepository, _state);
            var parsedCommand = parser.Parse("go");
            Assert.AreEqual("go", parsedCommand.First().Word);
        }

        [TestMethod]
        public void ShouldGetTwoWordVerb()
        {
            _verbRepository.Stub(vr => vr.FindMatch(new Pair<IWord,IWord>(new UnknownWord("pick"), new UnknownWord("up")))).Return(new PickUp());
            var parser = new NewCommandParser(_verbRepository, _state);
            var parsedCommand = parser.Parse("pick up");
            Assert.AreEqual("pick up", parsedCommand.First().Word);
        }

        [TestMethod]
        public void ShouldAddRecognisedObjects()
        {
            var parser = new NewCommandParser(_verbRepository, _state);
            _state.Stub(s => s.GetObject("spear")).Return(new Spear());
            var parsedCommand = parser.Parse("spear");
            Assert.IsTrue(parsedCommand.First() is GameObject);
        }

        [TestMethod]
        public void ShouldPurgeUnidentifiedWords()
        {
            var parser = new NewCommandParser(_verbRepository, _state);
            var parsedCommand = parser.Parse("the quick brown fox jumped over the lazy dog");
            Assert.AreEqual(0, parsedCommand.Count());
        }

        private class Spear : GameObject
        {
            public Spear(): base("spear")
            {
            }
        }
    }
}
