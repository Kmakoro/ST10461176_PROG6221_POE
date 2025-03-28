﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10461176_PROG6221_POE
{
    class CyberDictionary
    {
        private Dictionary<string, int> passwordsTopic = new Dictionary<string, int>();
        private Dictionary<string, int> phishingTopic = new Dictionary<string, int>();
        private Dictionary<string, int> safeBrowsingTopic = new Dictionary<string, int>();

        public CyberDictionary()
        {
            password();
            phishing();
            safebrowsing();
        }


        public Dictionary<string,int> getPasswordDictionary()
        {
            return this.passwordsTopic;
        }
        public Dictionary<string, int> getPhishingDictionary()
        {
            return this.phishingTopic;
        }
        public Dictionary<string, int> getSafeBrosingDictionary()
        {
            return this.safeBrowsingTopic;
        }
        private void password()
        {
            passwordsTopic.Add($"Create passwords that are at least 12-16 characters long and include a mix of uppercase letters, lowercase letters, numbers, and special characters (e.g., !, @, #, $).", 1);
            passwordsTopic.Add($"Reusing the same password across multiple accounts is risky. If one account is compromised, hackers can access all your other accounts.",2);
            passwordsTopic.Add($"Use unique passwords for every account, especially for sensitive accounts like email, banking, and social media", 3);
            passwordsTopic.Add($"Adding an extra layer of security, such as a one-time code sent to your phone or an authenticator app, makes it much harder for attackers to access your accounts, even if they have your password.", 4);
            passwordsTopic.Add($"Password managers securely store and generate strong, unique passwords for all your accounts. You only need to remember one master password to access them.", 5);
            passwordsTopic.Add($"Change your passwords periodically, especially for critical accounts. If you suspect a breach or notice unusual activity, update your password immediately.", 6);
            passwordsTopic.Add($"Avoid Dictionary Words: Hackers use tools that can easily guess passwords based on common words or phrases.", 7);
            passwordsTopic.Add($"Hackers often trick people into revealing their passwords through fake emails, websites, or messages. Always verify the sender's identity and avoid clicking on suspicious links.", 8);
        }
        private void phishing()
        {
            phishingTopic.Add($"Phishing attacks trick victims into revealing sensitive information by pretending to be a trusted entity, such as a bank, government agency, or popular website.", 1);
            phishingTopic.Add($"Suspicious Sender Addresses: Check the email address carefully—phishing emails often use misspelled or fake domains (e.g., support@amaz0n.com).", 2);
            phishingTopic.Add($"Unexpected Attachments or Links: Be cautious of unsolicited emails with attachments or links, especially if they claim to be invoices, receipts, or important documents", 3);
            phishingTopic.Add($"Phishing attacks often direct you to fake websites that look identical to legitimate ones (e.g., a fake banking login page).", 4);
            phishingTopic.Add($"If you fall for a phishing scam, attackers can steal your personal information, access your bank accounts, or even commit identity theft.", 5);
            phishingTopic.Add($"Phishing is also a common way for hackers to install malware or ransomware on your device.", 6);
            phishingTopic.Add($"Phishing is Constantly Evolving: Attackers are using more sophisticated techniques, such as AI-generated emails and deepfake voice calls, to make their scams harder to detect.", 7);
            phishingTopic.Add($"Report Phishing Attempts: If you receive a phishing email, report it to your email provider or the organization being impersonated. Many companies have dedicated channels for reporting phishing.", 8);
        }

        private void safebrowsing()
        {
            safeBrowsingTopic.Add($"Always ensure the websites you visit use HTTPS (Hypertext Transfer Protocol Secure) instead of HTTP. HTTPS encrypts data between your browser and the website, protecting it from interception.", 1);
            safeBrowsingTopic.Add($"Regularly update your web browser, operating system, and plugins/extensions to patch security vulnerabilities.", 2);
            safeBrowsingTopic.Add($"Be cautious of links in emails, social media messages, or pop-up ads, especially if they seem too good to be true or create a sense of urgency.", 3);
            safeBrowsingTopic.Add($"Hover over links to see the actual URL before clicking, and avoid visiting untrusted or unfamiliar websites.", 4);
            safeBrowsingTopic.Add($"Install and maintain antivirus software to detect and block malware, phishing attempts, and other online threats.", 5);
            safeBrowsingTopic.Add($"Enable a firewall to monitor and control incoming and outgoing network traffic.", 6);
            safeBrowsingTopic.Add($"Only download files or software from trusted sources, such as official websites or app stores.", 7);
            safeBrowsingTopic.Add($"Avoid downloading pirated software or media, as they often contain malware.", 8);
        }
    }
}
