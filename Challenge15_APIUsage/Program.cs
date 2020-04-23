using Challenge15_APIUsage.Entities;
using System;
using System.Threading;

namespace Challenge15_APIUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var swapi = new SWAPI();

            swapi.GetPeople();

            Console.WriteLine("Hello World!");
        }
    }
}
