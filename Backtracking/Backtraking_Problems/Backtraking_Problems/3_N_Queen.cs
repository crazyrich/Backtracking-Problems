namespace Backtraking_Problems
{
    using System;

    /// <summary>
    /// Defines the <see cref="N_Queen_3" />
    /// </summary>
    internal class N_Queen_3
    {
        /// <summary>
        /// Defines the n
        /// </summary>
        internal static int n = 4;

        /// <summary>
        /// Defines the board
        /// </summary>
        internal static int[,] board = new int[n, n];

        /// <summary>
        /// The solveNQueen
        /// </summary>
        public static void solveNQueen()
        {
            if (!solveNQueenUtil(0))
                Console.Write("No feasible solution !!");
            else
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(board[i, j] + " ");
                    }
                    Console.WriteLine();
                }
        }

        /// <summary>
        /// The isValidMove
        /// </summary>
        /// <param name="row">The row<see cref="int"/></param>
        /// <param name="col">The col<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private static bool isValidMove(int row, int col)
        {
            int i, j;

            // Cols on left for same row
            for (i = 0;i<col;i++)
            {
                if (board[row,i] == 1)
                {
                    return false;
                }
            }

            // Upper Left Diagonal
            for (i=row,j=col; i>=0 && j>=0; i--,j--)
            {
                if (board[i,j] == 1)
                {
                    return false;
                }
            }

            // Lower Left Diagonal
            for (i = row, j = col; i < n && j >= 0; i++, j--)
            {
                if (board[i, j] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// The solveNQueenUtil
        /// </summary>
        /// <param name="col">The col<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool solveNQueenUtil(int col)
        {
            if (col >= n)
            {
                return true;
            }

            for (int row = 0; row < n; row++)
            {
                if (isValidMove(row, col))
                {
                    board[row, col] = 1;
                    if (solveNQueenUtil(col + 1))
                    {
                        return true;
                    }

                    board[row, col] = 0;
                }
            }

            return false;
        }

        /// <summary>
        /// The Main
        /// </summary>
        public static void Main()
        {
            solveNQueen();
            Console.Read();
        }
    }
}
