using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class DayOnePartOne
    {
        public void MySolution()
        {
            string filePath = "day1part1.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                List<int> numbers = new List<int>();
                while ((line = sr.ReadLine()) != null)
                {
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
                }

                double sum = numbers.Sum();
                Console.WriteLine("Day 1 part 1, the sum is :" + sum);
            }
        }
    }
}
