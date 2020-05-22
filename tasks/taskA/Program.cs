using System.Collections.Generic;
using System.IO;

namespace taskA
{
    public class Program
    {
        public static void Main()
        {
            var dict = new SortedDictionary<long, int>();

            foreach (var inputStr in File.ReadAllLines("input-201.txt"))
            {
                if (inputStr != null)
                {
                    string[] numbers = inputStr.Split(' ', '\n');
                    foreach (var numStr in numbers)
                    {
                        long number;
                        if (long.TryParse(numStr, out number))
                        {
                            int count;
                            dict.TryGetValue(number, out count);
                            dict[number] = count + 1;
                        }
                    }
                }
            }

            foreach (var d in dict)
            {
                if (d.Value % 2 == 1)
                {
                    File.WriteAllText("input-201.a.txt", d.Key.ToString());
                    return;
                }
            }

            File.WriteAllText("input-201.a.txt", "");
        }
    }
}