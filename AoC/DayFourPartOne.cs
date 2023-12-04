using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class DayFourPartOne
    {

        private List<double> points = new List<double>();
        public void CheckWinning(string line)
        {
            int indexOfColon = line.IndexOf(':');
            int indexOfVertical = line.IndexOf('|');

            string winningNumbers = line.Substring(indexOfColon + 1, indexOfVertical - indexOfColon - 1);
            //Console.WriteLine(winningNumbers);

            string myNumbers = line.Substring(indexOfVertical + 1);

            // Convert to List

            List<string> winningNumbersList = new List<string>(winningNumbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            //Convert to List

            List<string> myNumbersList = new List<string>(myNumbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            int count = 0;

            foreach (string myNumber in myNumbersList)
            {

                bool checkExist = winningNumbersList.Contains(myNumber);
                if (checkExist)
                {
                    count++;
                    //Console.WriteLine(" match number:" + myNumber);
                }
            }

            //Console.WriteLine("Count: " + count);
            if (count >0)
            {
                double point = Math.Pow(2, count - 1);

                //Console.WriteLine("the point is:" + point);

                this.points.Add(point);
            }
        }

        public void MySolution()
        {
            string filePath = "day4part1.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                int card = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    card++;
                    //Console.WriteLine("card: " + card);
                    CheckWinning(line);
                }
            }

            double sum = this.points.Sum();
            Console.WriteLine("The total points is:" + sum);
        }
    }
}
