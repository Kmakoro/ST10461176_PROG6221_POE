using System;
using System.Collections;
using System.Threading;

namespace ST10461176_PROG6221_POE
{
    public class ChatBot
    {
        
        //username 
        private string user = string.Empty;
        //creaye cyber dictionary object to give responses
        private CyberDictionary responseDictionary;
        //string to hold the question
        private string question = string.Empty;

        //constructor to initialize the chatbot
        public ChatBot(string user)
        {
            this.user = user;
            this.responseDictionary = new CyberDictionary();
            
            
            //keep the state true while the chatbot is active
            Boolean state = true;
            //loop through the chatbot until the user types exit
            do
            {
                //method to ask question
                askquestion();

                //check if the user wants to exit
                if (question.Equals("exit")||question.Equals("quit") || question.Equals("q"))
                {
                    //set the state to false to exit the loop
                    botResponse("Thank you for using CoCo your AI-powered cybersecurity assistant. Have a great day!");
                    state = false;
                }
                else
                {
                    //check the question
                    checkQuestion(question);
                }

            } while (state);//end of loop

        }

        private void askquestion()
        {
            //ask question
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Please enter your question below or type 'exit', 'quit', or 'q' to terminate the program");
            Console.Write(user + " >> : ");
            Console.ForegroundColor = ConsoleColor.White;
            question = Console.ReadLine();
            question = question.ToLower();
        }

        private void checkQuestion(string question)
        {
            Boolean passworddetected = false;
            Boolean phishingDetected = false;
            Boolean safebrowsingDetected = false;
            Boolean virusdeteDetected = false;
            Boolean malwareDetected = false;
            Boolean ransomwareDetected = false;
            
            string[] words;//array for the split function to split words

            //begin working if the string is not empty
            if(question != string.Empty)
            {
                
                words = question.Split(' ');
                int correctwords = 0;
                int incorrectwords = 0;
                //loop to check if the question contains correct words in the dictionary if not then the user will have to be prompted again
                for(int counter = 0; counter < words.Length; counter++)
                {
                    //check if the word is in the dictionary
                    if (responseDictionary.getKeywords().Contains(words[counter]))
                    {
                        correctwords++;
                    }
                    //check if the word is not in the dictionary
                    else
                    {
                        incorrectwords++;
                    }
                }//end of loop

                //check if no incorrect keywords were entered
                if(incorrectwords == 0)
                {
                    //loop through the words or the sentence
                    for(int index = 0; index < words.Length; index++)
                    {
                        //check if the user is asking about passwords
                        if (words[index].Contains("password"))
                        {
                            
                            passworddetected = true;

                        }
                        //check if the user is asking about phishing
                        if (words[index].Contains("phishing"))
                        {
                            
                            phishingDetected = true;
                        }
                        //check if the user is asking about safe browsing
                        if (question.Contains("safe browsing"))
                        {

                            safebrowsingDetected = true;
                        }
                        //check if the user is asking about virus
                        if (words[index].Contains("virus"))
                        {
                            virusdeteDetected = true;
                        }
                        //check if the user is asking about malware
                        if (words[index].Contains("malware"))
                        {
                            malwareDetected = true;
                        }
                        //check if the user is asking about ransomware
                        if (words[index].Contains("ransomware")){
                            ransomwareDetected = true;
                        }
                        //provide a response to the user to greet the user
                        if (question.Contains("hello"))
                        {
                            botResponse(string.Concat("Hello ", user, " I trust you are well, " +
                                "how would you like me to assist you today? " +
                                "please note this chatbot can only respond to cybersecurity related questions."));
                            break;
                        }
                        //provide a response to the user to know how the chatbot is doing
                        if (question.Contains("how are you"))
                        {
                            botResponse("I'm doing great, thank you for asking. How can I help you today?");
                            break;
                        }
                        //provide a repsonse to the user to know the purpose of the chatbot
                        if (question.Contains("what's your purpose"))
                        {
                           botResponse("I'm here to help you with any questions you have about cybersecurity. Feel free to ask me anything!");
                            break;
                        }
                        //provaide a response for the user to know what they can ask the chatbot
                        if (question.Contains("what can i ask you about"))
                        {
                            botResponse("You can ask me about passwords, phishing, safe browsing, and more. Just type your question, and I'll do my best to help!");
                            break;
                        }

                        //provide a response to a user should there be a question without direct meaning
                       /* if(!phishingDetected && !passworddetected && !safebrowsingDetected)
                        {
                            botResponse("Remember you can ask me about anything related to cyber security examples include things like password, phishing and safe browsing!", true);
                            break;
                        }*/
                    }

                }
                //else give error should there be incorrect or non-words entered
                else
                {
                    //give error message for not understanding the question of the user or words used not in the dictionary
                   botResponse("I didn't quite understand that. Could you rephrase? Remember to as me about topics related to cyber security", true);
                   
                }

                //if password has been detected then proceed
                if (passworddetected)
                {
                    
                    //give response based on password
                    botResponse(Response(responseDictionary.getPasswordDictionary(),"\tPassword"));
                  

                }
                //if phishing has been detected then proceed
                if (phishingDetected)
                {
                    
                    //give response based on phishing
                    botResponse(Response(responseDictionary.getPhishingDictionary(),"\tPhishing"));
                    
                    
                }
                //if safe browsing has been detected then proceed
                if(safebrowsingDetected)
                {

                    //give response based on safe browsing
                    botResponse(Response(responseDictionary.getSafeBrosingDictionary(),"\tSafe Browsing"));

                }
                if(virusdeteDetected)
                {
                    //give response based on virus
                    botResponse(Response(responseDictionary.getVirusDictionary(), "\tVirus"));
                }
                if (malwareDetected)
                {
                    //give response based on malware
                    botResponse(Response(responseDictionary.getMalwareDictionary(), "\tMalware"));
                }
                if (ransomwareDetected)
                {
                    //give response based on ransomware
                    botResponse(Response(responseDictionary.getRansomwareDictionary(), "\tRansomware"));
                }

            }
            //else if the string is empty display appropriate message
            else
            {
                //give error message for not understanding the question of the user or words used not in the dictionary
                botResponse("Please type a question related to cyber security or type exit to terminate the program",true);
              
            }
        }

       

        //function to display the bot response
        public static void botResponse(string response, bool error = false)
        {
            //chatbot string 
            string bot = "ChatBot >> : ";
            //check if the response is an error
            if (error)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(bot);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Concat("\t",response));
            }
            //display the response
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(bot);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t");
                for(int counter = 0; counter < response.Length; counter++)
                {
                    Console.Write(response[counter]);
                    Thread.Sleep(20);
                }
                //Console.WriteLine(string.Concat("\t", response));
                Console.WriteLine();
               
            }
                
        }

        //function to retrieve 3 random reponses based on Topic
        private string Response(ArrayList Topic, string optional = null)
        {
            //local string variable to hold the response
            string response = string.Empty;
            //create a local random object
            Random random = new Random();
            //convert dictionary keys to a list for easy random access
            //List<string> randomkeys = Topic.Keys.ToList();

            string[] arrayTopic = (string[])Topic.ToArray(typeof(string));
            //randomly display 3 values from the dictionary
            for (int counter = 0; counter < 3; counter++)
            {
                //generate a random index or number
                int index = random.Next(arrayTopic.Length);

                //get the corresponding value pair at index
                string message = arrayTopic[index];
                //concatinate or join the responses on a new line
                response = response + '\n' + String.Concat((counter + 1), ". ", message);
            }
            //return the response should there be an optional value
            if (optional != null)
            {//text formatting and underling the optional value
                return string.Concat(optional, "\n", "\t\t\t", new string('-', optional.Length), "\n", response);
            }
            //return the response
            return response;
        }



    }
}