using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge11_FizzBuzz
{
    class FizzBuzzRule
    {
        public string text { get; set; }
        public int divNumber { get; set; }
    }
    class Program
    {
        static void FizzBuzz(int lowerBound, int upperBound, List<FizzBuzzRule> rules)
        {
            for(int i = lowerBound;i <= upperBound;i++)
            {
                StringBuilder text = new StringBuilder();
                foreach(var rule in rules)
                {
                    if (i % rule.divNumber == 0)
                        text.Append(rule.text);
                }
                if (text.Length != 0)
                    Console.WriteLine(text);
                else
                    Console.WriteLine(i);
            }
        }
        static void Main(string[] args)
        {
            List<FizzBuzzRule> rules = new List<FizzBuzzRule>();
            rules.Add(new FizzBuzzRule { text = "Fizz", divNumber = 3 });
            rules.Add(new FizzBuzzRule { text = "Buzz", divNumber = 5 });
            rules.Add(new FizzBuzzRule { text = "Jazz", divNumber = 7 });

            FizzBuzz(1, 100, rules);

            Console.ReadLine();
        }
    }
}
