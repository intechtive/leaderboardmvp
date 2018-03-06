using Leaderboard.WinApp.Helpers;

namespace Leaderboard.WinApp.ViewModel
{
    public class PlayerItem : NotifyPropertyChanged
    {
        private string name;
        private string score;
        private string participatedContests;
        private string noOfWin;
        private string noOfLoss;
        private string noOfDraw;


        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public string Score
        {
            get { return score; }
            set { SetProperty(ref score, value); }
        }

        public string ParticipatedContests
        {
            get { return participatedContests; }
            set { SetProperty(ref participatedContests, value); }
        }

        public string NoOfWin
        {
            get { return noOfWin; }
            set { SetProperty(ref noOfWin, value); }
        }

        public string NoOfLoss
        {
            get { return noOfLoss; }
            set { SetProperty(ref noOfLoss, value); }
        }

        public string NoOfDraw
        {
            get { return noOfDraw; }
            set { SetProperty(ref noOfDraw, value); }
        }

        public PlayerItem(string name, string score, string participatedContests, string noOfWin, string noOfLoss, string noOfDraw)
        {
            this.name = name;
            this.score = score;
            this.participatedContests = participatedContests;
            this.noOfWin = noOfWin;
            this.noOfLoss = noOfLoss;
            this.noOfDraw = noOfDraw;
        }
    }
}