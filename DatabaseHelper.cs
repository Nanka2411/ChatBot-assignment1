using System;
using Microsoft.Data.SqlClient;

namespace CyberSecurityChatbotGUI
{
    public class DatabaseHelper
    {
        private string connectionString =
            "Server=.\\SQLEXPRESS;Database=CyberBot;Trusted_Connection=True;TrustServerCertificate=True";

        // ================= ADD TASK =================
        public void AddTask(string title, string desc, DateTime reminder)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Tasks 
                                    (Title, Description, ReminderDate, Status) 
                                    VALUES (@t, @d, @r, 'Pending')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@t", title);
                        cmd.Parameters.AddWithValue("@d", desc);
                        cmd.Parameters.AddWithValue("@r", reminder);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("AddTask Error: " + ex.Message);
            }
        }

        // ================= GET TASKS =================
        public string GetTasks()
        {
            string result = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Tasks";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result += $"{reader["TaskID"]}. {reader["Title"]} - {reader["Status"]}\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }

            return string.IsNullOrEmpty(result) ? "No tasks found." : result;
        }

        // ================= DELETE TASK =================
        public void DeleteTask(int taskId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM Tasks WHERE TaskID = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", taskId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("DeleteTask Error: " + ex.Message);
            }
        }
    }
}



