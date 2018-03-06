namespace Leaderboard.Containers
{
    /// <summary>
    /// Defines different result type that a player can earn.
    /// </summary>
    /// <remarks>Corresponding scores can be moved to the higher level.</remarks>
    public enum PlayerResult : uint
    {
        /// <summary>
        /// Loss.
        /// </summary>
        Loss = 0,

        /// <summary>
        /// Draw.
        /// </summary>
        Draw = 1,

        /// <summary>
        /// Win.
        /// </summary>
        Win = 3
    }
}
