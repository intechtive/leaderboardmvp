namespace Leaderboard.DataService.Data
{
    public interface IJsonSerializable
    {
        /// <summary>
        /// Serialize the object to <see cref="string"/>.
        /// </summary>
        /// <returns>An <see cref="string"/> contains json representation of the object.</returns>
        string Serialize();

        /// <summary>
        /// DeSerialize input <see cref="string"/> to the object.
        /// </summary>
        /// <param name="json">JSON file content.</param>
        void DeSerialize(string json);
    }
}