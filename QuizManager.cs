using System;
using System.Collections.Generic;

namespace CyberSecurityChatbotGUI
{
    public class QuizManager
    {
        private List<(string question, string answer, string explanation)> questions;
        private int index = 0;
        private int score = 0;

        public QuizManager()
        {
            questions = new List<(string, string, string)>
            {
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

        public string GetNextQuestion()
        {
            if (index >= questions.Count)
                return null;

            return questions[index].question;
        }

        public string CheckAnswer(string input)
        {
            string correct = questions[index].answer;

            bool isCorrect =
                input.Contains(correct.ToLower()) ||
                input.Trim().ToLower() == correct;

            string feedback = isCorrect ? "Correct! " : "Wrong! ";

            if (isCorrect)
                score++;

            feedback += questions[index].explanation;

            index++;
            return feedback;
        }

        public string GetFinalScore()
        {
            return $"Final Score: {score}/{questions.Count}\n" +
                   (score >= 7 ? "Great job! You're a cybersecurity pro!" :
                    "Keep learning to stay safe online!");
        }

        public void Reset()
        {
            index = 0;
            score = 0;
        }
    }
}