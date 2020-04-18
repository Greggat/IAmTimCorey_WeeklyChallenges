using System;
using System.Collections.Generic;

namespace Challenge14_CorrectChange
{
    class Program
    {
        static void Main(string[] args)
        {
            var moneyList = new List<Money>();
            moneyList.Add(new Money { Name = "$10 Bill", Value = 10.0M });
            moneyList.Add(new Money { Name = "$5 Bill", Value = 5.0M });
            moneyList.Add(new Money { Name = "$1 Bill", Value = 1.0M });
            moneyList.Add(new Money { Name = "Quarter", Value = 0.25M });
            moneyList.Add(new Money { Name = "Dime", Value = 0.10M });
            moneyList.Add(new Money { Name = "Nickel", Value = 0.05M });
            moneyList.Add(new Money { Name = "Penny", Value = 0.01M });

            var calc = new ChangeCalculator(moneyList);
            while (true)
            {
                try
                {
                    Console.Write("Amount Owed: ");
                    decimal owed = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Amount Paid: ");
                    decimal paid = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Maximum Change Value: ");
                    decimal maxChange = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("--Changed Received--"); ;
                    foreach (var change in calc.GetChange(owed, paid, maxChange))
                    {
                        Console.WriteLine($"{change.Amount} {change.Money.Name}s");
                    }
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Value entered must be a number! Please try again.\n");
                    continue;
                }
            }
        }
    }
}
