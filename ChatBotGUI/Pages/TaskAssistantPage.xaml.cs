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
        // TaskItem class
        public class TaskItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? ReminderDate { get; set; }
            public bool IsCompleted { get; set; }

            public override string ToString()
            {
                string status = IsCompleted ? "[Completed] " : "";
                string reminder = ReminderDate.HasValue ? $" (Remind: {ReminderDate.Value.ToShortDateString()})" : "";
                return $"{status}{Title}: {Description}{reminder}";
            }
        }

        public TaskAssistantPage()
        {
            InitializeComponent();
            UpdateTaskList();  // Load tasks from TaskManager when page loads
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitleBox.Text.Trim();
            string description = TaskDescriptionBox.Text.Trim();
            bool reminderParsed = int.TryParse(ReminderBox.Text.Trim(), out int days);

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            DateTime? reminderDate = reminderParsed ? DateTime.Now.AddDays(days) : null;

            TaskItem task = new TaskItem
            {
                Title = title,
                Description = description,
                ReminderDate = reminderDate,
                IsCompleted = false
            };

            TaskManager.AddTask(task);

            UpdateTaskList();
            ClearInputs();

            // Log task added with optional reminder
            ChatBotGUI.Data.ActivityLogManager.AddTaskAdded(title, reminderDate);
        }

        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem is TaskItem task)
            {
                TaskManager.CompleteTask(task);
                UpdateTaskList();

                ActivityLogManager.AddEntry($"Task marked completed: {task.Title}");
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem is TaskItem task)
            {
                TaskManager.DeleteTask(task);
                UpdateTaskList();

                ActivityLogManager.AddEntry($"Task deleted: {task.Title}");
            }
        }

        private void UpdateTaskList()
        {
            TaskListBox.Items.Clear();

            foreach (var task in TaskManager.Tasks)
            {
                TaskListBox.Items.Add(task);
            }
        }

        private void ClearInputs()
        {
            TaskTitleBox.Text = "";
            TaskDescriptionBox.Text = "";
            ReminderBox.Text = "";
        }
    }
}
