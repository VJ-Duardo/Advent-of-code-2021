using aoc.Properties;
using System;

namespace aoc.Day3
{
    class Binary
    {
        enum Rating
        {
            OxygenGeneratorRating,
            Co2ScrubberRating
        }

        static void Main()
        {
            string[] diagnostic = Resources.day3_input.Split("\r\n");

            Console.WriteLine(GetPowerConsumption(diagnostic));
            Console.WriteLine(GetLifeSupportRating(diagnostic));
        }


        static int GetMostCommonBit(string[] arr, int pos)
        {
            int occStatus = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                occStatus = arr[i][pos] == '0' ? occStatus - 1 : occStatus + 1;
            }
            return occStatus < 0 ? 0 : 1;
        }


        static int GetPowerConsumption(string[] report)
        {
            int digits = report[0].Length;
            int initial = (int)(Math.Pow(2, digits) - 1);
            int number = initial;
            for (int i = 0; i < digits; i++)
            {
                number = GetMostCommonBit(report, i) == 0 ? ~(~number | (1 << digits - (i + 1))) : number;
            }
            return number * (~number & initial);
        }


        static int DetermineLastBinary(string[] report, int index, Rating rating)
        {
            if (report.Length == 1)
            {
                return Convert.ToInt32(report[0], 2);
            }

            int occStatus = GetMostCommonBit(report, index);
            occStatus = rating == Rating.Co2ScrubberRating ? 1 - occStatus : occStatus;

            return DetermineLastBinary(Array.FindAll(report, s => s[index] == (char)(occStatus + '0')), index + 1, rating);
        }


        static int GetLifeSupportRating(string[] report)
        {
            return DetermineLastBinary(report, 0, Rating.OxygenGeneratorRating) * DetermineLastBinary(report, 0, Rating.Co2ScrubberRating);
        }

    }
}
