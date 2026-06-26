using System.Collections.Generic;
using System.Linq;

namespace CyberSecurityChatbotGUI
{
    public class ActivityLogger
    {
        private List<string> logs = new List<string>();

        public void Add(string action)
        {
            logs.Add(action);
        }

        public string GetRecent()
        {
            if (logs.Count == 0)
                return "No activity yet.";

            var recent = logs
                .TakeLast(10)
                .Reverse()
                .ToList();

            string result = "Recent Activity:\n";

            for (int i = 0; i < recent.Count; i++)
            {
                result += $"{i + 1}. {recent[i]}\n";
            }

            return result;
        }
    }
}