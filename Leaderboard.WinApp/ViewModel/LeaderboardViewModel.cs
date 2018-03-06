using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Leaderboard.Containers;
using Leaderboard.Containers.Interfaces;
using Leaderboard.DataService.Data;
using Leaderboard.DataService.Service;
using Leaderboard.WinApp.Helpers;

namespace Leaderboard.WinApp.ViewModel
{
    public class LeaderboardViewModel : NotifyPropertyChanged
    {
        private int currentBoardIndex;
        private string name;
        private bool opponentTwoEnabled;
        private bool resultsEnabled;
        private string selectedPlayerOne;
        private string selectedPlayerTwo;
        private readonly List<IBoard> boards;
        private readonly IDataProvider dataProvider;

        public ObservableCollection<PlayerItem> Players { get; set; }
        public ObservableCollection<PlayerItem> Header { get; set; }
        public ObservableCollection<PlayerItem> Opponents { get; set; }
        public ObservableCollection<string> Results { get; set; }

        public LeaderboardViewModel()
        {
            dataProvider = new DataProvider("data.json");
            List<BoardData> data = dataProvider.GetData();
            if (data == null || !data.Any())
            {
                return;
            }

            boards = new List<IBoard>();
            foreach (BoardData boardData in data)
            {
                boards.Add(CreateBoardFromData(boardData));
            }

            Header = new ObservableCollection<PlayerItem>
            {
                new PlayerItem("Name", "Score", "Games", "Win", "Loss", "Draw")
            };

            Results = new ObservableCollection<string>();
            Players = new ObservableCollection<PlayerItem>();
            Opponents = new ObservableCollection<PlayerItem>();
            currentBoardIndex = 0;
            SetActiveBoard(currentBoardIndex);
        }

        public bool OpponentTwoEnabled
        {
            get { return opponentTwoEnabled; }
            set { SetProperty(ref opponentTwoEnabled, value); }
        }

        public bool ResultsEnabled
        {
            get { return resultsEnabled; }
            set { SetProperty(ref resultsEnabled, value); }
        }

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private IBoard CurrentBoard => boards[currentBoardIndex];

        public void PlayerOneSelected(string player)
        {
            OpponentTwoEnabled = true;
            IPlayer playerOne= CurrentBoard.Players.First(p => p.Name == player);
            Opponents.Clear();
            foreach (IPlayer opponent in CurrentBoard.Players)
            {
                if (playerOne.Name == opponent.Name)
                {
                    continue;
                }

                Opponents.Add(CreatePlayerItem(opponent));
            }

            selectedPlayerOne = player;
            RefreshResults();
        }

        public void PlayerTwoSelected(string player)
        {
            ResultsEnabled = true;
            selectedPlayerTwo = player;
            RefreshResults();
        }

        public void SetResult(string playerOne, string playerTwo, string result)
        {
            if (playerOne == playerTwo)
            {
                return;
            }

            CurrentBoard.UpdateContestResult(playerOne, playerTwo, result);
            SetActiveBoard(currentBoardIndex, true);
        }
            

        private void SetActiveBoard(int index, bool send = false)
        {
            Name = boards[index].Name;
            Players.Clear();
            foreach (IPlayer player in boards[index].Players)
            {
                Players.Add(CreatePlayerItem(player));
            }

            OpponentTwoEnabled = false;
            Opponents.Clear();
            Results.Clear();
            OpponentTwoEnabled = false;
            ResultsEnabled = false;

            if (send)
            {
                List<BoardData> newData = new List<BoardData>();
                foreach (IBoard board in boards)
                {
                    newData.Add(CreateBoardDataFromBoard(board));
                }
                dataProvider.SetData(newData);
            }
        }

        private PlayerItem CreatePlayerItem(IPlayer player)
        {
            return new PlayerItem(player.Name, $"{player.Score}",
                $"{player.ParticipatedContests}", $"{player.GetNoOfResultOfType(PlayerResult.Win)}",
                $"{player.GetNoOfResultOfType(PlayerResult.Loss)}",
                $"{player.GetNoOfResultOfType(PlayerResult.Draw)}");
        }

        private void RefreshResults()
        {
            if (string.IsNullOrEmpty(selectedPlayerOne) || string.IsNullOrEmpty(selectedPlayerTwo))
            {
                return;
            }

            Results.Clear();
            Results.Add(selectedPlayerOne);
            Results.Add(selectedPlayerTwo);
            Results.Add(DataDefault.Draw);
        }

        private IBoard CreateBoardFromData(BoardData data)
        {
            List<IPlayer> players = new List<IPlayer>();
            List<IContest> contests = new List<IContest>();

            foreach (ContestData contestData in data.Contests)
            {
                IPlayer playerOne = players.FirstOrDefault(p => p.Name == contestData.PlayerOne);
                IPlayer playerTwo = players.FirstOrDefault(p => p.Name == contestData.PlayerTwo);
                if (playerOne == null)
                {
                    playerOne = new Player(contestData.PlayerOne);
                    players.Add(playerOne);
                }

                if (playerTwo == null)
                {
                    playerTwo = new Player(contestData.PlayerTwo);
                    players.Add(playerTwo);
                }

                contests.Add(new Contest(playerOne, playerTwo, contestData.Result));
            }

            return new Board(data.Name, players, contests, data.IsPrivate);
        }

        private BoardData CreateBoardDataFromBoard(IBoard board)
        {
            List<string> players = board.Players.Select(p => p.Name).ToList();
            List<ContestData> contests = board.Contests.Select(c => new ContestData(c.PlayerOne.Name, c.PlayerTwo.Name, c.Result)).ToList();
            return new BoardData(board.Name, players, contests, board.IsPrivate);
        }
    }
}