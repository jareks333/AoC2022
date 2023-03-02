using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AoC2022
{
    class Task3
    {
        static void Main(string[] args)
        {
            var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\input3.txt"));
            List<string> data = File.ReadAllLines(path).ToList();
            List<string> compartment1 = new List<string>();
            List<string> compartment2 = new List<string>();
            List<char> charArray = new List<char>();
            int result = 0;
            foreach (var item in data)
            {
                compartment1.Add(item.Substring(0, item.Length / 2));
                compartment2.Add(item.Substring(item.Length / 2));
            }
            for (int i = 0; i < compartment1.Count(); i++)
            {
                foreach (char item in compartment1[i])
                {
                    if (compartment2[i].Contains(item))
                    {
                        charArray.Add(item);
                        break;
                    }
                }
            }
            foreach (char item in charArray)
            {
                if (char.IsLower(item))
                {
                    result += (int)item - 96;
                }
                else if (char.IsUpper(item))
                {
                    result += (int)item - 38;
                }
            }
            List<string> dataset = new List<string>();
            List<char> matches = new List<char>();
            for (int i = 0; i < data.Count(); i = i + 3)
            {
                foreach (char item in data[i])
                {
                    if (data[i + 1].Contains(item))
                    {
                        if (data[i + 2].Contains(item))
                        {
                            matches.Add(item);
                            break;
                        }
                    }
                }
            }
            int result1 = 0;
            foreach (var item in matches)
            {
                if (char.IsLower(item))
                {
                    result1 += (int)item - 96;
                }
                else if (char.IsUpper(item))
                {
                    result1 += (int)item - 38;
                }
                Console.WriteLine(item);
            }
            Console.WriteLine(result1 + "\n");
        }
    }
}