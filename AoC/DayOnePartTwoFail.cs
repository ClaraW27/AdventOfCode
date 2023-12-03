using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class DayOnePartTwoFail
    {
        public void MySolution()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "day1part1.txt");
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                List<int> numbers = new List<int>();
                Dictionary<string, int> numberWordsDic = new Dictionary<string, int>
                {
                    {"zero",0 },
                    {"one",1 },
                    { "two", 2 },
                    { "three",3},
                    { "four",4},
                    {"five",5 },
                    {"six",6 },
                    {"seven",7 },
                    {"eight",8 },
                    {"nine",9 }
                };
                while ((line = sr.ReadLine()) != null)
                {
                    string firstWordToReplace = null;
                    int firstWordIndex = int.MaxValue;
                    string lastWordToReplace = null;
                    int lastWordIndex = -1;

                    foreach (var numberWord in numberWordsDic)
                    {
                        int firstIndex = line.IndexOf(numberWord.Key);
                        int lastIndex = line.LastIndexOf(numberWord.Key);

                        if (firstIndex >= 0 && firstIndex < firstWordIndex)
                        {
                            firstWordToReplace = numberWord.Key;
                            firstWordIndex = firstIndex;
                        }

                        if (lastIndex >= 0 && lastIndex > lastWordIndex)
                        {
                            lastWordToReplace = numberWord.Key;
                            lastWordIndex = lastIndex;
                        }
                    }

                    if (firstWordToReplace != null)
                    {
                        line = line.Substring(0, firstWordIndex) + numberWordsDic[firstWordToReplace] + line.Substring(firstWordIndex + firstWordToReplace.Length);
                    }

                    if (lastWordToReplace != null)
                    {
                        lastWordIndex = line.LastIndexOf(lastWordToReplace);
                        if (lastWordIndex != -1)
                        {
                            line = line.Substring(0, lastWordIndex) + numberWordsDic[lastWordToReplace] + line.Substring(lastWordIndex + lastWordToReplace.Length);
                        }
                    }

                    Console.Write("The new line should be:" + line);

                    int firstDigit = 0;
                    int secondDigit = 0;
                    int lastIndexDigit = line.Length - 1;

                    foreach (char c in line)
                    {
                        if (char.IsDigit(c))
                        {
                            firstDigit = c - '0';
                            break;
                        }
                    }
                    for (int i = lastIndexDigit; i >= 0; i--)
                    {
                        char c = line[i];
                        if (char.IsDigit(c))
                        {
                            secondDigit = c - '0';
                            break;
                        }

                    }

                    int twoDigits = firstDigit * 10 + secondDigit;
                    numbers.Add(twoDigits);
                    Console.WriteLine(" " + twoDigits);

                }

                double sum = numbers.Sum();
                Console.WriteLine("the real sum is :" + sum);

            }
        }
    }
}
