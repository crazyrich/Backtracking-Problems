namespace Backtraking_Problems
{
    using System;

    /// <summary>
    /// Defines the <see cref="The_Knight_1" />
    /// </summary>
    internal class The_Knight_1
    {
        /// <summary>
        /// Defines the chessBoard
        /// </summary>
        internal static int[,] chessBoard = new int[8, 8];

        /// <summary>
        /// Defines the coordX
        /// </summary>
        internal static int[] coordX = { 2, 1, -1, -2, -2, -1, 1, 2 };

        /// <summary>
        /// Defines the coordY
        /// </summary>
        internal static int[] coordY = { 1, 2, 2, 1, -1, -2, -2, -1 };

        /// <summary>
        /// The isValidMove
        /// </summary>
        /// <param name="x">The x<see cref="int"/></param>
        /// <param name="y">The y<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private static bool isValidMove(int x, int y)
        {
            return (x >= 0 && y >= 0 && x < 8 && y < 8 && chessBoard[x, y] == -1);
        }

        /// <summary>
        /// The solveKnightProblem
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public static bool solveKnightProblem()
        {

            // initialize each position of chessboard with -1
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    chessBoard[i, j] = -1;

            chessBoard[0, 0] = 0;
            if (!solveKnightProblemUtil(0, 0, 1))
            {
                Console.WriteLine("No feasible solution !!");
                return false;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write(chessBoard[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            return true;
        }

        /// <summary>
        /// The solveKnightProblemUtil
        /// </summary>
        /// <param name="x">The x<see cref="int"/></param>
        /// <param name="y">The y<see cref="int"/></param>
        /// <param name="count">The count<see cref="int"/></param>
        /// <returns>The <see cref="int[,]"/></returns>
        private static bool solveKnightProblemUtil(int x, int y, int count)
        {
            int nextX, nextY;
            if (count == 64)
            {
                return true;
            }
            for (int i = 0; i < 8; i++)
            {

                nextX = x + coordX[i];
                nextY = y + coordY[i];
                if (isValidMove(nextX, nextY))
                {
                    chessBoard[nextX, nextY] = count;

                    if (solveKnightProblemUtil(nextX, nextY, count + 1))
                    {
                        return true;
                    }
                    else
                    {
                        chessBoard[nextX, nextY] = -1;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// The Main
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/></param>
        internal static void Main1(string[] args)
        {
            solveKnightProblem();
            Console.Read();
        }
    }
}
