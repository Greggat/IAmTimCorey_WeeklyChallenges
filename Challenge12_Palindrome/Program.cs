using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Challenge12_Palindrome
{
    class Program
    {
        static string ReverseString(string text)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1;i <= text.Length;i++)
            {
                result.Append(text[text.Length-i]);
            }

            return result.ToString();
        }
        static bool CheckPalindrome(string text)
        {
            //Remove non-alphanumerics
            text = Regex.Replace(text, "[^a-zA-Z0-9]", "");

            //reverse and compare the strings non-case sensitive
            if (text.ToLower() == ReverseString(text).ToLower())
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            string test = "Test";
            string isOrIsNot = CheckPalindrome(test) ? "is" : "isn't";
            Console.WriteLine($"{test} {isOrIsNot} a palindrome");

            test = "Radar";
            isOrIsNot = CheckPalindrome(test) ? "is" : "isn't";
            Console.WriteLine($"{test} {isOrIsNot} a palindrome");

            test = "Stack cats$$$";
            isOrIsNot = CheckPalindrome(test) ? "is" : "isn't";
            Console.WriteLine($"{test} {isOrIsNot} a palindrome");
        }
    }
}
