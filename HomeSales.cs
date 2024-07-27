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
            // Prompt user to enter a salesperson initial or Z to finish
            Console.Write("Enter salesperson initial (D, E, F) or Z to finish: ");
            char salesperson = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            // Break the loop if user enters 'Z'
            if (salesperson == 'Z')
            {
                break;
            }
            // Check if the entered initial is valid (D, E, or F)
            if (!sales.ContainsKey(salesperson))
            {
                Console.WriteLine("intermediate output: Error, invalid salesperson selected, please try again");
                continue;// Restart the loop if invalid initial is entered
            }
            // Prompt user to enter the sale amount
            Console.Write("Enter sale amount: ");
            if (double.TryParse(Console.ReadLine(), out double saleAmount) && saleAmount >= 0)
            {
                // Add the valid sale amount to the corresponding salesperson's total
                sales[salesperson] += saleAmount;
            }
            else
            {
                // Display an error message if the entered amount is invalid
                Console.WriteLine("intermediate output: Error, invalid salesperson selected, please try again");
            }
        }

        // Variables to calculate the grand total and track the highest sales
        double grandTotal = 0;
        char highestSalesperson = ' ';
        double highestSales = 0;
        // Loop through the dictionary to calculate totals and identify the highest salesperson
        foreach (var kvp in sales)
        {
            // Print the sales amount for each salesperson
            Console.WriteLine($"Salesperson {kvp.Key}: {kvp.Value:C}");
            grandTotal += kvp.Value;
            // Check if the current salesperson has the highest sales
            if (kvp.Value > highestSales)
            {
                highestSales = kvp.Value;
                highestSalesperson = kvp.Key;
            }
        }
        // Print the grand total of all sales
        Console.WriteLine($"Grand Total: {grandTotal:C}");
        // Print the initial of the salesperson with the highest sales
        Console.WriteLine($"Highest Sale: {highestSalesperson}");
    }
}
// 2024/06/16_SenShoikot_Module 4: 4.2