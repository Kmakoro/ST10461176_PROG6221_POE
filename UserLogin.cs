using System;

namespace ST10461176_PROG6221_POE
{
    public class UserLogin
    {
        //create an empty string variable
        private string username = string.Empty; 

        //setter
        public void setUsername()
        {
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Hello, Please input your username >> ");
            Console.ForegroundColor = ConsoleColor.White;
            this.username = Console.ReadLine();
            //using the string function to combine strings
            Console.ForegroundColor = ConsoleColor.Green;
            ChatBot.botResponse(String.Concat("Hello ", this.username, " weclome to CoCo your AI-powered cybersecurity assistant, " +
                "Whether you’re defending against threats, securing your systems, or just looking for best practices, I’m here to help you stay safe in the digital world."));
            
        }
        //getter
        public string getUsername()
        {
            return this.username;
        }
    }
}