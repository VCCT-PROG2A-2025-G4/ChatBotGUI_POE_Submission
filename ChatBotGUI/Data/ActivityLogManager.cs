using System;
using System.Collections.Generic;
using System.Linq;
using ChatBotGUI.Data;

namespace ChatBotGUI.Data
{
    public static class ActivityLogManager
    {
        // List to store general log entries with timestamps
        private static readonly List<string> logEntries = new List<string>();

        // List to track tasks added, storing task title and optional reminder date
        private static readonly List<(string Title, DateTime? ReminderDate)> tasksAdded = new List<(string, DateTime?)>();

        // List to track reminders set, storing task title and reminder date
        private static readonly List<(string Title, DateTime ReminderDate)> remindersSet = new List<(string, DateTime)>();

        // Counter to track how many quiz questions have been answered
        private static int quizQuestionsAnswered = 0;

        // Adds a general entry to the log with the current timestamp
        public static void AddEntry(string entry)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            logEntries.Add($"{timestamp} - {entry}");
        }

        // Logs the addition of a new task, optionally with a reminder date
        public static void AddTaskAdded(string title, DateTime? reminderDate)
        {
            tasksAdded.Add((title, reminderDate));

            // Add a descriptive log entry about the task addition and reminder if any
            AddEntry($"Task added: '{title}'" + (reminderDate.HasValue ? $" (Reminder set for {reminderDate.Value:MMMM d, yyyy})" : ""));

            // If a reminder date is set, record it separately for reminder tracking
            if (reminderDate.HasValue)
                remindersSet.Add((title, reminderDate.Value));
        }

        // Sets the number of quiz questions answered and logs quiz completion
        public static void SetQuizQuestionsAnswered(int count)
        {
            quizQuestionsAnswered = count;
            AddEntry($"Quiz completed - {count} questions answered.");
        }

        // Logs the event of starting the quiz
        public static void AddQuizStarted()
        {
            AddEntry("Quiz started.");
        }

        // Returns a formatted string summary of the last 'maxEntries' log entries
        public static string GetFormattedSummary(int maxEntries = 10)
        {
            if (logEntries.Count == 0)
                return "No recent actions found.";

            // Get the most recent log entries up to maxEntries
            var recentEntries = logEntries.Skip(Math.Max(0, logEntries.Count - maxEntries)).ToList();

            var lines = new List<string> { "Here's a summary of recent actions:" };
            int index = 1;

            // Format each entry with an index number for readability
            foreach (var entry in recentEntries)
            {
                lines.Add($"{index}. {entry}");
                index++;
            }

            return string.Join("\n", lines);
        }

        // Clears all log data: entries, tasks, reminders, and quiz counters
        public static void Clear()
        {
            logEntries.Clear();
            tasksAdded.Clear();
            remindersSet.Clear();
            quizQuestionsAnswered = 0;
        }

        // Provides a read-only list of all log entries (for safe external access)
        public static IReadOnlyList<string> GetLog() => logEntries.AsReadOnly();
    }
}
