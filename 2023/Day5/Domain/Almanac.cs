using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Domain
{
    public class Almanac
    {
        public int PartNumber { get; set; }
        public List<Int64> Seeds { get; set; } = [];
        public List<Map> Maps = [];
        public void ParseLinesToMaps(List<string> lines)
        {
            
            List<List<string>> mapStrings = new List<List<string>>();
            List<string> mapLines = new List<string>();
            bool newMap = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("seeds"))
                {
                    if (PartNumber == 1)
                        ParseSeed(line);
                    else
                        ParseSeedRange(line);
                }
                if (line.EndsWith("map:"))
                {
                    newMap = true;
                    mapLines=new List<string>();
                }
                if (line == string.Empty)
                {
                    if(mapLines.Count > 0)
                        mapStrings.Add(mapLines);
                    newMap = false;
                }

                if(newMap==true) 
                {
                    mapLines.Add(line);
                }
            }
            mapStrings.Add(mapLines);
            foreach (var mapDatas in mapStrings) 
            {
                Maps.Add(ParseMap(mapDatas));
            }

        }

        public Int64 GetMinLocationNumber()
        {
            
            Int64 minLocation = Int64.MaxValue;
            var total = Seeds.Count;
            Int64 cptSeed = 0;
            Console.WriteLine($"Total: {total}");
            foreach  (Int64 seed in Seeds )
            {
                var percent = (Int64)(((double)(cptSeed / total))*100);
                if (percent > 0 && percent % 1 == 0)
                    Console.WriteLine($"Pourcentage : {percent} {cptSeed}/{total}");

                var currentLocation = GetLocationNumber(seed);
                if (minLocation > currentLocation)
                {
                    minLocation = currentLocation;
                }
                cptSeed++;
            }
            return minLocation;
            
        }
        private Int64 GetLocationNumber(Int64 seed)
        {
            Int64 location = seed;
            Console.WriteLine("------------");
            Console.WriteLine(location);
            location = Maps.First(m => m.MapType == MapType.SeedToSoil).GetMatchingNumber(location);
            Console.WriteLine(location);
            location = Maps.First(m => m.MapType == MapType.SoilToFertilizer).GetMatchingNumber(location);
            Console.WriteLine(location);
            location = Maps.First(m => m.MapType == MapType.FertilizerToWater).GetMatchingNumber(location);
            Console.WriteLine(location); 
            location = Maps.First(m => m.MapType == MapType.WaterToLight).GetMatchingNumber(location);
            Console.WriteLine(location); 
            location = Maps.First(m => m.MapType == MapType.LightToTemperature).GetMatchingNumber(location);
            Console.WriteLine(location); 
            location = Maps.First(m => m.MapType == MapType.TemperatureToHumitdity).GetMatchingNumber(location);
            Console.WriteLine(location); 
            location = Maps.First(m => m.MapType == MapType.HumidityToLocation).GetMatchingNumber(location);
            Console.WriteLine(location); 
            return location;
        }
        private Map ParseMap(List<string> lines)
        {
            Map map = new();
            string mapType = lines[0].Split(' ')[0];
            switch (mapType)
            {
                case "seed-to-soil":
                    map.MapType=MapType.SeedToSoil; break;
                case "soil-to-fertilizer":
                    map.MapType = MapType.SoilToFertilizer; break;
                case "fertilizer-to-water":
                    map.MapType = MapType.FertilizerToWater; break;
                case "water-to-light":
                    map.MapType = MapType.WaterToLight; break;
                case "light-to-temperature":
                    map.MapType = MapType.LightToTemperature; break;
                case "temperature-to-humidity":
                    map.MapType = MapType.TemperatureToHumitdity; break;
                case "humidity-to-location":
                    map.MapType = MapType.HumidityToLocation; break;
            }
            for (int i=1; i<lines.Count; i++)
            {
                if (lines[i] != string.Empty)
                    map.Ranges.Add(ParseRange(lines[i]));
            }
            return map;
        }
        private Range ParseRange(string line)
        {
            Range range = new Range();
            var arrRange = line.Split(' ');
            range.Min = Convert.ToInt64(arrRange[1]);
            range.Max = range.Min + Convert.ToInt64(arrRange[2]);
            range.MinDest = Convert.ToInt64(arrRange[0]);
            return range;
        }

        private void ParseSeed(string line)
        { 
            var arrSeeds = line.Split(' ');
            for (Int64 i = 1; i < arrSeeds.Length; i++)
            {
                Seeds.Add(Convert.ToInt64(arrSeeds[i]));
            }
        }

        private void ParseSeedRange(string line)
        {
            var arrSeeds = line.Split(' ');
            int i = 1;
            
            while (i < arrSeeds.Length)
            {
                var range = Convert.ToInt64(arrSeeds[i + 1]);
                for (int cptSeed = 0; cptSeed < range; cptSeed++)
                {
                    Seeds.Add(Convert.ToInt64(arrSeeds[i]) + cptSeed);
                }
                i = i + 2;
            }
            Seeds = Seeds.Distinct().ToList();

        }

    }
}
