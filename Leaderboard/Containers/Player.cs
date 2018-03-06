using System;
using System.Collections.Generic;
using System.Linq;
using Leaderboard.Containers.Interfaces;
using Leaderboard.Utilities;

namespace Leaderboard.Containers
{
    public class Player : IPlayer
    {
        private readonly Dictionary<IPlayer, PlayerResult> contests;

        /// <summary>
        /// Gets the player name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the number of contests that the player has participated.
        /// </summary>
        public int ParticipatedContests => contests.Count;

        /// <summary>
        /// Gets the accumulated player score.
        /// </summary>
        public long Score => contests.Values.Sum(r => (uint)r);

        /// <summary>
        /// Gets the list of the player's opponents.
        /// </summary>
        public IReadOnlyList<IPlayer> Opponents => contests.Keys.ToList().AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Player(string name)
        {
            name.ThrowIfNullOrEmpty();
            Name = name;
            contests = new Dictionary<IPlayer, PlayerResult>();
        }

        /// <summary>
        /// Adds a new <see cref="PlayerResult"/> for the player.
        /// </summary>
        /// <param name="opponent">The opponent.</param>
        /// <param name="playerResult"></param>
        public void AddResult(IPlayer opponent, PlayerResult playerResult)
        {
            if (!Enum.IsDefined(typeof(PlayerResult), playerResult))
                throw new ArgumentOutOfRangeException(nameof(playerResult), "Value should be defined in the PlayerResult enum.");
            
            contests[opponent] = playerResult;
        }

        /// <summary>
        /// Gets the No. of <see cref="PlayerResult"/> that the player has gained.
        /// </summary>
        /// <param name="playerResult"></param>
        /// <returns></returns>
        public int GetNoOfResultOfType(PlayerResult playerResult)
        {
            return contests.Values.Count(r => r == playerResult);
        }
    }
}