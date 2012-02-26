using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAdventureEngine.Parsing;
using TextAdventureEngine.Verbs;
using Rhino.Mocks;
using TextAdventureEngine.State;
using TextAdventureEngine.Objects;
using TextAdventureEngine;
using TextAdventureEngine.Locations;

namespace TextAdventureEngineTests
{
    [TestClass]
    public class CommandParserTests
    {
        IVerb injectedVerb;
        IVerbRepository verbRepository;
        private GameState gameState; 
        [TestInitialize]
        public void Init()
        {
            injectedVerb = MockRepository.GenerateMock<IVerb>();
            verbRepository = MockRepository.GenerateMock<IVerbRepository>();
            gameState = new GameState();
            gameState.Inventory = new List<GameObject>();
            gameState.Location = new StubLocation();
        }

        [TestMethod]
        public void ShouldUseVerbsFromVerbRepo()
        {
            verbRepository.Stub(vr => vr.FindVerb("go north")).Return(new Go());
            
            var parser = new CommandParser(verbRepository, gameState);
            var meaningfulCommmand = parser.Parse("go north");
            Assert.AreEqual(injectedVerb, meaningfulCommmand.Verb);
        }

        [TestMethod]
        public void ShouldGetOtherWordsToBeObjectAndTool()
        {
            injectedVerb.Stub(v => v.Means("slap")).Return(true);
            verbRepository.Stub(vr => vr.FindVerb("slap belly with slapper")).Return(injectedVerb);

            var parser = new CommandParser(verbRepository, gameState);
            var meaningfulCommmand = parser.Parse("slap belly with slapper");
            Assert.AreEqual("belly", meaningfulCommmand.VerbObject);
            Assert.AreEqual("slapper", meaningfulCommmand.VerbTool);
        }

        [TestMethod]
        public void OnlyNounShouldBeObject()
        {
            verbRepository.Stub(vr => vr.FindVerb("go north")).Return(new Go());

            var parser = new CommandParser(verbRepository, gameState);
            var meaningfulCommmand = parser.Parse("go north");

            Assert.AreEqual("north", meaningfulCommmand.VerbObject.Name);
        }

        [TestMethod]
        public void ShouldRegisterTheTwoWordsPickUpAsOneVerb()
        {
            verbRepository
                .Stub(vr => vr.FindMatch(new Pair<IWord,IWord>(new UnknownWord("pick"),new UnknownWord("up"))))
                .IgnoreArguments()
                .Return(new PickUp());

            gameState.Location.NearObjects.Add(new Shovel());

            var parser = new CommandParser(verbRepository, gameState);
            var meaningfulCommmand = parser.Parse("pick up shovel");

            Assert.AreEqual("shovel", meaningfulCommmand.VerbObject.Name);
        }

        public class Shovel : GameObject
        {
            public Shovel() : base("shovel") { }
        }
    }
}
