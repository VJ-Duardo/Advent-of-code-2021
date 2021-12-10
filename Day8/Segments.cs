using aoc.Properties;
using System;
using System.Linq;

namespace aoc.Day8
{
    class Segments
    {
        static void Main()
        {
            Display[] displays = Resources.day8_input.Split("\r\n")
                .Select(s => 
                    {
                        string[][] parts = s.Split(" | ").Select(s => s.Split(" ").Select(oS =>
                        {
                            char[] chars = oS.ToCharArray();
                            Array.Sort(chars);
                            return new string(chars);
                        }).ToArray()).ToArray();
                        return new Display(parts[0], parts[1]);
                    })
                .ToArray();

            Console.WriteLine(CountUniques(displays));
            Console.WriteLine(GetAllOutputs(displays));
        }



        static int CountUniques(Display[] displays)
        {
            return displays.Select(d => d.GetOnlyUnique()).Sum();
        }


        static int GetAllOutputs(Display[] displays)
        {
            return displays.Select(d => d.GetOutputValue()).Sum();
        }
    }
}
