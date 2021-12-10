using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc.Day8
{
    class Display
    {
        private readonly string[] _patterns;
        private readonly string[] _digits;
        private Dictionary<string, int> _numbers;

        public Display(string[] patterns, string[] digits)
        {
            this._patterns = patterns;
            this._digits = digits;
            _numbers = new();
            this.DeductSegmentDigits();
        }


        private void DeductSegmentDigits()
        {
            char[] numOne = this.SelectStringsByLength(2)[0].ToCharArray();
            _numbers.Add(new string(numOne), 1);

            char[] numFour = this.SelectStringsByLength(4)[0].ToCharArray();
            _numbers.Add(new string(numFour), 4);

            _numbers.Add(this.SelectStringsByLength(3)[0], 7);
            _numbers.Add(this.SelectStringsByLength(7)[0], 8);


            foreach(string pattern in this.SelectStringsByLength(6))
            {
                _numbers.Add(pattern, GetDifferencesCount(numOne, pattern.ToCharArray()) == 6 ? 6 :
                    GetDifferencesCount(numFour, pattern.ToCharArray()) == 4 ? 0 : 9);
            }

            foreach (string pattern in this.SelectStringsByLength(5))
            {
                _numbers.Add(pattern, GetDifferencesCount(numOne, pattern.ToCharArray()) == 3 ? 3 :
                    GetDifferencesCount(numFour, pattern.ToCharArray()) == 5 ? 2 : 5);
            }
        }


        private int GetDifferencesCount(char[] a, char[] b)
        {
            return a.Except(b).Union(b.Except(a)).ToArray().Length;
        }


        private string[] SelectStringsByLength(int length)
        {
            return Array.FindAll(this._patterns, pat => pat.Length == length);
        }


        public int GetOnlyUnique()
        {
            int[] uniqueNumbers = { 1, 4, 7, 8 };
            return this._digits.Count(d => uniqueNumbers.Contains(_numbers[d]));
        }


        public int GetOutputValue()
        {
            int output = 0;
            foreach(string digitString in this._digits)
            {
                output = output * 10 + this._numbers[digitString];
            }
            return output;
        }

    }
}
