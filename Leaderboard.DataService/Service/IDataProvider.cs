using System.Collections.Generic;
using Leaderboard.DataService.Data;

namespace Leaderboard.DataService.Service
{
    public interface IDataProvider
    {
        /// <summary>
        /// Gets the data service address.
        /// </summary>
        string Address { get; }

        /// <summary>
        /// Gets boards' data.
        /// </summary>
        /// <returns></returns>
        List<BoardData> GetData();

        /// <summary>
        /// Sets boards' data.
        /// </summary>
        /// <param name="boards"></param>
        void SetData(List<BoardData> boards);
    }
}