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

        public QuizPage()
        {
            InitializeComponent();
            LoadTerms();
            StartQuiz();
        }

        private void LoadTerms()
        {
            // Get all keys from the dictionary
            _terms = CyberSecurityDictionary.Program.keyValuePairs.Keys.ToList();
        }

        private void StartQuiz()
        {
            _score = 0;
            _currentQuestionIndex = 0;
            ScoreTextBlock.Text = $"Score: {_score} / {_terms.Count}";
            FeedbackTextBlock.Text = "";
            NextButton.IsEnabled = false;
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            if (_currentQuestionIndex >= _terms.Count)
            {
                // Quiz finished
                ShowFinalResults();
                return;
            }

            string term = _terms[_currentQuestionIndex];

            QuestionTextBlock.Text = $"What is the correct definition of '{term}'?";

            _currentCorrectDefinition = CyberSecurityDictionary.Program.keyValuePairs[term][0];

            // Select 3 wrong definitions randomly
            var wrongDefinitions = _terms
                .Where(t => t != term)
                .OrderBy(x => _random.Next())
                .Take(3)
                .Select(t => CyberSecurityDictionary.Program.keyValuePairs[t][0])
                .ToList();

            // Combine and shuffle options
            _currentOptions = wrongDefinitions.Append(_currentCorrectDefinition)
                .OrderBy(x => _random.Next())
                .ToList();

            // Assign text to option buttons
            OptionButton1.Content = _currentOptions[0];
            OptionButton2.Content = _currentOptions[1];
            OptionButton3.Content = _currentOptions[2];
            OptionButton4.Content = _currentOptions[3];

            // Enable buttons
            SetOptionButtonsEnabled(true);

            FeedbackTextBlock.Text = "";
            NextButton.IsEnabled = false;
        }

        private void SetOptionButtonsEnabled(bool isEnabled)
        {
            OptionButton1.IsEnabled = isEnabled;
            OptionButton2.IsEnabled = isEnabled;
            OptionButton3.IsEnabled = isEnabled;
            OptionButton4.IsEnabled = isEnabled;
        }

        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton == null)
                return;

            string selectedDefinition = clickedButton.Content.ToString();

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

            SetOptionButtonsEnabled(false);
            NextButton.IsEnabled = true;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _currentQuestionIndex++;
            FeedbackTextBlock.Text = "";
            LoadQuestion();
        }

        private void ShowFinalResults()
        {
            QuestionTextBlock.Text = "Quiz Completed!";
            FeedbackTextBlock.Text = _score switch
            {
                var s when s == _terms.Count => "Perfect! You're a cybersecurity pro! 🏆",
                var s when s >= _terms.Count / 2 => "Good job! Keep learning to stay safe online!",
                _ => "Keep learning and practicing to improve your cybersecurity knowledge!"
            };

            OptionButton1.Visibility = Visibility.Collapsed;
            OptionButton2.Visibility = Visibility.Collapsed;
            OptionButton3.Visibility = Visibility.Collapsed;
            OptionButton4.Visibility = Visibility.Collapsed;
            NextButton.IsEnabled = false;
        }
    }
}
