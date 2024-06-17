using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class DaySevenPartOne
    {

        private List<char> sortOrder = new List<char>
        {
            'A','K','Q','J','T','9','8','7','6','5','4','3','2'
        };

        private Dictionary<string, int> handsAndBids = new Dictionary<string, int>();

        private List<string> fiveKind = new List<string>();// should have used List<List<string>> or created an object
        private List<string> fourKind = new List<string>();
        private List<string> fullHouse = new List<string>();
        private List<string> threeKind = new List<string>();
        private List<string> twoPair = new List<string>();
        private List<string> onePair = new List<string>();
        private List<string> highCard = new List<string>();

        public void CheckType(string hand)
        {
            // if hand all five cards are the same,

            // if hand four cards the same, 

            // full house: if hand 3 cards same, and the rest two the same

            // if hand three cards, the same,the rest two different, add to threeKind

            // if hand  two pairs same

            // if hand one pair the same

            // if all cards are different

            // we already know this string will be 5 char

            var charCounts = hand.GroupBy(c => c).Select(group => group.Count()).ToList();

            if (charCounts.Count == 1)
            {
                this.fiveKind.Add(hand);
            }
            else if (charCounts.Contains(4))
            {
                this.fourKind.Add(hand);
            }
            else if (charCounts.Contains(3) && charCounts.Contains(2))
            {
                this.fullHouse.Add(hand);
            }
            else if (charCounts.Contains(3))
            {
                this.threeKind.Add(hand);
            }
            else if (charCounts.Count == 3 && charCounts.Count(c => c == 2) == 2)
            {
                this.twoPair.Add(hand);
            }
            else if (charCounts.Count == 4)
            {
                this.onePair.Add(hand);
            }
            else
            {
                this.highCard.Add(hand);
            }

        }

        public void SortHands(List<string> handsKind)
        {
            if (handsKind.Count > 1)
            {
                handsKind.Sort((str1, str2) => CompareStrings(str1, str2, 0));
            }



            foreach (string hand in handsKind)
            {

                Console.WriteLine(hand);
            }
            Console.WriteLine("\n");

        }

        public int CompareStrings(string str1, string str2, int index)
        {

            // check if we already reach the end of one string
            if (index >= str1.Length || index >= str2.Length)
            {

                if (str1.Length == str2.Length)
                {
                    return 0;
                }
                else
                {
                    return str1.Length < str2.Length ? -1 : 1;
                }
            }

            //Console.WriteLine("str 1 is: " + str1);
            //Console.WriteLine("str 2 is: " + str2);
            //Console.WriteLine("current index is:" + index);

            var currentCharStr1 = str1[index];
            var currentCharStr2 = str2[index];

            //Console.WriteLine("current char in str 1 is:" + currentCharStr1);
            //Console.WriteLine("current char in str 2 is：" + currentCharStr2);

            int order1 = this.sortOrder.IndexOf(currentCharStr1);
            int order2 = this.sortOrder.IndexOf(currentCharStr2);

            if (order1 > order2)
            {
                return -1;// means str1 should be in front of str2 -- no no, str 1 should be behind str2
            }
            else if (order1 < order2)
            {
                return 1;
            }
            else
            {
                return CompareStrings(str1, str2, index + 1);
            }

        }

        public List<KeyValuePair<string, int>> SortDictionary()
        {
            var tempList = new List<KeyValuePair<string, int>>();
            var tempDict = new Dictionary<string, int>(this.handsAndBids);


            foreach (var key in this.highCard)
            {
                if (tempDict.TryGetValue(key, out int value))
                {
                    tempList.Add(new KeyValuePair<string, int>(key, value));
                    tempDict.Remove(key);
                }
            }

            foreach (var key in this.onePair)
            {
                if (tempDict.TryGetValue(key, out int value))
                {
                    tempList.Add(new KeyValuePair<string, int>(key, value));
                    tempDict.Remove(key);
                }
            }

            foreach (var key in this.twoPair)
            {
                if (tempDict.TryGetValue(key, out int value))
                {
                    tempList.Add(new KeyValuePair<string, int>(key, value));
                    tempDict.Remove(key);
                }
            }

            foreach (var key in this.threeKind)
            {
                if (tempDict.TryGetValue(key, out int value))
                {
                    tempList.Add(new KeyValuePair<string, int>(key, value));
                    tempDict.Remove(key);
                }
            }


            foreach (var key in this.fullHouse)
            {
                if (tempDict.TryGetValue(key, out int value))
                {
                    tempList.Add(new KeyValuePair<string, int>(key, value));
                    tempDict.Remove(key);
                }
            }

            foreach (var key in this.fourKind)
            {
                if (tempDict.TryGetValue(key, out int value))
                {
                    tempList.Add(new KeyValuePair<string, int>(key, value));
                    tempDict.Remove(key);
                }
            }

            foreach (var key in this.fiveKind)
            {
                if (tempDict.TryGetValue(key, out int value))
                {
                    tempList.Add(new KeyValuePair<string, int>(key, value));
                    tempDict.Remove(key);
                }
            }


            return tempList;

        }

        public void MySolution()
        {
            // read file
            string filePath = "day7part1.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    string[] currentLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (currentLine.Length > 0)
                    {
                        string hand = currentLine[0];
                        int bid = int.Parse(currentLine[1]);
                        this.handsAndBids.Add(hand, bid);// save the whole file to a dic {hand: bid} for final multiplying

                        // divide these hands into 7 types 
                        CheckType(hand);
                    }
                }

            }



            // sorting inside each type (use custom .Sort method)
            Console.WriteLine("fivekind");

            SortHands(this.fiveKind);
            Console.WriteLine("fourkind");
            SortHands(this.fourKind);
            Console.WriteLine("full house");
            SortHands(this.fullHouse);
            Console.WriteLine("three kind");
            SortHands(this.threeKind);
            Console.WriteLine("two pair");
            SortHands(this.twoPair);
            Console.WriteLine("one pair");
            SortHands(this.onePair);
            Console.WriteLine("high card");
            SortHands(this.highCard);

            // combine the 7 type together so we have a sorted hands dic

            var finalRankList = SortDictionary();

            //foreach (var pair in finalRankList)
            //{
            //    int index=finalRankList.IndexOf(pair);
            //    Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value},Index: {index}");
            //}

            // multiplying bid*rank, rank is the index
            long sum = 0;
            for (int i = 0; i < finalRankList.Count; i++)
            {
                sum += finalRankList[i].Value * (i + 1);
            }

            Console.WriteLine("the sum is:" + sum);

        }
    }
}
