using System;
using Microsoft.Data.SqlClient;

namespace CyberSecurityChatbotGUI
{
    public class DatabaseHelper
    {
        // Connection string used to connect the application to the CyberBot SQL Server database.
        private string connectionString =
            "Server=.\\SQLEXPRESS;Database=CyberBot;Trusted_Connection=True;TrustServerCertificate=True";

        // ================= ADD TASK =================

        // This method adds a new cybersecurity task to the Tasks table in the database.
        // It stores the task title, description, reminder date and sets the status to "Pending".
        public void AddTask(string title, string desc, DateTime reminder)
        {
            try
            {
                // Creates and opens a connection to the database.
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL INSERT statement used to add a new task.
                    string query = @"INSERT INTO Tasks 
                                    (Title, Description, ReminderDate, Status) 
                                    VALUES (@t, @d, @r, 'Pending')";

                    // Creates the SQL command and adds parameter values.
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@t", title);
                        cmd.Parameters.AddWithValue("@d", desc);
                        cmd.Parameters.AddWithValue("@r", reminder);

                        // Executes the INSERT command.
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Displays an error message if the task could not be added.
                System.Windows.MessageBox.Show("AddTask Error: " + ex.Message);
            }
        }

        // ================= GET TASKS =================

        // This method retrieves all tasks stored in the database
        // and returns them as a formatted string.
        public string GetTasks()
        {
            string result = "";

            try
            {
                // Opens a connection to the database.
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL query to retrieve all records from the Tasks table.
                    string query = "SELECT * FROM Tasks";

                    // Executes the query and reads the results.
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Formats each task for display in the chatbot.
                            result += $"{reader["TaskID"]}. {reader["Title"]} - {reader["Status"]}\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Returns an error message if the database cannot be accessed.
                return "Error: " + ex.Message;
            }

            // Returns a message if there are no tasks; otherwise returns the task list.
            return string.IsNullOrEmpty(result) ? "No tasks found." : result;
        }

        // ================= DELETE TASK =================

        // This method deletes a task from the database
        // using the TaskID entered by the user.
        public void DeleteTask(int taskId)
        {
            try
            {
                // Opens a connection to the database.
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL DELETE statement to remove the selected task.
                    string query = "DELETE FROM Tasks WHERE TaskID = @id";

                    // Creates the SQL command and supplies the TaskID parameter.
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", taskId);

                        // Executes the DELETE command.
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Displays an error message if the task could not be deleted.
                System.Windows.MessageBox.Show("DeleteTask Error: " + ex.Message);
            }
        }
    }
}
