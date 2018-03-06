using System.Collections.ObjectModel;
using Leaderboard.WinApp.Helpers;

namespace Leaderboard.WinApp.ViewModel
{
    public class ContestItem : NotifyPropertyChanged
    {
        private string playerOne;
        private string playerTwo;
        private string result;

        public string PlayerOne
        {
            get { return playerOne; }
            set { SetProperty(ref playerOne, value); }
        }

        public string PlayerTwo
        {
            get { return playerTwo; }
            set { SetProperty(ref playerTwo, value); }
        }

        public string Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }

        public ObservableCollection<string> Results { get; set; }
    }
}