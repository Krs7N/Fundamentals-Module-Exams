using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.FriendList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] commands = Console.ReadLine().Split();
            int blacklistCount = 0;
            int lostNames = 0;

            while (commands[0] != "Report")
            {
                if (commands[0] == "Blacklist")
                {
                    string name = commands[1];
                    int index = list.IndexOf(name);
                    if (list.Contains(name))
                    {
                        list.RemoveAt(index);
                        list.Insert(index, "Blacklisted");
                        Console.WriteLine($"{name} was blacklisted.");
                        blacklistCount++;
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (commands[0] == "Error")
                {
                    int index = int.Parse(commands[1]);
                    if (index < list.Count && index >= 0)
                    {
                        string name = list[index];
                        if (list[index] != "Blacklisted")
                        {
                            if (list[index] != "Lost")
                            {
                                list.RemoveAt(index);
                                list.Insert(index, "Lost");
                                lostNames++;
                                Console.WriteLine($"{name} was lost due to an error.");
                            }
                        }
                    }
                }
                else if (commands[0] == "Change")
                {
                    int index = int.Parse(commands[1]);
                    string newName = commands[2];
                    if (index < list.Count && index >= 0)
                    {
                        string currName = list[index];
                        list.RemoveAt(index);
                        list.Insert(index, newName);
                        Console.WriteLine($"{currName} changed his username to {newName}.");
                    }
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine($"Blacklisted names: {blacklistCount}");
            Console.WriteLine($"Lost names: {lostNames}");
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
