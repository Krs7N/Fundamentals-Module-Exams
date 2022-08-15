using System;
using System.Collections.Generic;

namespace _03.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var foodByQuantity = new Dictionary<string, int>();

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int soldCount = 0;

            while (commands[0] != "Complete")
            {
                string action = commands[0];

                switch (action)
                {
                    case "Receive":
                        Receive(int.Parse(commands[1]), commands[2], foodByQuantity);
                        break;
                    case "Sell":
                        int quantity = int.Parse(commands[1]);
                        string food = commands[2];
                        if (!foodByQuantity.ContainsKey(food))
                        {
                            Console.WriteLine($"You do not have any {food}.");

                            break;
                        }

                        if (foodByQuantity[food] < quantity)
                        {
                            Console.WriteLine($"There aren't enough {food}. You sold the last {foodByQuantity[food]} of them.");
                            soldCount += foodByQuantity[food];
                            foodByQuantity[food] -= foodByQuantity[food];
                            foodByQuantity.Remove(food);
                        }
                        else
                        {
                            foodByQuantity[food] -= quantity;
                            Console.WriteLine($"You sold {quantity} {food}.");
                            soldCount += quantity;

                            if (foodByQuantity[food] == 0)
                            {
                                foodByQuantity.Remove(food);
                            }
                        }
                        break;
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var food in foodByQuantity)
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
            Console.WriteLine($"All sold: {soldCount} goods");
        }


        static void Receive(int quantity, string food, Dictionary<string, int> foodByQuantity)
        {
            if (quantity <= 0)
            {
                return;
            }

            if (!foodByQuantity.ContainsKey(food))
            {
                foodByQuantity.Add(food, quantity);
            }
            else
            {
                foodByQuantity[food] += quantity;
            }
        }
    }
}
