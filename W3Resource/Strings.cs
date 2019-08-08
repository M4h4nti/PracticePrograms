using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3Resource
{
    public static class Strings
    {
        static string constant = "w3resource.com";
        static string sentence = "This is w3resource.com";
        static string firstString = "This is first strinp";
        static string secondSttring = "This is first string";
        static string welcomeString = "Welcome to w3resource.com";


        public static void PrintString(string text)
        {
            Console.WriteLine(text);
        }

        public static void GetStringlength()
        {
            Console.WriteLine(constant.Length);
        }

        public static void CharacterSeperation()
        {
            int l = 0;
            while(l <= constant.Length -1)
            {
                Console.Write($"{constant[l]} ");
                l++;
            }
        }

        public static void CharacterReverse()
        {
            int l = constant.Length - 1;
            while (l >= 0 )
            {
                Console.Write($"{constant[l]} ");
                l--;
            }
        }

        public static void WordCount()
        {
            int l = 0;
            int wrd = 1;

            while(l <= sentence.Length -1)
            {
                if (sentence[l] == ' ' || sentence[l] == '\n' || sentence[l] == '\t')
                    wrd++;
                l++;                
            }
            Console.WriteLine(wrd);
        }

        public static void CompareStrings()
        {
            int l1 = firstString.Length;
            int l2 = secondSttring.Length;
            int flag = 0, yn = 0;

            if(l1 == l2)
            {
                for(int i =0; i<l1;i++)
                {
                    if(firstString[i]  != secondSttring[i])
                    {
                        yn = 1;
                        i = l2;
                    }
                }
            }

            if (l1 == l2)
                flag = 0;
            else if (l1 > l2)
                flag = 1;
            else flag = -1;

            if(flag == 0)
            {
                if(yn ==0)
                    Console.WriteLine("Both strings have same length and same.");
                else Console.WriteLine("Both strings have same length but not same" +
                    ".");
            }
            else if(flag == 1)
                Console.WriteLine("First string is greater than second string.");
            else Console.WriteLine("First string is smaller than second string.");
        }

        public static void CharsCount()
        {
            int alph = 0;
            int digits = 0;
            int splchar = 0;
            int l = sentence.Length;

           for(int i =0; i < l;i++)
            {
                if (char.ToLower(sentence[i]) >= 'a' && char.ToLower(sentence[i]) <= 'z')
                    alph++;
                else if (sentence[i] >= '0' && sentence[i] <= '9')
                    digits++;
                else splchar++;
            }
            Console.WriteLine($"Alphabets : {alph} \nDigits : {digits} \nSpecialChars : {splchar}");
        }

        public static void CopyString()
        {
            int l = sentence.Length;
            int i = 0;
            var newSentence = new string[l];
            while(i < l)
            {
                var temp = sentence[i].ToString();
                newSentence[i] = temp;
                i++;
            }
            Console.WriteLine(string.Join("",newSentence));
        }

        public static void countVowelsOrConstants()
        {
            int l = welcomeString.Length;
            char[] vowels = {'a', 'e', 'i', 'o', 'u'};
            int vowelCount = 0;
            for(int i =0;i<l;i++)
            {
                if (vowels.Contains(welcomeString[i]))
                    vowelCount++;
            }
            Console.WriteLine($"vowels : {vowelCount} and constants : {l-vowelCount}");
        }
    }
}
