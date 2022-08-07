using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Hero_Recruitment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var heroesBySpells = new Dictionary<string, List<string>>();

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "End")
            {
                string action = commands[0];

                switch (action)
                {
                    case "Enroll":
                        Enroll(commands[1], heroesBySpells);
                        break;
                    case "Learn":
                        Learn(commands[1], commands[2], heroesBySpells);
                        break;
                    case "Unlearn":
                        Unlearn(commands[1], commands[2], heroesBySpells);
                        break;
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Heroes:");
            foreach (var heroByspell in heroesBySpells)
            {
                Console.WriteLine($"== {heroByspell.Key}: {string.Join(", ", heroByspell.Value)}");
            }
        }

        static void Unlearn(string heroName, string spell, Dictionary<string, List<string>> heroesBySpells)
        {
            if (!heroesBySpells.ContainsKey(heroName))
            {
                Console.WriteLine($"{heroName} doesn't exist.");
            }
            else if (!heroesBySpells[heroName].Contains(spell))
            {
                Console.WriteLine($"{heroName} doesn't know {spell}");
            }
            else
            {
                heroesBySpells[heroName].Remove(spell);
            }
        }

        static void Learn(string heroName, string spell, Dictionary<string, List<string>> heroesBySpells)
        {
            if (!heroesBySpells.ContainsKey(heroName))
            {
                Console.WriteLine($"{heroName} doesn't exist.");
            }
            else if (!heroesBySpells[heroName].Contains(spell))
            {
                heroesBySpells[heroName].Add(spell);
            }
            else
            {
                Console.WriteLine($"{heroName} has already learnt {spell}");
            }
        }

        static void Enroll(string heroName, Dictionary<string, List<string>> heroesBySpells)
        {
            if (!heroesBySpells.ContainsKey(heroName))
            {
                heroesBySpells.Add(heroName, new List<string>());

                return;
            }

            Console.WriteLine($"{heroName} is already enrolled.");
        }
    }
}
