using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class DayOnePartTwo
    {
        private Dictionary<string, int> wordsDic = new Dictionary<string, int>
                {
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

        public string ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public int GetFirstDigit(string line)
        {
            foreach (char element in line)
            {
                int firstIndex = line.IndexOf(element);

                string threeWords = line.Substring(firstIndex, 3);
                string fourWords = line.Substring(firstIndex, 4);
                string fiveWords = line.Substring(firstIndex, 5);

                if (char.IsDigit(element))
                {
                    return (element - '0');
                }
                else if (this.wordsDic.ContainsKey(threeWords))
                {
                    return (this.wordsDic[threeWords]);
                }
                else if (this.wordsDic.ContainsKey(fourWords))
                {
                    return (this.wordsDic[fourWords]);
                }
                else if (this.wordsDic.ContainsKey(fiveWords))
                {
                    return (this.wordsDic[fiveWords]);
                }
            }
            return 0;// this return 0 should not happen.
        }

        public int GetSecondDigit(string line)
        {
            string reverseLine=ReverseString(line);
            Console.WriteLine("the reverse line is:"+reverseLine);

            foreach (char element in reverseLine)
            {
                int firstIndex = line.IndexOf(element);

                string threeWords = line.Substring(firstIndex, 3);
                string fourWords = line.Substring(firstIndex, 4);
                string fiveWords = line.Substring(firstIndex, 5);


                if (char.IsDigit(element))
                {
                    return (element - '0');
                }
                else if (this.wordsDic.ContainsKey(threeWords))
                {
                    return (this.wordsDic[threeWords]);
                }
                else if (this.wordsDic.ContainsKey(fourWords))
                {
                    return (this.wordsDic[fourWords]);
                }
                else if (this.wordsDic.ContainsKey(fiveWords))
                {
                    return (this.wordsDic[fiveWords]);
                }
            }
            return 0;// this return 0 should not happen.
        }
        public void MySolution()
        {
            string filePath = "day1part1.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                List<int> numbers = new List<int>();

                while ((line = sr.ReadLine()) != null)
                {
                    int firstDigit = GetFirstDigit(line);
                    int secondDigit = GetSecondDigit(line);
                    int twoDigits = firstDigit * 10 + secondDigit;
                    Console.WriteLine("the two digits of this line is:"+twoDigits);
                    numbers.Add(twoDigits);
                }

                double sum = numbers.Sum();
                Console.WriteLine("the real sum is :" + sum);

            }
        }
    }
}
