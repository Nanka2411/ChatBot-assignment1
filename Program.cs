using CyberSecurityChatbot; 
using System;                
using System.Media;           // for playing audio sounds (like greeting voice)

// Set the console window title
Console.Title = "Cybersecurity Awareness Bot";

// Display the chatbot logo (from your UIHelper class)
UIHelper.DisplayLogo();

// Play a voice greeting when the program starts
VoiceGreeting.PlayGreeting();

// Ask the user for their name
Console.ForegroundColor = ConsoleColor.Yellow; // Set text color for input prompt
Console.Write("\nEnter your name: ");
Console.ResetColor(); // Resets the text color back to default

// Read user input for name
string nameInput = Console.ReadLine();

// If the user doesn't enter a name, use a default
if (string.IsNullOrWhiteSpace(nameInput))
{
    nameInput = "User";
}

// Create a User object with the entered name
User user = new User { Name = nameInput };

// Set console text color for bot messages
Console.ForegroundColor = ConsoleColor.Cyan;

// Greet the user with their name
Console.WriteLine($"\nHello {user.Name}! Welcome to the Cybersecurity Awareness Bot.");

// Display the list of topics the chatbot can answer
Console.WriteLine("You can ask me questions about the following cybersecurity topics:");
Console.WriteLine("1. password safety");
Console.WriteLine("2. phishing");
Console.WriteLine("3. safe browsing");
Console.WriteLine("4. malware");
Console.WriteLine("5. public wifi");

// Inform the user how to exit the chatbot
Console.WriteLine("Type 'exit' to close the chatbot.");

// starts the chatbot session, passing in the User object
Chat.StartChat(user);