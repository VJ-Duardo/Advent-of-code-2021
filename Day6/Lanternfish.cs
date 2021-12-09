using aoc.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc.Day6
{
    class Lanternfish
    {
        static readonly Dictionary<int, long> cache = new();

        static void Main()
        {
            List<int> fish = Array.ConvertAll(Resources.day6_input.Split(","), s => Int32.Parse(s)).ToList<int>();

            long sum = 0;
            foreach(int f in fish)
            {
                sum += MakeFish(256 - f);
            }
            Console.WriteLine(sum+fish.Count);
        }


        static long MakeFish(int days)
        {
            if (cache.TryGetValue(days, out long val))
            {
                return val;
            }

            long sum = 0;
            for (int i = 0; i < Math.Ceiling((double)days / 7); i++)
            {
                sum++;
                sum += MakeFish(((days - i * 7)-9));
            }
            cache.Add(days, sum);
            return sum;
        }

    }
}
