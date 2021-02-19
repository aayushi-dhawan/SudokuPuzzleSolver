using System;

namespace SudokuPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Sudoku World");
            SudokuSolver objSolver = new SudokuSolver();
            objSolver.GetPuzzle();
            bool isSolvable = objSolver.SolvePuzzle(0,0);
            if(isSolvable)
                objSolver.PrintSolution();
            
        }
    }
}
