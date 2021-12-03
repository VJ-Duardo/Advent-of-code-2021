using aoc.Properties;
using System;

namespace aoc.Day3
{
    class Binary
    {

        static void Main()
        {
            string[] diagnostic = Resources.day3_input.Split("\r\n");

            Console.WriteLine(GetPowerConsumption(diagnostic));
        }


        static int GetPowerConsumption(string[] report)
        {
            int digits = report[0].Length;
            int initial = (int)(Math.Pow(2, digits) - 1);
            int number = initial;
            for(int i = 0; i < digits; i++)
            {
                int occStatus = 0;
                for (int j = 0; j < report.Length; j++)
                {
                    occStatus = report[j][i] == '0' ? occStatus - 1 : occStatus + 1;
                }
                number = occStatus < 0 ? ~(~number | (1 << digits-(i+1))) : number;
            }
            return number * (~number & initial);
        }

    }
}
