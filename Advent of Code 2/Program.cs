using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_of_Code_2
{
    internal class Program
    {
        static int computeScore2(string currentPlay)
        {
            int score = 0;
            int draw = 3;
            int win = 6;
            int rock = 1;
            int paper = 2;
            int scissors = 3;

            string[] moves = currentPlay.Split(' ');
            string playerOneMove = moves[0];
            string playerTwoMove = moves[1];

            switch (playerOneMove)
            {
                case "A":
                    switch (playerTwoMove)
                    {
                        case "X":
                            score += scissors;
                            break;
                        case "Y":
                            score += rock + draw;
                            break;
                        case "Z":
                            score += paper + win;
                            break;
                        default:
                            break;
                    }
                    break;
                case "B":
                    switch (playerTwoMove)
                    {
                        case "X":
                            score += rock;
                            break;
                        case "Y":
                            score += paper + draw;
                            break;
                        case "Z":
                            score += scissors + win;
                            break;
                        default:
                            break;
                    }
                    break;
                case "C":
                    switch (playerTwoMove)
                    {
                        case "X":
                            score += paper;
                            break;
                        case "Y":
                            score += scissors + draw;
                            break;
                        case "Z":
                            score += rock + win;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            return score;
        }
        static int computeScore(string currentPlay)
        {
            int score = 0;
            int draw = 3;
            int win = 6;
            int rock = 1;
            int paper = 2;
            int scissors = 3;

            string[] moves = currentPlay.Split(' ');
            string playerOneMove = moves[0];
            string playerTwoMove = moves[1];

            switch (playerOneMove)
            {
                case "A":
                    switch (playerTwoMove)
                    {
                        case "X":
                            score += rock + draw;
                            break;
                        case "Y":
                            score += paper + win;
                            break;
                        case "Z":
                            score += scissors;
                            break;
                        default:
                            break;
                    }
                    break;
                case "B":
                    switch (playerTwoMove)
                    {
                        case "X":
                            score += rock;
                            break;
                        case "Y":
                            score += paper + draw;
                            break;
                        case "Z":
                            score += scissors + win;
                            break;
                        default:
                            break;
                    }
                    break;
                case "C":
                    switch (playerTwoMove)
                    {
                        case "X":
                            score += rock + win;
                            break;
                        case "Y":
                            score += paper;
                            break;
                        case "Z":
                            score += scissors + draw;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            return score;

        }
        static void Main(string[] args)
        {
            int sum1 = 0, sum2 = 0;
            string fileName = "moves.txt";
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    sum1 += computeScore(line);
                    sum2 += computeScore2(line);
                }
            }

            Console.WriteLine(sum1 + "\n" + sum2);


            Console.ReadKey(true);
        }
    }
}
