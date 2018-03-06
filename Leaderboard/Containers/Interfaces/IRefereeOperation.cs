namespace Leaderboard.Containers.Interfaces
{
    public interface IRefereeOperation
    {
        /// <summary>
        /// Updates the result of a specific contest.
        /// </summary>
        /// <param name="playerOne">The first participant's name.</param>
        /// <param name="playerTwo">The second participant's name.</param>
        /// <param name="result">The contest's result.</param>
        void UpdateContestResult(string playerOne, string playerTwo, string result);
    }
}