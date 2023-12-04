using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{

    internal class DayFourPartTwo
    {

        List<int> cardsAmount = Enumerable.Repeat(1, 193).ToList();

        public void CheckCards(int currentCard, string line)
        {
            int thisCardAmount = this.cardsAmount[currentCard];

            //Console.WriteLine($"the amount of this card is:{thisCardAmount}");

            int indexOfColon = line.IndexOf(':');
            int indexOfVertical = line.IndexOf('|');

            string winningNumbers = line.Substring(indexOfColon + 1, indexOfVertical - indexOfColon - 1);
            string myNumbers = line.Substring(indexOfVertical + 1);
            List<string> winningNumbersList = new List<string>(winningNumbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            List<string> myNumbersList = new List<string>(myNumbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            int match = 0;

            foreach (string myNumber in myNumbersList)
            {
                bool checkExist = winningNumbersList.Contains(myNumber);
                if (checkExist)
                {
                    match++;
                }
            }

            //Console.WriteLine("Match: " + match);

            for (int i = 0; i < thisCardAmount; i++)
            {
                ProduceCopies(currentCard, match);
            }
        }

        public void ProduceCopies(int currentCard, int match)
        {
            for (int i = 0; i < match; i++)
            {
                this.cardsAmount[currentCard + (i + 1)] += 1;
                //Console.WriteLine("card: " + (currentCard + (i+1)+1) + " get a copy from card: " + (currentCard + 1));
            }
        }

        public void MySolution()
        {
            string filePath = "day4part1.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                int currentCard = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine("current card: " + (currentCard + 1));
                    CheckCards(currentCard, line);
                    currentCard++; // start from index 0, when print, remember to +1
                }
            }

            int totalCards = this.cardsAmount.Sum();
            Console.WriteLine("total scratchcards: " + totalCards);

        }
    }
}
