using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;


    namespace ChatBotGUI.Data
    {
    public class CyberSecurityDictionary
    {
        public static class Program
        {


            // Declaring the dictionary as "public static" so it can be accessed from the Menu class.
            public static Dictionary<string, List<string>> keyValuePairs = new Dictionary<string, List<string>>()
        {
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        // A collection of cybersecurity terminologies paired with their corresponding definition
        // Assisted by Ai(ChatGPT)
        /// </summary

    {"Cybersecurity", new List<string> {
        "It is the practice of protecting systems, networks, and programs from digital attacks."
    }},
    {"Phishing", new List<string> {
        "A fraudulent attempt to steal sensitive information by pretending to be trustworthy."
    }},
    {"Malware", new List<string> {
        "Malicious software designed to harm or exploit devices and networks."
    }},
    {"Firewall", new List<string> {
        "Monitors and filters network traffic based on security rules."
    }},
    {"Encryption", new List<string> {
        "The process that converts data into a code to prevent unauthorized access."
    }},
    {"Decryption", new List<string> {
        "The process of converting encrypted data back into readable form."
    }},
    {"Ransomware", new List<string> {
        "Software that locks systems and demands payment to restore access."
    }},
    {"Spyware", new List<string> {
        "Software that secretly collects information about a user's activities."
    }},
    {"Trojan Horse", new List<string> {
        "Disguises as legitimate software but is malicious."
    }},
    {"Adware", new List<string> {
        "Displays unwanted ads on your device automatically."
    }},
    {"Botnet", new List<string> {
        "A network of infected computers controlled remotely by attackers."
    }},
    {"DDoS Attack", new List<string> {
        "Floods a target with excessive traffic to disrupt service."
    }},
    {"Social Engineering", new List<string> {
        "Manipulates people to reveal confidential information."
    }},
    {"Antivirus", new List<string> {
        "Software that detects and removes malicious programs from computers."
    }},
    {"Two-Factor Authentication (2FA)", new List<string> {
        "An extra security step requiring two forms of verification."
    }},
    {"Zero-Day Vulnerability", new List<string> {
        "A security flaw unknown to the software maker."
    }},
    {"Backdoor", new List<string> {
        "A hidden entry allowing unauthorized access to a system."
    }},
    {"VPN (Virtual Private Network)", new List<string> {
        "Encrypts your internet traffic and hides your IP address."
    }},
    {"Brute Force Attack", new List<string> {
        "Attempts to guess passwords by trying all possible combinations."
    }},
    {"Keylogger", new List<string> {
        "Records every keystroke made on a device secretly."
    }},
    {"Patch", new List<string> {
        "A software update that fixes bugs or security vulnerabilities."
    }}
};
            // Add this right below your existing keyValuePairs dictionary:
            // Dictionary to store helpful cybersecurity tips for each term
            /// <summary>
            // A collection of cybersecurity keyTips paired with their corresponding term
            // Assisted by Ai(ChatGPT)
            /// </summary
            public static Dictionary<string, List<string>> keyTips = new Dictionary<string, List<string>>()
{
    {"Cybersecurity", new List<string> {
        "Always use strong, unique passwords for every account.",
        "Keep all your software and operating systems updated regularly."
    }},
    {"Phishing", new List<string> {
        "Be cautious of unsolicited emails asking for personal information.",
        "Verify URLs before clicking on links in emails or messages."
    }},
    {"Malware", new List<string> {
        "Install and regularly update reputable antivirus software.",
        "Avoid downloading software or files from untrusted sources."
    }},
    {"Firewall", new List<string> {
        "Enable firewalls on all your devices to block unauthorized access.",
        "Regularly review firewall settings to ensure proper protection."
    }},
    {"Encryption", new List<string> {
        "Use encryption tools to protect sensitive data both in transit and at rest.",
        "Always use strong encryption protocols such as AES or RSA."
    }},
    {"Decryption", new List<string> {
        "Only decrypt data using trusted software and authorized keys.",
        "Keep your decryption keys secure and never share them openly."
    }},
    {"Ransomware", new List<string> {
        "Regularly backup important files to offline or cloud storage.",
        "Never pay ransom; instead, report the attack to authorities."
    }},
    {"Spyware", new List<string> {
        "Install anti-spyware tools and scan your devices frequently.",
        "Avoid clicking on suspicious pop-ups or downloading unknown apps."
    }},
    {"Trojan Horse", new List<string> {
        "Download software only from official and trusted sources.",
        "Use comprehensive security solutions that detect hidden malware."
    }},
    {"Adware", new List<string> {
        "Be careful when installing free software, opt-out of bundled adware.",
        "Use ad-blockers and regularly scan for unwanted adware programs."
    }},
    {"Botnet", new List<string> {
        "Keep your devices updated to prevent them from becoming infected.",
        "Use strong passwords on all your devices to prevent unauthorized control."
    }},
    {"DDoS Attack", new List<string> {
        "Use network traffic monitoring to detect unusual spikes early.",
        "Employ DDoS protection services if you run a public-facing website."
    }},
    {"Social Engineering", new List<string> {
        "Never share sensitive information over the phone or email without verifying the requester.",
        "Be skeptical of urgent requests and always double-check identities."
    }},
    {"Antivirus", new List<string> {
        "Keep your antivirus software updated and run regular scans.",
        "Avoid downloading attachments or clicking links from unknown senders."
    }},
    {"Two-Factor Authentication (2FA)", new List<string> {
        "Enable 2FA on all accounts that support it for extra security.",
        "Use an authenticator app rather than SMS for stronger protection."
    }},
    {"Zero-Day Vulnerability", new List<string> {
        "Apply security patches promptly when they become available.",
        "Use intrusion detection systems to identify suspicious activity."
    }},
    {"Backdoor", new List<string> {
        "Regularly audit systems to detect unauthorized access points.",
        "Keep software updated to patch potential backdoors."
    }},
    {"VPN (Virtual Private Network)", new List<string> {
        "Always connect through a trusted VPN on public Wi-Fi networks.",
        "Choose VPN providers that do not log your activity."
    }},
    {"Brute Force Attack", new List<string> {
        "Use complex passwords with a mix of characters and symbols.",
        "Implement account lockout policies after multiple failed login attempts."
    }},
    {"Keylogger", new List<string> {
        "Avoid downloading software from untrusted sources to prevent keylogger installation.",
        "Use virtual keyboards or password managers to reduce keylogging risk."
    }},
    {"Patch", new List<string> {
        "Apply patches and updates as soon as they are released.",
        "Test patches in a controlled environment before wide deployment."
    }},
};
            // Supplies emotional intelligence to the chatbot.
            // Maps each keyword to a set of emotional responses (worried, curious, frustrated).
            // Helps tailor tips and assist based on how the user feels about a topic.
            // Assisted by Ai(ChatGPT)

            public static Dictionary<string, Dictionary<string, string>> sentimentMessages = new Dictionary<string, Dictionary<string, string>>()
            {
                { "cybersecurity", new Dictionary<string, string>
                {
                    { "worried", "It's completely understandable to feel worried about cybersecurity. Let me share some tips to help you stay safe." },
                    { "curious", "It's great that you're curious about cybersecurity. Let me share some tips to help you stay safe." },
                    { "frustrated", "Feeling frustrated is normal when it comes to cybersecurity. Let me share some tips to help you stay safe." }
                } },
                { "phishing", new Dictionary<string, string>
                {
                    { "worried", "It's natural to be worried about phishing scams. Let me share some tips to help you stay safe." },
                    { "curious", "If you're curious about how phishing works, you're not alone. Let me share some tips to help you stay safe." },
                    { "frustrated", "It's frustrating when phishing tricks are hard to spot. Let me share some tips to help you stay safe." }
                } },
                { "malware", new Dictionary<string, string>
                {
                    { "worried", "Worrying about malware is totally understandable. Let me share some tips to help you stay safe." },
                    { "curious", "Curiosity about how malware spreads is smart. Let me share some tips to help you stay safe." },
                    { "frustrated", "It's frustrating dealing with malware threats. Let me share some tips to help you stay safe." }
                } },
                { "firewall", new Dictionary<string, string>
                {
                    { "worried", "It's okay to feel worried about your firewall setup. Let me share some tips to help you stay safe." },
                    { "curious", "Being curious about how firewalls work is a great start. Let me share some tips to help you stay safe." },
                    { "frustrated", "Firewall settings can be frustrating to configure. Let me share some tips to help you stay safe." }
                } },
                { "encryption", new Dictionary<string, string>
                {
                    { "worried", "Feeling worried about encryption is valid. Let me share some tips to help you stay safe." },
                    { "curious", "Curious about how encryption protects your data? Let me share some tips to help you stay safe." },
                    { "frustrated", "Encryption can be confusing and frustrating. Let me share some tips to help you stay safe." }
                } },
                { "decryption", new Dictionary<string, string>
                {
                    { "worried", "It’s natural to be worried about decryption processes. Let me share some tips to help you stay safe." },
                    { "curious", "Curiosity about decryption is good—it’s a key part of secure communication. Let me share some tips to help you stay safe." },
                    { "frustrated", "Decryption can be tricky and frustrating at first. Let me share some tips to help you stay safe." }
                } },
                { "ransomware", new Dictionary<string, string>
                {
                    { "worried", "Ransomware threats are scary, and it’s okay to be worried. Let me share some tips to help you stay safe." },
                    { "curious", "If you’re curious about ransomware, that’s smart thinking. Let me share some tips to help you stay safe." },
                    { "frustrated", "Dealing with ransomware can be extremely frustrating. Let me share some tips to help you stay safe." }
                } },
                { "spyware", new Dictionary<string, string>
                {
                    { "worried", "Worrying about spyware invading your privacy is valid. Let me share some tips to help you stay safe." },
                    { "curious", "Curious about how spyware works? Let me share some tips to help you stay safe." },
                    { "frustrated", "Spyware can be frustrating to detect and remove. Let me share some tips to help you stay safe." }
                } },
                { "trojan horse", new Dictionary<string, string>
                {
                    { "worried", "It's understandable to feel worried about Trojan Horses. Let me share some tips to help you stay safe." },
                    { "curious", "Trojan Horses are deceptive—being curious about them is smart. Let me share some tips to help you stay safe." },
                    { "frustrated", "It’s frustrating when malware hides as trusted software. Let me share some tips to help you stay safe." }
                } },
                { "adware", new Dictionary<string, string>
                {
                    { "worried", "Adware can be annoying and worrisome. Let me share some tips to help you stay safe." },
                    { "curious", "If you're curious about adware, you're on the right path. Let me share some tips to help you stay safe." },
                    { "frustrated", "Adware pop-ups can be really frustrating. Let me share some tips to help you stay safe." }
                } },
                { "botnet", new Dictionary<string, string>
                {
                    { "worried", "Being worried about botnets is understandable. Let me share some tips to help you stay safe." },
                    { "curious", "If you're curious about how botnets work, you’re not alone. Let me share some tips to help you stay safe." },
                    { "frustrated", "Frustration with botnets is common—they’re stealthy. Let me share some tips to help you stay safe." }
                } },
                { "ddos attack", new Dictionary<string, string>
                {
                    { "worried", "Worrying about DDoS attacks is perfectly valid. Let me share some tips to help you stay safe." },
                    { "curious", "Curiosity about DDoS attacks is a good thing. Let me share some tips to help you stay safe." },
                    { "frustrated", "It’s frustrating when services go down due to DDoS. Let me share some tips to help you stay safe." }
                } },
                { "social engineering", new Dictionary<string, string>
                {
                    { "worried", "Social engineering attacks are sneaky, so it’s normal to feel worried. Let me share some tips to help you stay safe." },
                    { "curious", "Curious about social engineering? Great—awareness is key. Let me share some tips to help you stay safe." },
                    { "frustrated", "It’s frustrating to deal with manipulative tactics. Let me share some tips to help you stay safe." }
                } },
                { "antivirus", new Dictionary<string, string>
                {
                    { "worried", "It's okay to be worried about antivirus protection. Let me share some tips to help you stay safe." },
                    { "curious", "Curiosity about how antivirus works is useful. Let me share some tips to help you stay safe." },
                    { "frustrated", "Antivirus software can be frustrating to manage. Let me share some tips to help you stay safe." }
                } },
                { "two-factor authentication (2fa)", new Dictionary<string, string>
                {
                    { "worried", "It's perfectly fine to be worried about login security. Let me share some tips to help you stay safe with 2FA." },
                    { "curious", "Being curious about 2FA is smart—it strengthens your security. Let me share some tips to help you stay safe." },
                    { "frustrated", "2FA can feel frustrating to use, but it’s worth it. Let me share some tips to help you stay safe." }
                } },
                { "zero-day vulnerability", new Dictionary<string, string>
                {
                    { "worried", "Zero-day vulnerabilities sound alarming—and your concern is valid. Let me share some tips to help you stay safe." },
                    { "curious", "Curiosity about zero-day flaws is important. Let me share some tips to help you stay safe." },
                    { "frustrated", "It's frustrating when unknown bugs become threats. Let me share some tips to help you stay safe." }
                } },
                { "backdoor", new Dictionary<string, string>
                {
                    { "worried", "Backdoors are serious concerns, and it’s okay to feel worried. Let me share some tips to help you stay safe." },
                    { "curious", "Curious about backdoors? Learning more helps. Let me share some tips to help you stay safe." },
                    { "frustrated", "Frustration is normal when backdoors leave systems vulnerable. Let me share some tips to help you stay safe." }
                } },
                { "vpn (virtual private network)", new Dictionary<string, string>
                {
                    { "worried", "It’s normal to be worried about your online privacy. Let me share some tips to help you stay safe with VPNs." },
                    { "curious", "Being curious about VPNs is a smart move. Let me share some tips to help you stay safe." },
                    { "frustrated", "VPNs can be confusing and frustrating. Let me share some tips to help you stay safe." }
                } },
                { "brute force attack", new Dictionary<string, string>
                {
                    { "worried", "Brute force attacks can be worrying, and that’s understandable. Let me share some tips to help you stay safe." },
                    { "curious", "Curious about how brute force attacks work? Let me share some tips to help you stay safe." },
                    { "frustrated", "It's frustrating to think of hackers guessing passwords. Let me share some tips to help you stay safe." }
                } },
                { "keylogger", new Dictionary<string, string>
                {
                    { "worried", "Worrying about keyloggers is completely valid. Let me share some tips to help you stay safe." },
                    { "curious", "If you're curious about how keyloggers operate, you're being proactive. Let me share some tips to help you stay safe." },
                    { "frustrated", "Keyloggers can be sneaky and frustrating. Let me share some tips to help you stay safe." }
                } },
                { "patch", new Dictionary<string, string>
                {
                    { "worried", "It’s natural to worry about unpatched software. Let me share some tips to help you stay safe." },
                    { "curious", "Curious about software patches and why they matter? Let me share some tips to help you stay safe." },
                    { "frustrated", "Keeping up with patches can be frustrating. Let me share some tips to help you stay safe." }
                }



                }
            };
        }
    }
}
    //------------------------------------------------------------------|THE END OF FILE| ------------------------------------------------------------------------------------------//



