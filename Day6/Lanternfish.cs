using aoc.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc.Day6
{
    class Lanternfish
    {

        static void Main()
        {
            List<int> fish = Array.ConvertAll(Resources.day6_input.Split(","), s => Int32.Parse(s)).ToList<int>();

            Console.WriteLine(MakeFish(fish, 80));
        }


        static int MakeFish(List<int> fish, int days)
        {
            for (int i=0; i < days; i++)
            {
                for (int j=0; j < fish.Count; j++)
                {
                    if (fish[j] == 0)
                    {
                        fish[j] = 6;
                        fish.Add(9);
                    } else
                    {
                        fish[j]--;
                    }
                }
            }

            return fish.Count;
        }

    }
}
