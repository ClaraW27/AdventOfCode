using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class DaySixPartTwo
    {
        long time = 38677673;
        long distance = 234102711571236;


        public long GetWinWays(long maxSecond, long record)
        {
            long winWays = 0;

            for (long i = 0; i < maxSecond; i++)
            {

                if (BeatRecord(i, maxSecond, record))
                {
                    winWays++;
                }
            }

            return winWays;

        }

        public bool BeatRecord(long holdTime, long maxSecond, long record)
        {
            bool result = false;

            long restTime = maxSecond - holdTime;
            long speed = holdTime * 1;

            long myDistance = speed * restTime;

            result = Compare(myDistance, record);

            return result;
        }

        public bool Compare(long myDistance, long recordDistance)
        {
            return (myDistance > recordDistance);
        }

        public void MySolution()
        {
            long myWinWays = GetWinWays(this.time, this.distance);
            Console.WriteLine(" In this longer race my ways: " + myWinWays);
        }
    }
}
