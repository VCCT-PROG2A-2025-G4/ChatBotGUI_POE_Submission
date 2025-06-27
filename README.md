ChatBot (WPF Version – Final POE Part 3)
What this ChatBot does:

Greets you with a text-to-speech welcome message.

Prompts the user for their name for a personalized greeting.

Provides a WPF-based GUI with tabbed navigation that includes:

Start a chat with the bot ✅

Browse a dictionary of cybersecurity definitions ✅

Take a Cybersecurity Knowledge Test ✅

Manage tasks and set reminders ✅

View an activity log of your interactions ✅

The chatbot’s conversation logic responds to greetings, definitions for cybersecurity keywords, expressions of thanks, and unknown inputs. Dictionary functionality displays terms and definitions. The quiz tests knowledge. Task Assistant helps users create and track cybersecurity-related tasks. The Activity Log tracks all user actions.

📖 Features
🔊 Text-to-Speech
Welcome message uses System.Speech.Synthesis.

User can toggle speech on or off from the chat interface.

🧑 Personalized Chat Interface
Bot asks for the user’s name and greets accordingly.

Chat input detects cybersecurity keywords, emotions, and natural language commands like:

add task

remind me in 2 days

show activity log

clear chat

📘 Dictionary Page
Interactive display of 10+ cybersecurity terms with their definitions.

🧠 Quiz Page
21-question multiple-choice quiz based on cybersecurity terms.

Real-time score calculation.

✅ Task Assistant Page
Add, view, and delete cybersecurity tasks.

Optionally set reminder durations in natural language (e.g., "remind me in 2 days").

Task reminder info shown next to each task.

🗂️ Activity Log Page
Displays a summary of all recent user actions (tasks created, reminders set, quiz attempted).

Responds to chat input like show activity log.

📦 Technologies & Packages Used
WPF / .NET (Framework 4.7.2+)

C#

System.Speech.Synthesis for text-to-speech

Spectre.Console for previous console version (now GUI-based)

XAML for UI layout

MVVM-lite architecture for WPF features (if applied)

🖥️ How to Run the Project in Visual Studio
Prerequisites
Windows OS (required for System.Speech.Synthesis)

Visual Studio 2022

.NET Framework 4.7.2 or higher

Steps to Run
Clone the Repository
Visual Studio > Git > Clone Repository
Paste your GitHub repository URL.

Open Solution in Visual Studio

Build Solution
Build > Build Solution or press Ctrl + Shift + B
Ensure there are no errors in the output window.

Run the Project
Press F5 or click Start ▶
The GUI ChatBot will launch.

🔄 How to Commit & Push Changes
Go to View > Git Changes

Stage your updated files

Add a clear commit message

Click Commit All

Click Push to upload to GitHub

📜 Credits
Text-to-speech: Powered by System.Speech.Synthesis

Cybersecurity terms: Curated with the help of ChatGPT & trusted cybersecurity sources

Styling ideas: ChatGPT provided inspiration for color-coded UI and ASCII art (console version)

Keyword Tips & Sentiment Responses: Enhanced using ChatGPT suggestions for user engagement

NLP Command Recognition: Pattern-based string detection for tasks, reminders, and activity log

📂 Project Code Structure Overview
🗂️ MainWindow.xaml / .cs
Hosts all UI tabs (ChatBot, Dictionary, Quiz, Task Assistant, Activity Log)

Maintains persistent state between tabs

Routes user input to the ChatBotEngine

🧠 ChatBotEngine.cs
Processes natural language input

Handles keyword lookup, emotional responses, task creation, reminders, and activity log tracking

Supports voice toggle functionality

📘 Dictionary.cs
Stores key-value pairs of cybersecurity terms and definitions

📑 QuizManager.cs
Contains quiz logic and scoring

📝 TaskAssistantPage.xaml / .cs
Displays task creation UI

Enables task reminders and marking tasks as completed

📊 ActivityLogManager.cs
Tracks all key user actions like task creation, reminders, and quiz scores

🔐 Declaration of AI Usage
I have used AI to assist in:

Sourcing definitions and structuring my cybersecurity dictionary

Styling the console and GUI outputs

Implementing NLP logic for chatbot features like task creation, reminders, and emotional response handling

Debugging and polishing features like voice synthesis and UI consistency
