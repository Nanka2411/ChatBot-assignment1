using System;
using System.IO;
using System.Media;

namespace CyberSecurityChatbot
{
    public class VoiceGreeting
    {
        //This method plays a greeting audio file
        public static void PlayGreeting()
        {
            try
            {
                //Creates the full path to the audio file
                //It combines the base directory of the app with the "audio" folder and file name
                string path = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Audio",
                    "cyber.wav.wav"
                );

                //Creates a SoundPlayer object and load the audio file from the path
                SoundPlayer player = new SoundPlayer(path);

                //plays the audio file
                player.Play();
            }
            catch (Exception ex)
            {
                //if a error occurs for example file not found ,it displays an error message.
                Console.WriteLine("Error playing audio: " + ex.Message);
            }
        }
    }
}


