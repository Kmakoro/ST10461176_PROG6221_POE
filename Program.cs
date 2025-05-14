namespace ST10461176_PROG6221_POE
{
    class Program
    {
        static void Main(string[] args)
        {
            //voice greeting
            //class with a constructor
            new voiceGreeting() { };
            //logo
            //class with a constructor
            new logo() { };
            //user class
            UserLogin user = new UserLogin();
            user.setUsername();
            //chatbot initialize
            new ChatBot(user.getUsername()) { };



        }
    }
}
