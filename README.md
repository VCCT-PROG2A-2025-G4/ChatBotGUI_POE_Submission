# Cybersecurity Awareness ChatBot (WPF GUI)

## What this ChatBot does:

- Greets you with a text-to-speech welcome message
- Prompts for your name for a personalized greeting
- Provides a graphical menu to access:
  - Chat with the bot (implemented)
  - Browse a dictionary of cybersecurity definitions (implemented)
  - Take a cybersecurity quiz
  - Manage tasks with reminders
  - View an activity log of your interactions
  - Exit the application

The chatbot’s conversation logic responds to greetings, cybersecurity keywords, expressions of thanks, and unknown inputs appropriately. The dictionary display functionality shows a list of cybersecurity terms and definitions in a user-friendly GUI.

---

## 📖 Features:

- 🔊 Voice greeting by text-to-speech when the application starts.
- 🙋‍♂️ Personalized user greeting by asking for the user's name.
- 📜 Interactive GUI menu with tabs/pages for:
  - ChatBot conversation with keyword recognition and sentiment detection.
  - Cybersecurity Dictionary with definitions.
  - Cybersecurity Quiz with multiple-choice questions.
  - Task Assistant with task creation, completion, and reminders.
  - Activity Log displaying recent user actions and chatbot responses.
- 💾 Persistent chat history and task management.
- 🔔 Reminders for tasks set with friendly chatbot prompts.
- 📚 Detailed cybersecurity terms and helpful tips.

---

## 📦 Technologies & Packages Used

- C# (.NET Framework 4.7.2+)
- WPF for GUI
- System.Speech.Synthesis for text-to-speech
- MaterialDesignThemes.Wpf for UI styling
- Spectre.Console (used in earlier console versions, no longer core)

---

## 🖥️ How to Run the Project in Visual Studio

### Prerequisites

- Windows OS (for System.Speech)
- Visual Studio 2022 or later
- .NET Framework 4.7.2+ installed

### Steps to Run

1. Clone or download the repository.
2. Open the solution (`.sln`) in Visual Studio.
3. Build the solution (`Build > Build Solution` or Ctrl+Shift+B).
4. Run the program (`Start` button or F5).
5. Interact with the chatbot through the GUI interface.

---

## 🔄 How to Commit & Push Changes (in Visual Studio)

1. Open `View > Git Changes`.
2. Stage your updated files.
3. Type a clear commit message.
4. Click `Commit All`.
5. Click `Push` to upload changes to your connected GitHub repository.

---

## 📜 Credits

- Text-to-speech implemented using `System.Speech.Synthesis`.
- Cybersecurity definitions and tips assisted by ChatGPT and online sources.
- GUI design enhanced with Material Design in XAML Toolkit (`MaterialDesignThemes.Wpf`).
- Sentiment-based chatbot responses and task reminder logic crafted with AI assistance.

---

## DECLARATION OF AI USAGE

This project uses AI assistance in:

- Compiling and refining cybersecurity terms and definitions.
- Designing text and UI styles.
- Debugging and enhancing code quality.
- Suggesting features such as task reminders and activity logging.

---

## Project Code Structure Overview

- **MainWindow.xaml / MainWindow.xaml.cs**  
  The main GUI window hosting navigation and interaction.

- **ChatBotEngine**  
  Core chatbot logic including NLP simulation, quiz, and task management.

- **TaskAssistantPage.xaml / .cs**  
  UI and logic for creating, viewing, completing, and deleting tasks with reminders.

- **ActivityLogManager.cs**  
  Tracks and formats a log of user actions and chatbot events.

- **DictionaryPage.xaml / .cs**  
  Displays cybersecurity dictionary terms and definitions.

- **QuizPage.xaml / .cs**  
  Implements the cybersecurity quiz interface and logic.

---

