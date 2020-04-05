using System;
using System.Globalization;

namespace Challenge6_DateTime
{
    class Program
    {
        static void CheckDate()
        {
            Console.Write("Give me a date: ");
            var dateString = Console.ReadLine();

            Console.Write("What date format did you use? ");
            var dateFormatString = Console.ReadLine();

            DateTime date = DateTime.ParseExact(dateString, dateFormatString, CultureInfo.InvariantCulture);
            int days = Convert.ToInt32(Math.Abs((date - DateTime.Today).TotalDays));

            Console.WriteLine($"It has been {days} days since {date.ToString(dateFormatString)}.");
        }

        static void CheckTime()
        {
            Console.Write("Give me a time: ");
            var timeString = Console.ReadLine();

            Console.Write("What time format did you use? ");
            var timeFormatString = Console.ReadLine();

            DateTime time = DateTime.ParseExact(timeString, timeFormatString, CultureInfo.InvariantCulture);

            //Check if the time is in the future
            if (time > DateTime.Now)
                time = time.AddDays(-1);//Use the time from yesterday

            TimeSpan difference = DateTime.Now - time;
            Console.WriteLine($"{time.ToString(timeFormatString)} was {difference.Hours} hours and {difference.Minutes} minutes ago.");
        }
        static void Main(string[] args)
        {
            CheckDate();
            CheckTime();
        }
    }
}
