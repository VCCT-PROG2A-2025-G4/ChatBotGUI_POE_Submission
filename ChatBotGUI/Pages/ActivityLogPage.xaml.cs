using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;

namespace ChatBotGUI.Pages
{
    /// <summary>
    /// Interaction logic for ActivityLogPage.xaml
    /// Displays recent activity log entries with an option to show more or less entries.
    /// </summary>
    public partial class ActivityLogPage : Page
    {
        private const int DefaultDisplayCount = 10;  // Default number of entries to show initially
        private bool showingAll = false;              // Flag to track whether all entries are shown

        public ActivityLogPage()
        {
            InitializeComponent();
            LoadActivityLog();
        }

        // Loads the activity log entries into the ListBox UI element
        private void LoadActivityLog()
        {
            LogListBox.Items.Clear();

            var log = ActivityLogManager.GetLog();

            // Show either all entries or only the last DefaultDisplayCount entries based on toggle
            var entriesToShow = showingAll ? log : log.TakeLast(DefaultDisplayCount);

            foreach (var entry in entriesToShow)
            {
                LogListBox.Items.Add(entry);
            }
        }

        // Button click handler to toggle between showing more or fewer log entries
        private void ShowMore_Click(object sender, RoutedEventArgs e)
        {
            showingAll = !showingAll;  // Toggle the flag
            LoadActivityLog();

            // Update button text accordingly
            (sender as Button).Content = showingAll ? "Show Less" : "Show More";
        }
    }

    /// <summary>
    /// Static manager class to maintain the application-wide activity log entries.
    /// Entries are timestamped and capped at 100 to avoid excessive memory use.
    /// </summary>
    public static class ActivityLogManager
    {
        // Internal list storing the log entries
        private static readonly List<string> logEntries = new List<string>();

        // Adds a new log entry with a timestamp
        public static void AddEntry(string message)
        {
            string entry = $"[{DateTime.Now:HH:mm}] {message}";
            logEntries.Add(entry);

            // Optional: Keep maximum of 100 entries by removing the oldest when exceeded
            if (logEntries.Count > 100)
            {
                logEntries.RemoveAt(0);
            }
        }

        // Returns a copy of the current log entries as an IEnumerable<string>
        public static IEnumerable<string> GetLog()
        {
            return new List<string>(logEntries);
        }
    }
}
