using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        // Sales amounts for each salesperson
        Dictionary<char, double> sales = new Dictionary<char, double>()
        {
            { 'D', 0 },
            { 'E', 0 },
            { 'F', 0 }
        };

        while (true)
        {
            Console.Write("Enter salesperson initial (D, E, F) or Z to finish: ");
            char salesperson = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (salesperson == 'Z')
            {
                break;
            }

            if (!sales.ContainsKey(salesperson))
            {
                Console.WriteLine("intermediate output: Error, invalid salesperson selected, please try again");
                continue;
            }

            Console.Write("Enter sale amount: ");
            if (double.TryParse(Console.ReadLine(), out double saleAmount) && saleAmount >= 0)
            {
                sales[salesperson] += saleAmount;
            }
            else
            {
                Console.WriteLine("intermediate output: Error, invalid salesperson selected, please try again");
            }
        }

        // Calculate totals
        double grandTotal = 0;
        char highestSalesperson = ' ';
        double highestSales = 0;

        foreach (var kvp in sales)
        {
            Console.WriteLine($"Salesperson {kvp.Key}: {kvp.Value:C}");
            grandTotal += kvp.Value;

            if (kvp.Value > highestSales)
            {
                highestSales = kvp.Value;
                highestSalesperson = kvp.Key;
            }
        }

        Console.WriteLine($"Grand Total: {grandTotal:C}");
        Console.WriteLine($"Highest Sale: {highestSalesperson}");
    }
}
// 2024/06/16_SenShoikot_Module 4: 4.2