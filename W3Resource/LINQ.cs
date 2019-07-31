using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace W3Resource
{
    static class Linq
    {
        static int[] numberArray = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static int[] negativeNumberArray = new int[10] { 1, -2, 4, 31, 5, -7, 23, -24, 10, 28 };
        static int[] repeatingArray = new int[] { 1, 2, 3, 4, 3, 5, 6, 7, 8, 4, 6, 3, 5, 9, 8 };
        static string[] weekDays = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        static string[] cityNames = new string[] { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS", "TEXAS" };
        static string[] xtensionArray = new string[] { "aaa.frx", "bbb.TXT", "xyz.dbf", "abc.pdf", "aaaa.PDF", "xyz.frt", "abc.xml", "ccc.txt", "zzz.txt" };
        static string word = "boOK-keEPEr";

        static IEnumerable<int> nQuery = null;

        static public void NumbersDivisibleBy2()
        {
            nQuery = from num in numberArray
                     where (num % 2 == 0)
                     select num;

            Console.Write("Numbers divisible by 2 in the array are:");
            printOutput();
        }

        public static void PrintPositiveNumbers()
        {
            nQuery = from num in negativeNumberArray
                     where (num > 0 && num < 29)
                     select num;
            Console.Write("Positive numbers below 29 in the array are:");
            printOutput();
        }

        public static void SquareOfNumberGreaterThan20()
        {
            var sqQuery = from int num in numberArray
                          let sqNum = num * num
                          where sqNum > 20
                          select new { num, sqNum };
            foreach (var num in sqQuery)
            {
                Console.WriteLine(num);
            }
        }

        static public void FrequencyOfNumbers()
        {
            var fQuery = from nums in repeatingArray
                         group nums by nums into num
                         select num;
            foreach (var output in fQuery)
            {
                Console.WriteLine($"Number {output.Key} appears {output.Count()} times");
            }
        }

        public static void FrequencyOfLetters()
        {
            var fQuery = from chars in word
                         group chars by chars into charac
                         select charac;
            foreach (var output in fQuery)
            {
                Console.WriteLine($"Character {output.Key} appears {output.Count()} times");
            }
        }

        public static void PrintDaysOfWeek()
        {
            var wQuery = from days in weekDays
                         select days;
            foreach (var day in wQuery)
            {
                Console.WriteLine(day);
            }
        }

        static public void MultiplyNumberWithFrequency()
        {
            var nfQuery = from num in repeatingArray
                          group num by num into nums
                          select nums;
            foreach (var num in nfQuery)
            {
                Console.WriteLine($"{num.Key}  {num.Count()}  {num.Sum()}");
            }
        }

        public static void SpecificCharAtStartAndEnd(string startChar, string endChar)
        {
            var sQuery = from city in cityNames
                         where city.StartsWith(startChar)
                         where city.EndsWith(endChar)
                         select city;
            foreach (var city in sQuery)
            {
                Console.WriteLine($"City starting with {startChar} and ending with {endChar} is {city}");
            }
        }

        public static void PrintNumbersGreaterThan(int num)
        {
            nQuery = from numbers in negativeNumberArray
                     where numbers > num
                     orderby numbers
                     select numbers;
            printOutput();
        }

        public static void GetTopNthRecords(int n)
        {
            var numberList = negativeNumberArray.ToList();
            numberList.Sort();
            numberList.Reverse();

            foreach (int numbers in numberList.Take(n))
            {
                Console.WriteLine(numbers);
            }
        }

        public static void GetUpperCaseLetters()
        {
            var upperCaseLetters = word.Split('-').Where(x => string.Equals(x, x.ToUpper(), StringComparison.Ordinal));
            //string[] wordArray = word.Split('-');
            //int wordArraycount = wordArray.Count();
            //while(wordArraycount > 0)
            //{
            //    word.Split('-').Where(x => string.Equals(x, x.ToUpper(), StringComparison.Ordinal));
            //}

            foreach (var letters in upperCaseLetters)
            {
                Console.WriteLine(letters);
            }
        }

        static public void StringArrayToString()
        {
            var newString = string.Join(",", weekDays.Select(x => x.ToString()).ToArray());
            Console.WriteLine(newString);
        }

        public static void StudentGradepoint(int rank)
        {
            Students stu = new Students();
            var studentList = stu.GetStudentList();
            var stuQuery = (from students in studentList
                            group students by students.GPA into studentGrade
                            orderby studentGrade.Key descending
                            select new { studentRecord = studentGrade.ToList() }).ToList();

            stuQuery[rank - 1].studentRecord.ForEach(x => Console.WriteLine($"StudentId : {x.sId}, StudentName : {x.sName} and GPA : {x.GPA}"));
        }

        public static void GroupXtensionsAndGetCount()
        {
            //var file = Path.GetExtension(file).TrimStart('.').ToLower();
            //var gQuery = from xtension in xtensionArray
            //             group xtension by xtension into xtensions
            //             select xtensions;
            //foreach(var xtension in gQuery)
            //    Console.WriteLine($"{xtension.Count()} files with {xtension.Key} extension");

            var gQuery = xtensionArray.Select(file => Path.GetExtension(file).TrimStart('.').ToLower())
                                    .GroupBy(z => z, (xtn, ctr) => new {
                                        xtension= xtn,
                                        count = ctr.Count()
                                    });

            foreach (var xtension in gQuery)
                Console.WriteLine($"{xtension.count} files with {xtension.xtension} extension");
        }

        public static void RemoveEntryFromList()
        {
            Students student = new Students();
            var studentList = student.GetStudentList();
            Console.WriteLine("Before removing the entry :\n");
            var StuQuery = from students in studentList
                           select students;
            foreach(var studnt in StuQuery)
                Console.WriteLine($"StudentId : {studnt.sId}, StudentName : {studnt.sName} and GPA : {studnt.GPA}");

            //var removingStudent = studentList.FirstOrDefault(x => x.sId == 3);      //17
            //studentList.Remove(removingStudent);
            //studentList.Remove(studentList.FirstOrDefault(x => x.sName == "KK"));            //18
            //studentList.RemoveAll(x => x.GPA == 8.5);                                                         //19
            //studentList.RemoveAt(3);                                                                                  //20
            studentList.RemoveRange(1, 3);                                                                              //21

            Console.WriteLine("\n\nAfter removing the entry :\n");
            StuQuery = from students in studentList
                       select students;
            foreach (var studnt in StuQuery)
                Console.WriteLine($"StudentId : {studnt.sId}, StudentName : {studnt.sName} and GPA : {studnt.GPA}");

        }       

        public static void GetSpecificLengthString(int length)
        {
            var sQuery = from strings in cityNames
                         where strings.Length == length
                         orderby strings
                         select strings;
            foreach(var str in sQuery)
                Console.WriteLine($"Strings have length {length} is/are : {str}");
        }

        public static void CartesianProduct()
        {
            /* Number 23
            var cQuery = from numbers in numberArray
                         from city in cityNames
                         select new { numbers, city };
            foreach(var item in cQuery)
                Console.WriteLine(item);
            */

            //Number 24
            var cQuery = from numbers in numberArray
                         from city in cityNames
                         from days in weekDays
                         select new { numbers, city, days };
            foreach (var item in cQuery)
                Console.WriteLine(item);
        }

        public static void Performjoin()
        {
            Joins joins = new Joins();
            var itemList = joins.GetItemsList();
            var purchaseList = joins.GetPurchaseList();

            var jQuery = from item in itemList
                         join purchase in purchaseList
                         on item.itemId equals purchase.itemId
                         select new
                         {
                             id = item.itemId,
                             desc = item.itemDesc,
                             qty = purchase.purchaseQty
                         };
            foreach(var item in jQuery)
                Console.WriteLine(item);
        }

        static void printOutput()
        {
            foreach (var item in nQuery)
            {
                Console.Write(item + " ");
            }
        }
    }
    class Students
    {
        public int sId;
        public string sName;

        public double GPA { get; private set; }

        public List<Students> GetStudentList()
        {
            List<Students> studentList = new List<Students>
            {
                new Students { sId = 1, sName = "VJ", GPA = 8.5 },
                new Students { sId = 2, sName = "KK", GPA = 9.0 },
                new Students { sId = 3, sName = "GV", GPA = 9.5 },
                new Students { sId = 4, sName = "RK", GPA = 10 },
                new Students { sId = 5, sName = "TA", GPA = 8.5 }
            };
            return studentList;
        }
    }

    class Joins
    {
        public List<Items> GetItemsList()
        {
            List<Items> items = new List<Items>
            {
                new Items{itemId = 1,itemDesc="Biscuit"},
                new Items{itemId=2,itemDesc="Bread"},
                new Items{itemId=3,itemDesc="Choclate"},
                new Items{itemDesc="Junk",itemId = 4}
            };
            return items;
        }

        public List<Purchase> GetPurchaseList()
        {
            List<Purchase> purchase = new List<Purchase>
            {
                new Purchase{invNum=1,itemId=2,purchaseQty=23},
                new Purchase{invNum=2,itemId=1,purchaseQty=89},
                new Purchase{invNum=3,itemId=3,purchaseQty=35},
                new Purchase{invNum=4,itemId=1,purchaseQty=11},
                new Purchase{invNum=5,itemId=4,purchaseQty=101},
                new Purchase{invNum=6,itemId=3,purchaseQty=66}
            };
            return purchase;
        }
    }
    class Items
    {
        public int itemId;
        public string itemDesc;
    }
    class Purchase
    {
        public int invNum;
        public int itemId;
        public int purchaseQty;
    }

}
