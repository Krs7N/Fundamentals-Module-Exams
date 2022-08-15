using System;
using System.Text.RegularExpressions;

namespace _02.Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfRegistrations = int.Parse(Console.ReadLine());

            string pattern = @"U\$(?<username>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Za-z]{5,}\d+)P@\$";

            int successfulRegistrationCount = 0;

            for (int i = 0; i < countOfRegistrations; i++)
            {
                string userInfo = Console.ReadLine();

                Match match = Regex.Match(userInfo, pattern);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid username or password");
                    continue;
                }

                successfulRegistrationCount++;
                Console.WriteLine("Registration was successful");
                string username = match.Groups["username"].Value;
                string password = match.Groups["password"].Value;
                Console.WriteLine($"Username: {username}, Password: {password}");
            }

            Console.WriteLine($"Successful registrations: {successfulRegistrationCount}");
        }
    }
}
