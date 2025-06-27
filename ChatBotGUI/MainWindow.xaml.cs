using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Speech.Synthesis;
using ChatBotGUI.Data;
using System.Windows.Media;
using ChatBotEngine;
using ChatBotGUI.Pages;
using MaterialDesignThemes.Wpf;

namespace ChatBotGUI
{
    public partial class MainWindow : Window
    {
        private readonly SpeechSynthesizer speaker;
        private readonly Random random;

        private readonly ChatBotEngine.ChatBotEngine chatBotEngine;

        // Persistent instance of ChatPage for chat history preservation
        private readonly ChatPage chatPage;

        public MainWindow()
        {
            InitializeComponent();

            speaker = new SpeechSynthesizer
            {
                Volume = 100
            };

            random = new Random();
            chatBotEngine = new ChatBotEngine.ChatBotEngine();

            // Initialize ChatPage once and keep the instance for history persistence
            chatPage = new ChatPage();

            // Navigate to the persistent ChatPage instance
            MainFrame.Navigate(chatPage);
        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the existing ChatPage instance to preserve chat history
            MainFrame.Navigate(chatPage);
        }

        private void DictionaryButton_Click(object sender, RoutedEventArgs e)
        {
            // Open DictionaryPage as a modal dialog (blocking)
            var dictionaryWindow = new DictionaryPage
            {
                Owner = this
            };
            dictionaryWindow.ShowDialog();
        }

        private void QuizButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to a new QuizPage instance
            MainFrame.Navigate(new QuizPage());
        }

        private void TaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to a new TaskAssistantPage instance
            MainFrame.Navigate(new TaskAssistantPage());
        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the ActivityLogPage to show activity logs
            MainFrame.Navigate(new ActivityLogPage());
        }

        // Method called to process user input in chat and update UI
        public void SendChat(string userInput, ListBox chatListBox, TextBox userInputTextBox)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return;

            string lowerInput = userInput.Trim().ToLower();

            // Handle clear chat commands
            if (lowerInput == "clear" || lowerInput == "clear chat")
            {
                chatListBox.Items.Clear(); // Clear chat messages visually

                AddMessageToChat(chatListBox, "Bot: Chat cleared. Memory is preserved.", Brushes.DarkGreen);

                // Optional: Speak confirmation
                speaker.SpeakAsync("Chat cleared. Memory is preserved.");

                userInputTextBox.Clear();
                return;
            }

            // Add user message to chat UI
            AddMessageToChat(chatListBox, $"You: {userInput}", Brushes.DarkBlue);

            // Get chatbot response
            string engineResponse = chatBotEngine.GetChatbotResponse(userInput);

            // Add bot response to chat UI
            AddMessageToChat(chatListBox, $"Bot: {engineResponse}", Brushes.DarkGreen);

            // Speak bot response aloud
            speaker.SpeakAsync(engineResponse);

            // Clear user input textbox
            userInputTextBox.Clear();
        }

        // Helper method to add messages to chat ListBox with color
        private void AddMessageToChat(ListBox listBox, string message, Brush color)
        {
            var item = new ListBoxItem
            {
                Content = message,
                Foreground = color
            };
            listBox.Items.Add(item);
            listBox.ScrollIntoView(item);
        }
    }
}
