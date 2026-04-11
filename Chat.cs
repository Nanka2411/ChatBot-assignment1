using System;
using System.Security.Cryptography.X509Certificates;

class Chat
{
    public static void StartChat(User user)
    {
        // variable to remember the last topic user asked about (used for "more" requests)
        string lastTopic = "";

        // Infinite loop to keep chat running until user exits
        while (true)
        {
            try
            {
                // Set console text color for user input
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nYou: ");
                Console.ResetColor();

                // Read user input
                string input = Console.ReadLine();
                input = input.ToLower(); // convert input to lowercase for easier matching

                // Exit condition
                if (input.Contains("exit"))
                {
                    Console.WriteLine($"Bot: Goodbye {user.Name}! Stay safe online.");
                    break; // exit the loop
                }

                // SWITCH statement to handle different user inputs
                switch (true)
                {
                    // Respond to greetings or "how are you"
                    case bool _ when input.Contains("how are you"):
                        Console.WriteLine(value: $"Bot: I'm doing great {user.Name}! Ready to help with cybersecurity questions.");
                        lastTopic = "how are you"; // store the topic for "more"
                        break;

                    // Respond to "purpose" question
                    case bool _ when input.Contains("purpose"):
                        Console.WriteLine("Bot: My purpose is to educate users about cybersecurity awareness.");
                        lastTopic = "purpose"; // store the topic
                        break;

                    // Respond to "password safety" topic
                    case bool _ when input.Contains("password safety"):
                        Console.WriteLine("Bot: Password safety is the practice of creating and managing passwords in a way that keeps your online accounts secure from hackers, identity thieves, and cyber attacks. Strong password practices reduce the risk of unauthorized access to personal, financial, or sensitive information.");
                        lastTopic = "password safety"; // store the topic
                        break;

                    // Respond to "phishing" topic
                    case bool _ when input.Contains("phishing"):
                        Console.WriteLine("Bot: Phishing is a type of cyberattack where someone pretends to be a trusted person or company to trick you into giving away sensitive information.");
                        lastTopic = "phishing"; // store the topic
                        break;

                    // Respond to "safe browsing" topic
                    case bool _ when input.Contains("safe browsing"):
                        Console.WriteLine("Bot: Safe browsing is the practice of using the internet in a way that protects your personal information, device, and privacy from online threats.");
                        lastTopic = "safe browsing"; // store the topic
                        break;

                    // Respond to "malware" topic
                    case bool _ when input.Contains("malware"):
                        Console.WriteLine("Bot: Malware is harmful software designed to damage, steal, or disrupt your device or data.");
                        lastTopic = "malware"; // store the topic
                        break;

                    // Respond to "wifi" topic
                    case bool _ when input.Contains("wifi"):
                        Console.WriteLine("Bot: Public WiFi is a wireless internet network that anyone can connect to, often found in places like cafes, airports, hotels, or libraries. Although convenient, it can be risky because it’s not very secure. Hackers may try to steal your information if you use it without caution.");
                        lastTopic = "wifi"; // store the topic
                        break;

                    // Handle "more" requests to provide additional info on the last topic
                    case bool _ when input.Contains("more"):
                        switch (lastTopic)
                        {
                            case "password safety":
                                Console.WriteLine("Bot: How to avoid or prevent :\r\n\t1. Make strong passwords\r\n\t2. Use uppercase, lowercase, numbers, and symbols.\r\n\t3. Make them long (12–16 characters).\r\n\t4. Don’t use obvious info like your birthday or name.\r\n\t5. Use a different password for each account\r\n\t6. Don’t reuse passwords.\r\n\t7. If one account is hacked, others stay safe.\r\n\r\n3. Change passwords regularly\r\n\t• Update them often, especially for email, bank, or social media.\r\n\t• Change immediately if you think an account was compromised.\r\n\r\n4. Use a password manager\r\n\t• It makes and stores complex passwords for you.\r\n\t• You only need to remember one main password.\r\n\r\n5. Turn on two-factor authentication (2FA)\r\n\t• Adds extra protection by sending a code to your phone or email.\r\n\r\n6. Keep passwords private\r\n\t• Don’t share them or write them in unsafe places.\r\n\r\nExample of a strong password:G7!kP9@zL2#q.");
                                break;

                            case "phishing":
                                Console.WriteLine("Bot: How to prevent/avoid:\r\n\t1. Don’t click on suspicious links in emails or messages\r\n\t2. Check the sender’s email address carefully\r\n\t3. Avoid urgent or threatening messages (“Act now!”)\r\n\t4. Don’t enter personal info on unknown websites\r\n\t5. Look for secure sites (https://)\r\n\t6. Enable two-factor authentication (2FA)\r\n\t7. Verify requests by contacting the company directly.");
                                break;

                            case "safe browsing":
                                Console.WriteLine("Bot: Tips to stay safe:\r\n\t1. Only visit trusted and secure websites (https://)\r\n\t2. Don’t click suspicious links or pop-ups\r\n\t3. Avoid downloading from unknown sources\r\n\t4. Keep your browser and device updated\r\n\t5. Use strong, unique passwords\r\n\t6. Enable two-factor authentication (2FA)\r\n\t7. Log out on public computers\r\n\t8. Be careful when using public Wi-Fi.");
                                break;

                            case "malware":
                                Console.WriteLine("Bot: How to prevent/avoid:\r\n\t1. Don’t download files or apps from untrusted websites\r\n\t2. Avoid clicking suspicious links or pop-ups\r\n\t3. Use antivirus software and keep it updated\r\n\t4. Keep your device/software updated\r\n\t5. Don’t open unknown email attachments\r\n\t6. Use strong, unique passwords\r\n\t7. Only use secure and trusted Wi-Fi networks.");
                                break;

                            case "wifi":
                                Console.WriteLine("Bot: Tips to stay safe on public WiFi:\r\n\t1. Avoid sensitive activities – Don’t log in to banking, email, or shopping accounts unless necessary.\r\n\t2. Use a VPN – A Virtual Private Network encrypts your connection, keeping your data private.\r\n\t3. Check the network – Make sure it’s the official WiFi for the location, not a fake hotspot.\r\n\t4. Keep your device updated – Security updates help protect against vulnerabilities.\r\n\t5. Turn off sharing – Disable file or printer sharing when on public networks.");
                                break;

                            default:
                                Console.WriteLine("Bot: There's no additional info for this topic.");
                                break;
                        }
                        break;

                    // Default response if input is not recognized
                    default:
                        Console.WriteLine("Bot: I didn't quite understand that. Could you rephrase?");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Catch any runtime errors and display message
                Console.WriteLine("Bot: Something went wrong. Try again.");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}