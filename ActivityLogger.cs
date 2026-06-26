using System.Collections.Generic;
using System.Linq;

namespace CyberSecurityChatbotGUI
{
    // This class tracks and stores all user and system activities
    // such as tasks, quiz actions, and chatbot interactions.
    public class ActivityLogger
    {
        // Stores all logged actions in memory
        private List<string> logs = new List<string>();

        // Adds a new action to the activity log
        public void Add(string action)
        {
            logs.Add(action);
        }

        // Retrieves the most recent activities (last 10 actions)
        // and formats them for display in the chatbot UI
        public string GetRecent()
        {
            // If no logs exist, return default message
            if (logs.Count == 0)
                return "No activity yet.";

            // Gets the last 10 actions and reverses them
            // so newest actions appear first
            var recent = logs
                .TakeLast(10)
                .Reverse()
                .ToList();

            string result = "Recent Activity:\n";

            // Formats each log entry with numbering
            for (int i = 0; i < recent.Count; i++)
            {
                result += $"{i + 1}. {recent[i]}\n";
            }

            return result;
        }
    }
}