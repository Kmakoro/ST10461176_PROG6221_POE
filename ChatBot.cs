using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ST10461176_PROG6221_POE
{
    public class ChatBot
    {
        private string user = string.Empty;
        private Dictionary<string,int> keywords = new Dictionary<string,int>();
        
        public ChatBot(string user)
        {
            this.user = user;
            Console.Write

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