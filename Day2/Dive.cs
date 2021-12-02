using aoc.Properties;
using System;
using System.Linq;

namespace aoc.Day2
{
    class Dive
    {
        static void Main()
        {
            (string cmd, int val)[] commands = Resources.day2_input.Split("\r\n").Select(s => 
            {
                string[] p = s.Split(" "); 
                return (p[0], Int32.Parse(p[1]));
            }).ToArray();

            Console.WriteLine(MultiplyPlannedCourse(commands));
            Console.WriteLine(MultiplyRealPlannedCourse(commands));
        }


        private static int MultiplyPlannedCourse((string cmd, int val)[] commands)
        {
            int x = 0, y = 0;
            foreach((string cmd, int val) in commands)
            {
                switch (cmd)
                {
                    case "forward":
                        x+= val;
                        break;
                    case "down":
                        y+= val;
                        break;
                    case "up":
                        y-= val;
                        break;
                }
            }
            return x * y;
        }

        private static int MultiplyRealPlannedCourse((string cmd, int val)[] commands)
        {
            int x = 0, y = 0, aim = 0;
            foreach ((string cmd, int val) in commands)
            {
                switch (cmd)
                {
                    case "forward":
                        x += val;
                        y += aim * val;
                        break;
                    case "down":
                        aim += val;
                        break;
                    case "up":
                        aim -= val;
                        break;
                }
            }
            return x * y;
        }
    }
}
