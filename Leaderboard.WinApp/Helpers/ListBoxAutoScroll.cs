using System.Windows.Controls;

namespace Leaderboard.WinApp.Helpers
{
    /// <summary>
    /// Extends <see cref="ListBox"/> to support scrolling customized behavior.
    /// </summary>
    public class ListBoxAutoScroll : ListBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListBoxAutoScroll"/> class.
        /// </summary>
        public ListBoxAutoScroll()
        {
            SelectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScrollIntoView(SelectedItem);
        }
    }
}