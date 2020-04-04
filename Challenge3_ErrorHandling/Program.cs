using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    var result = paymentProcessor.MakePayment($"Demo{ i }", i);

                    if (result != null)
                        Console.WriteLine(result.TransactionAmount);
                    else
                        Console.WriteLine($"Null value for item {i}");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine($"Skipped Invalid record  {e?.InnerException?.Message}");
                }
                catch (FormatException e)
                {
                    if (i != 5)
                        Console.WriteLine($"Formatting Issue {e?.InnerException?.Message}");
                    else
                        Console.WriteLine($"Payment skipped for payment with {i} items");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Payment skipped for payment with {i} items");
                }
            }
            Console.ReadLine();
        }
    }
}
