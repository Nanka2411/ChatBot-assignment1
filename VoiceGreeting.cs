using System.Media;

namespace CyberSecurityChatbotGUI
{

    // PURPOSE:Plays an audio greeting when the application starts


    public static class VoiceGreeting
    {
        
        // METHOD: PlayGreeting
        // PURPOSE:Loads and plays a WAV audio file to welcome the user.
       
        
        public static void PlayGreeting()
        {
            try
            {
                // Create a SoundPlayer instance and load the audio file
                // The file path points to the stored WAV file in the Assets folder
                SoundPlayer player = new SoundPlayer("Assets/cyber.wav.wav");

                // Play the sound asynchronously (does not freeze the UI)
                player.Play();
            }
            catch
            {

                // ERROR HANDLING: If the file is missing or cannot be played,the application continues without crashing
                
                

                // Fail silently to avoid disrupting user experience or marking
            }
        }
    }
}