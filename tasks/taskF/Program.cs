using System.Collections.Generic;
using System.IO;
using System.Text;

namespace taskF
{
    public class Program
    {
        public static void Main()
        {
            const string fileName = "input.txt";
            const int bufferSize = 28 * 1024 * 1024;

            int target = 0;
            var numberDict = new SortedDictionary<int, byte>();

            //считаем файл в словарь
            using (var sr = new StreamReader(fileName))
            {
                var buffer = new char[bufferSize];
                var count = bufferSize;

                var numStr = new StringBuilder();
                var firstLine = true;

                var length = sr.BaseStream.Length;
                var totalRead = 0L;

                while (count > 0)
                {
                    count = sr.Read(buffer, 0, bufferSize);
                    int limit = 0;
                    foreach (var nextChar in buffer)
                    {
                        if (limit++ >= count) break;

                        totalRead++;
                        if (nextChar != ' ' && nextChar != '\n' && nextChar != '\r')
                        {
                            numStr.Append(nextChar);
                            if (length > totalRead)
                            {
                                continue;
                            }
                        }

                        if (nextChar == '\n' || nextChar == '\r')
                        {
                            if (firstLine)
                            {
                                target = int.Parse(numStr.ToString());
                                firstLine = false;
                                numStr.Clear();
                            }
                        }
                        else
                        {
                            int key;
                            if (int.TryParse(numStr.ToString(), out key))
                            {
                                if (numberDict.ContainsKey(key))
                                {
                                    numberDict[key]++;
                                }
                                else
                                {
                                    numberDict[key] = 1;
                                }
                            }

                            numStr.Clear();
                        }
                    }
                }
            }

            //основная часть алгоритма анализа
            foreach (var kvp in numberDict)
            {
                var delta = target - kvp.Key;
                byte value;
                if (numberDict.TryGetValue(delta, out value))
                {
                    if (kvp.Key != delta || value > 1)
                    {
                        File.WriteAllText("output.txt", "1");
                        return;
                    }
                }
            }

            File.WriteAllText("output.txt", "0");
        }
    }
}