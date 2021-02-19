using System;

namespace SudokuPuzzle
{
    internal class SudokuSolver
    {
        public int[,] Puzzle  = new int[9,9] {{3,0,6,5,0,8,4,0,0},{5,2,0,0,0,0,0,0,0},{0,8,7,0,0,0,0,3,1},{0,0,3,0,1,0,0,8,0},{9,0,0,8,6,3,0,0,5},{0,5,0,0,9,0,6,0,0},{1,3,0,0,0,0,2,5,0},{0,0,0,0,0,0,0,7,4},{0,0,5,2,0,6,3,0,0}};
        const int GRIDSIZE = 9;
        const int BLOCKSIZE = 3;
        public SudokuSolver()
        {           

        }

        public void GetPuzzle()
        {
            try
            {
                for(int i=0; i<9; i++)
                {
                    Console.WriteLine("Please provide row of Sudoku puzzle, Write 0 for empty spaces");
                    string input = Console.ReadLine();
                    string[] row = input.Split(',');
                    for(int j=0; j< row.Length; j++)
                    { 
                        this.Puzzle[i,j] = Int32.Parse(row[j]);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Invalid input string");
            }
        }
       
        public bool SolvePuzzle(int row, int col)
        {
            Tuple<int, int> pair  = getNextZeroIdxs(row,col);
            if(pair != null)
            {
                row = pair.Item1 ;
                col = pair.Item2 ;
            }
            else
            {
               // return false;
            }

            if (row == GRIDSIZE -1 && col == GRIDSIZE)
                return true;

            int num = 1 ;
            while (num <= GRIDSIZE)
            {
                if (isSafe(row, col, num))
                {
                    this.Puzzle[row,col] = num;
                    if (SolvePuzzle(row, col + 1))
                        return true;
                    this.Puzzle[row,col] = 0;
                }
                num++;
            }
            return false;
        }

        bool isSafe(int row, int col, int num)
        {
            if (row >= GRIDSIZE || col >= GRIDSIZE)
            {
                return false;
            }
            for (int r =0; r < GRIDSIZE; r++)
            {
                if (this.Puzzle[r,col] == num)
                    return false;
            }
            for (int c=0; c < GRIDSIZE; c++)
            {
                if (this.Puzzle[row,c] == num)
                    return false;
            }
            for (int r=  row - row % BLOCKSIZE; r < row - row%BLOCKSIZE + BLOCKSIZE; r++)
            {
                for (int c = col - col % BLOCKSIZE; c < col - col % BLOCKSIZE + BLOCKSIZE; c++)
                {
                    if (this.Puzzle[r,c] == num)
                        return false;
                }
            }
            return true;
        }

        Tuple<int,int> getNextZeroIdxs(int row, int col)
        {
            try
            {
                Tuple<int, int> pair = null;
                for (; row < GRIDSIZE; row++)
                {
                    for (; col < GRIDSIZE; col++)
                    {
                        if (this.Puzzle[row,col] == 0)
                        {
                            pair = Tuple.Create(row,col);
                            return pair;
                        }
                    }
                    col = 0;
                }
                return pair;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PrintSolution()
        {
            try
            {
                int rowLength = this.Puzzle.GetLength(0);
                int colLength = this.Puzzle.GetLength(1);
                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        Console.Write(string.Format("{0} ", this.Puzzle[i, j]));
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
                }
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Error in priting puzzle");
            }
        }
    }
}
