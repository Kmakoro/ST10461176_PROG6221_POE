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
            Console.WriteLine(String.Concat("Hello ", this.username, " weclome to the Cybersecurity Awareness Bot"));
        }
        //getter
        public string getUsername()
        {
            return this.username;
        }
    }
}