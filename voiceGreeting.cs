using System;
using System.IO;
using System.Media;

namespace ST10461176_PROG6221_POE
{
    internal class voiceGreeting
    {
        public voiceGreeting()
        {
            //get the app full location
            string full_location = AppDomain.CurrentDomain.BaseDirectory;
            //set new path to root directory of app
            string new_path = full_location.Replace("bin\\Debug\\", "");
            //set final path of the audio recording
            string voicePath = Path.Combine(new_path, "sound.wav");

            //try to load and play the voice greeting
            try
            {
                //function to initialize and play the sound recording
                using(SoundPlayer voice = new SoundPlayer(voicePath))
                {
                    //load the audio file first
                    voice.Load();
                    //Play the Audio using play sync to not interupt any windows sound media thats currently playing
                    voice.PlaySync();
                }
            }catch(Exception ex)
            {
                //display appropriate error message
                Console.WriteLine(ex.Message);
            }

        }
    }
}