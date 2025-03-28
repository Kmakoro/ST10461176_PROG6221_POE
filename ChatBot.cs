﻿using System;
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
            Boolean tellmeabout = false;
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
                if(incorrectwords == 0)
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
                    Console.WriteLine("I didn't quite understand that. Could you rephrase?");
                }

                if (passworddetected)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(bot);
                    Console.ForegroundColor = ConsoleColor.White;
                    //give response based on password
                    Console.WriteLine(Response(responseDictionary.getPasswordDictionary()));

                }
                if (phishingDetected)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(bot);
                    Console.ForegroundColor = ConsoleColor.White;
                    //give response based on phishing
                    Console.WriteLine(Response(responseDictionary.getPhishingDictionary()));
                    
                }
            }
            else
            {

                Console.WriteLine(string.Concat(bot, "I didn't quite understand that. Could you rephrase?"));
            }
        }

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

                response = response +'\n'+ String.Concat(( counter + 1), ". ", key );
            }
            return response;
        }



    }
}