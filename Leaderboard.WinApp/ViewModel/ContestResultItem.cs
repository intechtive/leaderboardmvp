using Leaderboard.WinApp.Helpers;

namespace Leaderboard.WinApp.ViewModel
{
    public class ContestResultItem : NotifyPropertyChanged
    {
        private string result;

        public string Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }

    }
}