using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ChatBotGUI.Data;

namespace ChatBotGUI.Pages
{
    public partial class QuizPage : Page
    {
        private List<string> _terms; // All cybersecurity terms
        private int _currentQuestionIndex;
        private int _score;
        private List<string> _currentOptions; // 4 options for current question (shuffled)
        private string _currentCorrectDefinition;
        private Random _random = new Random();

        // Constructor initializes UI and starts the quiz
        public QuizPage()
        {
            InitializeComponent();
            LoadTerms();
            StartQuiz();
        }

        // Load all cybersecurity terms (keys) from the dictionary
        private void LoadTerms()
        {
            _terms = CyberSecurityDictionary.Program.keyValuePairs.Keys.ToList();
        }

        // Initialize quiz state and start first question
        private void StartQuiz()
        {
            _score = 0;
            _currentQuestionIndex = 0;
            ScoreTextBlock.Text = $"Score: {_score} / {_terms.Count}";
            FeedbackTextBlock.Text = "";
            NextButton.IsEnabled = false;
            LoadQuestion();
        }

        // Load the current quiz question and answer options
        private void LoadQuestion()
        {
            if (_currentQuestionIndex >= _terms.Count)
            {
                // If no more questions, show final results
                ShowFinalResults();
                return;
            }

            string term = _terms[_currentQuestionIndex];

            // Display the question with the current term
            QuestionTextBlock.Text = $"What is the correct definition of '{term}'?";

            // Get the correct definition (first definition in list)
            _currentCorrectDefinition = CyberSecurityDictionary.Program.keyValuePairs[term][0];

            // Select 3 random incorrect definitions from other terms
            var wrongDefinitions = _terms
                .Where(t => t != term)
                .OrderBy(x => _random.Next())
                .Take(3)
                .Select(t => CyberSecurityDictionary.Program.keyValuePairs[t][0])
                .ToList();

            // Combine correct and wrong definitions and shuffle them
            _currentOptions = wrongDefinitions.Append(_currentCorrectDefinition)
                .OrderBy(x => _random.Next())
                .ToList();

            // Assign shuffled definitions to the four option buttons
            OptionButton1.Content = _currentOptions[0];
            OptionButton2.Content = _currentOptions[1];
            OptionButton3.Content = _currentOptions[2];
            OptionButton4.Content = _currentOptions[3];

            // Enable option buttons for user to select
            SetOptionButtonsEnabled(true);

            // Clear feedback text and disable the Next button until an answer is selected
            FeedbackTextBlock.Text = "";
            NextButton.IsEnabled = false;
        }

        // Enable or disable all option buttons
        private void SetOptionButtonsEnabled(bool isEnabled)
        {
            OptionButton1.IsEnabled = isEnabled;
            OptionButton2.IsEnabled = isEnabled;
            OptionButton3.IsEnabled = isEnabled;
            OptionButton4.IsEnabled = isEnabled;
        }

        // Event handler for when an option button is clicked by the user
        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton == null)
                return;

            string selectedDefinition = clickedButton.Content.ToString();

            // Check if selected definition matches the correct one
            if (selectedDefinition == _currentCorrectDefinition)
            {
                FeedbackTextBlock.Text = "Correct! 🎉";
                _score++;
                ScoreTextBlock.Text = $"Score: {_score} / {_terms.Count}";
            }
            else
            {
                FeedbackTextBlock.Text = $"Incorrect. The correct answer was:\n{_currentCorrectDefinition}";
            }

            // Disable option buttons after an answer is selected
            SetOptionButtonsEnabled(false);
            // Enable Next button to proceed to the next question
            NextButton.IsEnabled = true;
        }

        // Event handler for Next button click to load the next question
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _currentQuestionIndex++;
            FeedbackTextBlock.Text = "";
            LoadQuestion();
        }

        // Show final quiz results with personalized feedback
        private void ShowFinalResults()
        {
            QuestionTextBlock.Text = "Quiz Completed!";

            // Provide feedback based on user's score
            FeedbackTextBlock.Text = _score switch
            {
                var s when s == _terms.Count => "Perfect! You're a cybersecurity pro! 🏆",
                var s when s >= _terms.Count / 2 => "Good job! Keep learning to stay safe online!",
                _ => "Keep learning and practicing to improve your cybersecurity knowledge!"
            };

            // Hide the option buttons as quiz is finished
            OptionButton1.Visibility = Visibility.Collapsed;
            OptionButton2.Visibility = Visibility.Collapsed;
            OptionButton3.Visibility = Visibility.Collapsed;
            OptionButton4.Visibility = Visibility.Collapsed;

            // Disable the Next button since no more questions remain
            NextButton.IsEnabled = false;
        }
    }
}
