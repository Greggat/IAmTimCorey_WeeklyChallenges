using System;
using System.Collections.Generic;

namespace Challenge13_PrimeNumber
{
    class Factor
    {
        public UInt64 Value { get; set; }
        public bool IsPrime { get; set; }
    }
    class Program
    {
        static List<Factor> GetFactors(UInt64 number)
        {
            //Could optimize this more, but instructions were not to..
            var factors = new List<Factor>();
            for (UInt64 i = number - 1; i > 1; i--)
            {
                if (number % i == 0)
                {
                    factors.Add(new Factor { Value = i, IsPrime = IsPrimeNumber(i) });
                }
            }

            return factors;
        }

        static bool IsPrimeNumber(UInt64 number) => GetFactors(number).Count == 0;
        static bool IsPrimeNumber(uint number) =>  IsPrimeNumber(Convert.ToUInt64(number));

        static List<Factor> GetFactors(uint number) => GetFactors(Convert.ToUInt64(number));

        static void Main(string[] args)
        {
            uint number = 198238;
            var factors = GetFactors(number);

            if (factors.Count == 0)//Is a Prime number
                Console.WriteLine($"{number} is a prime number!");
            foreach (var factor in factors)
            {
                string IsPrime = factor.IsPrime ? "prime " : "";
                Console.WriteLine($"{factor.Value} is a {IsPrime}factor of {number}");
            }
        }
    }
}
