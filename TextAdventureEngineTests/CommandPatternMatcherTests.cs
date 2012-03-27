using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAdventureEngine.Parsing;
using TextAdventureEngine.Verbs;
using TextAdventureEngine.Objects.Directions;

namespace TextAdventureEngineTests
{
    [TestClass]
    public class CommandPatternMatcherTests
    {
        [TestMethod, ExpectedException(typeof(CouldNotUnderstandException))]
        public void ShouldThowExceptionWhenNonsense()
        {
            var matcher = new CommandPatternMatcher();
            var parsedCommand = new List<IWord>{new Go(),new Go(),new Go(),new Go()};
            matcher.GetCommand(parsedCommand);
        }

        [TestMethod]
        public void ShouldMatchSimpleVerbObjectPattern()
        {
            var matcher = new CommandPatternMatcher();
            var parsedCommand = new List<IWord>{new Go(),new North()};
            var command  = matcher.GetCommand(parsedCommand);
            Assert.AreEqual(command.Verb.Word, "go");
            Assert.AreEqual(command.VerbObject.Word, "north");
        }
    }
}
