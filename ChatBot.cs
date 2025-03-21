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

        //initialize the cyber dictionary to give responses
        private CyberDictionary responseDictionary;
        
        public ChatBot(string user)
        {
            this.user = user;
            this.responseDictionary = new CyberDictionary();
            initializeKeywords();
            //string to hold the question
            string question = string.Empty;
            //keep the state true while the chatbot is active
            Boolean state = true;
            do
            {
                //ask question
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(user + " >> :");
                Console.ForegroundColor = ConsoleColor.White;
                question = Console.ReadLine();
                question.ToLower();
                if (question.Equals("exit"))
                {
                    state = false;
                }
                else
                {
                    checkQuestion(question);
                }

            } while (state);

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
                    if (keywords.ContainsKey(words[counter]))
                    {
                        correctwords++;
                    }
                    else
                    {
                        incorrectwords++;
                    }
                }

                //check if no incorrect keywords were entered
                if(incorrectwords <= 1)
                {
                    //loop through the words or the sentence
                    for(int index = 0; index < words.Length; index++)
                    {
                        if (words[index].Contains("password"))
                        {
                            
                            passworddetected = true;

                        }
                        if (words[index].Contains("phishing"))
                        {
                            
                            phishingDetected = true;
                        }
                        
                    }

                }
                else
                {
                    //give error message for not understanding the question
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(bot);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error! I did not understand your question. Please enter a valid question related to cyber security");
                }

                if (passworddetected)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(bot);
                    //give response based on password
                    Console.WriteLine(Response(responseDictionary.getPasswordDictionary()));

                }
                if (phishingDetected)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(bot);
                    //give response based on phishing
                    Console.WriteLine(Response(responseDictionary.getPhishingDictionary()));
                    
                }
            }
            else
            {

                Console.WriteLine(string.Concat(bot, "Please Enter a Valid Question based on cybersecurity..."));
            }
        }

        private void initializeKeywords()
        {
            keywords.Add($"What", 1);
            keywords.Add($"is", 2);
            keywords.Add($"tell",3);
            keywords.Add($"me",4);
            keywords.Add($"about",5);
            keywords.Add($"How",6);
            keywords.Add($"are",7);
            keywords.Add($"you",8);
            keywords.Add($"whats's",9);
            keywords.Add($"your",10);
            keywords.Add($"purpose",11);
            keywords.Add($"can",12);
            keywords.Add($"I",13);
            keywords.Add($"ask",14);
            keywords.Add($"you",15);
            keywords.Add("password", 16);
            keywords.Add("phishing", 17);
            keywords.Add("safe", 18);
            keywords.Add("browsing", 19);
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

                response = String.Concat(( counter + 1), key + '\n' );
            }
            return response;
        }



    }
}