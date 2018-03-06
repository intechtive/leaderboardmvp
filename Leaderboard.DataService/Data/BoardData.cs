using System.Collections.Generic;

namespace Leaderboard.DataService.Data
{
    public class BoardData
    {
        /// <summary>
        /// Gets the board's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the list of players.
        /// </summary>
        public List<string> Players { get; set; }

        /// <summary>
        /// Gets the list of contests.
        /// </summary>
        public List<ContestData> Contests { get; set; }

        /// <summary>
        /// Gets a value indicating whether this is a private board.
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardData"/> class.
        /// </summary>
        public BoardData(string name, List<string> players, List<ContestData> contests, bool isPrivate)
        {
            Name = name;
            Players = players;
            Contests = contests;
            IsPrivate = isPrivate;
        }
    }
}