using System;
using System.Threading;

namespace Wolf_and_Sheeps_LP2
{
    /// <summary>
    /// GameLoop Class
    /// </summary>
    public class GameLoop
    {

        private UserInterface userInterface;
        private Board gameBoard;

        /// <summary>
        /// 
        /// </summary>
        public GameLoop()
        {
            userInterface = new UserInterface();
            gameBoard = new Board();
        }

        /// <summary>
        /// 
        ///   </summary>

        public void Start()
        {
            userInterface.WolfPositonPrint();
            gameBoard.InitialWolfPosition();

            Loop();
        }

        private void Loop()
        {
            Pieces lastTurn;
            int x, y, i, j;
            x = 0;
            y = 0;
            i = 0;
            j = 0;

            Thread update = new Thread(() => userInterface.DisplayBoard(
                gameBoard, gameBoard.TurnColor));

            update.Start();

            while (true)
            {
                lastTurn = gameBoard.Turn;
                string userIn = userInterface.ReadInput();
                /*Thread input = new Thread(() =>
                    { userIn = userInterface.ReadInput(); });

                input.Start();
                input.Join();*/

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