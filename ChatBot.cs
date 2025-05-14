using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace ST10461176_PROG6221_POE
{
    public class ChatBot
    {
        bool password = false;
        bool phishing = false;
        bool safebrowsing = false;
        bool virus = false;
        bool malware = false;
        bool ransomware = false;

        bool passwordMemory = false;
        bool phishingMemory = false;
        bool safebrowsingMemory = false;
        bool virusMemory = false;
        bool malwareMemory = false;
        bool ransomwareMemory = false;


        int programLoopCounter = 0;

        static List<string> save_Data = new List<string>();

        //username 
        private string user = string.Empty;
        //creaye cyber dictionary object to give responses
        private CyberDictionary responseDictionary;
        //string to hold the question
        private string question = string.Empty;
        private MemoryRecall memoryRecall;
        //constructor to initialize the chatbot
        public ChatBot(string user)
        {
            this.user = user;
            responseDictionary = new CyberDictionary();
            memoryRecall = new MemoryRecall(user);

            if (memoryRecall.fileExists)
            {

                botResponse("I have saved your previous questions and responses. Do you want to see them?\nType Yes to load or No to continue without loading");
                string input = Console.ReadLine();
                input = input.ToLower();
                programLoopCounter = 0;
                if (input.Equals("yes"))
                {
                    displayMemory(memoryRecall.return_memory());
                }

            }

            //keep the state true while the chatbot is active
            Boolean state = true;
            //loop through the chatbot until the user types exit
            do
            {
                //method to ask question
                askquestion();
                programLoopCounter++;
                //check if the user wants to exit
                if (question.Equals("exit") || question.Equals("quit") || question.Equals("q"))
                {
                    //set the state to false to exit the loop
                    memoryRecall.save_memory(save_Data);
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
            if (programLoopCounter == 2 || programLoopCounter == 6)
            {
                if (passwordMemory)
                {
                    botResponse("I remember you asked about passwords before. Do you have any new questions about it?");
                }
                if (phishingMemory)
                {
                    botResponse("I remember you asked about phishing before. Do you have any new questions about it?");
                }
                if (safebrowsingMemory)
                {
                    botResponse("I remember you asked about safe browsing before. Do you have any new questions about it?");
                }
                if (virusMemory)
                {
                    botResponse("I remember you asked about viruses before. Do you have any new questions about it?");
                }
                if (malwareMemory)
                {
                    botResponse("I remember you asked about malware before. Do you have any new questions about it?");
                }
                if (ransomwareMemory)
                {
                    botResponse("I remember you asked about ransomware before. Do you have any new questions about it?");
                }
            }
            if (programLoopCounter == 3)
            {
                if (password)
                {
                    botResponse("Remember to use strong passwords and avoid sharing them with anyone. If you have any questions about password security");
                    programLoopCounter = 0;
                }
                if (phishing)
                {
                    botResponse("Be cautious of phishing attempts. Always verify the source before clicking on links or providing personal information");
                    programLoopCounter = 0;
                }
                if (safebrowsing)
                {
                    botResponse("Safe browsing is important. Make sure to use secure connections and be cautious of suspicious websites");
                    programLoopCounter = 0;
                }
                if (virus)
                {
                    botResponse("Viruses can be harmful to your system. Ensure you have up-to-date antivirus software and avoid downloading unknown files");
                    programLoopCounter = 0;
                }
                if (malware)
                {
                    botResponse("Malware can compromise your system. Always be cautious of downloads and use reliable security software");
                    programLoopCounter = 0;
                }
                if (ransomware)
                {
                    botResponse("Ransomware can be devastating. Always back up your data and be cautious of suspicious emails and downloads");
                    programLoopCounter = 0;
                }
            }
            //display the question
            if (password)
            {
                botResponse("Feel free to ask me more about passwords");

            }
            if (phishing)
            {
                botResponse("Feel free to ask me more about phishing");

            }
            if (safebrowsing)
            {
                botResponse("Feel free to ask me more about safe browsing");

            }
            if (virus)
            {
                botResponse("Feel free to ask me more about viruses");

            }
            if (malware)
            {
                botResponse("Feel free to ask me more about malware");

            }
            if (ransomware)
            {
                botResponse("Feel free to ask me more about ransomware");

            }
            //display the question
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Please enter your question below or type 'exit', 'quit', or 'q' to terminate the program");
            Console.Write(user + " >> : ");
            Console.ForegroundColor = ConsoleColor.White;
            question = Console.ReadLine();
            save_Data.Add(user + " >> : " + question);
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


            //create a local string variable to hold the words
            string[] words;//array for the split function to split words

            //begin working if the string is not empty
            if (question != string.Empty)
            {

                words = question.Split(' ');
                int correctwords = 0;
                int incorrectwords = 0;
                //loop to check if the question contains correct words in the dictionary if not then the user will have to be prompted again
                for (int counter = 0; counter < words.Length; counter++)
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
                if (incorrectwords == 0)
                {
                    //loop through the words or the sentence
                    for (int index = 0; index < words.Length; index++)
                    {
                        //check if the user is asking about passwords
                        if (words[index].Contains("password"))
                        {

                            passworddetected = true;
                            password = true;

                        }
                        //check if the user is asking about phishing
                        if (words[index].Contains("phishing"))
                        {

                            phishingDetected = true;
                            phishing = true;
                        }
                        //check if the user is asking about safe browsing
                        if (question.Contains("safe browsing"))
                        {

                            safebrowsingDetected = true;
                            safebrowsing = true;
                        }
                        //check if the user is asking about virus
                        if (words[index].Contains("virus"))
                        {
                            virusdeteDetected = true;
                            virus = true;
                        }
                        //check if the user is asking about malware
                        if (words[index].Contains("malware"))
                        {
                            malwareDetected = true;
                            malware = true;
                        }
                        //check if the user is asking about ransomware
                        if (words[index].Contains("ransomware"))
                        {
                            ransomwareDetected = true;
                            ransomware = true;
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
                    botResponse((Response(responseDictionary.getPasswordDictionary(), "\tPassword")) + "\n" + checkSentiment(question));
                    //give response based on password
                    if (programLoopCounter == 1)
                    {
                        //give response based on password
                        botResponse("Thank you I will make sure to remember that you are asking about passwords");
                    }
                }
                //if phishing has been detected then proceed
                if (phishingDetected)
                {
                    //give response based on phishing
                    botResponse((Response(responseDictionary.getPhishingDictionary(), "\tPhishing")) + "\n" + checkSentiment(question));
                    if (programLoopCounter == 1)
                    {
                        //give response based on phishing
                        botResponse("Thank you I will make sure to remember that you are asking about phishing");
                    }

                }
                //if safe browsing has been detected then proceed
                if (safebrowsingDetected)
                {
                    //give response based on safe browsing
                    botResponse((Response(responseDictionary.getSafeBrosingDictionary(), "\tSafe Browsing")) + "\n" + checkSentiment(question));
                    if (programLoopCounter == 1)
                    {
                        //give response based on safe browsing
                        botResponse("Thank you I will make sure to remember that you are asking about safe browsing");
                    }

                }
                if (virusdeteDetected)
                {
                    //give response based on virus
                    botResponse((Response(responseDictionary.getVirusDictionary(), "\tVirus")) + "\n" + checkSentiment(question));
                    if (programLoopCounter == 1)
                    {
                        //give response based on virus
                        botResponse("Thank you I will make sure to remember that you are asking about virus");
                    }
                }
                if (malwareDetected)
                {
                    //give response based on malware
                    botResponse((Response(responseDictionary.getMalwareDictionary(), "\tMalware")) + "\n" + checkSentiment(question));
                    if (programLoopCounter == 1)
                    {
                        botResponse("Thank you I will make sure to remember that you are asking about malware");
                    }
                }
                if (ransomwareDetected)
                {
                    //give response based on ransomware
                    botResponse((Response(responseDictionary.getRansomwareDictionary(), "\tRansomware")) + "\n" + checkSentiment(question));
                    if (programLoopCounter == 1)
                    {
                        //give response based on ransomware
                        botResponse("Thank you I will make sure to remember that you are asking about ransomware");
                    }
                }

            }
            //else if the string is empty display appropriate message
            else
            {
                //give error message for not understanding the question of the user or words used not in the dictionary
                botResponse("Please type a question related to cyber security or type exit to terminate the program", true);

            }
        }

        //method to check sentiment of the user
        private string checkSentiment(string question)
        {
            //create a local string variable to hold the words
            string[] words;//array for the split function to split words
            //split the question into words
            words = question.Split(' ');
            //loop through the words or the sentence
            for (int index = 0; index < words.Length; index++)
            {
                if (words[index].Contains("happy"))
                {//using lambda expression
                    return responseDictionary.sentimentKeyword.FirstOrDefault(x => x.Key == "happy").Value;
                }
                if (words[index].Contains("sad"))
                {
                    //using lambda expression
                    return responseDictionary.sentimentKeyword.FirstOrDefault(x => x.Key == "sad").Value;
                }
                if (words[index].Contains("excited"))
                {
                    //using lambda expression
                    return responseDictionary.sentimentKeyword.FirstOrDefault(x => x.Key == "excited").Value;
                }
                if (words[index].Contains("worried"))
                {
                    //using lambda expression
                    return responseDictionary.sentimentKeyword.FirstOrDefault(x => x.Key == "worried").Value;
                }
                if (words[index].Contains("frustrated"))
                {
                    //using lambda expression
                    return responseDictionary.sentimentKeyword.FirstOrDefault(x => x.Key == "frustrated").Value;
                }
                if (words[index].Contains("angry"))
                {
                    //using lambda expression
                    return responseDictionary.sentimentKeyword.FirstOrDefault(x => x.Key == "angry").Value;
                }
                if (words[index].Contains("scared"))
                {
                    //using lambda expression
                    return responseDictionary.sentimentKeyword.FirstOrDefault(x => x.Key == "scared").Value;
                }
                if (words[index].Contains("curious"))
                {
                    //using lambda expression
                    return responseDictionary.sentimentKeyword.FirstOrDefault(x => x.Key == "curious").Value;
                }
            }
            return "";
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
                Console.WriteLine(string.Concat("\t", response));
                save_Data.Add(bot + "\t" + response);
            }
            //display the response
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(bot);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t");
                for (int counter = 0; counter < response.Length; counter++)
                {
                    Console.Write(response[counter]);
                    Thread.Sleep(20);
                }
                save_Data.Add(bot + "\t" + response);
                //Console.WriteLine(string.Concat("\t", response));
                Console.WriteLine();

            }

        }

        private void displayMemory(List<string> memory)
        {

            foreach (string line in memory)
            {
                Console.WriteLine(line);
                if (line.Contains("password"))
                {
                    passwordMemory = true;
                }
                if (line.Contains("phishing"))
                {
                    phishingMemory = true;
                }
                if (line.Contains("safe browsing"))
                {
                    safebrowsingMemory = true;
                }
                if (line.Contains("virus"))
                {
                    virusMemory = true;
                }
                if (line.Contains("malware"))
                {
                    malwareMemory = true;
                }
                if (line.Contains("ransomware"))
                {
                    ransomwareMemory = true;
                }
            }

        }

        //function to retrieve 3 random reponses based on Topic
        private string Response(List<string> Topic, string optional = null)
        {
            //local string variable to hold the response
            string response = string.Empty;
            //create a local random object
            Random random = new Random();
            //convert dictionary keys to a list for easy random access
            //List<string> randomkeys = Topic.Keys.ToList();

            string[] arrayTopic = (string[])Topic.ToArray();
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