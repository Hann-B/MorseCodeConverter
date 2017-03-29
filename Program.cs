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


        static void Main(string[] args)
        {
            string codePath = "morse.csv.txt";
            var morseCode = new Dictionary<string, string>();

            using (var reader = new StreamReader(codePath))
            {
                while (reader.Peek() > -1)
                {
                    var message = reader.ReadLine();
                    var split = message.Split(',');
                    morseCode.Add(split[0],split[1]);
                }
            }
            morseCode.Add(" ", " ");
            Console.WriteLine("Enter a message:");
            var sentence = Console.ReadLine().ToUpper();
            foreach (var letter in sentence)
            {
                    Console.Write(morseCode[letter.ToString()]);
            }
            string answerPath = "Translations.txt";
            using (StreamWriter w = File.AppendText(answerPath))
            {
                
            }
            Console.WriteLine("Another message?:");
            var answer = Console.ReadLine();
        }
    }
}
