using System;
using System.Linq;

namespace _01.FirstTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "Complete")
            {
                string action = commands[0];

                switch (action)
                {
                    case "Make":
                        password = Make(password, commands);
                        break;
                    case "Insert":
                        password = Insert(int.Parse(commands[1]), char.Parse(commands[2]), password);
                        break;
                    case "Replace":
                        password = Replace(char.Parse(commands[1]), int.Parse(commands[2]), password);
                        break;
                    case "Validation":
                        Validation(password);
                        break;
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }

        static string Make(string password, string[] commands)
        {
            int index = int.Parse(commands[2]);

            if (char.IsLetter(password[index]))
            {
                switch (commands[1])
                {
                    case "Upper":
                        string substring = password.Substring(index, index - 1);
                        password = password.Remove(index, index - 1);
                        password = password.Insert(index, substring.ToUpper());
                        break;
                    case "Lower":
                        substring = password.Substring(index, index - 1);
                        password = password.Remove(index, index - 1);
                        password = password.Insert(index, substring.ToLower());
                        break;
                }

                Console.WriteLine(password);
            }

            return password;
        }

        static string Insert(int index, char ch, string password)
        {
            if (!(index < 0 || index > password.Length - 1))
            {
                password = password.Insert(index, ch.ToString());
                Console.WriteLine(password);
            }

            return password;
        }

        static string Replace(char ch, int value, string password)
        {
            if (password.Contains(ch))
            {
                int newSymbol = ch + value;
                password = password.Replace(ch, (char)newSymbol);
                Console.WriteLine(password);
            }

            return password;
        }

        static void Validation(string password)
        {
            if (password.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters long!");
            }

            if (!password.All(c => char.IsLetterOrDigit(c) || c == '_'))
            {
                Console.WriteLine("Password must consist only of letters, digits and _!");
            }

            if (!password.Any(char.IsUpper))
            {
                Console.WriteLine("Password must consist at least one uppercase letter!");
            }

            if (!password.Any(char.IsLower))
            {
                Console.WriteLine("Password must consist at least one lowercase letter!");
            }

            if (!password.Any(char.IsDigit))
            {
                Console.WriteLine("Password must consist at least one digit!");
            }
        }
    }
}