using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Security;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.ComponentModel.Design;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;

namespace AoC2022
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\input7.txt"));
            //Console.WriteLine(path);
            List<string> data = File.ReadAllLines(path).ToList();
            data.Reverse();
            List<Folder> folders = new List<Folder>();
            bool indicate=false;
            Folder temp = new Folder();

            foreach (var item in data)
            {
                string[] str = item.Split(' ');
                
                if (int.TryParse(str[0],out int value ))
                {
                    temp.addFile(str[1], value);
                }
                if (item.Equals("$ cd .."))
                {
                    continue;
                }
                if (item.Equals("$ ls"))
                {
                    indicate= true;
                }
                if (item.Contains("$ cd "))
                {
                    temp.setName(str[2]);
                    Console.WriteLine(temp.name);
                    folders.Add(temp);
                    indicate = false;
                    temp.Reset();
                }
                if (str[0].Equals("dir"))
                {
                    temp.addSubfolder(str[1]);
                }

            }


            Console.WriteLine("-------------------");
            foreach (var item in folders)
            {
                               

            }
            

        }

        public class Folder 
        {
            public string name;
            public List<string> subfolders = new List<string>();
            public List<string> files = new List<string>();
            public int size;

            public void Reset()
            {
                //name = null;
                subfolders.Clear();
                size = 0;
            }
            public void addSubfolder(string subfolder)
            {
                subfolders.Add(subfolder);
            }
            public void addFile(string fileNeme,int fileSize)
            {
                files.Add(fileNeme);
                size = size+ fileSize;  
            }
            public void setName(string folderName)
            {
                name = folderName;
            }

        }


    }
}
/* Task1
 *  var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\input.txt"));
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
 */
/* Task2
 *         var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\input2.txt"));
           Console.WriteLine(path); 
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
           //14264 - SCORE 1
           foreach (var item in data)
           {
               if (item == "A X") score2 += 3;
               else if (item == "A Y") score2 += 4;
               else if(item == "A Z") score2 += 8;
               else if (item == "B X") score2 += 1;
               else if (item == "B Y") score2 += 5;
               else if (item == "B Z") score2 += 9;
               else if (item == "C X") score2 += 2;
               else if (item == "C Y") score2 += 6;
               else if (item == "C Z") score2 += 7;
           }
           Console.WriteLine("t2score is:\n"+score2);
           //12382  -SCORE 2
 * 
 */
/* Task3
 * var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\input3.txt"));
            Console.WriteLine(path);
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
                //Console.WriteLine(compartment1[i] + "\r\t\t\t\t" + compartment2[i]);
            }
            foreach (char item in charArray)
            {
                if (char.IsLower(item))
                {
                    //Console.WriteLine(item + "\t" + ((int)item-96));
                    result += (int)item - 96;
                }
                else if (char.IsUpper(item))
                {
                    //Console.WriteLine(item + "\t" + ((int)item-38));
                    result += (int)item - 38;
                }
            }
            //Console.WriteLine(result);
            //7821 - Task 1
            //2752 - TASK 2
            List<string> dataset = new List<string>();
            List<char> matches = new List<char>();  
            for (int i = 0; i < data.Count(); i=i+3)
            {
                foreach (char item in data[i])
                {
                        if (data[i + 1].Contains(item))
                        {
                            if (data[i+2].Contains(item))
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
                        //Console.WriteLine(item + "\t" + ((int)item-96));
                        result1 += (int)item - 96;
                    }
                    else if (char.IsUpper(item))
                    {
                        //Console.WriteLine(item + "\t" + ((int)item-38));
                        result1 += (int)item - 38;
                    }
                Console.WriteLine(item);   
            }
            Console.WriteLine(result1+ "\n");
 */
/* Task4
 *  int result = 0;
            int result1 = 0;
            for (int i = 0; i < data.Count; i++)
            {
                string[] values = data[i].Split('-', ',');
                if (int.Parse(values[3]) >= int.Parse(values[1]) && int.Parse(values[0]) >= int.Parse(values[2]) || int.Parse(values[3]) <= int.Parse(values[1]) && int.Parse(values[0]) <= int.Parse(values[2]))
                {
                    result++;
                }
            }
            Console.WriteLine(result);
            //Result: 569
            foreach (var item in data)
            {
                string[] values = item.Split('-', ',');
                if (int.Parse(values[0]) <= int.Parse(values[3]) && int.Parse(values[1]) >= int.Parse(values[3]) || int.Parse(values[1]) >= int.Parse(values[2]) && int.Parse(values[3]) >= int.Parse(values[1]))
                {
                    result1++;
                }
            }
            Console.WriteLine(result1);
            //Result1: 936
 */
/* Task5
 * 
            //Dictionary<int, string> Stack = new Dictionary<int, string>();
            List<string> stock = new List<string>();

            for (int i = 0; i <9;)
            {
                for (int j = 1; j < data[i].Length; j=j+4)
                {
                string myString = "";
                    for (int k = 0; k < 8; k++)
                    {
                        myString = myString.Insert(0,data[k].ElementAtOrDefault(j).ToString());
                    }
                    stock.Add(myString);
                    i++;
                }
            }
            stock = stock.Select(t => t.Trim()).ToList(); 
            /*
            for (int i = 10; i < data.Count; i++)
            {
                int toMoveCount = int.Parse(data[i].Split().ElementAt(1));
                int toMoveFrom = int.Parse(data[i].Split().ElementAt(3)) -1;
                int toMoveWhere = int.Parse(data[i].Split().ElementAt(5)) -1;
                //Console.WriteLine("{0} from: {1} to: {2}", toMoveCount,toMoveFrom,toMoveWhere);
                for (int j = 0; j < toMoveCount; j++)
                {
                    stock[toMoveWhere] = stock[toMoveWhere].Insert(stock[toMoveWhere].Length, stock[toMoveFrom].LastOrDefault().ToString());
                    stock[toMoveFrom] = stock[toMoveFrom].Remove(stock[toMoveFrom].Length-1);
                }
            }
            string result1 = "";
            foreach (var item in stock) result1 = result1 + item.ElementAt(item.Length-1);
            Console.WriteLine("result1: "+result1);
            //RFFFWBPNS
            
//  PART 2
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

//CQQBBJFCS
*/
/* Task6
 * 
 * var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\input6.txt"));
            //Console.WriteLine(path);
            List<string> data = File.ReadAllLines(path).ToList();



            for (int i = 0; i <= data[0].Length - 5; i++)
            {
                string inputString = data[0].Substring(i, 5);
                string answer = new String(inputString.Distinct().ToArray());
                if (answer.Length>=5)
                {
                    Console.WriteLine((i+4) + " " + answer);
                    break;
                }
                //1538 fmwgt
            }
            Console.WriteLine();
            for (int i = 0; i <= data[0].Length - 13; i++)
            {
                string inputString = data[0].Substring(i, 13);
                string answer = new String(inputString.Distinct().ToArray());
                if (answer.Length >= 13)
                {
                    Console.WriteLine((i+14) + " " + answer);
                    break;
                }
                //2315 cfnrbztvlwjhg
            }
 */