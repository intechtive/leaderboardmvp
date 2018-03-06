using System.Windows;
using System.Windows.Controls;
using Leaderboard.WinApp.ViewModel;

namespace Leaderboard.WinApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LeaderboardViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new LeaderboardViewModel();

            DataContext = viewModel;
        }


        private void OnClickSignIn(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            if (signInWindow.ShowDialog() == true)
            {
                // TODO:
            }
        }

        private void OnClickPrevious(object sender, RoutedEventArgs e)
        {
        }

        private void OnClickNext(object sender, RoutedEventArgs e)
        {
        }

        private void OnClickSetResults(object sender, RoutedEventArgs e)
        {
            var playerOne = PlayerOneComboBox.SelectedItem as PlayerItem;
            var playerTwo = PlayerTwoComboBox.SelectedItem as PlayerItem;
            var result = ContestResultComboBox.SelectionBoxItem as string;
            if (playerOne == null || playerTwo == null || string.IsNullOrEmpty(result))
            {
                return;
            }

            viewModel.SetResult(playerOne.Name, playerTwo.Name, result);
        }

        private void OnPlayerOneSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            PlayerItem selectedPlayer = comboBox?.SelectedItem as PlayerItem;
            if (selectedPlayer != null)
            {
                viewModel.PlayerOneSelected(selectedPlayer.Name);
            }
        }

        private void OnPlayerTwoSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            PlayerItem selectedPlayer = comboBox?.SelectedItem as PlayerItem;
            if (selectedPlayer != null)
            {
                viewModel.PlayerTwoSelected(selectedPlayer.Name);
            }
        }
    }
}
