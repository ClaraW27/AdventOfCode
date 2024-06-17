using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    class DayFivePartOne
    {
        private List<long> seedNumbers = new List<long>();
        private List<long> locationNumbers = new List<long>();

        // destination, source,range
        private List<List<long>> seedToSoil = new List<List<long>>();
        private List<List<long>> soilToFretilizer = new List<List<long>>();
        private List<List<long>> fretilizerToWater = new List<List<long>>();
        private List<List<long>> waterToLight = new List<List<long>>();
        private List<List<long>> lightToTemperature = new List<List<long>>();
        private List<List<long>> temperatureToHumidity = new List<List<long>>();
        private List<List<long>> humidityToLocation = new List<List<long>>();

        bool readingSeed = false;
        bool readingSoil = false;
        bool readingFretilizer = false;
        bool readingWater = false;
        bool readingLight = false;
        bool readingTemperature = false;
        bool readingHumidity = false;


        public long GetDestination(long sourceNumber, List<List<long>> map)
        {
            Console.WriteLine("print this map info: the first line: ");
            Console.WriteLine(map[0][0]);
            Console.WriteLine(map[0][1]);
            Console.WriteLine(map[0][2]);

            Console.WriteLine("this sourcenumber is：" + sourceNumber);

            Console.WriteLine("Map size: " + map.Count);

            int i = 0;
            foreach (var item in map)
            {
                Console.WriteLine("now we are in line: " + i);


                long sourceStart = item[1];
                long range = item[2];
                long destination = item[0];

                long sourceEnd = sourceStart + range;

                if (sourceNumber >= sourceStart && sourceNumber < sourceEnd)
                {
                    long nextNumber = destination + (sourceNumber - sourceStart);
                    return nextNumber;
                }

                i++;
            }
            return sourceNumber;// not in the map, means destination = sourceNumber


        }
        public void MySolution()
        {
            string filePath = "day5part1.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // how to skip empty line (usually with \n) 
                    if (String.IsNullOrWhiteSpace(line)) //(String.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    if (line.Contains("seeds"))
                    {
                        string[] temporary = line.Split(' '); // but only need the numbers!
                        foreach (string temp in temporary)
                        {
                            if (long.TryParse(temp, out long number)) // abandon the 'seed:'
                            {
                                this.seedNumbers.Add(number);
                            }
                        }
                        continue;
                    }

                    if (line.Contains("seed-to-soil"))
                    {
                        Console.WriteLine("Starting seed-to-soil segment.");
                        this.readingSeed = true;
                        continue;
                    }
                    if (this.readingSeed)
                    {
                        string[] temporary = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //string[] temporary = line.Split(' ');
                        List<long> thisLine = new List<long>(); // list for this line, contains 3 elements
                        foreach (string temp in temporary)
                        {
                            if (long.TryParse(temp, out long number))
                            {
                                thisLine.Add(number);
                            }
                        }
                        //Console.WriteLine("Adding to seedToSoil: " + String.Join(", ", thisLine));
                        //this.seedToSoil.Add(thisLine);
                        if (thisLine.Count > 0) // ensure no empty list element will be added
                        {
                            Console.WriteLine("Adding to seedToSoil: " + String.Join(", ", thisLine));
                            this.seedToSoil.Add(thisLine);
                        }
                        else
                        {
                            Console.WriteLine("Skipping empty line in seedToSoil segment.");
                        }

                    }

                    if (line.Contains("soil-to-fertilizer"))
                    {
                        this.readingSeed = false;
                        this.readingSoil = true;
            
                        continue;
                    }
                    if (this.readingSoil)
                    {
                        string[] temporary = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        List<long> thisLine = new List<long>(); // list for this line, contains 3 elements
                        foreach (string temp in temporary)
                        {
                            if (long.TryParse(temp, out long number))
                            {
                                thisLine.Add(number);
                            }

                        }
                        //this.soilToFretilizer.Add(thisLine);
                        if (thisLine.Count > 0) // ensure no empty list element will be added
                        {
                            Console.WriteLine("Adding to seedToSoil: " + String.Join(", ", thisLine));
                            this.soilToFretilizer.Add(thisLine);
                        }
                        else
                        {
                            Console.WriteLine("Skipping empty line in seedToSoil segment.");
                        }
                    }

                    if (line.Contains("fertilizer-to-water"))
                    {
                        this.readingSoil=false;
                        this.readingFretilizer = true;
    
                        continue;
                    }
                    if (this.readingFretilizer)
                    {
                        string[] temporary = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        List<long> thisLine = new List<long>(); // list for this line, contains 3 elements
                        foreach (string temp in temporary)
                        {
                            if (long.TryParse(temp, out long number))
                            {
                                thisLine.Add(number);
                            }

                        }
                        //this.fretilizerToWater.Add(thisLine);
                        if (thisLine.Count > 0) // ensure no empty list element will be added
                        {
                            Console.WriteLine("Adding to seedToSoil: " + String.Join(", ", thisLine));
                            this.fretilizerToWater.Add(thisLine);
                        }
                        else
                        {
                            Console.WriteLine("Skipping empty line in seedToSoil segment.");
                        }
                    }

                    if (line.Contains("water-to-light") )
                    {
                        this.readingFretilizer=false;
                        this.readingWater = true;
                        //this.readingLight = false;
                        continue;
                    }

                    if (this.readingWater)
                    {
                        string[] temporary = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        List<long> thisLine = new List<long>(); // list for this line, contains 3 elements
                        foreach (string temp in temporary)
                        {
                            if (long.TryParse(temp, out long number))
                            {
                                thisLine.Add(number);
                            }
                        }
                        //this.waterToLight.Add(thisLine);
                        if (thisLine.Count > 0) // ensure no empty list element will be added
                        {
                            Console.WriteLine("Adding to seedToSoil: " + String.Join(", ", thisLine));
                            this.waterToLight.Add(thisLine);
                        }
                        else
                        {
                            Console.WriteLine("Skipping empty line in seedToSoil segment.");
                        }
                    }

                    if (line.Contains("light-to-temperature"))
                    {
                        this.readingWater=false;
                        this.readingLight = true;
                        //this.readingTemperature = false;
                        continue;
                    }
                    if (this.readingLight)
                    {
                        string[] temporary = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        List<long> thisLine = new List<long>(); // list for this line, contains 3 elements
                        foreach (string temp in temporary)
                        {
                            if (long.TryParse(temp, out long number))
                            {
                                thisLine.Add(number);
                            }
                        }
                        //this.lightToTemperature.Add(thisLine);
                        if (thisLine.Count > 0) // ensure no empty list element will be added
                        {
                            Console.WriteLine("Adding to seedToSoil: " + String.Join(", ", thisLine));
                            this.lightToTemperature.Add(thisLine);
                        }
                        else
                        {
                            Console.WriteLine("Skipping empty line in seedToSoil segment.");
                        }
                    }

                    if (line.Contains("temperature-to-humidity"))
                    {
                        this.readingLight=false;
                        this.readingTemperature = true;
                        //this.readingHumidity = false;
                        continue;
                    }
                    if (this.readingTemperature)
                    {
                        string[] temporary = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        List<long> thisLine = new List<long>(); // list for this line, contains 3 elements
                        foreach (string temp in temporary)
                        {
                            if (long.TryParse(temp, out long number))
                            {
                                thisLine.Add(number);
                            }
                        }
                        //this.temperatureToHumidity.Add(thisLine);
                        if (thisLine.Count > 0) // ensure no empty list element will be added
                        {
                            Console.WriteLine("Adding to seedToSoil: " + String.Join(", ", thisLine));
                            this.temperatureToHumidity.Add(thisLine);
                        }
                        else
                        {
                            Console.WriteLine("Skipping empty line in seedToSoil segment.");
                        }
                    }


                    if (line.Contains("humidity-to-location") )
                    {
                        this.readingTemperature=false;
                        this.readingHumidity = true;

                        continue;
                    }
                    if (this.readingHumidity)
                    {
                        string[] temporary = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        List<long> thisLine = new List<long>(); // list for this line, contains 3 elements
                        foreach (string temp in temporary)
                        {
                            if (long.TryParse(temp, out long number))
                            {
                                thisLine.Add(number);
                            }
                        }
                        // this.humidityToLocation.Add(thisLine);
                        if (thisLine.Count > 0) 
                        {
                            Console.WriteLine("Adding to seedToSoil: " + String.Join(", ", thisLine));
                            this.humidityToLocation.Add(thisLine);
                        }
                        else
                        {
                            Console.WriteLine("Skipping empty line in seedToSoil segment.");
                        }
                    }
                }
            }

            foreach (long seedNumber in this.seedNumbers)
            {
                Console.WriteLine("print seednumber:" + seedNumber);
                long soilNumber = GetDestination(seedNumber, this.seedToSoil);
                long fretilizerNumber = GetDestination(soilNumber, this.soilToFretilizer);
                long waterNumber = GetDestination(fretilizerNumber, this.fretilizerToWater);
                long lightNumber = GetDestination(waterNumber, this.waterToLight);
                long temperatureNumber = GetDestination(lightNumber, this.lightToTemperature);
                long humidityNumber = GetDestination(temperatureNumber, this.temperatureToHumidity);
                long locationNumber = GetDestination(humidityNumber, this.humidityToLocation);
                this.locationNumbers.Add(locationNumber);
                Console.WriteLine("Added location number:" + locationNumber);
            }

            // find the smallest number in that locationNumbers List
            long lowestLocation = this.locationNumbers.Min();
            // print it
            Console.WriteLine("the lowest location is:" + lowestLocation);

        }
    }
}
