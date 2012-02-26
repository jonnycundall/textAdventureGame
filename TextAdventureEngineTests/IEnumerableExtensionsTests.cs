using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TextAdventureEngine;

namespace TextAdventureEngineTests
{
    [TestClass]
    public class IEnumerableExtensionsTests
    {
        [TestClass]
        public class AdjacentPairs
        {
            [TestMethod]
            public void ShouldGetNothingFromCollectionWithSingleMember()
            {
                Assert.AreEqual(0, new[] { 1 }.AdjacentPairs().Count());
            }

            [TestMethod]
            public void ShouldGetOnePairFromTwoMemberCollection()
            {
                Assert.AreEqual(1, new[] { 1, 2 }.AdjacentPairs().Count());
                Assert.AreEqual(1, new[] { 1, 2 }.AdjacentPairs().First().First);
                Assert.AreEqual(2, new[] { 1, 2 }.AdjacentPairs().First().Second);
            }
        }

        [TestClass]
        public class Substitute
        {
            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ShouldErrorIfItemNotInCollection()
            {
                new[] { 1, 2 }.Substitute(3, 4);
            }

            [TestMethod]
            public void ShouldSubstituteItem()
            {
                CollectionAssert.AreEqual(new[] { 1, 2, 4 }, new[] { 1, 2, 3 }.Substitute(3, 4).ToArray());
                CollectionAssert.AreEqual(new[] { "foo","bar","foo" }, new[] { "foo","bar","baz" }.Substitute("baz", "foo").ToArray());
            }

            [TestMethod]
            public void ShouldSubstitutePair()
            {
                CollectionAssert.AreEqual(new[] { 1, 2, 4,5 }, new[] { 1, 2, 3,4,5 }.Substitute(new Pair<int,int>(3,4), 4).ToArray());
            }
        }
    }
}
