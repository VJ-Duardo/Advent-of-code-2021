using aoc.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc.Day11
{
    class Octopus
    {

        private static readonly List<(int, int)> direcs = CreateDirecsArray();

        static void Main()
        {
            List<List<int>> squids = Resources.day11_input.Split("\r\n")
                .Select(line => Array.ConvertAll(line.ToCharArray(), s => (int)Char.GetNumericValue(s)).ToList()).ToList();


            //Console.WriteLine(GetFlashes(squids, 100));
            Console.WriteLine(GetSynchronizedStep(squids));
        }


        static int GetSynchronizedStep(List<List<int>> squids)
        {
            int steps = 0;
            while(squids.SelectMany(l => l).Sum() > 0)
            {
                steps++;
                DoStep(squids);
            }
            return steps;
        }

        static int GetFlashes(List<List<int>> squids, int steps)
        {
            int flashes = 0;
            for (int i=0; i< steps; i++)
            {
                flashes += DoStep(squids);
            }

            return flashes;
        }

        private static int DoStep(List<List<int>> squids)
        {
            int flashes = 0;
            List<(int, int)> toFlash = new();
            List<(int, int)> flashed = new();
            
            for (int i=0; i < squids.Count; i++)
            {
                for (int j=0; j < squids[i].Count; j++)
                {
                    if (++squids[i][j] > 9)
                    {
                        toFlash.Add((i, j));
                    }
                }
            }
            do
            {
                flashes += toFlash.Count;
                toFlash = DoFlash(squids, toFlash, flashed);
            } while (toFlash.Count > 0);

            foreach((int y, int x) in flashed)
            {
                squids[y][x] = 0;
            }
            return flashes;
        }

        private static List<(int, int)> DoFlash(List<List<int>> squids, List<(int,int)> toFlash, List<(int, int)> flashed)
        {
            List<(int, int)> newToFlash = new();
            foreach ((int i, int j) in toFlash)
            {
                flashed.Add((i, j));
                foreach ((int y, int x) in GetAdjacent(i, j, squids))
                {
                    if (++squids[y][x] > 9 && !flashed.Contains((y, x)))
                    {
                        newToFlash.Add((y, x));
                    }
                }
            }
            return newToFlash;
        }

        private static List<(int, int)> GetAdjacent(int i, int j, List<List<int>> squids)
        {
            List<(int, int)> adjacents = new();
            foreach((int y, int x) in direcs)
            {
                if (i+y < squids.Count && i+y >= 0 && j+x < squids[i].Count && j+x >= 0 && squids[i+y][j+x] <= 9)
                {
                    adjacents.Add((i + y, j + x));
                }
            }
            return adjacents;
        }

        private static List<(int, int)> CreateDirecsArray()
        {
            List<(int, int)> direcs = new();
            int[] vals = { -1, 0, 1 };
            foreach(int val in vals)
            {
                foreach(int rVal in vals)
                {
                    direcs.Add((val, rVal));
                }
            }
            return direcs;
        }
    }
}
