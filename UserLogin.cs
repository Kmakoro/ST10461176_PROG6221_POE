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

            Console.Write("Hello, Please input your username >> ");
            this.username = Console.ReadLine();
            //using the string function to combine strings
            Console.WriteLine(String.Concat("Hello ", this.username));
        }
        //getter
        public string getUsername()
        {
            return this.username;
        }
    }
}