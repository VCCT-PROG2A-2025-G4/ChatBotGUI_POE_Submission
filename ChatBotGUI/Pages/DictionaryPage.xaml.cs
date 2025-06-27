using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using ChatBotGUI.Data;
using MaterialDesignThemes.Wpf;

namespace ChatBotGUI.Pages
{
    public partial class DictionaryPage : Window
    {
        // Constructor initializes the page and loads dictionary entries
        public DictionaryPage()
        {
            InitializeComponent();
            LoadDictionaryEntries();
        }

        // Loads cybersecurity dictionary terms and definitions into the UI panel
        private void LoadDictionaryEntries()
        {
            // Clear existing children from the panel before adding new entries
            DictionaryPanel.Children.Clear();

            // Retrieve the dictionary terms and their definitions
            var terms = CyberSecurityDictionary.Program.keyValuePairs;

            // Iterate through each term and its list of definitions
            foreach (var pair in terms)
            {
                // Create a TextBlock for the term title, styled with bold font and dark blue color
                var termText = new TextBlock
                {
                    Text = pair.Key,
                    FontWeight = FontWeights.Bold,
                    FontSize = 16,
                    Foreground = Brushes.DarkBlue,
                    Margin = new Thickness(0, 10, 0, 5)
                };
                // Add the term title to the DictionaryPanel
                DictionaryPanel.Children.Add(termText);

                // Create a StackPanel to hold all definitions as a bulleted list, indented for clarity
                var defsStack = new StackPanel { Margin = new Thickness(10, 0, 0, 10) };

                // Add each definition as a TextBlock with a bullet point and wrapping
                foreach (var definition in pair.Value)
                {
                    var defText = new TextBlock
                    {
                        Text = "• " + definition,
                        TextWrapping = TextWrapping.Wrap,
                        FontSize = 14,
                        Foreground = Brushes.Black,
                        Margin = new Thickness(0, 2, 0, 2)
                    };
                    defsStack.Children.Add(defText);
                }

                // Add the definitions stack panel below the term title
                DictionaryPanel.Children.Add(defsStack);
            }
        }

        // Event handler for Close button click to close the DictionaryPage window
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
