using Challenge15_APIUsage.Entities;
using System;
using System.Threading;

namespace Challenge15_APIUsage
{
    enum test
    {
        a,
        b
    }
    class Program
    {
        static void Main(string[] args)
        {
            var swapi = new SWAPI();

            swapi.GetPeople();

            Console.WriteLine(test.a);
        }
    }
}
