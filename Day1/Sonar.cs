using aoc.Properties;
using System;
using System.Linq;

namespace aoc.Day1 
{    
    class Sonar 
    {
        static void Main() 
        {
            int[] depths = Array.ConvertAll(Resources.day1_input.Split("\r\n"), s => Int32.Parse(s));

            Console.WriteLine(Sonar.CountIncreasedDepths(depths));
            Console.WriteLine(Sonar.CountIncreasedDepthWindows(depths));
        }

        
        private static int CountIncreasedDepths(int[] depths)
        {
            int last = depths[0], count = 0;
            for (int i = 1; i < depths.Length; i++)
            {
                if (depths[i] > last)
                {
                    count++;
                }
                last = depths[i];
            }
            return count;
        }


        private static int CountIncreasedDepthWindows(int[] depths)
        {
            int last = depths.Take(3).Sum(), count = 0;
            for (int i = 1; i < depths.Length; i++)
            {
                int newSum = depths.Skip(i).Take(3).Sum();
                if (newSum > last)
                {
                    count++;
                }
                last = newSum;
            }
            return count;
        }
    }
}
