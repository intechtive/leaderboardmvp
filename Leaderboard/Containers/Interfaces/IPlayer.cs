using System.Collections.Generic;

namespace Leaderboard.Containers.Interfaces
{
    /// <summary>
    /// Defines public actions and behavior of a Player.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Gets the player name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the number of contests that the player has participated.
        /// </summary>
        int ParticipatedContests { get; }

        /// <summary>
        /// Gets the accumulated player score.
        /// </summary>
        long Score { get; }

        /// <summary>
        /// Gets the list of the player's opponents.
        /// </summary>
        IReadOnlyList<IPlayer> Opponents { get; }

        /// <summary>
        /// Adds a new <see cref="PlayerResult"/> for the player.
        /// </summary>
        /// <param name="opponent">The opponent.</param>
        /// <param name="playerResult"></param>
        void AddResult(IPlayer opponent, PlayerResult playerResult);

        /// <summary>
        /// Gets the No. of <see cref="PlayerResult"/> that the player has gained.
        /// </summary>
        /// <param name="playerResult"></param>
        /// <returns></returns>
        int GetNoOfResultOfType(PlayerResult playerResult);
    }
}