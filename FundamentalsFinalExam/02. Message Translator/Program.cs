using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"!(?<command>[A-Z][a-z]{2,})!:\[(?<colon>[A-Za-z]{8,})\]";

            int countOfInputs = int.Parse(Console.ReadLine());

            List<int> charList = new List<int>();

            for (int i = 0; i < countOfInputs; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                string command = match.Groups["command"].Value;
                string colon = match.Groups["colon"].Value;

                if (!match.Success)
                {
                    Console.WriteLine("The message is invalid");
                }
                else
                {
                    if (colon.Length == 0)
                    {
                        Console.WriteLine("The message is invalid");
                    }
                    else
                    {
                        for (int j = 0; j < colon.Length; j++)
                        {
                            charList.Add(colon[j]);
                        }
                    }

                    if (charList.Count == 0)
                    {
                        Console.WriteLine("The message is invalid");
                    }
                    else
                    {
                        Console.WriteLine($"{command}: {string.Join(' ', charList)}");
                    }
                }
            }
        }
    }
}
