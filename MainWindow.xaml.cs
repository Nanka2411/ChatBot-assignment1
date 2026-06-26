using System;
using System.Windows;
using System.Windows.Input;

namespace CyberSecurityChatbotGUI
{
    public partial class MainWindow : Window
    {
        // Core components used by the chatbot system
        private Chatbot chatbot = new Chatbot();                 // Handles NLP-style responses
        private QuizManager quiz = new QuizManager();            // Manages quiz questions and scoring
        private ActivityLogger logger = new ActivityLogger();    // Stores user and system activity logs
        private DatabaseHelper db = new DatabaseHelper();        // Handles database operations (tasks)

        // Tracks whether the quiz is currently active
        private bool quizActive = false;

        // ===== STATE FLAGS FOR MULTI-STEP USER INPUT =====
        // Used to handle follow-up inputs (delete task, reminders)
        private bool waitingForDelete = false;
        private bool waitingForReminder = false;
        private string pendingTask = "";

        // Constructor - initializes the window and displays welcome message
        public MainWindow()
        {
            InitializeComponent();
            AddMessage("Bot", "Welcome! Ask me about cybersecurity or type 'quiz' or 'tasks'.");
        }

        // Runs when the window is fully loaded
        // Used here to play the startup audio greeting
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VoiceGreeting.PlayGreeting();
        }

        // Handles all user input from the send button / textbox
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            AddMessage("You", input);
            logger.Add("User: " + input);

            string lower = input.ToLower();

            // ================= DELETE TASK FLOW =================
            // Step 1: Detect delete command
            if (lower.Contains("delete task"))
            {
                AddMessage("Bot", "Please enter the Task ID to delete:");
                waitingForDelete = true;
                UserInput.Clear();
                return;
            }

            // Step 2: Process Task ID input
            if (waitingForDelete)
            {
                if (int.TryParse(input, out int id))
                {
                    db.DeleteTask(id);
                    AddMessage("Bot", "Task deleted successfully.");
                    logger.Add($"Task deleted (ID: {id})");
                }
                else
                {
                    AddMessage("Bot", "Invalid ID. Please enter a number.");
                }

                waitingForDelete = false;
                UserInput.Clear();
                return;
            }

            // ================= TASK MANAGEMENT =================
            if (lower.Contains("add task"))
            {
                db.AddTask("Cyber Task", input, DateTime.Now.AddDays(3));
                AddMessage("Bot", "Task added successfully.");
                logger.Add("Task added");
            }
            else if (lower.Contains("view tasks"))
            {
                AddMessage("Bot", db.GetTasks());
                logger.Add("Viewed tasks");
            }

            // ================= NLP REMINDER FLOW =================
            // Detects natural language task requests
            if (lower.Contains("remind me") || lower.Contains("add task") || lower.Contains("create task"))
            {
                pendingTask = input;
                waitingForReminder = true;

                AddMessage("Bot", "Got it. When should I remind you? (tomorrow or X days)");
                logger.Add("NLP task detected");

                UserInput.Clear();
                return;
            }

            // Processes reminder timing input
            if (waitingForReminder)
            {
                DateTime reminderDate = DateTime.Now.AddDays(7);

                if (lower.Contains("tomorrow"))
                    reminderDate = DateTime.Now.AddDays(1);
                else if (lower.Contains("day"))
                    reminderDate = DateTime.Now.AddDays(3);

                db.AddTask("Cyber Task", pendingTask, reminderDate);

                AddMessage("Bot", $"Task created: '{pendingTask}'");
                logger.Add("Task created via NLP");

                waitingForReminder = false;
                pendingTask = "";

                UserInput.Clear();
                return;
            }

            // ================= QUIZ SYSTEM =================
            else if (lower.Contains("quiz"))
            {
                quizActive = true;
                quiz.Reset();
                AddMessage("Bot", quiz.GetNextQuestion());
                logger.Add("Quiz started");
            }
            else if (quizActive)
            {
                AddMessage("Bot", quiz.CheckAnswer(lower));

                string next = quiz.GetNextQuestion();

                if (next == null)
                {
                    AddMessage("Bot", quiz.GetFinalScore());
                    quizActive = false;
                    logger.Add("Quiz completed");
                }
                else
                {
                    AddMessage("Bot", next);
                }
            }

            // ================= ACTIVITY LOG =================
            else if (lower.Contains("log") || lower.Contains("activity"))
            {
                AddMessage("Bot", logger.GetRecent());
            }

            // ================= DEFAULT NLP CHATBOT =================
            else
            {
                AddMessage("Bot", chatbot.GetResponse(input));
            }

            UserInput.Clear();
        }

        // Displays all tasks from the database when button is clicked
        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            AddMessage("Bot", db.GetTasks());
        }

        // Starts the quiz when button is clicked
        private void Quiz_Click(object sender, RoutedEventArgs e)
        {
            quizActive = true;
            quiz.Reset();
            AddMessage("Bot", quiz.GetNextQuestion());
        }

        // Displays recent activity logs
        private void Log_Click(object sender, RoutedEventArgs e)
        {
            AddMessage("Bot", logger.GetRecent());
        }

        // Handles Enter key as Send button trigger
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SendButton_Click(sender, null);
        }

        // Adds messages to the chat display area
        private void AddMessage(string sender, string message)
        {
            ChatBox.Document.Blocks.Add(
                new System.Windows.Documents.Paragraph(
                    new System.Windows.Documents.Run($"{sender}: {message}")
                )
            );

            ChatBox.ScrollToEnd();
        }
    }
}