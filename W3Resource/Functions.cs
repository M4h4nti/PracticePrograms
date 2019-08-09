using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3Resource
{
    public static class Functions
    {
        public static void BasicFunction()
        {
            Console.WriteLine("Welcome Friends!\nHave a nice day!");
        }

        public static void FunctionWithParameter(string text)
        {
            Console.WriteLine($"Welcome friend '{text}'!\nHave a nice day!");
        }

        public static void AddTwoNumbers(int n1, int n2)
        {
            Console.WriteLine($"Sum of '{n1}' and '{n2}' is '{n1+n2}'");
        }

        public static void GetNumberOfSpaces(string text)
        {
            int count = 0;
            int l = text.Length;
            for(int i=0;i<l;i++)
            {
                if (text[i] == ' ')
                    count++;
            }
            Console.WriteLine($"Number of spaces in '{text}' are '{count}'");
        }

        public static void SumOfArrayElements(int[] numArray)
        {
            int l = numArray.Length;
            int sum = 0;
            for(int i=0;i<l;i++)
            {
                sum += numArray[i];
            }
            Console.WriteLine($"Sum of array elements : {sum}");
        }

        public static void SwapTwoNumbers(int n1,int n2)
        {
            Console.WriteLine($"Before swap : num1 = {n1} and num2 = {n2}");           
            int temp = n1;
            n1 = n2;
            n2 = temp;
            Console.WriteLine($"After swap : num1 = {n1} and num2 = {n2} ");
        }      
        
        public static void ToThePower(int num,int pow)
        {
            int result = 1;
            for(int i=1;i<=pow;i++)
                result *= num;
            Console.WriteLine($"'{num}' to the power of '{pow}' is '{result}'.");
        }


    }
}
