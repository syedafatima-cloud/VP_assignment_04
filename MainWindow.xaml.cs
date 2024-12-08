using System.Collections.ObjectModel;
using System.Windows;

namespace CricketTeamManager
{
    public partial class MainWindow : Window
    {
        // ObservableCollection to hold the list of players
        public ObservableCollection<string> Players { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the ObservableCollection
            Players = new ObservableCollection<string>();

            // Set the DataContext for data binding
            this.DataContext = this;
        }

        // Add player to the roster
        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text.Trim();

            // Validation: Prevent adding empty or duplicate names
            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Player name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Players.Contains(playerName))
            {
                MessageBox.Show("Player already exists in the roster.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Add player to the list
            Players.Add(playerName);
            MessageBox.Show($"Player '{playerName}' added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear the TextBox
            PlayerNameTextBox.Clear();
        }

        // Remove player from the roster
        private void RemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected player
            string selectedPlayer = (string)PlayersListBox.SelectedItem;

            if (selectedPlayer == null)
            {
                MessageBox.Show("Please select a player to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Remove player from the list
            Players.Remove(selectedPlayer);
            MessageBox.Show($"Player '{selectedPlayer}' removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
