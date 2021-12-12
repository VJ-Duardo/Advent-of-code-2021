using aoc.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc.Day10
{
    class Syntax
    {
        static void Main()
        {
            List<string> lines = Resources.day10_input.Split("\r\n").ToList();

            int errorSum = 0;
            long completionScore = 0;
            GetErrorScore(lines, ref errorSum, ref completionScore);

            Console.WriteLine(errorSum);
            Console.WriteLine(completionScore);
        }


        static void GetErrorScore(List<string> lines, ref int errorSum, ref long completionScore)
        {
            Stack<char> bracketsStack = new();
            char[] brackets = { '(', '{', '<', '[' };

            Dictionary<char, int> errorPoints = new() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
            Dictionary<char, int> completionPoints = new() { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };

            List<long> completions = new();

            for (int i=0; i< lines.Count; i++)
            {
                bool fault = false;
                foreach (char bracket in lines[i].ToCharArray())
                {
                    if (brackets.Contains(bracket))
                    {
                        bracketsStack.Push(bracket == '(' ? ')' : (char)(Convert.ToUInt16(bracket)+2));
                    } else
                    {
                        char next = bracketsStack.Pop();
                        if (bracket != next)
                        {
                            errorSum += errorPoints[bracket];
                            fault = true;
                            bracketsStack = new();
                            break;
                        }
                    }
                }
                if (fault)
                    continue;

                long lineCompletionScore = 0;
                while(bracketsStack.Count > 0)
                {
                    lineCompletionScore = lineCompletionScore*5 + completionPoints[bracketsStack.Pop()];
                }
                completions.Add(lineCompletionScore);
            }
            completions.Sort((a, b) => a.CompareTo(b));
            completionScore = completions[(int)Math.Floor((double)completions.Count / 2)];
        }
    }
}
