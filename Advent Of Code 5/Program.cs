using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_Of_Code_5
{
    internal class Program
    {
        static int[] getWordlessInstruction(string instruction)
        {
            string[] seperate = instruction.Split(' ');
            int[] wordless = new int[3];
            wordless[0] = int.Parse(seperate[1]);
            wordless[1] = int.Parse(seperate[3]);
            wordless[2] = int.Parse(seperate[5]);

            return wordless;
        }
        public static string reverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static void Main(string[] args)
        {
            //part one
            string fileName = "startingStacks.txt";
            List<Stack<char>> stacks1 = new List<Stack<char>>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                int i = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    stacks1.Add(new Stack<char>());
                    foreach (char c in line)
                    {
                        stacks1[i].Push(c);
                    }
                    i++;
                }
            }
            fileName = "instructions.txt";
            
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string instruction = sr.ReadLine();
                    int[] instructionWordless = getWordlessInstruction(instruction);
                    for (int i = 0; i < instructionWordless[0]; i++)
                    {
                        char toPush = stacks1[instructionWordless[1] - 1].Pop();
                        stacks1[instructionWordless[2] - 1].Push(toPush);
                    }
                }
            }
            string result1 = "";
            foreach (Stack<char> stack in stacks1)
            {
                result1 += stack.Peek();
            }

            //part two
            fileName = "startingStacks.txt";
            List<Stack<char>>stacks2 = new List<Stack<char>>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                int i = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    stacks2.Add(new Stack<char>());
                    foreach (char c in line)
                    {
                        stacks2[i].Push(c);
                    }
                    i++;
                }
            }
            fileName = "instructions.txt";

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string toPush = "";
                    string instruction = sr.ReadLine();
                    int[] instructionWordless = getWordlessInstruction(instruction);
                    for (int i = 0; i < instructionWordless[0]; i++)
                    {
                        toPush += stacks2[instructionWordless[1] - 1].Pop();
                    }
                    toPush = reverseString(toPush);
                    foreach (char c in toPush)
                    {
                        stacks2[instructionWordless[2] - 1].Push(c);
                    }
                }
            }
            string result2 = "";
            foreach (Stack<char> stack in stacks2)
            {
                result2 += stack.Peek();
            }
            Console.WriteLine(result1);
            Console.WriteLine(result2);

            Console.ReadKey(true);
        }
    }
}
