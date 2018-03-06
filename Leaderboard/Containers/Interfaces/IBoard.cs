using System.Collections.Generic;

namespace Leaderboard.Containers.Interfaces
{
    /// <summary>
    /// Defines public actions and behavior of a board.
    /// </summary>
    public interface IBoard : IRefereeOperation
    {
        /// <summary>
        /// Gets the board name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a value indicating whether the board is private or public.
        /// </summary>
        bool IsPrivate { get; }

        /// <summary>
        /// Gets the list of current players who are ordered based on their score.
        /// </summary>
        IReadOnlyList<IPlayer> Players { get; }

        /// <summary>
        /// Gets the list of round robin contests.
        /// </summary>
        IReadOnlyList<IContest> Contests { get; }
    }
}