using System;
using System.Windows;
using System.Windows.Input;

namespace CyberSecurityChatbotGUI
{
    public partial class MainWindow : Window
    {
        private Chatbot chatbot = new Chatbot();
        private QuizManager quiz = new QuizManager();
        private ActivityLogger logger = new ActivityLogger();
        private DatabaseHelper db = new DatabaseHelper();

        private bool quizActive = false;

        // ===== FIX ADDED =====
        private bool waitingForDelete = false;
        private bool waitingForReminder = false;
        private string pendingTask = "";

        public MainWindow()
           
        {
            InitializeComponent();
            AddMessage("Bot", "Welcome! Ask me about cybersecurity or type 'quiz' or 'tasks'.");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VoiceGreeting.PlayGreeting();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            AddMessage("You", input);
            logger.Add("User: " + input);

            string lower = input.ToLower();

            // ================= DELETE TASK FIX =================
            if (lower.Contains("delete task"))
            {
                AddMessage("Bot", "Please enter the Task ID to delete:");
                waitingForDelete = true;
                UserInput.Clear();
                return;
            }

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

            // ================= TASKS =================
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

            // ================= NLP TASK FIX =================
            if (lower.Contains("remind me") || lower.Contains("add task") || lower.Contains("create task"))
            {
                pendingTask = input;
                waitingForReminder = true;

                AddMessage("Bot", "Got it. When should I remind you? (tomorrow or X days)");
                logger.Add("NLP task detected");

                UserInput.Clear();
                return;
            }

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

            // ================= QUIZ =================
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

            // ================= LOG =================
            else if (lower.Contains("log") || lower.Contains("activity"))
            {
                AddMessage("Bot", logger.GetRecent());
            }

            // ================= NLP CHATBOT =================
            else
            {
                AddMessage("Bot", chatbot.GetResponse(input));
            }

            UserInput.Clear();
        }

        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            AddMessage("Bot", db.GetTasks());
        }

        private void Quiz_Click(object sender, RoutedEventArgs e)
        {
            quizActive = true;
            quiz.Reset();
            AddMessage("Bot", quiz.GetNextQuestion());
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            AddMessage("Bot", logger.GetRecent());
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SendButton_Click(sender, null);
        }

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