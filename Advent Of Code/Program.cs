using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Advent_Of_Code
{
    internal class Program
    {
        static int findHighestCalories(List<int> CaloriesList)
        {
            int best = 0;
            foreach (int c in CaloriesList)
            {
                if (c > best)
                {
                    best = c;
                }
            }

            return best;
        }
        static int findTopThreeHighestCalories(List<int> CaloriesList)
        {
            CaloriesList.Sort();

            int sum = CaloriesList[CaloriesList.Count - 1] + CaloriesList[CaloriesList.Count - 2] + CaloriesList[CaloriesList.Count - 3];

            return sum;
        }
        static void Main(string[] args)
        {
            string fileName = "calories.txt";
            List<int> CaloriesList = new List<int>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                int caloriesSum = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.Length > 0)
                    {
                        caloriesSum += int.Parse(line);
                    }
                    else
                    {
                        CaloriesList.Add(caloriesSum);
                        caloriesSum = 0;
                    }
                }
            }

            Console.WriteLine(findHighestCalories(CaloriesList));
            Console.WriteLine(findTopThreeHighestCalories(CaloriesList));

            Console.ReadKey(true);
        }
    }
}
