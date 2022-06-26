using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.DeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int setOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < setOfInputs; i++)
            {
                string[] commands = Console.ReadLine().Split(", ");
                if (commands[0] == "Add")
                {
                    string cardName = commands[1];
                    if (cards.Contains(cardName))
                    {
                        Console.WriteLine("Card is already in the deck");
                    }
                    else
                    {
                        cards.Add(cardName);
                        Console.WriteLine("Card successfully added");
                    }
                }
                else if (commands[0] == "Remove")
                {
                    string cardName = commands[1];
                    if (!cards.Contains(cardName))
                    {
                        Console.WriteLine("Card not found");
                    }
                    else
                    {
                        cards.Remove(cardName);
                        Console.WriteLine("Card successfully removed");
                    }
                }
                else if (commands[0] == "Remove At")
                {
                    int index = int.Parse(commands[1]);
                    if (index < 0 || index > cards.Count)
                    {
                        Console.WriteLine("Index out of range");
                    }
                    else
                    {
                        cards.RemoveAt(index);
                        Console.WriteLine("Card successfully removed");
                    }
                }
                else if (commands[0] == "Insert")
                {
                    int index = int.Parse(commands[1]);
                    string cardName = commands[2];
                    if (index < 0 || index > cards.Count)
                    {
                        Console.WriteLine("Index out of range");
                    }
                    else if (index > 0 && index <= cards.Count && cards.Contains(cardName))
                    {
                        Console.WriteLine("Card is already added");
                    }
                    else
                    {
                        cards.Insert(index, cardName);
                        Console.WriteLine("Card successfully added");
                    }
                }
            }

            Console.WriteLine(string.Join(", ", cards));
        }
    }
}
