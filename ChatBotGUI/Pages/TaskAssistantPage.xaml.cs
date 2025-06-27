using System;
using System.Windows;
using System.Windows.Controls;
using ChatBotGUI.Data;

namespace ChatBotGUI.Pages
{
    /// <summary>
    /// Interaction logic for TaskAssistantPage.xaml
    /// </summary>
    public partial class TaskAssistantPage : Page
    {
        // TaskItem class representing a single task
        public class TaskItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? ReminderDate { get; set; }
            public bool IsCompleted { get; set; }

            // Override ToString for display in UI lists
            public override string ToString()
            {
                string status = IsCompleted ? "[Completed] " : "";
                string reminder = ReminderDate.HasValue ? $" (Remind: {ReminderDate.Value.ToShortDateString()})" : "";
                return $"{status}{Title}: {Description}{reminder}";
            }
        }

        // Constructor - initializes component and loads existing tasks
        public TaskAssistantPage()
        {
            InitializeComponent();
            UpdateTaskList();  // Load tasks from TaskManager when page loads
        }

        // Event handler for Add Task button click
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitleBox.Text.Trim();
            string description = TaskDescriptionBox.Text.Trim();

            // Try parse the reminder days input into an int
            bool reminderParsed = int.TryParse(ReminderBox.Text.Trim(), out int days);

            // Validate title input
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            // Calculate reminder date if days were successfully parsed, otherwise null
            DateTime? reminderDate = reminderParsed ? DateTime.Now.AddDays(days) : null;

            // Create new TaskItem object with user inputs
            TaskItem task = new TaskItem
            {
                Title = title,
                Description = description,
                ReminderDate = reminderDate,
                IsCompleted = false
            };

            // Add task to TaskManager's internal storage
            TaskManager.AddTask(task);

            // Refresh task list UI and clear input fields
            UpdateTaskList();
            ClearInputs();

            // Log the new task addition, including reminder if set
            ChatBotGUI.Data.ActivityLogManager.AddTaskAdded(title, reminderDate);
        }

        // Event handler for marking a selected task as completed
        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem is TaskItem task)
            {
                // Mark the task as completed via TaskManager
                TaskManager.CompleteTask(task);
                UpdateTaskList();

                // Log completion action
                ActivityLogManager.AddEntry($"Task marked completed: {task.Title}");
            }
        }

        // Event handler for deleting a selected task
        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem is TaskItem task)
            {
                // Remove task from TaskManager
                TaskManager.DeleteTask(task);
                UpdateTaskList();

                // Log deletion action
                ActivityLogManager.AddEntry($"Task deleted: {task.Title}");
            }
        }

        // Updates the displayed list of tasks in the UI
        private void UpdateTaskList()
        {
            TaskListBox.Items.Clear();

            // Add all tasks from TaskManager to the ListBox
            foreach (var task in TaskManager.Tasks)
            {
                TaskListBox.Items.Add(task);
            }
        }

        // Clears the input fields for adding a new task
        private void ClearInputs()
        {
            TaskTitleBox.Text = "";
            TaskDescriptionBox.Text = "";
            ReminderBox.Text = "";
        }
    }
}
