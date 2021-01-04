using System;

namespace Wolf_and_Sheeps_LP2
{
    /// <summary>
    /// Board class, contains game info.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Board dimension.
        /// </summary>
        private const int Dimension = 8;

        /// <summary>
        /// User Interface instance, used to print on console.
        /// </summary>
        private readonly UserInterface userInterface;

        /// <summary>
        /// Gets player's turn.
        /// </summary>
        /// <value>Current player's turn.</value>
        public Pieces Turn { get; private set; }

        /// <summary>
        /// Gets player's turn color.
        /// </summary>
        /// /// <value>Player turn color.</value>
        public ConsoleColor TurnColor { get; private set; }

        /// <summary>
        /// Board array, stores positions.
        /// </summary>
        private readonly char[,] board;

        /// <summary>
        /// Stores wolf position.
        /// </summary>
        private int[] wolfPos;

        /// <summary>
        /// Board constructor.
        /// </summary>
        public Board()
        {
            Turn = Pieces.X;

            TurnColor = ConsoleColor.White;

            board = new char[Dimension, Dimension];

            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    board[i, j] = (char)Pieces.Empty;
                }
            }

            userInterface = new UserInterface();
        }

        /// <summary>
        /// Wolf initial position
        /// and choice for initial position.
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

            board[7, 0] = (char)Pieces.O;
            board[7, 2] = (char)Pieces.O;
            board[7, 4] = (char)Pieces.O;
            board[7, 6] = (char)Pieces.O;
        }

        /// <summary>
        /// Method that moves the wolf, if possible.
        /// </summary>
        /// <param name="x">Line to move to.</param>
        /// <param name="y">Column to move to.</param>
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
                {
                    System.Console.WriteLine("There is a piece in that place.");
                }
            }
            else
            {
                System.Console.WriteLine("Invalid position to move to.");
            }
        }

        /// <summary>
        /// Method that moves the Sheep if possible.
        /// </summary>
        /// <param name="x">Sheep's line.</param>
        /// <param name="y">Sheep's column.</param>
        /// <param name="i">Line to move to.</param>
        /// <param name="j">Column to move to.</param>
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
                {
                    System.Console.WriteLine("The Sheep can't move there.");
                }
            }
            else
            {
                System.Console.WriteLine("Invalid Input.");
            }
        }

        /// <summary>
        /// Checks if the given position is empty.
        /// </summary>
        /// <param name="x">Line to check.</param>
        /// <param name="y">Column to check.</param>
        /// <returns>True if empty, false if ocuppied.</returns>
        private bool IsEmpty(int x, int y)
        {
            return board[x, y] == (char)Pieces.Empty;
        }

        /// <summary>
        /// Checks constantly the game victory condition.
        /// </summary>
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
                        wolfPos[1] + j >= 0 && wolfPos[1] + j <= 7 &&
                        board[wolfPos[0] + i, wolfPos[1] + j] == (char)Pieces.Empty)
                        {
                            return;
                        }
                    }
                }

                userInterface.SheepVictory();
            }
        }

        /// <summary>
        /// Returns the board.
        /// </summary>
        /// <returns>Game board.</returns>
        public char[,] GetBoard() => board;

        /// <summary>
        /// Gets the board's given position.
        /// </summary>
        /// <param name="x">Line.</param>
        /// <param name="y">Column.</param>
        /// <returns>X, O or Empty.</returns>
        public char GetPos(int x, int y) => board[x, y];
    }
}