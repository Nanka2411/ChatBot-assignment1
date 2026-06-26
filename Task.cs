using System;

namespace CyberSecurityChatbotGUI
{
    // Represents a cybersecurity task stored in the system/database
    public class Task
    {
        // Unique identifier for each task
        public int TaskID { get; set; }

        // Title or short name of the task
        public string Title { get; set; }

        // Detailed description of what the task involves
        public string Description { get; set; }

        // Date and time when the user should be reminded about the task
        public DateTime ReminderDate { get; set; }

        // Current status of the task (e.g., Pending, Completed)
        public string Status { get; set; }
    }
}