using System;
using System.Collections.Generic;

namespace CyberSecurityChatbotGUI
{
    public class Chatbot
    {
        // Stores user information like name and interests
        private Dictionary<string, string> memory = new Dictionary<string, string>();

        // Keeps track of which tips and extra info have already been shown
        private Dictionary<string, int> tipIndex = new Dictionary<string, int>();
        private Dictionary<string, int> extraIndex = new Dictionary<string, int>();

        // Tracks if a definition has already been shown for a topic
        private Dictionary<string, bool> showedDefinition = new Dictionary<string, bool>();

        // Remembers the last topic discussed
        private string lastTopic = "";

        // Used to ask for the user's name only once
        private bool waitingForName = true;

        // Used for random responses
        private Random random = new Random();

        // Delegate used to call different response methods
        private delegate string ResponseDelegate(string topic);
        private ResponseDelegate responseHandler;

        // Stores chatbot responses for each topic
        private Dictionary<string, List<string>> responses;

        // Stores definitions for topics
        private Dictionary<string, List<string>> definitions;

        // Stores extra information for topics
        private Dictionary<string, List<string>> extraInfo;

        // Stores tips for topics
        private Dictionary<string, List<string>> tips;

        public Chatbot()
        {
            // Main responses shown after the definition
            responses = new Dictionary<string, List<string>>()
            {
                ["password"] = new()
                {
                    "Use strong passwords with symbols and numbers.",
                    "Avoid personal information in passwords.",
                    "Never reuse passwords.",
                    "Use a password manager."
                },

                ["phishing"] = new()
                {
                    "Phishing tricks users into revealing data.",
                    "Check sender emails carefully.",
                    "Avoid clicking unknown links.",
                    "Look for urgency in messages."
                },

                ["privacy"] = new()
                {
                    "Privacy is controlling your personal data.",
                    "Limit app permissions.",
                    "Avoid oversharing online.",
                    "Enable 2FA."
                },

                ["scam"] = new()
                {
                    "Scams trick users into losing money or data.",
                    "Verify suspicious messages.",
                    "Avoid urgent requests for money.",
                    "Use official channels."
                },

                ["malware"] = new()
                {
                    "Malware harms devices and steals data.",
                    "Avoid unknown downloads.",
                    "Keep antivirus updated.",
                    "Update your system regularly."
                }
            };

            // Definitions for each cybersecurity topic
            definitions = new Dictionary<string, List<string>>()
            {
                ["password"] = new() { "A password is a secret used to protect accounts." },

                ["phishing"] = new()
                {
                    "Phishing is a scam that steals personal information."
                },

                ["privacy"] = new()
                {
                    "Privacy is control over your personal information."
                },

                ["scam"] = new()
                {
                    "A scam is a trick used to steal money or data."
                },

                ["malware"] = new()
                {
                    "Malware is software designed to harm systems or steal data."
                }
            };

            // Additional information users can request
            extraInfo = new Dictionary<string, List<string>>()
            {
                ["password"] = new()
                {
                    "Use at least 12 characters.",
                    "Avoid names or birthdays.",
                    "Use password managers."
                },

                ["phishing"] = new()
                {
                    "Check email domains carefully.",
                    "Hover over links before clicking.",
                    "Scammers create urgency."
                },

                ["privacy"] = new()
                {
                    "Turn off location sharing.",
                    "Limit app permissions.",
                    "Review privacy settings regularly."
                },

                ["scam"] = new()
                {
                    "Always verify unknown requests.",
                    "Never send money quickly under pressure.",
                    "Be cautious of fake offers."
                },

                ["malware"] = new()
                {
                    "Avoid unknown files.",
                    "Use antivirus software.",
                    "Keep systems updated."
                }
            };

            // Helpful cybersecurity tips
            tips = new Dictionary<string, List<string>>()
            {
                ["password"] = new()
                {
                    "Never reuse passwords.",
                    "Enable two-factor authentication.",
                    "Use a password manager."
                },

                ["phishing"] = new()
                {
                    "Never click suspicious links.",
                    "Check sender email carefully.",
                    "Report phishing attempts."
                },

                ["privacy"] = new()
                {
                    "Limit app permissions.",
                    "Avoid oversharing personal info.",
                    "Turn off location tracking when not needed."
                },

                ["scam"] = new()
                {
                    "Do not trust urgent money requests.",
                    "Verify before sending information.",
                    "Use official websites only."
                },

                ["malware"] = new()
                {
                    "Keep antivirus updated.",
                    "Avoid unknown downloads.",
                    "Do not plug unknown USB devices."
                }
            };
        }

        // Main chatbot response method
        public string GetResponse(string input)
        {
            // Checks if the user entered nothing
            if (string.IsNullOrWhiteSpace(input))
                return "Please enter a message.";

            // Stores original input before converting to lowercase
            string original = input;
            input = input.ToLower();

            // First message is treated as the user's name
            if (waitingForName)
            {
                waitingForName = false;
                memory["name"] = original;

                return $"Hello {original}, what cybersecurity topic would you like to learn about?\n\n" +
                       "1. Password\n2. Phishing\n3. Privacy\n4. Scam\n5. Malware";
            }

            // Detects worried or confused emotions
            if (input.Contains("worried") ||
                input.Contains("confused") ||
                input.Contains("frustrated") ||
                input.Contains("stressed"))
            {
                string topic = DetectTopic(input);

                // Gives a definition if a topic is detected
                if (!string.IsNullOrEmpty(topic))
                {
                    lastTopic = topic;
                    return HandleResponse(topic, "definition");
                }

                return "It's okay. Let me guide you step by step.";
            }

            // Goodbye message
            if (input.Contains("bye") || input.Contains("goodbye"))
                return $"Goodbye {memory["name"]}! Stay safe online.";

            // Thank you response
            if (input.Contains("thanks") || input.Contains("thank you"))
                return $"You're welcome {memory["name"]}!";

            // Stores user interests in memory
            if (input.Contains("i like"))
            {
                string topic = input.Replace("i like", "").Trim();

                memory["interest"] = topic;

                return $"I'll remember you're interested in {topic}.";
            }

            // Detects requests for tips
            if (input.Contains("tip") ||
                input.Contains("another tip") ||
                input.Contains("give me a tip") ||
                input.Contains("how do i protect") ||
                input.Contains("protect"))
            {
                string detectedTipTopic = DetectTipTopic(input);

                // Gives a tip for the detected topic
                if (!string.IsNullOrEmpty(detectedTipTopic))
                {
                    lastTopic = detectedTipTopic;
                    return GetTip(detectedTipTopic);
                }

                // Uses the last discussed topic if none detected
                if (!string.IsNullOrEmpty(lastTopic))
                    return GetTip(lastTopic);

                return "Tell me a topic first (password, phishing, privacy, scam, malware).";
            }

            // Detects requests for more explanation
            if (input.Contains("tell me more") ||
                input.Contains("explain") ||
                input.Contains("i don't understand"))
            {
                return GetExtra(lastTopic);
            }

            // Detects the topic from user input
            string topicDetected = DetectTopic(input);

            if (!string.IsNullOrEmpty(topicDetected))
            {
                lastTopic = topicDetected;

                // Shows definition first time only
                if (!showedDefinition.ContainsKey(topicDetected))
                {
                    showedDefinition[topicDetected] = true;
                    return HandleResponse(topicDetected, "definition");
                }

                // Gives random responses after definition
                return HandleResponse(topicDetected, "random");
            }

            // Default response if chatbot does not understand
            return $"I’m not sure, {memory["name"]}. Try password, phishing, privacy, scam, or malware.";
        }

        // Uses the delegate to choose the correct response method
        private string HandleResponse(string topic, string mode)
        {
            if (mode == "definition")
                responseHandler = GetDefinition;

            else if (mode == "extra")
                responseHandler = GetExtra;

            else if (mode == "tip")
                responseHandler = GetTip;

            else
                responseHandler = GetRandomResponse;

            return responseHandler(topic);
        }

        // Returns the definition for a topic
        private string GetDefinition(string topic)
        {
            return definitions[topic][0];
        }

        // Returns a random response from the list
        private string GetRandomResponse(string topic)
        {
            var list = responses[topic];
            return list[random.Next(list.Count)];
        }

        // Returns extra information without repeating immediately
        private string GetExtra(string topic)
        {
            if (!extraInfo.ContainsKey(topic))
                return "Ask a topic first.";

            if (!extraIndex.ContainsKey(topic))
                extraIndex[topic] = 0;

            var list = extraInfo[topic];

            if (extraIndex[topic] < list.Count)
                return list[extraIndex[topic]++];

            return "No more extra information.";
        }

        // Returns tips one at a time
        private string GetTip(string topic)
        {
            if (!tips.ContainsKey(topic))
                return "Tell me a topic like password, phishing, privacy, scam, or malware.";

            if (!tipIndex.ContainsKey(topic))
                tipIndex[topic] = 0;

            var list = tips[topic];

            if (tipIndex[topic] < list.Count)
                return list[tipIndex[topic]++];

            return "You’ve seen all tips for this topic.";
        }

        // Detects the topic from user input
        private string DetectTopic(string input)
        {
            if (input.Contains("password") || input.Contains("2fa"))
                return "password";

            if (input.Contains("phishing") || input.Contains("scam"))
                return "phishing";

            if (input.Contains("privacy"))
                return "privacy";

            if (input.Contains("malware") || input.Contains("virus"))
                return "malware";

            return "";
        }

        // Detects which topic the user wants tips for
        private string DetectTipTopic(string input)
        {
            if (input.Contains("password") || input.Contains("login"))
                return "password";

            if (input.Contains("phishing") || input.Contains("scam"))
                return "phishing";

            if (input.Contains("privacy"))
                return "privacy";

            if (input.Contains("malware"))
                return "malware";

            return "";
        }
    }
}