using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AoC2022
{
    class Task5
    {
        static void Main(string[] args)
        {
            var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\input5.txt"));
            List<string> data = File.ReadAllLines(path).ToList();
            List<string> stock = new List<string>();
            for (int i = 0; i < 9;)
            {
                for (int j = 1; j < data[i].Length; j = j + 4)
                {
                    string myString = "";
                    for (int k = 0; k < 8; k++)
                    {
                        myString = myString.Insert(0, data[k].ElementAtOrDefault(j).ToString());
                    }
                    stock.Add(myString);
                    i++;
                }
            }
            stock = stock.Select(t => t.Trim()).ToList();  
            for (int i = 10; i < data.Count; i++)
            {
                int toMoveCount = int.Parse(data[i].Split().ElementAt(1));
                int toMoveFrom = int.Parse(data[i].Split().ElementAt(3)) -1;
                int toMoveWhere = int.Parse(data[i].Split().ElementAt(5)) -1;
                for (int j = 0; j < toMoveCount; j++)
                {
                    stock[toMoveWhere] = stock[toMoveWhere].Insert(stock[toMoveWhere].Length, stock[toMoveFrom].LastOrDefault().ToString());
                    stock[toMoveFrom] = stock[toMoveFrom].Remove(stock[toMoveFrom].Length-1);
                }
            }
            string result1 = "";
            foreach (var item in stock) result1 = result1 + item.ElementAt(item.Length-1);
            Console.WriteLine("result1: " + result1);            
            for (int i = 10; i < data.Count; i++)
            {
                int moveCount = int.Parse(data[i].Split().ElementAt(1));
                int moveFrom = int.Parse(data[i].Split().ElementAt(3)) - 1;
                int moveWhere = int.Parse(data[i].Split().ElementAt(5)) - 1;
                stock[moveWhere] = stock[moveWhere].Insert(stock[moveWhere].Length, stock[moveFrom].Substring(stock[moveFrom].Length - moveCount));
                stock[moveFrom] = stock[moveFrom].Remove(stock[moveFrom].Length - moveCount);
            }
            string result2 = "";
            foreach (var item in stock) result2 = result2 + item.ElementAt(item.Length - 1);
            Console.WriteLine("result1: " + result2);
        }
    }
}