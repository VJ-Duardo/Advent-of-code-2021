using aoc.Properties;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc.Day4
{
    class Bingo
    {
        static void Main()
        {
            string[] parts = Resources.day4_input.Split("\r\n\r\n");
            int[] draws = Array.ConvertAll(parts[0].Split(","), s => Int32.Parse(s));

            Board[] boards = GetBoards(parts);

            Console.WriteLine(GetFinalScore(boards, draws));
            Console.WriteLine(GetFinalScoreLoser(boards, draws));
        }


        static int GetFinalScore(Board[] boards, int[] draws)
        {
            for (int i=0; i< draws.Length; i++)
            {
                for (int j=0; j< boards.Length; j++)
                {
                    boards[j].MarkNext(draws[i]);
                    if (boards[j].TestForWin())
                    {
                        return boards[j].GetUnmarkedSum()*draws[i];
                    }
                }
            }
            return -1;
        }

        static int GetFinalScoreLoser(Board[] boards, int[] draws)
        {
            int amount = boards.Length;
            for (int i = 0; i < draws.Length; i++)
            {
                for (int j = 0; j < boards.Length; j++)
                {
                    boards[j].MarkNext(draws[i]);
                    if (!boards[j].GetDone() && boards[j].TestForWin())
                    {
                        if (amount == 1)
                        {
                            return boards[j].GetUnmarkedSum() * draws[i];
                        }
                        boards[j].SetDone();
                        amount--;
                    }
                }
            }
            return -1;
        }


        static Board[] GetBoards(string[] parts)
        {
            Board[] boards = new Board[parts.Length-1];
            for (int i=1; i < parts.Length; i++)
            {
                boards[i - 1] = new Board(parts[i]
                    .Split("\r\n")
                    .Select(line => Array.ConvertAll(Regex.Split(line.Trim(), @"\s+"), s => { return (Int32.Parse(s), false); }))
                    .ToArray());
            }
            return boards;
        }
        
    }
}
