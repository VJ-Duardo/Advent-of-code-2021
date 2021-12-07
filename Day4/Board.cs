using System;

namespace aoc.Day4
{
    class Board
    {
        private (int val, bool marked)[][] numbers;
        private readonly int width;
        private readonly int height;
        private bool done = false;

        public Board((int val, bool marked)[][] numbers)
        {
            this.numbers = numbers;
            this.width = this.numbers[0].Length;
            this.height = this.numbers.Length;
        }


        public void MarkNext(int next)
        {
            for (int i=0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    if (this.numbers[i][j].val == next)
                    {
                        this.numbers[i][j].marked = true;
                    }
                }
            }
        }   


        public int GetUnmarkedSum()
        {
            int sum = 0;
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    if (!this.numbers[i][j].marked)
                    {
                        sum += this.numbers[i][j].val;
                    }
                }
            }
            return sum;
        }


        public bool TestForWin()
        {
            return this.TestLines() || this.TestColumns();
        }

        private bool TestLines()
        {
            return Array.Exists(this.numbers, line => 
            {
                for (int i=0; i < this.height; i++)
                {
                    if (!line[i].marked)
                    {
                        return false;
                    }
                }
                return true;
            });
        }

        private bool TestColumns()
        {
            for (int j=0; j < this.width; j++)
            {
                bool win = true;
                for (int i=0; i < this.height; i++)
                {
                    if (!this.numbers[i][j].marked)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                {
                    return true;
                }
            }
            return false;
        }


        public void SetDone()
        {
            this.done = true;
        }

        public bool GetDone()
        {
            return this.done;
        }
    }
}
