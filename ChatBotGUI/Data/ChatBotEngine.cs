using ChatBotGUI.Data;
using ChatBotGUI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using static ChatBotGUI.Data.CyberSecurityDictionary;


namespace ChatBotEngine
{
    public class ChatBotEngine
    {
        private readonly Random random;

        // New fields for task reminder state
        private bool awaitingReminder = false;
        private string pendingTaskTitle = null;
        private string pendingTaskDescription = null;

        public ChatBotEngine()
        {
            random = new Random();
        }

        // Returns the bot's response given user input
        public string GetChatbotResponse(string input)
        {
            input = input.ToLower();

            // --- New reminder handler at start ---
            if (awaitingReminder)
            {
                if (input.Contains("remind me in"))
                {
                    var words = input.Split(' ');
                    int daysIndex = Array.IndexOf(words, "in") + 1;

                    if (daysIndex <= 0 || daysIndex >= words.Length)
                        return "Please specify the number of days for the reminder, e.g. 'remind me in 3 days'.";

                    if (int.TryParse(words[daysIndex], out int days))
                    {
                        var lastTask = TaskManager.Tasks.LastOrDefault();
                        if (lastTask == null)
                            return "No recent task found to set a reminder.";

                        lastTask.ReminderDate = DateTime.Now.AddDays(days);

                        // Log task added with reminder date using AddTaskAdded()
                        ChatBotGUI.Data.ActivityLogManager.AddTaskAdded(lastTask.Title, lastTask.ReminderDate);

                        // Reset state
                        awaitingReminder = false;
                        pendingTaskTitle = null;
                        pendingTaskDescription = null;

                        return $"Got it! I'll remind you in {days} days.";
                    }
                    else
                    {
                        return "I couldn't understand the number of days. Please say something like 'remind me in 3 days'.";
                    }
                }
                else
                {
                    return "Please specify when to remind me using 'remind me in X days'.";
                }
            }

            // --- Existing NLP Command Simulation for Task Assistant & Activity Log ---

            // Handle "add task" anywhere in input
            if (input.Contains("add") && input.Contains("task"))
            {
                int index = input.IndexOf("add task");
                string taskTitle = null;

                if (index >= 0)
                {
                    string remainder = input.Substring(index + "add task".Length).Trim();
                    if (remainder.StartsWith("-"))
                        remainder = remainder.Substring(1).Trim();

                    taskTitle = remainder;
                }

                if (string.IsNullOrEmpty(taskTitle))
                    return "I see you want to add a task. Please tell me the task title using 'add task - [title]'.";

                string description = $"Task '{taskTitle}' added.";

                var task = new TaskAssistantPage.TaskItem
                {
                    Title = taskTitle,
                    Description = description,
                    IsCompleted = false,
                    ReminderDate = null
                };

                TaskManager.AddTask(task);

                // Log task added without reminder yet
                ChatBotGUI.Data.ActivityLogManager.AddTaskAdded(task.Title, null);

                // Set state to wait for reminder input next
                pendingTaskTitle = taskTitle;
                pendingTaskDescription = description;
                awaitingReminder = true;

                return $"Task added with the description \"{description}\". Would you like a reminder?";
            }

            // Handle reminder without awaiting (in case user just says reminder out of flow)
            if (input.Contains("remind me in"))
            {
                var words = input.Split(' ');
                int daysIndex = Array.IndexOf(words, "in") + 1;

                if (daysIndex <= 0 || daysIndex >= words.Length)
                    return "Please specify the number of days for the reminder, e.g. 'remind me in 3 days'.";

                if (int.TryParse(words[daysIndex], out int days))
                {
                    var lastTask = TaskManager.Tasks.LastOrDefault();
                    if (lastTask == null)
                        return "No recent task found to set a reminder.";

                    lastTask.ReminderDate = DateTime.Now.AddDays(days);

                    ChatBotGUI.Data.ActivityLogManager.AddTaskAdded(lastTask.Title, lastTask.ReminderDate);

                    return $"Got it! I'll remind you in {days} days.";
                }
                else
                {
                    return "I couldn't understand the number of days. Please say something like 'remind me in 3 days'.";
                }
            }

            // Show activity log commands
            if (input.Contains("show activity log") || input.Contains("show log") || input.Contains("activity log"))
            {
                var summary = ChatBotGUI.Data.ActivityLogManager.GetFormattedSummary();
                if (string.IsNullOrWhiteSpace(summary))
                    return "Activity log is currently empty.";
                return summary;
            }

            // --- Existing Sentiment and Chatbot Logic ---

            string[] sentiments = { "worried", "curious", "frustrated" };
            foreach (var sentiment in sentiments)
            {
                if (input.Contains(sentiment))
                {
                    foreach (var pair in Program.keyValuePairs)
                    {
                        if (input.Contains(pair.Key.ToLower()))
                        {
                            if (Program.sentimentMessages.TryGetValue(pair.Key.ToLower(), out var termSentiments))
                            {
                                if (termSentiments.TryGetValue(sentiment, out string reply))
                                {
                                    return reply;
                                }
                            }
                        }
                    }
                }
            }

            if (input.Contains("interested"))
            {
                foreach (var term in Program.keyValuePairs.Keys)
                {
                    if (input.Contains(term.ToLower()))
                    {
                        return $"Great! I acknowledge your interest in {term}. It's a crucial part of staying safe online.";
                    }
                }
            }

            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
                return "Hello there! I am the CyberSecurity Awareness ChatBot. How may I assist you today?";

            if (input.Contains("how are you") || input.Contains("how you doing") || input.Contains("how is it going"))
                return "I’m good, here, and ready to help! How are you today?";

            if (input.Contains("im good") || input.Contains("i am fine") || input.Contains("im not too bad") || input.Contains("i am well") || input.Contains("im ok"))
                return "That's good to hear! Let's get started on enlightening you about cybersecurity.";

            if (input.Contains("im bad") || input.Contains("i am not doing well") || input.Contains("im not too good") || input.Contains("im not well") || input.Contains("not good") || input.Contains("feeling down"))
                return "Aw man, I’m sorry to hear that. Remember, staying safe online is one less thing to worry about. How can I assist to make your day better with some cybersecurity tips?";

            if (input.Contains("can you tell me a joke") || input.Contains("tell me something funny") || input.Contains("make me laugh"))
                return "Sure! Why did the computer go to therapy? Because it had too many bytes!";

            if (input.Contains("im feeling lonely") || input.Contains("im so alone"))
                return "I'm here for you. Just like a strong firewall—quiet but always watching your back.";

            if (input.Contains("im unsure") || input.Contains("im uncertain") || input.Contains("im not sure"))
                return "It's okay to feel unsure. Cybersecurity can seem complex, but I'm here to help you one step at a time. Would you like a tip to get started?";

            if (input.Contains("im sorry") || input.Contains("i did not know"))
                return "Don't worry! It's ok to make mistakes and now know as it is part of learning.";

            if (input.Contains("thank you") || input.Contains("thanks"))
                return "No problem! If there is anything else you want to know, feel free to ask!";

            if (input.Contains("bye") || input.Contains("goodbye"))
                return "Goodbye, Stay Safe Online!";

            // Tips or definitions
            bool isTip = input.Contains("tip");

            foreach (var pair in Program.keyValuePairs)
            {
                if (input.Contains(pair.Key.ToLower()))
                {
                    if (isTip && Program.keyTips.ContainsKey(pair.Key))
                    {
                        var tips = Program.keyTips[pair.Key];
                        var tip = tips[random.Next(tips.Count)];
                        return $"Absolutely! {tip}";
                    }
                    else
                    {
                        var definitions = pair.Value;
                        var definition = definitions[random.Next(definitions.Count)];
                        return $"{pair.Key} is defined as — {definition}";
                    }
                }
            }

            return "I'm not sure I understand and won't be able to respond, please try rephrasing?";
        }

        // Starts the quiz - returns the user's score after quiz ends or early exit
        public int StartCybersecurityQuiz(Func<string> inputProvider, Action<string> outputHandler)
        {
            ChatBotGUI.Data.ActivityLogManager.AddEntry("Quiz started.");

            var allTerms = Program.keyValuePairs.Keys.ToList();
            int score = 0;

            foreach (var term in allTerms)
            {
                outputHandler($"What is the correct definition of '{term}'?\n");

                var correctDefinition = Program.keyValuePairs[term][0];

                // Choose 3 wrong definitions randomly
                var wrongDefinitions = allTerms
                    .Where(t => t != term)
                    .OrderBy(x => random.Next())
                    .Take(3)
                    .Select(t => Program.keyValuePairs[t][0])
                    .ToList();

                // Merge and shuffle options
                var options = wrongDefinitions.Append(correctDefinition).OrderBy(x => random.Next()).ToList();

                for (int i = 0; i < options.Count; i++)
                {
                    outputHandler($"{i + 1}. {options[i]}");
                }

                string selectedInput;
                int selectedIndex;

                while (true)
                {
                    outputHandler("\nType the number of your choice or 'exit' to quit:");

                    selectedInput = inputProvider();

                    if (string.IsNullOrWhiteSpace(selectedInput))
                        continue;

                    if (selectedInput.Trim().ToLower() == "exit")
                    {
                        outputHandler("Quiz exited early. Returning to main menu...");
                        ChatBotGUI.Data.ActivityLogManager.SetQuizQuestionsAnswered(score);
                        return score;
                    }

                    if (int.TryParse(selectedInput, out selectedIndex) &&
                        selectedIndex >= 1 && selectedIndex <= options.Count)
                    {
                        break;
                    }
                    else
                    {
                        outputHandler("Invalid selection. Please try again.");
                    }
                }

                var selectedDefinition = options[selectedIndex - 1];

                if (selectedDefinition == correctDefinition)
                {
                    outputHandler("Correct!\n");
                    score++;
                }
                else
                {
                    outputHandler($"Incorrect. The correct answer was:\n{correctDefinition}\n");
                }
            }

            ChatBotGUI.Data.ActivityLogManager.SetQuizQuestionsAnswered(score);

            return score;
        }
    }
}
