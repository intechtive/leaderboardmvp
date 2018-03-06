using System.Linq;
using Leaderboard.Containers;
using Leaderboard.Containers.Interfaces;
using NUnit.Framework;

namespace Leaderboard.Tests.Containers
{
    [TestFixture]
    public class ContainersTests : TestsBase
    {
        [Test]
        public void TestPlayer()
        {
            IPlayer player1 = new Player(Player1);
            IPlayer player2 = new Player(Player2);
            IPlayer player3 = new Player(Player3);
            Assert.That(player1.Name, Is.EqualTo(Player1));
            Assert.That(player1.Score, Is.EqualTo(0));
            Assert.That(player1.ParticipatedContests, Is.EqualTo(0));
            Assert.That(player1.GetNoOfResultOfType(PlayerResult.Loss), Is.EqualTo(0));
            Assert.That(player1.GetNoOfResultOfType(PlayerResult.Draw), Is.EqualTo(0));
            Assert.That(player1.GetNoOfResultOfType(PlayerResult.Win), Is.EqualTo(0));

            player1.AddResult(player2, PlayerResult.Win);
            player1.AddResult(player3, PlayerResult.Loss);
            player1.AddResult(player3, PlayerResult.Draw);
            Assert.That(player1.Score, Is.EqualTo(4));
        }
    }
}