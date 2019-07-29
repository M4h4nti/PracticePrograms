using System;
using System.Collections.Generic;
using System.Linq;

namespace W3Resource
{
    static class Linq
    {
        static int[] numberArray = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static int[] negativeNumberArray = new int[10] { 1, -2, -4, 31, 5, -7, 23, -24, 10, 28 };
        static int[] repeatingArray = new int[] {1,2,3,4,3,5,6,7,8,4,6,3,5,9,8 };
        static string[] weekDays = new string[] { "Sunday", "Monday","Tuesday","Wednesday","Thursday","Friday","Saturday" };

        static string word = "book-keeper";

        static IEnumerable<int> nQuery = null;

        static public void numbersDivisibleBy2()
        {
            nQuery = from num in numberArray
                         where (num % 2 == 0)
                         select num;

            Console.Write("Numbers divisible by 2 in the array are:");
            printOutput();
        }

        public static void printPositiveNumbers()
        {
            nQuery = from num in negativeNumberArray
                     where (num > 0 && num < 29)
                     select num;
            Console.Write("Positive numbers below 29 in the array are:");
            printOutput();
        }

        public static void squareOfNumberGreaterThan20()
        {
             var sqQuery = from int num in numberArray
                     let sqNum = num * num
                     where sqNum > 20
                     select new { num, sqNum };
            foreach (var num in sqQuery)
                Console.WriteLine(num);
        }

        static public void frequencyOfNumbers()
        {
            var fQuery = from nums in repeatingArray
                     group nums by nums into num
                     select num;
            foreach(var output in fQuery)
                Console.WriteLine($"Number {output.Key} appears {output.Count()} times");
        }

        public static void frequencyOfLetters()
        {
            var fQuery = from chars in word
                         group chars by chars into charac
                         select charac;
            foreach (var output in fQuery)
                Console.WriteLine($"Character {output.Key} appears {output.Count()} times");
        }

        public static void printDaysOfWeek()
        {
            var wQuery = from days in weekDays
                     select days;
            foreach(var day in wQuery)
                Console.WriteLine(day);
        }


        static void printOutput()
        {
            foreach (var item in nQuery)
            {
                Console.Write(item + " ");
            }
        }      
    }
}
