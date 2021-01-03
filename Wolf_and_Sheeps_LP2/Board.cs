using System;

namespace Wolf_and_Sheeps_LP2
{
    /// <summary>
    /// 
    /// /// </summary>
    public class Board
    {
        private const int Dimension = 8;
        private Pieces turn;
        private char[,] board;
        private int[] wolfPos;

        /// <summary>
        /// 
        /// </summary>
        public Board()
        {
            turn = Pieces.X;

            wolfPos = new int[2] { 0, 10 };

            board = new char[Dimension, Dimension];

            for (int i = 0; i < Dimension; i++)
                for (int j = 0; j < Dimension; j++)
                    board[i, j] = (char)Pieces.Empty;
        }

        /// <summary>
        /// Wolf initial position
        /// and choice for initial position
        /// </summary>
        public void InitialWolfPosition()
        {

            while (wolfPos[1] == 10)
            {
                try
                {
                    int x = Convert.ToInt32(Console.ReadLine().Trim());
                    board[0, x] = (char)Pieces.X;
                    wolfPos[1] = x;
                }
                catch
                {
                    System.Console.WriteLine("Invalid Position. Insert [1] [3] [5] [7]");
                }
            }

            /// <summary>
            /// Sheeps Initial positions
            /// </summary>
            /// <returns></returns>
            board[7, 0] = (char)Pieces.O;
            board[7, 2] = (char)Pieces.O;
            board[7, 4] = (char)Pieces.O;
            board[7, 6] = (char)Pieces.O;
        }

        public void MoveWolf(int x, int y)
        {
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7 &&
                Math.Abs(x - wolfPos[0]) == 1 &&
                Math.Abs(y - wolfPos[1]) == 1)
            {
                if (board[x, y] == (char)Pieces.Empty)
                {
                    board[wolfPos[0], wolfPos[1]] = (char)Pieces.Empty;
                    board[x, y] = (char)Pieces.X;
                    wolfPos = new int[2] { x, y };
                }
                else
                    System.Console.WriteLine("There is a piece in that place.");
            }
            else
                System.Console.WriteLine("Invalid position to move to.");
        }

        public void MoveSheep()
        {

        }


        /// <summary>
        /// «7
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool IsEmpty(int x, int y)
        {
            if (board[x, y] == (char)Pieces.Empty)
                return true;
            else
                return false;
        }

        public char[,] GetBoard() => board;
    }
}