using Leaderboard.Utilities;

namespace Leaderboard.DataService.Data
{
    public class ContestData
    {
        /// <summary>
        /// Gets player one name.
        /// </summary>
        public string PlayerOne { get; set; }
        
        /// <summary>
        /// Gets player two name.
        /// </summary>
        public string PlayerTwo { get; set; }

        /// <summary>
        /// Gets contest result.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContestData"/> class.
        /// </summary>
        public ContestData(string playerOne, string playerTwo, string result)
        {
            playerOne.ThrowIfNullOrEmpty();
            playerTwo.ThrowIfNullOrEmpty();
            result.ThrowIfNullOrEmpty();

            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
            Result = result;
        }
    }
}