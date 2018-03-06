using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Leaderboard.Containers.Interfaces;
using Leaderboard.Utilities;

namespace Leaderboard.Containers
{
    public class Board : IBoard
    {
        private readonly List<IPlayer> players;
        private readonly List<IContest> contests;

        /// <summary>
        /// Gets the board name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a value indicating whether the board is private or public.
        /// </summary>
        public bool IsPrivate { get; }

        /// <summary>
        /// Gets the list of current players who are ordered by their score.
        /// </summary>
        public IReadOnlyList<IPlayer> Players => players.OrderByDescending(p => p.Score).ToList().AsReadOnly();

        /// <summary>
        /// Gets the list of round robin contests.
        /// </summary>
        public IReadOnlyList<IContest> Contests => contests.AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="boardName">Board title.</param>
        /// <param name="players">List of participating players.</param>
        /// <param name="contests">List of all contests in Round Robin format.</param>
        /// <param name="isPrivate">If true the board is private subscribers should be invited to be able to view the board.</param>
        public Board(string boardName, IEnumerable<IPlayer> players, IEnumerable<IContest> contests, bool isPrivate)
        {
            players.ThrowIfNull();

            // Check for name duplicates in players' names
            this.players = players.ToList();
            if (this.players.Select(p => p.Name).Distinct().Count() != this.players.Count)
            {
                throw new ArgumentException($"{nameof(players)} contains players with the same name.");
            }

            // TODO: validate contest
            this.contests = contests.ToList();

            Name = boardName;
            IsPrivate = isPrivate;
        }

        /// <summary>
        /// Updates the result of a specific contest.
        /// </summary>
        /// <param name="playerOne">The first participant's name.</param>
        /// <param name="playerTwo">The second participant's name.</param>
        /// <param name="result">The contest's result.</param>
        public void UpdateContestResult(string playerOne, string playerTwo, string result)
        {
            playerOne.ThrowIfNullOrEmpty();
            playerTwo.ThrowIfNullOrEmpty();
            result.ThrowIfNullOrEmpty();

            if(!(players.Any(p => p.Name == playerOne) && players.Any(p => p.Name == playerTwo)))
            {
                return;
            }

            IContest contest = GetMatchingContest(playerOne, playerTwo);
            contest?.UpdateResult(result);
        }
        
        private IContest GetMatchingContest(string playerOne, string playerTwo)
        {
            return contests.FirstOrDefault(c => c.Players.Contains(playerOne) && c.Players.Contains(playerTwo));
        }
    }
}
