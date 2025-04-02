using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ST10461176_PROG6221_POE
{
    public class ChatBot
    {
        //chatbot string 
        string bot = "ChatBot >> : ";
        //username 
        private string user = string.Empty;
        //dictionary to check the keys based on topic
        private Dictionary<string,int> keywords = new Dictionary<string,int>();

        //creaye cyber dictionary object to give responses
        private CyberDictionary responseDictionary;

        //string to hold the question
        private string question = string.Empty;

        public ChatBot(string user)
        {
            this.user = user;
            this.responseDictionary = new CyberDictionary();
            initializeKeywords();
            
            //keep the state true while the chatbot is active
            Boolean state = true;
            //loop through the chatbot until the user types exit
            do
            {
                //ask question
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(user + " >> :");
                Console.ForegroundColor = ConsoleColor.White;
                question = Console.ReadLine();
                question = question.ToLower();
                //check if the user wants to exit
                if (question.Equals("exit"))
                {
                    //set the state to false to exit the loop
                    state = false;
                }
                else
                {
                    //check the question
                    checkQuestion(question);
                }

            } while (state);//end of loop

        }

        private void checkQuestion(string question)
        {
            Boolean passworddetected = false;
            Boolean phishingDetected = false;
            Boolean safebrowsingDetected = false;
            string[] words;
            if(question != string.Empty)
            {
                
                words = question.Split(' ');
                int correctwords = 0;
                int incorrectwords = 0;
                for(int counter = 0; counter < words.Length; counter++)
                {
                    //check if the word is in the dictionary
                    if (keywords.ContainsKey(words[counter]))
                    {
                        correctwords++;
                    }
                    //check if the word is not in the dictionary
                    else
                    {
                        incorrectwords++;
                    }
                }

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
                        if(!phishingDetected && !passworddetected && !safebrowsingDetected)
                        {
                            botResponse("Remember you can ask me about anything related to cyber security examples include things like password, phishing and safe browsing!", true);
                            break;
                        }
                    }

                }
                else
                {
                    //give error message for not understanding the question of the user or words used not in the dictionary
                   botResponse("I didn't quite understand that. Could you rephrase? Remember to as me about topics related to cyber security", true);
                   
                }

                if (passworddetected)
                {
                    
                    //give response based on password
                    botResponse(Response(responseDictionary.getPasswordDictionary()));
                  

                }
                if (phishingDetected)
                {
                    
                    //give response based on phishing
                    botResponse(Response(responseDictionary.getPhishingDictionary()));
                    
                    
                }
                if(safebrowsingDetected)
                {

                    //give response based on safe browsing
                    botResponse(Response(responseDictionary.getSafeBrosingDictionary()));

                }
              
            }
            else
            {
                //give error message for not understanding the question of the user or words used not in the dictionary
                botResponse("Please type a question related to cyber security or type exit to terminate the program",true);
              
            }
        }

        //initialize the keywords
        private void initializeKeywords()
        {
            keywords.Add($"what", 1);
            keywords.Add($"is", 2);
            keywords.Add($"tell",3);
            keywords.Add($"me",4);
            keywords.Add($"about",5);
            keywords.Add($"how",6);
            keywords.Add($"are",7);
            keywords.Add($"you",8);
            keywords.Add($"what's",9);
            keywords.Add($"your",10);
            keywords.Add($"purpose",11);
            keywords.Add($"can",12);
            keywords.Add($"i",13);
            keywords.Add($"ask",14);
            keywords.Add($"password", 15);
            keywords.Add($"phishing", 16);
            keywords.Add($"safe", 17);
            keywords.Add($"browsing", 18);
            keywords.Add($"safety?", 19);
            keywords.Add($"safety", 20);
            keywords.Add($"more", 21);
            keywords.Add($"how are you?",23);
            keywords.Add($"what's your purpose?", 24);
            keywords.Add($"what can i ask you about?", 25);
            keywords.Add($"and", 26);
        }

        //function to display the bot response
        private void botResponse(string response, bool error = false)
        {
            //check if the response is an error
            if (error)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(bot);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(response);
            }
            //display the response
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(bot);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(response);
            }
                
        }

        //function to retrieve 3 random reponses based on Topic
        private string Response(Dictionary<string,int> Topic)
        {

            string response = string.Empty;
            //create a local random object
            Random random = new Random();
            //convert dictionary keys to a list for easy random access
            List<string> randomkeys = Topic.Keys.ToList();
            //randomly display 3 values from the dictionary 

            for(int counter = 0; counter < 3; counter++)
            {
                //generate a random index
                int index = random.Next(randomkeys.Count);
                //get the key at the random index
                string key = randomkeys[index];
                //get the corresponding value pair at index
                int value = Topic[key];
                //concatinate or join the responses on a new line
                response = response +'\n'+ String.Concat(( counter + 1), ". ", key );
            }
            //return the response
            return response;
        }



    }
}