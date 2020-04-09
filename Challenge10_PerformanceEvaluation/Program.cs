using System;
using System.Diagnostics;
using System.Text;

namespace Challenge10_PerformanceEvaluation
{
    class Program
    {
        static void Evaluate(int count)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            string test = "";
            for (int i = 0; i < count; i++)
                test += "test";
            stopwatch.Stop();
            Console.WriteLine($"String Concat[{count}]: {stopwatch.ElapsedMilliseconds}ms");


            stopwatch = new Stopwatch();
            stopwatch.Start();
            StringBuilder test2 = new StringBuilder();
            for (int i = 0; i < count; i++)
                test2.Append("test");
            stopwatch.Stop();
            Console.WriteLine($"StringBuilder[{count}]: {stopwatch.ElapsedMilliseconds}ms");
        }
        static void Main(string[] args)
        {
            Evaluate(500);
            Evaluate(5000);
            Evaluate(50000);

            Console.WriteLine("Hello World!");
        }
    }
}
