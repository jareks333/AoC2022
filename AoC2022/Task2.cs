using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AoC2022
{
    class Task2
    {
        static void Main(string[] args)
        {
            var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\input2.txt"));
            List<string> data = File.ReadAllLines(path).ToList();
            int score1 = 0;
            int score2 = 0;
            foreach (var item in data)
            {
                if (item == "A X" || item == "B Y" || item == "C Z") score1 += 3;
                else if (item == "B X" || item == "C Y" || item == "A Z") score1 += 0;
                else if (item == "C X" || item == "A Y" || item == "B Z") score1 += 6;
            }
            foreach (var item in data)
            {
                if (item.Contains('X')) score1 += 1;
                else if (item.Contains('Y')) score1 += 2;
                else if (item.Contains('Z')) score1 += 3;
            }
            Console.WriteLine(score1);
            foreach (var item in data)
            {
                if (item == "A X") score2 += 3;
                else if (item == "A Y") score2 += 4;
                else if (item == "A Z") score2 += 8;
                else if (item == "B X") score2 += 1;
                else if (item == "B Y") score2 += 5;
                else if (item == "B Z") score2 += 9;
                else if (item == "C X") score2 += 2;
                else if (item == "C Y") score2 += 6;
                else if (item == "C Z") score2 += 7;
            }
            Console.WriteLine("t2score is:\n" + score2);
        }
    }
}