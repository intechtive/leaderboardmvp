using System.Collections.Generic;
using Leaderboard.Containers;
using Leaderboard.Containers.Interfaces;

namespace Leaderboard.Tests.Containers
{
    public abstract class TestsBase
    {
        protected const string Board1 = "SuperLeague";

        protected const string Player1 = "John";
        protected const string Player2 = "Roy";
        protected const string Player3 = "Bob";

        protected static readonly List<string> Names = new List<string>
        {
            Player1,
            Player2,
            Player3
        };

        protected readonly List<IPlayer> Players;

        protected TestsBase()
        {
            Players = new List<IPlayer>
            {
                new Player(Player1),
                new Player(Player2),
                new Player(Player3)
            };
        }
    }
}
