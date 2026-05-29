using System;
using System.Windows;
using System.Windows.Input;
using CyberSecurityChatbotGUI;

namespace CyberSecurityChatbotGUI
{
    public partial class MainWindow : Window
    {
        // Creates an instance of the chatbot class
        private Chatbot chatbot = new Chatbot();

        public MainWindow()
        {
            // Initializes all GUI components
            InitializeComponent();

            // Plays a voice greeting if the feature exists
            try
            {
                VoiceGreeting.PlayGreeting();
            }
            catch
            {
                // Prevents program crash if voice greeting is unavailable
            }

            // Displays the first chatbot message
            AddMessage("Bot", "Hi! What is your name?");
        }

        // Runs when the Send button is clicked
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Reads text entered by the user
            string input = UserInput.Text;

            // Prevents empty messages from being sent
            if (string.IsNullOrWhiteSpace(input))
                return;

            // Displays the user's message in the chat box.
            AddMessage("You", input);

            // Sends the user input to the chatbot and gets a response
            string response = chatbot.GetResponse(input);

            // Displays the chatbot response
            AddMessage("Bot", response);

            // Clears the textbox after sending the message
            UserInput.Clear();
        }

        // Allows the Enter key to send messages
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Checks if the Enter key was pressed
            if (e.Key == Key.Enter)
            {
                SendButton_Click(sender, null);
            }
        }

        // Adds messages to the chat display area
        private void AddMessage(string sender, string message)
        {
            ChatBox.Document.Blocks.Add(
                new System.Windows.Documents.Paragraph(
                    new System.Windows.Documents.Run($"{sender}: {message}")
                )
            );

            // Automatically scrolls to the latest message
            ChatBox.ScrollToEnd();
        }
    }
}