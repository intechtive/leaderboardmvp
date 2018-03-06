using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using Leaderboard.Utilities;
using NUnit.Framework;

namespace Leaderboard.Tests.Helpers
{
    [TestFixture]
    public class HelpersTests
    {
        [Test]
        public void TestCombination()
        {
            const string player1 = "John";
            const string player2 = "Roy";
            const string player3 = "Bob";

            List<string> players = new List<string>
            {
                player1,
                player2,
                player3
            };

            List<List<string>> expected = new List<List<string>>
            {
                new List<string> {player1, player2},
                new List<string> {player1, player3},
                new List<string> {player2, player3}
            };

            var results = players.Combination().ToList();
            Assert.That(results, Is.EquivalentTo(expected));
        }
    }
}