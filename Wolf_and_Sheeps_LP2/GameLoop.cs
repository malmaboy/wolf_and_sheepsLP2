using System;
using System.Threading;

namespace Wolf_and_Sheeps_LP2
{
    /// <summary>
    /// GameLoop Class.
    /// </summary>
    public class GameLoop
    {
        /// <summary>
        /// instance of Userinterface.
        /// </summary>
        private readonly UserInterface userInterface;

        /// <summary>
        /// instance of Board.
        /// </summary>
        private readonly Board gameBoard;

        /// <summary>
        /// GameLoop Consctructor.
        /// </summary>
        public GameLoop()
        {
            userInterface = new UserInterface();
            gameBoard = new Board();
        }

        /// <summary>
        /// Game Start.
        /// </summary>
        public void Start()
        {
            userInterface.MainMenu();
            userInterface.WolfPositonPrint();
            gameBoard.InitialWolfPosition();

            Loop();
        }

        /// <summary>
        /// The game loop.
        /// </summary>
        private void Loop()
        {
            int x, y, i, j = 0;

            Thread update = new Thread(() => userInterface.DisplayBoard(
                gameBoard, gameBoard.TurnColor));

            update.Start();

            while (true)
            {
                string userIn = userInterface.ReadInput();

                try
                {
                    x = int.Parse(userIn[0].ToString());
                    y = int.Parse(userIn[1].ToString());
                }
                catch
                {
                    System.Console.WriteLine("Invalid Input.");
                    continue;
                }

                if (gameBoard.Turn == Pieces.X)
                {
                    gameBoard.MoveWolf(x, y);
                }
                else if (gameBoard.Turn == Pieces.O)
                {
                    try
                    {
                        i = int.Parse(userIn[3].ToString());
                        j = int.Parse(userIn[4].ToString());
                    }
                    catch
                    {
                        System.Console.WriteLine("Invalid Input.");
                        continue;
                    }

                    gameBoard.MoveSheep(x, y, i, j);
                }

                gameBoard.GameCheck();
            }
        }
    }
}