using System;

namespace CyberSecurityChatbotGUI
{
    public class Chatbot
    {
        public string GetResponse(string input)
        {
            input = input.ToLower();

            // ===== NLP SIMULATION (KEYWORD DETECTION) =====
            if (input.Contains("phishing"))
                return "Phishing is when attackers trick you into giving personal information.";

            if (input.Contains("password"))
                return "Use strong passwords with numbers, symbols, and letters.";

            if (input.Contains("malware"))
                return "Malware is harmful software that can damage your device.";

            if (input.Contains("2fa") || input.Contains("two factor"))
                return "Two-factor authentication adds extra security to your account.";

            if (input.Contains("privacy"))
                return "Always review your privacy settings regularly.";

            if (input.Contains("help"))
                return "You can ask about tasks, quiz, phishing, passwords, or malware.";

            return "I didn't fully understand that. Try asking about cybersecurity topics.";
        }
    }
}