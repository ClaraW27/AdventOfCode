using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class DaySixPartOne
    {
        Dictionary<int, int> document = new Dictionary<int, int>
        {
            {38,234 },
            {67,1027 },
            {76,1157 },
            {73,1236 }
        }; //{ time: distance }

        public int GetWinWays(int maxSecond, int record)
        {
            int winWays = 0;

            for (int i = 0; i < maxSecond; i++)
            {

                if (BeatRecord(i, maxSecond, record))
                {
                    winWays++;
                }
            }

            return winWays;

        }

        public bool BeatRecord(int holdTime, int maxSecond, int record)
        {
            bool result = false;

            int restTime = maxSecond - holdTime;
            int speed = holdTime * 1;

            int myDistance = speed * restTime;

            result = Compare(myDistance, record);

            return result;
        }

        public bool Compare(int myDistance, int recordDistance)
        {
            return (myDistance > recordDistance);
        }

        public void MySolution()
        {
            long multiplyNumbers = 1;
            foreach (var item in this.document)
            {
                int myTime = item.Key;
                int record = item.Value;
                int winWays = GetWinWays(myTime, record);

                if (winWays > 0)
                {
                    //Console.WriteLine(winWays);
                    multiplyNumbers *= winWays;

                }
            }
            Console.WriteLine("After we multiply the numbers:" + multiplyNumbers);
        }
    }
}
