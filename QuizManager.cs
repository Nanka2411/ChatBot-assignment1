using System;
using System.Collections.Generic;

namespace CyberSecurityChatbotGUI
{
    public class QuizManager
    {
        // Stores all quiz questions, correct answers, and explanations
        private List<(string question, string answer, string explanation)> questions;

        // Tracks the current question index
        private int index = 0;

        // Tracks the user's score
        private int score = 0;

        // Constructor: initializes the quiz questions
        public QuizManager()
        {
            questions = new List<(string, string, string)>
            {
                // Each tuple contains: question, correct answer, explanation

                ("What is phishing? (a) fishing (b) scam emails (c) hacking tools", "b",
                    "Phishing is fake emails used to steal information."),

                ("Strong passwords should include? (a) name (b) 1234 (c) symbols", "c",
                    "Symbols make passwords harder to guess."),

                ("True or False: Malware is good software", "false",
                    "Malware is harmful software."),

                ("What does 2FA do? (a) removes password (b) adds security (c) slows internet", "b",
                    "2FA adds extra login security."),

                ("Safe browsing means? (a) clicking all links (b) visiting trusted sites (c) downloading everything", "b",
                    "Only trusted sites are safe."),

                ("True or False: You should share your password", "false",
                    "Never share your password."),

                ("What is social engineering? (a) tricking people (b) coding (c) firewall", "a",
                    "It is manipulating people to give info."),

                ("Best WiFi practice? (a) open wifi (b) secured wifi (c) no password", "b",
                    "Secure WiFi protects your data."),

                ("What is a firewall? (a) game (b) security barrier (c) virus", "b",
                    "Firewall blocks threats."),

                ("True or False: Updates improve security", "true",
                    "Updates fix security issues.")
            };
        }

        // Returns the next quiz question or null if quiz is finished
        public string GetNextQuestion()
        {
            if (index >= questions.Count)
                return null;

            return questions[index].question;
        }

        // Checks the user's answer, gives feedback, and updates score
        public string CheckAnswer(string input)
        {
            // Gets correct answer for current question
            string correct = questions[index].answer;

            // Determines if user's answer matches correct answer
            bool isCorrect =
                input.Contains(correct.ToLower()) ||
                input.Trim().ToLower() == correct;

            // Builds feedback message
            string feedback = isCorrect ? "Correct! " : "Wrong! ";

            // Updates score if answer is correct
            if (isCorrect)
                score++;

            // Adds explanation for learning
            feedback += questions[index].explanation;

            // Moves to next question
            index++;

            return feedback;
        }

        // Returns final score and performance message
        public string GetFinalScore()
        {
            return $"Final Score: {score}/{questions.Count}\n" +
                   (score >= 7 ? "Great job! You're a cybersecurity pro!" :
                    "Keep learning to stay safe online!");
        }

        // Resets quiz so it can be played again
        public void Reset()
        {
            index = 0;
            score = 0;
        }
    }
}