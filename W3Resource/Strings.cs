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
        static string firstString = "This is a string";
        static string secondSttring = "This is first strinG";
        static string welcomeString = "Welcome to w3resource.com";
        static string magicWord = "abrakadabra";


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

        public static void countVowelsOrConsonants()
        {
            int l = welcomeString.Length;
            char[] vowels = {'a', 'e', 'i', 'o', 'u'};
            int vowelCount = 0;
            int consonantCount = 0;
            for(int i =0;i<l;i++)
            {
                if (vowels.Contains(welcomeString[i]))
                    vowelCount++;
                else if (char.ToLower(welcomeString[i]) >= 'a' && char.ToLower(welcomeString[i]) <= 'z')
                    consonantCount++;
            }
            Console.WriteLine($"vowels : {vowelCount} and constants : {consonantCount}");
        }

        public static void MaxOccuringChar()
        {
            int l = welcomeString.Length;
            int[] charCount = new int[256];

            for(int i = 0; i<l;i++)
                charCount[welcomeString[i]]++;

            int maxValue = -1;
            char character = ' ';
            for(int i =0;i<l;i++)
            {
                if(maxValue < charCount[welcomeString[i]])
                {
                    maxValue = charCount[welcomeString[i]];
                    character = welcomeString[i];
                }
            }
            Console.WriteLine($"{character} appears {maxValue} time in {welcomeString}.");
        }

        public static void sortStringAscending()
        {
            int l = constant.Length;
            char[] charArray = constant.ToCharArray();
            char ch;
            for(int i=1;i<l;i++)
            {
                for(int j=0;j<l-i;j++)
                {
                    if(charArray[j] > charArray[j+1])
                    {
                        ch = charArray[j];
                        charArray[j] = charArray[j + 1];
                        charArray[j + 1] = ch;
                    }
                }
            }
            Console.WriteLine(charArray);

        }

        public static void GetSubString(int pos,int ln)
        {
            //string subString = secondSttring.Substring(pos, ln);
            //Console.WriteLine(subString);
            char[] charArray = secondSttring.ToCharArray();           
            int c = 0;            
            while (c < ln)
            {
                Console.Write(charArray[(pos + c)]);
                c++;
            }
        }

        public static void CheckSubstring(string subString)
        {
            //if(secondSttring.Contains(subString))
            //    Console.WriteLine("The sub-string exists in the string.");
            //else Console.WriteLine("The sub-string does not exists in the string.");
            string[] strArray = secondSttring.Split(' ');
            bool flag = false;
            foreach(var str in strArray)
            {
                if (str.Equals(subString))
                    flag = true;
            }
            if(flag)
                Console.WriteLine("The sub-string exists in the string.");
            else Console.WriteLine("The sub-string does not exists in the string.");
        }

        public static void ReplaceLowerToUpper()
        {
            int l = secondSttring.Length;
            var replacedString = new StringBuilder();
            for(int i =0;i<l;i++)
            {
                if (secondSttring[i] >= 'a' && secondSttring[i] <= 'z')
                    replacedString.Append(char.ToUpper(secondSttring[i]));
                else if (secondSttring[i] >= 'A' && secondSttring[i] <= 'Z')
                    replacedString.Append(char.ToLower(secondSttring[i]));
                else replacedString.Append(secondSttring[i]);
            }
            Console.WriteLine(replacedString);
        }

        public static void GetSubstringPosition(string text)
        {
            //char[] charArray = firstString.ToCharArray();
            string[] strArray = firstString.Split(' ');
            int l = strArray.Length;
            int pos =-1;
            for(int i=0;i<l;i++)
            {
                if (text.Equals(strArray[i]))
                    pos = i;
            }
            if(pos > -1)
                Console.WriteLine($"The substring '{text}' is found at position '{pos}' in the string '{firstString}'");
            else Console.WriteLine($"The substring '{text}' is not found in the string '{firstString}'");
        }

        public static void CharOrNot(char ch)
        {            
             if(ch >= 'a' && ch<='z')           
                Console.WriteLine($"Given character '{ch}' is an alphabet and of lowercase.");         
             else if(ch >= 'A' && ch<='Z')
                Console.WriteLine($"Given character '{ch}' is an alphabet and of uppercase.");
            else Console.WriteLine($"Given character '{ch}' is not an alphabet.");           
        }

        public static void SubstringAppereanceCount(string text)
        {
            int start = 0;
            int count = -1;
            int index = -1;
            while( start != -1)
            {
                start = magicWord.IndexOf(text,index+1);
                count += 1;
                index = start;
            }
            Console.WriteLine($"The substring appears '{count}' times in the string '{magicWord}'");
        }


    }
}
