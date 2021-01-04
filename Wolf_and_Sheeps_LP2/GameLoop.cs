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
            userInterface.DisplayBoard(gameBoard.GetBoard());

            Loop();
        }

        private void Loop()
        {
            while (true)
            {
                string userIn = string.Empty;
                Thread input = new Thread(() =>
                    { userIn = userInterface.ReadInput(); });

                input.Start();
                input.Join();

                if (gameBoard.Turn == Pieces.X)
                {
                    int x = Int32.Parse(userIn[0].ToString());
                    int y = Int32.Parse(userIn[1].ToString());

                    gameBoard.MoveWolf(x, y);
                }
                else if (gameBoard.Turn == Pieces.O)
                {
                    int x = Int32.Parse(userIn[0].ToString());
                    int y = Int32.Parse(userIn[1].ToString());
                    int i = Int32.Parse(userIn[3].ToString());
                    int j = Int32.Parse(userIn[4].ToString());

                    //gameBoard.MoveSheep(x, y, i, j);
                }

                userInterface.DisplayBoard(gameBoard.GetBoard());
            }
        }
    }
}