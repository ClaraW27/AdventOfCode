using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{

    internal class DayThreePartOne
    {
        List<string> lineList = new List<string>();

        List<string> numberList = new List<string>();

        List<Tuple<int, int>> savedPositions = new List<Tuple<int, int>>();

        public bool CheckRepeated(int newRow, int newCol)
        {

            bool exist = this.savedPositions.Any(pair => pair.Item1 == newRow && pair.Item2 == newCol);

            if (!exist)
            {
                this.savedPositions.Add(new Tuple<int, int>(newRow, newCol));
            }

            return exist;
        }

        public void CheckSymbol(List<string> lineList)
        {
            for (int row = 0; row < lineList.Count; row++)
            {
                //Console.WriteLine("\n");
                //Console.WriteLine("this row is:" + row);
                for (int col = 0; col < lineList[row].Length; col++)
                {
                    char c = lineList[row][col];
                    if ((!char.IsDigit(c)) && (c != '.'))
                    {
                        //Console.WriteLine("this symbol is:" + c);

                        // check the surrounding 8 char, do they contain number?- check each one
                        char one = lineList[row - 1][col - 1];
                        char two = lineList[row - 1][col];
                        char three = lineList[row - 1][col + 1];
                        char four = lineList[row][col - 1];
                        char six = lineList[row][col + 1];
                        char seven = lineList[row + 1][col - 1];
                        char eight = lineList[row + 1][col];
                        char nine = lineList[row + 1][col + 1];

                        if (char.IsDigit(one))
                        {
                            Tuple<string, int> result = FindWholeNumber(lineList[row - 1], (col - 1));

                            string numberAtOne = result.Item1;
                            int offset = result.Item2;

                            int index = (col - 1) - offset;

                            bool exist = CheckRepeated(row - 1, index); // pass the row and the first index of the number (col)
                            if (!exist)
                            {
                                this.numberList.Add(numberAtOne);
                            }

                        }

                        if (char.IsDigit(two))
                        {
                            Tuple<string, int> result = FindWholeNumber(lineList[row - 1], (col));

                            string numberAtTwo = result.Item1;
                            int offset = result.Item2;

                            int index = (col) - offset;

                            bool exist = CheckRepeated(row - 1, index);
                            if (!exist)
                            {
                                this.numberList.Add(numberAtTwo);
                            }

                        }

                        if (char.IsDigit(three))
                        {
                            Tuple<string, int> result = FindWholeNumber(lineList[row - 1], (col + 1));

                            string numberAtThree = result.Item1;
                            int offset = result.Item2;

                            int index = (col + 1) - offset;

                            bool exist = CheckRepeated(row - 1, index);
                            if (!exist)
                            {
                                this.numberList.Add(numberAtThree);
                            }

                        }

                        if (char.IsDigit(four))
                        {
                            Tuple<string, int> result = FindWholeNumber(lineList[row], (col - 1));

                            string numberAtFour = result.Item1;
                            int offset = result.Item2;

                            int index = (col - 1) - offset;

                            bool exist = CheckRepeated(row, index);
                            if (!exist)
                            {
                                this.numberList.Add(numberAtFour);
                            }

                        }

                        if (char.IsDigit(six))
                        {
                            Tuple<string, int> result = FindWholeNumber(lineList[row], (col + 1));

                            string numberAtSix = result.Item1;
                            int offset = result.Item2;

                            int index = (col + 1) - offset;

                            bool exist = CheckRepeated(row, index);
                            if (!exist)
                            {
                                this.numberList.Add(numberAtSix);
                            }

                        }

                        if (char.IsDigit(seven))
                        {
                            Tuple<string, int> result = FindWholeNumber(lineList[row + 1], (col - 1));

                            string numberAtSeven = result.Item1;
                            int offset = result.Item2;

                            int index = (col - 1) - offset;

                            bool exist = CheckRepeated(row + 1, index);
                            if (!exist)
                            {
                                this.numberList.Add(numberAtSeven);
                            }

                        }

                        if (char.IsDigit(eight))
                        {
                            Tuple<string, int> result = FindWholeNumber(lineList[row + 1], (col));

                            string numberAtEight = result.Item1;
                            int offset = result.Item2;

                            int index = (col) - offset;

                            bool exist = CheckRepeated(row + 1, index);
                            if (!exist)
                            {
                                this.numberList.Add(numberAtEight);

                            }

                        }

                        if (char.IsDigit(nine))
                        {
                            Tuple<string, int> result = FindWholeNumber(lineList[row + 1], (col + 1));

                            string numberAtNine = result.Item1;
                            int offset = result.Item2;

                            int index = (col + 1) - offset;

                            bool exist = CheckRepeated(row + 1, index);
                            if (!exist)
                            {
                                this.numberList.Add(numberAtNine);

                            }

                        }

                    }
                }
            }


        }

        public Tuple<string, int> FindWholeNumber(string str, int index)
        {
            // go left to find the start
            int start = index;
            while (start > 0 && char.IsDigit(str[start - 1]))
            {
                start--;
            }

            // go right to find the end
            int end = index;
            while (end < str.Length - 1 && char.IsDigit(str[end + 1]))
            {
                end++;
            }
            int offset = index - start;// so you can find the start index of this substring, otherwise .IndexOf will only return the first substring found

            return new Tuple<string, int>(str.Substring(start, end - start + 1), offset);
        }

        public void MySolution()
        {
            string filePath = "day3part1.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    this.lineList.Add(line);
                }
            }

            CheckSymbol(lineList);

            // convert to int and sum up
            int sum = this.numberList.Sum(s => int.Parse(s));
            Console.WriteLine("the sum of all the part numbers is:" + sum);

        }
    }
}
