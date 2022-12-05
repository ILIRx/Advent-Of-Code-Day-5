using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Advent_Of_Code_4
{
    internal class Program
    {
        static List<string> generateListsOfSections(string sections)
        {
            string[] sectionsSplit = sections.Split(',');
            string[] elfOneSections = sectionsSplit[0].Split('-');
            string[] elfTwoSections = sectionsSplit[1].Split('-');

            List<string> allSections = new List<string>();

            foreach (string item in elfOneSections)
            {
                allSections.Add(item);
            }
            foreach (string item in elfTwoSections)
            {
                allSections.Add(item);
            }

            return allSections;
        }
        static bool checkIfOverlaps(List<string> currentSection)
        {
            int x1 = int.Parse(currentSection[0]);
            int y1 = int.Parse(currentSection[2]);

            int x2 = int.Parse(currentSection[1]);
            int y2 = int.Parse(currentSection[3]);


            return (x1 >= y1 && x1 <= y2) ||
                (x2 >= y1 && x2 <= y2) ||
                (y1 >= x1 && y1 <= x2) ||
                (y2 >= x1 && y2 <= x2);
        }
        static bool checkIfFullyContains(string sections)
        {
            string[] sectionsSplit = sections.Split(',');
            string[] elfOneSections = sectionsSplit[0].Split('-');
            string[] elfTwoSections = sectionsSplit[1].Split('-');

            int elfOneTopRange = int.Parse(elfOneSections[1]);
            int elfOneLowRange = int.Parse(elfOneSections[0]);

            int elfTwoTopRange = int.Parse(elfTwoSections[1]);
            int elfTwoLowRange = int.Parse(elfTwoSections[0]);

            if ((elfOneTopRange <= elfTwoTopRange && elfOneLowRange >= elfTwoLowRange) || (elfTwoTopRange <= elfOneTopRange && elfTwoLowRange >= elfOneLowRange))
            {
                return true;
            }
            else return false;
        }
        static void Main(string[] args)
        {
            string fileName = "sections.txt";

            int fullyContained = 0;
            int overlaps = 0;
            using (StreamReader sr = new StreamReader(fileName))
            {
                List<string> currentSection = generateListsOfSections(sr.ReadLine());
                while (!sr.EndOfStream)
                {
                    string sections = sr.ReadLine();

                    if (checkIfFullyContains(sections))
                    {
                        fullyContained++;
                    }

                }
            }

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    List<string> currentSection = generateListsOfSections(sr.ReadLine());
                    if (checkIfOverlaps(currentSection))
                    {
                        overlaps++;
                    }
                }
            }

            Console.WriteLine(fullyContained);
            Console.WriteLine(overlaps);

            Console.ReadKey(true);
        }
    }
}
