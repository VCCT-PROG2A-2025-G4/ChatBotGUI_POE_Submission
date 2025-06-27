using System;
using System.Collections.Generic;
using System.Linq;
using ChatBotGUI.Data;

namespace ChatBotGUI.Data

{
    public static class ActivityLogManager
    {
        private static readonly List<string> logEntries = new List<string>();
        private static readonly List<(string Title, DateTime? ReminderDate)> tasksAdded = new List<(string, DateTime?)>();
        private static readonly List<(string Title, DateTime ReminderDate)> remindersSet = new List<(string, DateTime)>();
        private static int quizQuestionsAnswered = 0;

        public static void AddEntry(string entry)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            logEntries.Add($"{timestamp} - {entry}");
        }

        public static void AddTaskAdded(string title, DateTime? reminderDate)
        {
            tasksAdded.Add((title, reminderDate));
            AddEntry($"Task added: '{title}'" + (reminderDate.HasValue ? $" (Reminder set for {reminderDate.Value:MMMM d, yyyy})" : ""));
            if (reminderDate.HasValue)
                remindersSet.Add((title, reminderDate.Value));
        }

        public static void SetQuizQuestionsAnswered(int count)
        {
            quizQuestionsAnswered = count;
            AddEntry($"Quiz completed - {count} questions answered.");
        }

        public static void AddQuizStarted()
        {
            AddEntry("Quiz started.");
        }

        // Returns last 'maxEntries' log entries in formatted string
        public static string GetFormattedSummary(int maxEntries = 10)
        {
            if (logEntries.Count == 0)
                return "No recent actions found.";

            var recentEntries = logEntries.Skip(Math.Max(0, logEntries.Count - maxEntries)).ToList();

            var lines = new List<string> { "Here's a summary of recent actions:" };
            int index = 1;
            foreach (var entry in recentEntries)
            {
                lines.Add($"{index}. {entry}");
                index++;
            }
            return string.Join("\n", lines);
        }

        public static void Clear()
        {
            logEntries.Clear();
            tasksAdded.Clear();
            remindersSet.Clear();
            quizQuestionsAnswered = 0;
        }

        public static IReadOnlyList<string> GetLog() => logEntries.AsReadOnly();
    }
}
