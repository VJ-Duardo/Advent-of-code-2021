using aoc.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc.Day5
{
    class Hydrothermal
    {

        static void Main()
        {
            (int x1, int y1, int x2, int y2)[] lines = Resources.day5_input.Split("\r\n")
                .Select(line => { int[] arr = Array.ConvertAll(Regex.Split(line, @"[,\s\->]").Where(s => s != String.Empty).ToArray(), 
                    a => Int32.Parse(a)); return (arr[0], arr[1], arr[2], arr[3]); })
                .ToArray();

            Console.WriteLine(DetermineOverlaps(lines, true));
            Console.WriteLine(DetermineOverlaps(lines, false));
        }


        static int DetermineOverlaps((int x1, int y1, int x2, int y2)[] lines, bool verticalOnly)
        {
            Dictionary<(int, int), int> points= new();
            int count = 0;
            for (int i=0; i < lines.Length; i++)
            {
                int x1 = lines[i].x1, x2 = lines[i].x2, y1 = lines[i].y1, y2 = lines[i].y2;
                if (verticalOnly && !(x1 == x2 || y1 == y2))
                {
                    continue;
                }

                int vecX = x2 - x1, vecY = y2 - y1;
                int steps = Math.Max(Math.Abs(vecX), Math.Abs(vecY));
                for (int j = 0; j<= steps; j++)
                {
                    int newX = x1 + vecX * j / steps;
                    int newY = y1 + vecY * j / steps;
                    if (!points.TryGetValue((newX, newY), out _))
                    {
                        points.Add((newX, newY), 1);
                    }
                    else
                    {
                        if (++points[(newX, newY)] == 2)
                        {
                            count++;
                        }
                    }
                }

            }
            return count;
        }
    }
}
