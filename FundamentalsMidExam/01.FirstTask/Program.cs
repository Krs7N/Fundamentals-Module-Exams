using System;
using System.Threading;

namespace _01.FirstTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceFlourPackage = double.Parse(Console.ReadLine());
            double priceSingleEgg = double.Parse(Console.ReadLine());
            double priceSingleApron = double.Parse(Console.ReadLine());

            double apronPrice = priceSingleApron * Math.Ceiling(students + students * 0.2);
            double eggPrice = priceSingleEgg * 10 * students;
            double flourPrice = priceFlourPackage * (students - students / 5);

            double totalPrice = apronPrice + eggPrice + flourPrice;

            if (totalPrice > budget)
            {
                double moneyNeeded = Math.Abs(totalPrice - budget);
                Console.WriteLine($"{(int)moneyNeeded:f2}$ more needed.");
            }
            else
            {
                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
            }
        }
    }
}
