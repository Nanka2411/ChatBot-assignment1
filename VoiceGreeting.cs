using System;
using System.Media;
using System.IO;
using System.Windows;

namespace CyberSecurityChatbotGUI
{
    public class VoiceGreeting
    {
        // This method plays the chatbot's welcome audio
        // when the application starts.
        public static void PlayGreeting()
        {
            try
            {
                // Creates the full file path to the audio file
                // stored inside the Audio folder.
                string path = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Audio",
                    "cyber.wav.wav"
                );

                // Checks whether the audio file exists before attempting to play it.
                if (!File.Exists(path))
                {
                    MessageBox.Show("Audio file not found:\n" + path);
                    return;
                }

                // Creates a SoundPlayer object, loads the audio file,
                // and plays the greeting sound.
                SoundPlayer player = new SoundPlayer(path);
                player.Load();
                player.Play();
            }
            catch (Exception ex)
            {
                // Displays an error message if the audio cannot be loaded or played.
                MessageBox.Show("Audio error:\n" + ex.Message);
            }
        }
    }
}