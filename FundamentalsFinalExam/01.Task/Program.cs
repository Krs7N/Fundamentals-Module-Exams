using System;
using System.Collections.Generic;

namespace _01.Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "Complete")
            {
                string action = commands[0];

                switch (action)
                {
                    case "Make":
                        email = Make(commands[1], email);
                        break;
                    case "GetDomain":
                        GetDomain(int.Parse(commands[1]), email);
                        break;
                    case "GetUsername":
                        GetUsername(email);
                        break;
                    case "Replace":
                        email = Replace(char.Parse(commands[1]), email);
                        break;
                    case "Encrypt":
                        Encrypt(email);
                        break;
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }

        static void Encrypt(string email)
        {
            List<int> chars = new List<int>();

            foreach (var ch in email)
            {
                chars.Add(ch);
            }

            Console.WriteLine(string.Join(' ', chars));
        }

        static string Replace(char ch, string email)
        {
            email = email.Replace(ch, '-');

            Console.WriteLine(email);

            return email;
        }

        static void GetUsername(string email)
        {
            if (!email.Contains('@'))
            {
                Console.WriteLine($"The email {email} doesn't contain the @ symbol.");

                return;
            }

            int verbatimIndex = email.IndexOf('@');
            string substring = email.Substring(0, verbatimIndex);

            Console.WriteLine(substring);
        }

        static void GetDomain(int count, string email)
        {
            string substring = email.Substring(email.Length - count);
            Console.WriteLine(substring);
        }

        static string Make(string upperOrLower, string email)
        {
            if (upperOrLower == "Upper")
            {
                email = email.ToUpper();
            }
            else if (upperOrLower == "Lower")
            {
                email = email.ToLower();
            }

            Console.WriteLine(email);

            return email;
        }
    }
}
