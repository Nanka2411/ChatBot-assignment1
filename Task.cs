using System;

namespace CyberSecurityChatbotGUI
{
    public class Task
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReminderDate { get; set; }
        public string Status { get; set; }
    }
}
