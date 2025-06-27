using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Speech.Synthesis;
using ChatBotEngine;
using MaterialDesignThemes.Wpf;

namespace ChatBotGUI.Pages
{
    public partial class ChatPage : Page
    {
        private readonly SpeechSynthesizer speaker;
        private readonly ChatBotEngine.ChatBotEngine chatBotEngine;

        public ChatPage()
        {
            InitializeComponent();

            speaker = new SpeechSynthesizer
            {
                Volume = 100
            };

            chatBotEngine = new ChatBotEngine.ChatBotEngine();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessUserInput();
        }

        private void UserInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessUserInput();
                e.Handled = true; // prevent beep on Enter
            }
        }

        private void ProcessUserInput()
        {
            string userInput = UserInputTextBox.Text.Trim();

            if (string.IsNullOrEmpty(userInput))
                return;

            // Handle "clear" or "clear chat" typed commands
            string lowerInput = userInput.ToLower();
            if (lowerInput == "clear" || lowerInput == "clear chat")
            {
                ChatListBox.Items.Clear();
                UserInputTextBox.Clear();
                return;
            }

            AddMessageToChat($"You: {userInput}", Brushes.DarkBlue);

            string botResponse = chatBotEngine.GetChatbotResponse(userInput);

            AddMessageToChat($"Bot: {botResponse}", Brushes.DarkGreen);

            speaker.SpeakAsync(botResponse);

            UserInputTextBox.Clear();

            // Scroll to bottom after adding messages
            if (VisualTreeHelper.GetChild(ChatListBox, 0) is Border border &&
                VisualTreeHelper.GetChild(border, 0) is ScrollViewer scrollViewer)
            {
                scrollViewer.ScrollToEnd();
            }
        }

        private void AddMessageToChat(string message, Brush color)
        {
            var textBlock = new TextBlock
            {
                Text = message,
                Foreground = color,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5)
            };

            ChatListBox.Items.Add(textBlock);
        }

        // Clear Chat button click handler
        private void ClearChatButton_Click(object sender, RoutedEventArgs e)
        {
            ChatListBox.Items.Clear();
        }
    }
}
