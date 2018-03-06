namespace Leaderboard.Containers.Interfaces
{
    /// <summary>
    /// Exposes public actions and behavior of a Contest. 
    /// </summary>
    public interface IContest
    {
        /// <summary>
        /// Gets the contest result, Name of the winner, "None", or "Draw".
        /// </summary>
        string Result { get; }

        /// <summary>
        /// Gets the first <see cref="IPlayer"/>.
        /// </summary>
        IPlayer PlayerOne { get; }

        /// <summary>
        /// Gets the second <see cref="IPlayer"/>.
        /// </summary>
        IPlayer PlayerTwo { get; }

        /// <summary>
        /// Gets the contest's players' names
        /// </summary>
        string[] Players { get; }

        /// <summary>
        /// Updates the contest's result.
        /// </summary>
        /// <param name="result">Name of the winner, "None", or "Draw".</param>
        void UpdateResult(string result);
    }
}