using ChatBotGUI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatBotGUI.Data
{
    internal static class TaskManager
    {
        // Internal list to store all task items
        private static readonly List<TaskAssistantPage.TaskItem> tasks = new List<TaskAssistantPage.TaskItem>();

        // Public readonly property to expose the list of tasks safely
        public static IReadOnlyList<TaskAssistantPage.TaskItem> Tasks => tasks.AsReadOnly();

        // Adds a new task to the internal task list
        public static void AddTask(TaskAssistantPage.TaskItem task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            tasks.Add(task);
        }

        // Marks a specific task as completed by setting its IsCompleted property to true
        public static void CompleteTask(TaskAssistantPage.TaskItem task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            var existing = tasks.FirstOrDefault(t => t == task);
            if (existing != null)
            {
                existing.IsCompleted = true;
            }
        }

        // 🔄 New method: Marks a task as completed by matching its title (case-insensitive)
        // Returns true if task was found and marked completed, false otherwise
        public static bool CompleteTaskByName(string taskName)
        {
            if (string.IsNullOrWhiteSpace(taskName))
                return false;

            var task = tasks.FirstOrDefault(t => t.Title.Equals(taskName, StringComparison.OrdinalIgnoreCase));
            if (task != null)
            {
                task.IsCompleted = true;
                return true;
            }
            return false;
        }

        // Deletes a task from the internal list
        public static void DeleteTask(TaskAssistantPage.TaskItem task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            tasks.Remove(task);
        }

        // 🔍 Optional helper method: Finds and returns a task by its title (case-insensitive)
        // Returns null if no matching task is found
        public static TaskAssistantPage.TaskItem GetTaskByTitle(string title)
        {
            return tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}
