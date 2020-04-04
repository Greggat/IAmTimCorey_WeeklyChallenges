using System;
using System.Collections.Generic;

namespace Challenge1_foreach
{
    class Person
    {
        public string FirstName;
        public string LastName;
    }
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> people = new List<Person>();

            people.Add(new Person { FirstName = "Austin", LastName = "Gregg" });
            people.Add(new Person { FirstName = "Tim", LastName = "Corey" });
            people.Add(new Person { FirstName = "Bob", LastName = "Smith" });
            people.Add(new Person { FirstName = "John", LastName = "Wick" });
             

            foreach(var person in people)
            {
                Console.WriteLine($"Hello {person.FirstName} {person.LastName}!");
            }
        }
    }
}
