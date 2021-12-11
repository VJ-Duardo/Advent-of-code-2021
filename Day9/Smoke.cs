using aoc.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc.Day9
{
    internal class Smoke
    {
        static void Main()
        {
            List<List<int>> heights = Resources.day9_input.Split("\r\n")
                .Select(s => Array.ConvertAll(s.ToCharArray(), n => n - '0').ToList())
                .ToList();

            int sum = 0;
            List<(int, int)> lowPoints = GetLowPoints(heights, ref sum);

            Console.WriteLine(sum);
            Console.WriteLine(MultiplyBiggestBasins(heights, lowPoints));
        }


        static List<(int, int)> GetAdjacentLocations(List<List<int>> heights, int i, int j)
        {
            List<(int, int)> adjacent = new();
            (int y, int x)[] direcs = { (0, -1), (-1, 0), (0, 1), (1, 0) };
            for (int k = 0; k < direcs.Length; k++)
            {
                if (i + direcs[k].y < 0 || i + direcs[k].y > heights.Count - 1
                    || j + direcs[k].x < 0 || j + direcs[k].x > heights[i].Count - 1)
                {
                    continue;
                }
                adjacent.Add((i + direcs[k].y, j + direcs[k].x));
            }
            return adjacent;
        }


        static List<(int, int)> GetLowPoints(List<List<int>> heights, ref int sum)
        {
            List <(int, int)> lowPoints = new();
            for (int i=0; i< heights.Count; i++)
            {
                for (int j=0; j < heights[i].Count; j++)
                {
                    bool lowPoint = true;
                    foreach ((int y, int x) in GetAdjacentLocations(heights, i, j))
                    {
                        if (heights[y][x] <= heights[i][j])
                        {
                            lowPoint = false;
                            break;
                        }
                    }
                    if (lowPoint)
                    {
                        sum += heights[i][j] + 1;
                        lowPoints.Add((i, j));
                    }
                }
            }
            return lowPoints;
        }


        static int MultiplyBiggestBasins(List<List<int>> heights, List<(int, int)> lowPoints)
        {
            List<int> basins = new();
            foreach((int i, int j) in lowPoints)
            {
                basins.Add(GetBasinSize(heights, new List<(int, int)>(), i, j));
            }

            basins.Sort((a, b) => b - a);
            return basins[0] * basins[1] * basins[2];
        }

        static int GetBasinSize(List<List<int>> heights, List<(int, int)> marked, int i, int j)
        {
            marked.Add((i, j));
            int count = 1;
            foreach ((int y, int x) in GetAdjacentLocations(heights, i, j))
            {
                if (heights[y][x] > heights[i][j] && heights[y][x] != 9)
                {
                    if (!marked.Contains((y, x)))
                    {
                        count += GetBasinSize(heights, marked, y, x);
                    }
                }
            }
            return count;
        }
    }
}
