using ChatBotGUI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatBotGUI.Data
{
    internal static class TaskManager
    {
        // Internal task storage
        private static readonly List<TaskAssistantPage.TaskItem> tasks = new List<TaskAssistantPage.TaskItem>();

        // Public readonly access to tasks list
        public static IReadOnlyList<TaskAssistantPage.TaskItem> Tasks => tasks.AsReadOnly();

        // Add a new task
        public static void AddTask(TaskAssistantPage.TaskItem task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            tasks.Add(task);
        }

        // Mark a task as completed
        public static void CompleteTask(TaskAssistantPage.TaskItem task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            var existing = tasks.FirstOrDefault(t => t == task);
            if (existing != null)
            {
                existing.IsCompleted = true;
            }
        }

        // 🔄 New: Mark task as completed by name
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

        // Delete a task
        public static void DeleteTask(TaskAssistantPage.TaskItem task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            tasks.Remove(task);
        }

        // 🔍 Optional: Get task by title
        public static TaskAssistantPage.TaskItem GetTaskByTitle(string title)
        {
            return tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}
