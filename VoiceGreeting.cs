using System;
using System.Media;
using System.IO;
using System.Windows;

namespace CyberSecurityChatbotGUI
{
    public class VoiceGreeting
    {
        public static void PlayGreeting()
        {
            try
            {
                string path = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Audio",
                    "cyber.wav.wav"
                );

                if (!File.Exists(path))
                {
                    MessageBox.Show("Audio file not found:\n" + path);
                    return;
                }

                SoundPlayer player = new SoundPlayer(path);
                player.Load();
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Audio error:\n" + ex.Message);
            }
        }
    }
}