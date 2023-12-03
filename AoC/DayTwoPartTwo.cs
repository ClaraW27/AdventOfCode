using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class DayTwoPartTwo
    {
        public int GetPowerEachLine(string line)
        {
            char[] delimiterChars = { ' ', ',', ':', ';' };

            string[] arrays = line.Split(delimiterChars);

            List<string> lineStuff = new List<string>(arrays);

            int largestRed = 0, largestGreen = 0, largestBlue = 0;

            int startIndexRed = 0, startIndexGreen = 0, startIndexBlue = 0;

            while (startIndexRed < lineStuff.Count)
            {
                int indexRedNumber = lineStuff.FindIndex(startIndexRed, x => x == "red") - 1;

                if (indexRedNumber < 0) { break; }

                int redNumber = int.Parse(lineStuff[indexRedNumber]);

                if (redNumber > largestRed)
                {
                    largestRed = redNumber;
                }

                startIndexRed = indexRedNumber + 2;// cause FindIndex will include the startIndex, need to +1
            }

            while (startIndexGreen < lineStuff.Count)
            {
                int indexGreenNumber = lineStuff.FindIndex(startIndexGreen, x => x == "green") - 1;

                if (indexGreenNumber < 0) { break; }

                int greenNumber = int.Parse(lineStuff[indexGreenNumber]);

                if (greenNumber > largestGreen)
                {
                    largestGreen = greenNumber;
                }

                startIndexGreen = indexGreenNumber + 2;
            }

            while (startIndexBlue < lineStuff.Count)
            {
                int indexBlueNumber = lineStuff.FindIndex(startIndexBlue, x => x == "blue") - 1;

                if (indexBlueNumber < 0) { break; }

                int blueNumber = int.Parse(lineStuff[indexBlueNumber]);

                if (blueNumber > largestBlue)
                {
                    largestBlue = blueNumber;
                }

                startIndexBlue = indexBlueNumber + 2;
            }

            int powerThisLine = largestRed * largestGreen * largestBlue;
            return powerThisLine;
        }

        public void MySolution()
        {
            string filePath = "day2part1.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                List<int> powers = new List<int>();

                int game = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    game += 1;

                    int linePower = GetPowerEachLine(line);
                    //Console.WriteLine("power of this game " + game + " is: " + linePower);

                    powers.Add(linePower);
                }

                double sum = powers.Sum();
                Console.WriteLine("Day 2 part 2, the sum of the powers is :" + sum);
            }
        }
    }
}

