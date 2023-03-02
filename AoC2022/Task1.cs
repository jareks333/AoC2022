using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AoC2022
{
    class Task1
    {
        static void Main(string[] args)
        {
            var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\input1.txt"));
            List<string> data = File.ReadAllLines(path).ToList();
            int sum = 0;
            List<int> elves = new List<int>();
            foreach (var item in data)
            {
                if (item == "")
                {
                    elves.Add(sum);
                    sum = 0;
                }
                if (item != "")
                {
                    sum = sum + int.Parse(item);
                }
            }
            elves.Sort();
            foreach (var item in elves)
            {
                Console.WriteLine(item);
            }
            int maxThreeValues = 0;
            for (int i = 0; i < 3; i++)
            {
                maxThreeValues = maxThreeValues + elves.Max();
                elves.RemoveAt(elves.IndexOf(elves.Max()));
            }
            Console.WriteLine(maxThreeValues);
        }
    }
}