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
        // Speech synthesizer instance for voice output
        private readonly SpeechSynthesizer speaker;

        // The chatbot engine instance to process user inputs and generate responses
        private readonly ChatBotEngine.ChatBotEngine chatBotEngine;

        public ChatPage()
        {
            InitializeComponent();

            // Initialize the speech synthesizer with full volume
            speaker = new SpeechSynthesizer
            {
                Volume = 100
            };

            // Create a new chatbot engine instance
            chatBotEngine = new ChatBotEngine.ChatBotEngine();
        }

        // Handler for Send button click event - triggers processing of user input
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessUserInput();
        }

        // Handler for key down event on the user input textbox
        // Processes input when Enter key is pressed and suppresses beep sound
        private void UserInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessUserInput();
                e.Handled = true; // Prevents the system beep on Enter key press
            }
        }

        // Processes the user input from the textbox, interacts with chatbot engine,
        // updates the chat display and triggers speech synthesis
        private void ProcessUserInput()
        {
            string userInput = UserInputTextBox.Text.Trim();

            // Ignore empty input
            if (string.IsNullOrEmpty(userInput))
                return;

            string lowerInput = userInput.ToLower();

            // Special commands to clear the chat UI
            if (lowerInput == "clear" || lowerInput == "clear chat")
            {
                ChatListBox.Items.Clear();
                UserInputTextBox.Clear();
                return;
            }

            // Add the user's message to the chat display in dark blue color
            AddMessageToChat($"You: {userInput}", Brushes.DarkBlue);

            // Get the bot's response from the chatbot engine
            string botResponse = chatBotEngine.GetChatbotResponse(userInput);

            // Add the bot's response to the chat display in dark green color
            AddMessageToChat($"Bot: {botResponse}", Brushes.DarkGreen);

            // Use speech synthesizer to speak the bot's response asynchronously
            speaker.SpeakAsync(botResponse);

            // Clear the input textbox for next message
            UserInputTextBox.Clear();

            // Automatically scroll the chat list box to the bottom after new messages
            if (VisualTreeHelper.GetChild(ChatListBox, 0) is Border border &&
                VisualTreeHelper.GetChild(border, 0) is ScrollViewer scrollViewer)
            {
                scrollViewer.ScrollToEnd();
            }
        }

        // Helper method to add a message string to the chat list box with specified text color
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

        // Event handler for the Clear Chat button to clear the chat messages
        private void ClearChatButton_Click(object sender, RoutedEventArgs e)
        {
            ChatListBox.Items.Clear();
        }
    }
}
