using System;

namespace Wolf_and_Sheeps_LP2
{
    /// <summary>
    /// 
    /// </summary>
    public class Board
    {
        private const int Dimension = 8;
        public Pieces Turn { get; private set; }
        public ConsoleColor TurnColor { get; private set; }
        private char[,] board;
        private int[] wolfPos;

        private UserInterface userInterface;

        /// <summary>
        ///
        /// </summary>
        public Board()
        {
            Turn = Pieces.X;

            TurnColor = ConsoleColor.White;

            board = new char[Dimension, Dimension];

            for (int i = 0; i < Dimension; i++)
                for (int j = 0; j < Dimension; j++)
                    board[i, j] = (char)Pieces.Empty;

            userInterface = new UserInterface();
        }

        /// <summary>
        /// Wolf initial position
        /// and choice for initial position
        /// </summary>
        public void InitialWolfPosition()
        {

            while (true)
            {
                try
                {
                    int x = Convert.ToInt32(Console.ReadLine().Trim());
                    board[0, x] = (char)Pieces.X;
                    wolfPos = new int[2] { 0, x };
                    break;
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
                if (IsEmpty(x, y))
                {
                    board[wolfPos[0], wolfPos[1]] = (char)Pieces.Empty;
                    board[x, y] = (char)Pieces.X;
                    wolfPos = new int[2] { x, y };
                    Turn = Pieces.O;
                    TurnColor = ConsoleColor.Cyan;
                }
                else
                    System.Console.WriteLine("There is a piece in that place.");
            }
            else
                System.Console.WriteLine("Invalid position to move to.");
        }

        public void MoveSheep(int x, int y, int i, int j)
        {
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7 &&
            i >= 0 && i <= 7 && j >= 0 && j <= 7 &&
            board[x, y] == (char)Pieces.O)
            {
                if (i - x == -1 && Math.Abs(j - y) == 1 &&
                IsEmpty(i, j))
                {
                    board[x, y] = (char)Pieces.Empty;
                    board[i, j] = (char)Pieces.O;
                    Turn = Pieces.X;
                    TurnColor = ConsoleColor.White;
                }
                else
                    System.Console.WriteLine("The Sheep can't move there.");
            }
            else
                System.Console.WriteLine("Invalid Input.");
        }


        /// <summary>
        /// 
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

        /// <summary>
        /// Checks constantly the game victory condition.
        /// /// </summary>
        public void GameCheck()
        {
            if (wolfPos[0] == 7)
            {
                userInterface.WolfVictory();

            }
            else
            {
                for (int i = -1; i <= 1; i += 2)
                {
                    for (int j = -1; j <= 1; j += 2)
                    {
                        if (wolfPos[0] + i >= 0 && wolfPos[0] + i <= 7 &&
                        wolfPos[1] + j >= 0 && wolfPos[1] + j <= 7)
                        {
                            if (board[wolfPos[0] + i, wolfPos[1] + j] == (char)Pieces.Empty)
                                return;
                        }
                    }
                }
                userInterface.SheepVictory();

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public char[,] GetBoard() => board;
        public char GetPos(int x, int y) => board[x,y];
    }
}