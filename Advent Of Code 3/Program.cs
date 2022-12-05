using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_Of_Code_3
{
    internal class Program
    {
        static int calculateSumOfMatchingTypes(string contents)
        {
            int returnSum = 0;

            StringBuilder sb = new StringBuilder(contents);
            int compartment1 = sb.Length / 2;
            int compartment2 = sb.Length - compartment1;
            char[] halfOne = new char[compartment1];
            char[] halfTwo = new char[compartment2];
            sb.CopyTo(0, halfOne, 0, compartment1);
            sb.CopyTo(compartment1, halfTwo, 0, compartment2);
            string[] compartments = new string[]
            {
   new string(halfOne), new string(halfTwo)
            };
            sb.Clear();


            char[] compOneChars = compartments[0].ToCharArray();
            char uniqueChar = ' ';

            foreach (char c in compartments[1])
            {
                if (compOneChars.Contains(c))
                {
                    uniqueChar = c;
                    break;
                }
            }

            if (IsLowercase(uniqueChar))
            {
                return returnSum = (int)uniqueChar - 96;
            }
            else
            {
                return returnSum = (int)uniqueChar - 38;
            }
        }
        static int calculateSumOfTriadMatchingTypes(List<string> contents)
        {
            int returnSum = 0;
            
            char[] compOneChars = contents[0].ToCharArray();
            char[] compTwoChars = contents[1].ToCharArray();

            char uniqueChar = ' ';

            foreach (char c in contents[2])
            {
                if (compOneChars.Contains(c) && compTwoChars.Contains(c))
                {
                    uniqueChar = c;
                    break;
                }
            }

            if (IsLowercase(uniqueChar))
            {
                return returnSum = (int)uniqueChar - 96;
            }
            else
            {
                return returnSum = (int)uniqueChar - 38;
            }
        }
        static bool IsLowercase(char c)
        {
            if ((int)c > 96 && (int)c < 123)
            {
                return true;
            }
            else return false;
        }
        static void Main(string[] args)
        {
            string fileName = "backpackContents.txt";

            int totalSum = 0;
            //part one
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    totalSum += calculateSumOfMatchingTypes(line);
                }
            }

            Console.WriteLine(totalSum);

            totalSum = 0;

            //part two
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    List<string> compartment = new List<string>();
                    for (int i = 0; i <= 2; i++)
                    {
                        compartment.Add(sr.ReadLine());
                    }
                    totalSum += calculateSumOfTriadMatchingTypes(compartment);
                }
            }

            Console.WriteLine(totalSum);

            Console.ReadKey(true);
        }
    }
}
