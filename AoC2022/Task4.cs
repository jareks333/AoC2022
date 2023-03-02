using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AoC2022
{
    class Task4
    {
        static void Main(string[] args)
        {
            var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\input4.txt"));
            List<string> data = File.ReadAllLines(path).ToList();
            int result = 0;
            int result2 = 0;
            for (int i = 0; i < data.Count; i++)
            {
                string[] values = data[i].Split('-', ',');
                if (int.Parse(values[3]) >= int.Parse(values[1]) && int.Parse(values[0]) >= int.Parse(values[2]) || int.Parse(values[3]) <= int.Parse(values[1]) && int.Parse(values[0]) <= int.Parse(values[2]))
                {
                    result++;
                }
            }
            Console.WriteLine(result);
            foreach (var item in data)
            {
                string[] values = item.Split('-', ',');
                if (int.Parse(values[0]) <= int.Parse(values[3]) && int.Parse(values[1]) >= int.Parse(values[3]) || int.Parse(values[1]) >= int.Parse(values[2]) && int.Parse(values[3]) >= int.Parse(values[1]))
                {
                    result2++;
                }
            }
            Console.WriteLine(result2);
        }
    }
}