using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AoC2022
{
    class Task6
    {
        static void Main(string[] args)
        {
            var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\input6.txt"));
            List<string> data = File.ReadAllLines(path).ToList();
            for (int i = 0; i <= data[0].Length - 5; i++)
            {
                string inputString = data[0].Substring(i, 5);
                string answer = new String(inputString.Distinct().ToArray());
                if (answer.Length >= 5)
                {
                    Console.WriteLine((i + 4) + " " + answer);
                    break;
                }
            }
            Console.WriteLine();
            for (int i = 0; i <= data[0].Length - 13; i++)
            {
                string inputString = data[0].Substring(i, 13);
                string answer = new String(inputString.Distinct().ToArray());
                if (answer.Length >= 13)
                {
                    Console.WriteLine((i + 14) + " " + answer);
                    break;
                }
            }
        }
    }
}