namespace Backtraking_Problems
{
    using System;

    /// <summary>
    /// Defines the <see cref="Maze" />
    /// </summary>
    internal class Maze
    {
        /// <summary>
        /// Defines the n
        /// </summary>
        internal static int n= 4;

        /// <summary>
        /// Defines the solution
        /// </summary>
        internal static int[,] solution = new int[4, 4];

        /// <summary>
        /// Defines the solution
        /// </summary>

        /// <summary>
        /// Initializes a new instance of the <see cref="Maze"/> class.
        /// </summary>
        /// <param name="length">The length<see cref="int"/></param>


        /// <summary>
        /// The isValidMove
        /// </summary>
        /// <param name="mazeMatrix">The mazeMatrix<see cref="int[,]"/></param>
        /// <param name="x">The x<see cref="int"/></param>
        /// <param name="y">The y<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool isValidMove(int[,] mazeMatrix, int x, int y)
        {
            return (x >= 0 && x < n && y >= 0 && y < n && mazeMatrix[x, y] == 1);
        }

        /// <summary>
        /// The solveMaze
        /// </summary>
        /// <param name="mazeMatrix">The mazeMatrix<see cref="int[,]"/></param>
        /// <param name="x">The x<see cref="int"/></param>
        /// <param name="y">The y<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool solveMazeUtil(int[,] mazeMatrix, int x, int y)
        {
            //Reached destination i.e last cell
            if (x == n - 1 && y == n - 1)
            {
                solution[x, y] = 1;
                return true;
            }

            if (isValidMove(mazeMatrix, x, y))
            {
                solution[x, y] = 1;
                // Forward
                if (solveMazeUtil(mazeMatrix, x+1, y))
                    return true;
                // Downward
                if (solveMazeUtil(mazeMatrix, x, y + 1))
                    return true;

                solution[x, y] = 0;
                return false;
            }
            return false;
            
        }

        /// <summary>
        /// The solveMaze
        /// </summary>
        /// <param name="mazeMatrix">The mazeMatrix<see cref="int[,]"/></param>
        /// <param name="x">The x<see cref="int"/></param>
        /// <param name="y">The y<see cref="int"/></param>
        /// <returns>The <see cref="int[,]"/></returns>
        public int[,] solveMaze(int[,] mazeMatrix, int x, int y)
        {
            if (!solveMazeUtil(mazeMatrix, x, y))
            {

                Console.WriteLine("No feasible solution !!");
                return new int[,] { };
            }
            else
                return solution;
        }
    }

    /// <summary>
    /// Defines the <see cref="Rat_In_A_Maze_2" />
    /// Given a N*N maze. A rat starts from starting position(0,0) has to reach the destination(N-1,N-1)
    /// </summary>
    internal class Rat_In_A_Maze_2
    {
        /// <summary>
        /// Defines the mazeMatrix
        /// </summary>
        internal static int[,] mazeMatrix = {
        { 1, 0, 0, 0 },
        { 1, 1, 0, 1 },
        { 0, 1, 0, 0 },
        { 1, 1, 1, 1 }};

        /// <summary>
        /// The Main
        /// </summary>
        public static void Main2()
        {
            Maze maze = new Maze();
            int[,] solMaze = new int[4, 4];
            solMaze = maze.solveMaze(mazeMatrix, 0, 0);

            // Print solution matrix
            int n = solMaze.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(solMaze[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
