using System;
using System.Collections.Generic;
using System.IO;
using Leaderboard.DataService.Data;
using Leaderboard.Utilities;

namespace Leaderboard.DataService.Service
{
    // TODO: partial data request/update
    public class DataProvider : IDataProvider
    {
        private readonly DataContainer container = new DataContainer();

        /// <summary>
        /// Gets the data service address.
        /// </summary>
        public string Address { get; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DataProvider"/> class.
        /// </summary>
        /// <param name="address"></param>
        public DataProvider(string address)
        {
            address.ThrowIfNullOrEmpty();
            Address = address;
            if (!File.Exists(address))
            {
                List<BoardData> boards = new List<BoardData>
                {
                    DataDefault.GetBoardOne(),
                    DataDefault.GetBoardTwo()
                };

                SetData(boards);
            }
        }

        /// <summary>
        /// Gets boards' data.
        /// </summary>
        /// <returns></returns>
        public List<BoardData> GetData()
        {
            // TODO: sanity check
            string data = File.ReadAllText(Address);
            container.DeSerialize(data);
            return container.Boards;
        }

        /// <summary>
        /// Sets boards' data.
        /// </summary>
        /// <param name="boards"></param>
        public void SetData(List<BoardData> boards)
        {
            container.Boards = boards;
            string data = container.Serialize();
            File.WriteAllText(Address, data);
        }
    }
}