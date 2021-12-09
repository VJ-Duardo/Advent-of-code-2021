using aoc.Properties;
using System;
using System.Linq;

namespace aoc.Day7
{
    class Crabs
    {

        static void Main()
        {
            int[] positions = Array.ConvertAll(Resources.day7_input.Split(","), s => Int32.Parse(s));
            Console.WriteLine(GetTotalFuel(positions));
            Console.WriteLine(GetRealTotalFuel(positions));
        }


        static int GetTotalFuel(int[] positions)
        {
            return positions.Select(pos =>
            {
                int diff = 0;
                for (int i = 0; i < positions.Length; i++)
                {
                    diff += Math.Abs(pos - positions[i]);
                }
                return diff;
            }).ToArray().Min();
        }

        static int GetRealTotalFuel(int[] positions)
        {
            return positions.Select(pos =>
            {
                int diff = 0;
                for (int i = 0; i < positions.Length; i++)
                {

                    int distance = Math.Abs(pos - positions[i]);
                    diff += (int)((Math.Pow(distance, 2) + distance) / 2);
                }
                return diff;
            }).ToArray().Min();
        }
    }
}
