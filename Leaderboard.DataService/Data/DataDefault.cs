using System.Collections.Generic;
using System.Linq;
using Leaderboard.Utilities;

namespace Leaderboard.DataService.Data
{
    public static class DataDefault
    {
        public const string John = "John";
        public const string Megan = "Megan";
        public const string Bob = "Bob";
        public const string Sarah = "Sarah";
        public const string Kyle = "Kyle";
        public const string Ted = "Ted";

        public const string None = "None";
        public const string Draw = "Draw";

        public const string BoardOneName = "Super League";
        public const string BoardTwoName = "Premium League";
        
        public static BoardData GetBoardOne()
        {
            List<string> players = new List<string> {John, Megan, Bob, Sarah};
            List<ContestData> contests = new List<ContestData>();
            var rounds = players.Combination();
            int bounce = 0;
            foreach (IEnumerable<string> round in rounds)
            {
                string[] opponents = round.ToArray();
                ContestData contest = new ContestData(opponents[0], opponents[1], None);
                contests.Add(contest);
            }

            return new BoardData(BoardOneName, players, contests, false);
        }

        public static BoardData GetBoardTwo()
        {
            List<string> players = new List<string> { John, Megan, Sarah, Kyle, Ted };
            List<ContestData> contests = new List<ContestData>();
            var rounds = players.Combination();
            int bounce = 0;
            foreach (IEnumerable<string> round in rounds)
            {
                string[] opponents = round.ToArray();
                ContestData contest = new ContestData(opponents[0], opponents[1], ++bounce %2 == 0 ? opponents[0] : Draw);
                contests.Add(contest);
            }

            return new BoardData(BoardTwoName, players, contests, false);
        }
    }
}