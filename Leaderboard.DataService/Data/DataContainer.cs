using System.Collections.Generic;
using Newtonsoft.Json;

namespace Leaderboard.DataService.Data
{
    public class DataContainer : IJsonSerializable
    {
        public List<BoardData> Boards { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContainer" /> class.
        /// </summary>
        public DataContainer(List<BoardData> boards)
        {
            Boards = boards;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContainer" /> class.
        /// </summary>
        public DataContainer()
        {
            Boards = new List<BoardData>();
        }


        /// <summary>
        /// Serialize the object to <see cref="string"/>.
        /// </summary>
        /// <returns>An <see cref="string"/> contains json representation of the object.</returns>
        public string Serialize()
        {
            return JsonConvert.SerializeObject(Boards, Formatting.Indented);
        }

        /// <summary>
        /// DeSerialize input <see cref="string"/> to the object.
        /// </summary>
        /// <param name="json">JSON file content.</param>
        public void DeSerialize(string json)
        {
            Boards = JsonConvert.DeserializeObject<List<BoardData>>(json);
        }
    }
}