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
    /// </summary>
    public partial class ActivityLogPage : Page
    {
        private const int DefaultDisplayCount = 10;
        private bool showingAll = false;

        public ActivityLogPage()
        {
            InitializeComponent();
            LoadActivityLog();
        }

        private void LoadActivityLog()
        {
            LogListBox.Items.Clear();

            var log = ActivityLogManager.GetLog();
            var entriesToShow = showingAll ? log : log.TakeLast(DefaultDisplayCount);

            foreach (var entry in entriesToShow)
            {
                LogListBox.Items.Add(entry);
            }
        }

        private void ShowMore_Click(object sender, RoutedEventArgs e)
        {
            showingAll = !showingAll;
            LoadActivityLog();

            // Toggle button text
            (sender as Button).Content = showingAll ? "Show Less" : "Show More";
        }
    }

    /// <summary>
    /// Shared static log manager used by all pages
    /// </summary>
    public static class ActivityLogManager
    {
        private static readonly List<string> logEntries = new List<string>();

        public static void AddEntry(string message)
        {
            string entry = $"[{DateTime.Now:HH:mm}] {message}";
            logEntries.Add(entry);

            // Optional: limit size to 100 entries
            if (logEntries.Count > 100)
            {
                logEntries.RemoveAt(0);
            }
        }

        public static IEnumerable<string> GetLog()
        {
            return new List<string>(logEntries);
        }
    }
}