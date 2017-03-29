using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeConverter
{
    class Program
    {
        static string codePath = "morse.csv.txt";
        static string answerPath = "Translations.txt";

        public static Dictionary<string, string> CompileMorseCode()
        {
            var morseCode = new Dictionary<string, string>();
            using (var reader = new StreamReader(codePath))
            {
                while (reader.Peek() > -1)
                {
                    var message = reader.ReadLine();
                    var split = message.Split(',');
                    morseCode.Add(split[0], split[1]);
                }
            }
            morseCode.Add(" ", " ");
            return morseCode;
        }
        public static string AskForMessage()
        {
            Console.WriteLine("Enter a message:");
            var sentence = Console.ReadLine().ToUpper();
            return sentence;
        }
        public static void DisplayTranslation(string sentence, Dictionary<string, string>morseCode)
        {
            foreach (var letter in sentence)
            {
                    Console.Write(morseCode[letter.ToString()]);
            }
        }
        public static void WriteToCSV(string sentence, Dictionary<string, string>morseCode)
        {
            using (StreamWriter w = File.AppendText(answerPath))
            {
                foreach (var letter in sentence)
                {
                    w.Write(morseCode[letter.ToString()]);
                }
                w.Write($"{sentence}");
            }
        }
        public static string AnotherMessage()
        {
            Console.WriteLine("Another message?(Y)es/(N)o");
            string answer = Console.ReadLine().ToUpper();
            return answer;
        }


        static void Main(string[] args)
        {
            Dictionary <string,string>morseCode = CompileMorseCode();
            var sentence = AskForMessage();
            DisplayTranslation(sentence,morseCode);
            WriteToCSV(sentence,morseCode);
            string answer = AnotherMessage();
            if (answer == "Y")
            {
                AskForMessage();
                DisplayTranslation(sentence, morseCode);
                WriteToCSV(sentence,morseCode);
                AnotherMessage();
            }
            else { Console.WriteLine("Thanks for visiting!"); }               
        }
    }
}
