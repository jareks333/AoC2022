using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2022
{
    public class Class1
    {
        var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\input.txt"));
            Console.WriteLine(path); 
            List<string> data = File.ReadAllLines(path).ToList();

            int sum = 0;
            List<int> elves = new List<int>();
    
            foreach (var item in data)
            {
                if (item == "")
                {
                    elves.Add(sum);
                    sum=0;
                }
                if (item != "")
                {
                   sum = sum + int.Parse(item);
                }
               // Console.WriteLine(item);
            }

            elves.Sort();
            foreach (var item in elves)
            {
                Console.WriteLine(item);
            }
            // 71780
            int maxThreeValues = 0;

            for (int i = 0; i < 3; i++)
            {
                maxThreeValues = maxThreeValues + elves.Max();
                elves.RemoveAt(elves.IndexOf(elves.Max()));
                
            }
            // 212489

            Console.WriteLine(maxThreeValues);


    }
}
