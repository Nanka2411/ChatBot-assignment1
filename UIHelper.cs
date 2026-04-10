using System; // Required for Console operations like WriteLine, ForegroundColor, etc.

// A static helper class for UI-related functionality
public static class UIHelper
{
    // Method to display a fancy ASCII logo for the chatbot
    public static void DisplayLogo()
    {
        // Change the text color to blue for the logo
        Console.ForegroundColor = ConsoleColor.Blue;

        // Display the ASCII art logo
        // The @ symbol allows multi-line string literals
        Console.WriteLine(@"
╔══════════════════════════════════════════════════════════════════════╗
║                                                                      ║
║   ██████╗██╗   ██╗██████╗ ███████╗██████╗  ██████╗  █████╗ ██╗       ║
║  ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗ ██╔══██╗██╔══██╗██║       ║
║  ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝ ██████╔╝███████║██║       ║
║  ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗ ██╔═══╝ ██╔══██║██║       ║
║  ╚██████╗   ██║   ██████╔╝███████╗██║  ██║ ██║     ██║  ██║███████╗  ║
║   ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝ ╚═╝     ╚═╝  ╚═╝╚══════╝  ║
║                                                                      ║
║               Cybersecurity Awareness Bot                            ║
║                 Protect Yourself Online                              ║
║                                                                      ║
╚══════════════════════════════════════════════════════════════════════╝
");

        // Reset the console text color back to default
        Console.ResetColor();
    }
}