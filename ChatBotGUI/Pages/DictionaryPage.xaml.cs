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
        public DictionaryPage()
        {
            InitializeComponent();
            LoadDictionaryEntries();
        }

        private void LoadDictionaryEntries()
        {
            DictionaryPanel.Children.Clear();

            var terms = CyberSecurityDictionary.Program.keyValuePairs;

            foreach (var pair in terms)
            {
                // Term Title
                var termText = new TextBlock
                {
                    Text = pair.Key,
                    FontWeight = FontWeights.Bold,
                    FontSize = 16,
                    Foreground = Brushes.DarkBlue,
                    Margin = new Thickness(0, 10, 0, 5)
                };
                DictionaryPanel.Children.Add(termText);

                // Definitions as bullet list
                var defsStack = new StackPanel { Margin = new Thickness(10, 0, 0, 10) };
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

                DictionaryPanel.Children.Add(defsStack);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
