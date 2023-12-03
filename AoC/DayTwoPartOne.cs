using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class DayTwoPartOne
    {
        private Dictionary<string, int> standardDic = new Dictionary<string, int> { { "red", 12 }, { "green", 13 }, { "blue", 14 } };
        public bool checkEachLine(string line)
        {
            char[] delimiterChars = { ' ', ',', ':', ';' };

            string[] arrays = line.Split(delimiterChars);

            List<string> lineStuff = new List<string>(arrays);

            bool thisLineCount = true;

            int largestRed = 0, largestGreen = 0, largestBlue = 0;

            int startIndexRed = 0, startIndexGreen = 0, startIndexBlue = 0;

            while ((startIndexRed < lineStuff.Count) && thisLineCount)
            {
                int indexRedNumber = lineStuff.FindIndex(startIndexRed, x => x == "red") - 1;
 
                if (indexRedNumber < 0) { break; }

                int redNumber = int.Parse(lineStuff[indexRedNumber]);

                if (redNumber > largestRed)
                {
                    largestRed = redNumber;
                }

                startIndexRed = indexRedNumber + 2;// cause FindIndex will include the startIndex, need to +1

                if (largestRed > this.standardDic["red"])
                {
                    thisLineCount = false;
                }
            }// when this loop finishes, either you know this line is too large to be counted, or you got the update largest red number.

            while ((startIndexGreen < lineStuff.Count) && thisLineCount)
            {
                int indexGreenNumber = lineStuff.FindIndex(startIndexGreen, x => x == "green") - 1;

                if (indexGreenNumber < 0) { break; }

                int greenNumber = int.Parse(lineStuff[indexGreenNumber]);

                if (greenNumber > largestGreen)
                {
                    largestGreen = greenNumber;
                }

                startIndexGreen = indexGreenNumber + 2;

                if (largestGreen > this.standardDic["green"])
                {
                    thisLineCount = false;
                }
            }

            while ((startIndexBlue < lineStuff.Count) && thisLineCount)
            {
                int indexBlueNumber = lineStuff.FindIndex(startIndexBlue, x => x == "blue") - 1;

                if (indexBlueNumber < 0) { break; }

                int blueNumber = int.Parse(lineStuff[indexBlueNumber]);

                if (blueNumber > largestBlue)
                {
                    largestBlue = blueNumber;
                }

                startIndexBlue = indexBlueNumber + 2;

                if (largestBlue > this.standardDic["blue"])
                {
                    thisLineCount = false;
                }
            }
            return thisLineCount;
        }

        public void MySolution()
        {
            string filePath = "day2part1.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                List<int> possibleIDs = new List<int>();

                int game = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine("Checking:" + line);
                    game += 1;

                    bool yesGame = checkEachLine(line);
                    if (yesGame)
                    {
                        possibleIDs.Add(game);
                        //Console.WriteLine("This game counts：game " + game);
                    }
                }

                double sum = possibleIDs.Sum();
                Console.WriteLine("Day 2 part 1, the sum of the IDs is :" + sum);
            }
        }
    }
}
