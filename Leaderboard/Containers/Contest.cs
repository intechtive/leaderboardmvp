using System;
using System.ComponentModel;
using Leaderboard.Containers.Interfaces;
using Leaderboard.Utilities;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace Leaderboard.Containers
{
    public class Contest : IContest
    {
        /// <summary>
        /// Gets the contest result, Name of the winner, "None", or "Draw".
        /// </summary>
        public string Result { get; private set; }

        /// <summary>
        /// Gets the first <see cref="IPlayer"/>.
        /// </summary>
        public IPlayer PlayerOne { get; }

        /// <summary>
        /// Gets the second <see cref="IPlayer"/>.
        /// </summary>
        public IPlayer PlayerTwo { get; }

        /// <summary>
        /// Gets the contest's players' names
        /// </summary>
        public string[] Players => new[] {PlayerOne.Name, PlayerTwo.Name};

        public Contest(IPlayer playerOne, IPlayer playerTwo, string result)
        {
            playerOne.ThrowIfNull();
            playerTwo.ThrowIfNull();
            result.ThrowIfNullOrEmpty();

            PlayerOne = playerOne;
            PlayerTwo = playerTwo;

            Result = result;
            UpdateResult(result);
        }

        /// <summary>
        /// Updates the contest's result.
        /// </summary>
        /// <param name="result">Name of the winner, "None", or "Draw".</param>
        public void UpdateResult(string result)
        {
            result.ThrowIfNullOrEmpty();

            Result = result;
            if (result == "Draw")
            {
                PlayerOne.AddResult(PlayerTwo, PlayerResult.Draw);
                PlayerTwo.AddResult(PlayerOne, PlayerResult.Draw);
                return;
            }

            if (result == PlayerOne.Name)
            {
                PlayerOne.AddResult(PlayerTwo, PlayerResult.Win);
                PlayerTwo.AddResult(PlayerOne, PlayerResult.Loss);
                return;
            }

            if (result == PlayerTwo.Name)
            {
                PlayerOne.AddResult(PlayerTwo, PlayerResult.Loss);
                PlayerTwo.AddResult(PlayerOne, PlayerResult.Win);
            }
        }

    }
}